Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
'Logo otomatis dari nama toko, dipakai selama user belum memilih logo sendiri (cpanel "Upload").
Module logotoko
    Private Const AWALAN As String = "logotoko-"
    Private ReadOnly warnalatar() As Color = {Color.FromArgb(0, 105, 92), Color.FromArgb(21, 101, 192), Color.FromArgb(173, 20, 87),
                                              Color.FromArgb(191, 54, 12), Color.FromArgb(69, 39, 160), Color.FromArgb(46, 125, 50)}

    'Buat PNG 600x300 (rasio kotak logo di nota/laporan) berisi nama toko di folder.
    'Nama file selalu baru, karena logo lama bisa sedang dikunci form yang terbuka (Bitmap.FromFile).
    'Hasil: path file yang dibuat.
    Public Function buatlogo(ByVal namatoko As String, ByVal folder As String) As String
        Dim teks As String = Trim(namatoko)
        If teks = "" Then
            teks = "System POS"
        End If
        Const LEBAR As Integer = 600
        Const TINGGI As Integer = 300
        Const TEPI As Integer = 36
        Dim area As New RectangleF(TEPI, TEPI, LEBAR - 2 * TEPI, TINGGI - 2 * TEPI)

        'warna latar tetap untuk nama yang sama
        Dim jumlah As Integer = 0
        For Each huruf As Char In teks.ToUpper()
            jumlah += AscW(huruf)
        Next

        Directory.CreateDirectory(folder)
        Dim lokasi As String = Path.Combine(folder, AWALAN + Now.ToString("yyyyMMddHHmmssfff") + ".png")
        Using gambar As New Bitmap(LEBAR, TINGGI)
            Using g As Graphics = Graphics.FromImage(gambar)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                g.Clear(warnalatar(jumlah Mod warnalatar.Length))
                Using bingkai As New Pen(Color.FromArgb(150, Color.White), 3)
                    g.DrawRectangle(bingkai, 14, 14, LEBAR - 29, TINGGI - 29)
                End Using

                Using format As New StringFormat()
                    format.Alignment = StringAlignment.Center
                    format.LineAlignment = StringAlignment.Center
                    Dim huruf As Font = hurufpas(g, teks, area, format)
                    g.DrawString(teks, huruf, Brushes.White, area, format)
                    huruf.Dispose()
                End Using
            End Using
            gambar.Save(lokasi, Imaging.ImageFormat.Png)
        End Using
        Return lokasi
    End Function

    'Font terbesar yang membuat teks muat di area tanpa memotong kata
    Private Function hurufpas(ByVal g As Graphics, ByVal teks As String, ByVal area As RectangleF, ByVal format As StringFormat) As Font
        Dim kata() As String = teks.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        For ukuran As Integer = 110 To 14 Step -4
            Dim huruf As New Font("Segoe UI", ukuran, FontStyle.Bold, GraphicsUnit.Pixel)
            Dim muat As Boolean = g.MeasureString(teks, huruf, CInt(area.Width), format).Height <= area.Height
            For Each satu As String In kata
                If g.MeasureString(satu, huruf).Width > area.Width Then
                    muat = False
                End If
            Next
            If muat Then
                Return huruf
            End If
            huruf.Dispose()
        Next
        Return New Font("Segoe UI", 14, FontStyle.Bold, GraphicsUnit.Pixel)
    End Function

    'Logo hasil buatlogo (bukan logo pilihan user)?
    Public Function logobuatan(ByVal lokasi As String) As Boolean
        Return lokasi <> "" AndAlso Path.GetFileName(lokasi).StartsWith(AWALAN, StringComparison.OrdinalIgnoreCase)
    End Function

    'Hapus logo buatan lama di folder selain yang dipakai. File yang masih dikunci form lain dilewati.
    Public Sub hapuslogolama(ByVal folder As String, ByVal dipakai As String)
        For Each lama As String In Directory.GetFiles(folder, AWALAN + "*.png")
            If Not String.Equals(Path.GetFullPath(lama), Path.GetFullPath(dipakai), StringComparison.OrdinalIgnoreCase) Then
                Try
                    File.Delete(lama)
                Catch ex As IOException
                Catch ex As UnauthorizedAccessException
                End Try
            End If
        Next
    End Sub
End Module
