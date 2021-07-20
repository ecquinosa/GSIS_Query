Module GlobalDeclarations

    Public Enc As New ClassEncryption("baronpogi")

    Public Function Connection_String() As String
        My.Settings.Reload()
        If My.Settings.WindowsAuthentication Then
            Return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" & My.Settings.Database & ";Data Source=" & My.Settings.Server
        Else
            Return "Server=" & My.Settings.Server & ";Database=" & My.Settings.Database & ";Uid=" & My.Settings.Username & "; Pwd=" & My.Settings.Password 'Enc.TripleDesDecryptText(My.Settings.Password)
        End If
    End Function

End Module
