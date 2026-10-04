Namespace My
    Partial Friend Class MyApplication
        'Dipanggil installer: Minimarket.exe --cek-mysql|--setup-server|--setup-client <file.ini>
        'Jalan tanpa membuka form, hasil lewat exit code & <file.ini>.hasil
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If e.CommandLine.Count = 2 AndAlso e.CommandLine(0).StartsWith("--") Then
                Environment.ExitCode = jalankanmode(e.CommandLine(0), e.CommandLine(1), folderdata())
                e.Cancel = True
            End If
        End Sub
    End Class
End Namespace
