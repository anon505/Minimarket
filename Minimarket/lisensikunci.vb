Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32
Imports MySql.Data.MySqlClient
'License key: dibuat generator terpisah (repo POS-License-Generator, kunci privat hanya di sana),
'diperiksa di sini dengan kunci publik. Format key HARUS sama dengan Lisensi.vb di repo generator:
'  [0] versi (1) | [1..10] ID mesin server | [11..12] hari sejak 2020-01-01 (UInt16 LE, 0 = selamanya)
'  | [13..76] tanda tangan ECDSA P-256/SHA-256 (r||s) atas byte 0..12. Ditulis base32 Crockford.
'Key disimpan di tabel lisensi (database server), jadi client ikut memakai key server.
Module lisensikunci
    'kunci publik ECDSA P-256 (X||Y, base64), dari "bmlisensi publik"
    Private Const KUNCIPUBLIK As String = "E0yVT68sKo/zaf+81Nbf/kiGfBGfIwZdbnDI4peFbvlQI/MALgaQ17rL3h4h4boV570War10BB0n2fQ6LNek1A=="
    Private Const ALFABET As String = "0123456789ABCDEFGHJKMNPQRSTVWXYZ"
    Private Const VERSI As Byte = 1
    Private Const PANJANGID As Integer = 10
    Private Const PANJANGDATA As Integer = 13
    Private Const PANJANGKEY As Integer = 77
    'peringatan perpanjangan muncul jika sisa masa berlaku kurang dari ini
    Public Const HARIPERINGATAN As Integer = 14

    Public Class hasillisensi
        Public valid As Boolean
        Public pesan As String = ""
        Public idmesin As String = ""
        Public selamanya As Boolean
        Public sampai As Date
        Public key As String = ""

        Public Function keterangan() As String
            If selamanya Then
                Return "berlaku selamanya"
            End If
            Return "berlaku sampai " + sampai.ToString("dd-MM-yyyy")
        End Function
    End Class

    'ID mesin komputer ini: hash MachineGuid Windows (tetap sampai Windows diinstal ulang)
    Public Function idmesin() As String
        Dim guid As String = ""
        'aplikasi x86: baca registry 64-bit, MachineGuid tidak ada di WOW6432Node
        Using hklm As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
            Using kunci As RegistryKey = hklm.OpenSubKey("SOFTWARE\Microsoft\Cryptography")
                If kunci IsNot Nothing Then
                    guid = CStr(kunci.GetValue("MachineGuid", ""))
                End If
            End Using
        End Using
        If guid = "" Then
            Throw New InvalidOperationException("ID mesin komputer ini tidak bisa dibaca (MachineGuid tidak ada).")
        End If
        Dim hash() As Byte
        Using sha As SHA256 = SHA256.Create()
            hash = sha.ComputeHash(Encoding.UTF8.GetBytes("BetterMoney-POS|" + guid.Trim().ToLowerInvariant()))
        End Using
        Dim id(PANJANGID - 1) As Byte
        Array.Copy(hash, id, PANJANGID)
        Return kelompokkan(kebase32(id))
    End Function

    'Periksa key. idharus = ID mesin yang wajib cocok (Nothing = tidak dicek, untuk client).
    Public Function periksakey(ByVal key As String, ByVal idharus As String) As hasillisensi
        Dim hasil As New hasillisensi()
        Dim rapi As String = rapikan(key)
        hasil.key = kelompokkan(rapi)
        If rapi = "" Then
            hasil.pesan = "License key belum diisi."
            Return hasil
        End If
        Dim data() As Byte = daribase32(rapi, PANJANGKEY)
        If data Is Nothing OrElse data(0) <> VERSI Then
            hasil.pesan = "Format license key salah. Periksa kembali key yang disalin."
            Return hasil
        End If
        Dim bagiandata(PANJANGDATA - 1) As Byte
        Dim tandatangan(63) As Byte
        Array.Copy(data, bagiandata, PANJANGDATA)
        Array.Copy(data, PANJANGDATA, tandatangan, 0, 64)
        Dim publik() As Byte = Convert.FromBase64String(KUNCIPUBLIK)
        Dim titik As New ECPoint()
        titik.X = publik.Take(32).ToArray()
        titik.Y = publik.Skip(32).ToArray()
        Dim parameter As New ECParameters()
        parameter.Curve = ECCurve.NamedCurves.nistP256
        parameter.Q = titik
        Using ecdsa As ECDsa = ECDsa.Create(parameter)
            If Not ecdsa.VerifyData(bagiandata, tandatangan, HashAlgorithmName.SHA256) Then
                hasil.pesan = "License key tidak asli."
                Return hasil
            End If
        End Using

        Dim id(PANJANGID - 1) As Byte
        Array.Copy(data, 1, id, 0, PANJANGID)
        hasil.idmesin = kelompokkan(kebase32(id))
        Dim hari As Integer = data(11) Or (CInt(data(12)) << 8)
        hasil.selamanya = (hari = 0)
        hasil.sampai = New Date(2020, 1, 1).AddDays(hari)

        If idharus IsNot Nothing AndAlso rapikan(idharus) <> rapikan(hasil.idmesin) Then
            hasil.pesan = "License key ini untuk komputer lain (ID mesin " + hasil.idmesin + "), bukan untuk komputer ini (" + idharus + ")."
        ElseIf Not hasil.selamanya AndAlso Date.Today > hasil.sampai Then
            hasil.pesan = "License key sudah habis masa berlakunya pada " + hasil.sampai.ToString("dd-MM-yyyy") + "."
        Else
            hasil.valid = True
            hasil.pesan = "License key valid, " + hasil.keterangan() + "."
        End If
        Return hasil
    End Function

    'Sisa hari masa berlaku (-1 = selamanya)
    Public Function sisahari(ByVal hasil As hasillisensi) As Integer
        If hasil.selamanya Then
            Return -1
        End If
        Return CInt((hasil.sampai - Date.Today).TotalDays)
    End Function

    Public Function bacalisensi(ByVal koneksi As MySqlConnection) As String
        Try
            Dim hasil As Object = New MySqlCommand("SELECT kunci FROM lisensi WHERE id=1", koneksi).ExecuteScalar()
            Return If(hasil Is Nothing OrElse IsDBNull(hasil), "", CStr(hasil))
        Catch ex As MySqlException When ex.Number = 1146
            'tabel lisensi belum ada
            Return ""
        End Try
    End Function

    Public Sub simpanlisensi(ByVal koneksi As MySqlConnection, ByVal key As String)
        Call New MySqlCommand("CREATE TABLE IF NOT EXISTS lisensi (id TINYINT NOT NULL PRIMARY KEY, kunci VARCHAR(255) NOT NULL) ENGINE=InnoDB", koneksi).ExecuteNonQuery()
        Dim simpan As New MySqlCommand("REPLACE INTO lisensi (id, kunci) VALUES (1, @kunci)", koneksi)
        simpan.Parameters.AddWithValue("@kunci", kelompokkan(rapikan(key)))
        simpan.ExecuteNonQuery()
    End Sub

    'Database ada di komputer ini? (aplikasi berjalan di komputer server)
    Public Function hostlokal(ByVal host As String) As Boolean
        host = Trim(host).ToLowerInvariant()
        If host = "" Or host = "localhost" Or host = "." Or host = "127.0.0.1" Or host = "::1" Or host = Dns.GetHostName().ToLowerInvariant() Then
            Return True
        End If
        Try
            For Each alamat As IPAddress In Dns.GetHostAddresses(Dns.GetHostName())
                If alamat.ToString().ToLowerInvariant() = host Then
                    Return True
                End If
            Next
        Catch ex As Exception
        End Try
        Return False
    End Function

    'Lisensi yang tersimpan di database. Di komputer server ID mesin wajib cocok; client hanya cek keaslian & masa berlaku.
    Public Function ceklisensi(ByVal koneksi As MySqlConnection, ByVal host As String) As hasillisensi
        Dim key As String = bacalisensi(koneksi)
        If key = "" Then
            Dim kosong As New hasillisensi()
            kosong.pesan = "Belum ada license key."
            Return kosong
        End If
        Return periksakey(key, If(hostlokal(host), idmesin(), Nothing))
    End Function

    Private Function kebase32(ByVal data() As Byte) As String
        Dim hasil As New StringBuilder()
        Dim penampung As Integer = 0
        Dim jumlahbit As Integer = 0
        For Each b As Byte In data
            penampung = (penampung << 8) Or b
            jumlahbit += 8
            While jumlahbit >= 5
                hasil.Append(ALFABET((penampung >> (jumlahbit - 5)) And 31))
                jumlahbit -= 5
            End While
            penampung = penampung And ((1 << jumlahbit) - 1)
        Next
        If jumlahbit > 0 Then
            hasil.Append(ALFABET((penampung << (5 - jumlahbit)) And 31))
        End If
        Return hasil.ToString()
    End Function

    Private Function daribase32(ByVal teks As String, ByVal jumlahbyte As Integer) As Byte()
        Dim hasil As New List(Of Byte)
        Dim penampung As Integer = 0
        Dim jumlahbit As Integer = 0
        For Each c As Char In teks
            Dim nilai As Integer = ALFABET.IndexOf(c)
            If nilai < 0 Then
                Return Nothing
            End If
            penampung = ((penampung << 5) Or nilai) And &HFFFF
            jumlahbit += 5
            If jumlahbit >= 8 Then
                hasil.Add(CByte((penampung >> (jumlahbit - 8)) And 255))
                jumlahbit -= 8
            End If
        Next
        If hasil.Count <> jumlahbyte Then
            Return Nothing
        End If
        Return hasil.ToArray()
    End Function

    'Huruf besar, buang pemisah, samakan huruf yang mirip (O->0, I/L->1)
    Private Function rapikan(ByVal teks As String) As String
        Dim hasil As New StringBuilder()
        For Each c As Char In If(teks, "").ToUpperInvariant()
            Select Case c
                Case "-"c, " "c, ControlChars.Cr, ControlChars.Lf, ControlChars.Tab
                Case "O"c
                    hasil.Append("0"c)
                Case "I"c, "L"c
                    hasil.Append("1"c)
                Case Else
                    hasil.Append(c)
            End Select
        Next
        Return hasil.ToString()
    End Function

    Private Function kelompokkan(ByVal teks As String) As String
        Dim bagian As New List(Of String)
        For i As Integer = 0 To teks.Length - 1 Step 4
            bagian.Add(teks.Substring(i, Math.Min(4, teks.Length - i)))
        Next
        Return String.Join("-", bagian)
    End Function
End Module
