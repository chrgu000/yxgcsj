Public Class Form_chat


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(20, My.Computer.Screen.Bounds.Height - 130)
        Focus()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                Clipboard.SetText(TextBox1.Text)
            Catch ex As Exception

            End Try

            AppActivate("Factorio 0.15.37")
            SendKeys.Send("`")
            SendKeys.Send("^v")
            SendKeys.Send("{ENTER}")
            'Shell("cmd.exe /c ""chat.vbs""", , True, vbHide)
            TextBox1.Text = ""
            Try
                Clipboard.Clear()
            Catch ex As Exception

            End Try
            Me.Hide()
        End If

    End Sub

End Class