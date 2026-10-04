Public Class formlisensi
    'Lihat / ganti license key. Key berlaku untuk ID mesin komputer server, jadi hanya bisa disimpan di komputer server.

    Private Sub formlisensi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtkey.Text = ""
        Try
            txtidmesin.Text = idmesin()
        Catch ex As Exception
            txtidmesin.Text = ""
            lblpetunjuk.Text = ex.Message
        End Try

        Dim diserver As Boolean = hostlokal(konek.DataSource)
        Try
            Dim hasil As hasillisensi = ceklisensi(konek, konek.DataSource)
            lblstatus.Text = hasil.pesan
            lblstatus.ForeColor = If(hasil.valid, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkRed)
        Catch ex As Exception
            lblstatus.Text = "Lisensi tidak bisa diperiksa: " + ex.Message
            lblstatus.ForeColor = System.Drawing.Color.DarkRed
        End Try

        txtkey.Enabled = diserver
        btnsimpan.Enabled = diserver
        If Not diserver Then
            lblpetunjuk.Text = "Komputer ini adalah client. License key dimasukkan di komputer server (menu Lisensi di aplikasi server)."
        End If
    End Sub

    Private Sub btnsalin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalin.Click
        If txtidmesin.Text <> "" Then
            Clipboard.SetText(txtidmesin.Text)
            MsgBox("ID mesin disalin. Tempel (Ctrl+V) di pesan ke BetterMoney.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim hasil As hasillisensi = periksakey(txtkey.Text, txtidmesin.Text)
        If Not hasil.valid Then
            MsgBox(hasil.pesan, MsgBoxStyle.Exclamation)
            txtkey.Focus()
            Exit Sub
        End If
        Try
            simpanlisensi(konek, txtkey.Text)
        Catch ex As Exception
            MsgBox("License key gagal disimpan ke database: " + ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        MsgBox("License key disimpan, " + hasil.keterangan() + ".", MsgBoxStyle.Information)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
