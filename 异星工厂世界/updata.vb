Public Class form_updata

    'Public upsrc = "http://code.taobao.org/svn/yxgcsj/trunk/updatafiles/"
    Public upsrc = "https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/updatafiles/"
    Public r_version = "0"
    Public l_version = "0"


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Check_ver()
    End Sub
    Private Sub Check_ver()
        Dim dFile As New System.Net.WebClient
        Dim myUri_version As New Uri(upsrc + "version.txt")
        l_version = Form_main.Label_Ver_No.Text
        Try
            r_version = dFile.DownloadString(myUri_version）
        Catch ex As Exception
            r_version = l_version
            '"检测超时"
        End Try
        If l_version = r_version Then
            Label_status.Text = "已是最新版本！"
            'MsgBox("已是最新版本！")
            Form_main.Show()
            Me.Hide()
        Else
            MsgBox（“需要升级”）
            Label_status.Text = "正在下载..."
            Up_autoupdata()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Computer.FileSystem.FileExists("up_com.bat") Then
            Try
                My.Computer.FileSystem.DeleteFile("up_com.bat")
            Catch ex As Exception

            End Try
        End If

        If My.Computer.FileSystem.FileExists("up_data.exe") Then
            Try
                My.Computer.FileSystem.DeleteFile("up_data.exe")
            Catch ex As Exception

            End Try
        End If
        Label_status.Text = "正在检测更新......"

    End Sub

    Private Sub Up_autoupdata()

        'Dim up_com_bat_rar_uri = New Uri(upsrc + "up_com.bat.rar")
        'Dim d2updata_rar_uri = New Uri(upsrc + "d2updata.rar")
        ProgressBar1.Value = 10
        Label_status.Text = "正在下载..."
        Dim dFile As New System.Net.WebClient
        'Dim myUri_up_com As New Uri(upsrc + "up_com.bat")
        Dim myUri_up_data As New Uri(upsrc + "up_data.exe")


        '下载更新文件
        'Try

        '    dFile.DownloadFile(myUri_up_com, "up_com.bat")
        '    ProgressBar1.Value = 30
        'Catch ex As Exception
        '    MsgBox("1下载失败请重试")
        '    ProgressBar1.Value = 0
        '    Exit Sub
        'End Try

        Try
            dFile.DownloadFile(myUri_up_data, "up_data.exe")
            ProgressBar1.Value = 80
        Catch ex As Exception
            MsgBox("下载失败请重试")
            ProgressBar1.Value = 0
            Exit Sub
        End Try

        Try
            System.IO.File.WriteAllText("up_com.bat", TextBox_up_com.Text, encoding:=System.Text.Encoding.Default)
        Catch ex As Exception
            MsgBox（"升级错误，请手动执行 up_data.exe")
        End Try

        ProgressBar1.Value = 100
        MsgBox（"升级完成后将自动重启。"）
        Shell("up_com.bat")
        Form_chat.Close()
        Form_main.Close()
        Me.Close()
    End Sub
End Class
