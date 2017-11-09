Public Class Form_chat


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Point(20, My.Computer.Screen.Bounds.Height - 130)
        'Focus()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(27) Then
            TextBox1.Text = ""
            Me.Hide()

        End If

        If e.KeyChar = ChrW(13) Then
            Try
                Clipboard.SetText(TextBox1.Text)
            Catch ex As Exception

            End Try
            Try
                AppActivate("Factorio 0.15.37")
                Threading.Thread.Sleep(100)
                SendKeys.Send("`")
                Threading.Thread.Sleep(100)
                SendKeys.Send("^v")
                Threading.Thread.Sleep(100)
                SendKeys.Send("{ENTER}")
            Catch ex As Exception
                MsgBox（"请确认已经打开游戏，游戏版本是0.15.37")
            End Try

            'Shell("cmd.exe /c ""chat.vbs""", , True, vbHide)
            TextBox1.Text = ""
            'Try
            'Clipboard.Clear()
            ' Catch ex As Exception
            ' End Try
            Me.Hide()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            AppActivate("Factorio 0.15.37")
            Threading.Thread.Sleep(100)
            SendKeys.Send("^v")
            Threading.Thread.Sleep(100)
            SendKeys.Send("{ENTER}")
        Catch ex As Exception
            MsgBox（"请确认已经打开游戏，游戏版本是0.15.37")
        End Try

        'Shell("cmd.exe /c ""chat.vbs""", , True, vbHide)
        TextBox1.Text = ""
        'Try
        'Clipboard.Clear()
        ' Catch ex As Exception
        ' End Try
        TextBox1.Focus()
        Me.Hide()
    End Sub

End Class