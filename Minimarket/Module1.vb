Imports MySql.Data
Module Module1
    Public id_kasir, hak_akses, pathlogo, namatoko As String
    Public konek As MySqlClient.MySqlConnection
    'password akun bawaan superadmin (minimarket_db.sql); user diingatkan menggantinya saat login
    Public Const PASSWORDBAWAAN As String = "password"

    'koneksi.txt & config.txt disimpan di C:\ProgramData\Minimarket, karena folder aplikasi
    '(C:\Program Files) tidak bisa ditulis user biasa.
    Public Function folderdata() As String
        Dim folder As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Minimarket")
        IO.Directory.CreateDirectory(folder)
        Return folder
    End Function
    Public Function lokasifile(ByVal nama As String) As String
        Dim lokasi As String = IO.Path.Combine(folderdata(), nama)
        'pindahkan file dari versi lama yang menyimpan di folder aplikasi
        Dim lama As String = IO.Path.Combine(Application.StartupPath, nama)
        If Not IO.File.Exists(lokasi) And IO.File.Exists(lama) Then
            IO.File.Copy(lama, lokasi)
        End If
        Return lokasi
    End Function
End Module
