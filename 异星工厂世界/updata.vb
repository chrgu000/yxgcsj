Imports System.ComponentModel
Imports System.Net
Public Class form_updata

    'Public upsrc = "http://code.taobao.org/svn/yxgcsj/trunk/updatafiles/"
    Public up_root = "https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/updatafiles/"
    Public r_version = "0"
    Public l_version = "0"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label_status.Text = "正在检测更新......"
        l_version = Form_main.Label_Ver_No.Text
        BackgroundWorker_check_ver.RunWorkerAsync()
    End Sub

    Private Sub Up_autoupdata()
        Label_status.Text = "正在下载..."
        BackgroundWorker_download_updata.RunWorkerAsync()

    End Sub


    Private Sub BackgroundWorker_check_ver_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_check_ver.DoWork
        Dim dFile As New System.Net.WebClient
        Dim upUri_version As New Uri(up_root + "version.txt")
        Try
            r_version = dFile.DownloadString(upUri_version)
        Catch ex As Exception
            Label_status.Text = "检测失败"
            r_version = "0"
        End Try

    End Sub

    Private Sub BackgroundWorker_check_ver_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker_check_ver.RunWorkerCompleted
        'MsgBox(e.Error)


        If l_version = r_version Then
            Me.Label_status.Text = "已是最新版本！"
            Form_main.Show()
            Form_chat.Hide()
        Else
            If r_version = "0" Then
                Label_status.Text = “检测失败”
            Else
                MsgBox（“需要升级”）
                Label_status.Text = "正在下载..."
                Up_autoupdata()
            End If
        End If
    End Sub

    Private Sub BackgroundWorker_download_updata_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker_download_updata.DoWork
        Dim dFile As New System.Net.WebClient
        Dim upUri_up_data As New Uri(up_root & "up_data.exe")
        Try
            dFile.DownloadFile(upUri_up_data, "up_data.exe")
        Catch ex As Exception
            Label_status.Text = "下载失败!"
        End Try



    End Sub

    Private Sub BackgroundWorker_download_updata_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker_download_updata.RunWorkerCompleted
        If Label_status.Text <> "下载失败!" Then
            Label_status.Text = "下载完成!"
            Try
                System.IO.File.WriteAllText("up_com.bat", TextBox_up_com.Text, encoding:=System.Text.Encoding.Default)
                Label_status.Text = "升级完成后将自动重启。"
                Shell("up_com.bat", Style:=AppWinStyle.NormalFocus)
                Form_chat.Close()
                Form_main.Close()
                Me.Close()
            Catch ex As Exception
                MsgBox（"升级错误，请手动执行 up_data.exe")
            End Try

        End If

    End Sub

    Private Sub BackgroundWorker_check_ver_Disposed(sender As Object, e As EventArgs) Handles BackgroundWorker_check_ver.Disposed
        MsgBox("disposed")
    End Sub

    Private Sub Timer_chech_ver_time_out_Tick(sender As Object, e As EventArgs) Handles Timer_chech_ver_time_out.Tick
        Timer_chech_ver_time_out.Enabled = False
        MsgBox（BackgroundWorker_check_ver.IsBusy.ToString()）
        Label_status.Text = "检测失败"
    End Sub

End Class
