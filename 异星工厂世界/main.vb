Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class Form_main
    'Public upsrc = "http://code.taobao.org/svn/yxgcsj/trunk/updatafiles/"
    Public up_root = "https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/serverlist/"
    Public r_version = "0"
    Public l_version = "0"

    'serverlist数组 y0为服务器名称，y1为ip，y2介绍，y3时间

    Public Const WM_HOTKEY = &H312
    'Public Const MOD_ALT = &H1
    Public Const MOD_CONTROL = &H2

    'Public Const MOD_SHIFT = &H4
    'Public Const GWL_WNDPROC = (-4)

    Public Declare Auto Function RegisterHotKey Lib "user32.dll" Alias _
        "RegisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Boolean

    Public Declare Auto Function UnRegisterHotKey Lib "user32.dll" Alias _
        "UnregisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer) As Boolean

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HOTKEY Then
            If CheckBox_chinese_chat.Checked = True Then
                Form_chat.Show()
                AppActivate("异星工厂世界中文聊天窗口")
                'MsgBox("在这里添加你要执行的代码", MsgBoxStyle.Information, "全局热键")
            End If
        End If

        MyBase.WndProc(m)
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '删除旧版vbs文件
        If My.Computer.FileSystem.FileExists("chat.vbs") Then
            Try
                My.Computer.FileSystem.DeleteFile("chat.vbs")
            Catch ex As Exception

            End Try
        End If

        '删除更新残留
        If My.Computer.FileSystem.FileExists("up_com.bat") Then
            Try
                My.Computer.FileSystem.DeleteFile("up_com.bat")
            Catch ex As Exception

            End Try
        End If
        If My.Computer.FileSystem.FileExists("up_data.exe") Then
            Try
                System.IO.File.WriteAllText("up_com.bat", TextBox_up_com.Text, encoding:=System.Text.Encoding.Default)
            Catch ex As Exception
                MsgBox（"升级错误，请手动执行 up_data.exe")
                Me.Close()
            End Try
            Shell("up_com.bat")
        End If
        '载入服务器列表

        '注册聊天热键
        RegisterHotKey(Handle, 0, MOD_CONTROL, 192)

        '后台开始下载serverlist文件
        BackgroundWorker_download_serverlist.RunWorkerAsync()

    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        '注销全局热键
        'UnRegisterHotKey(Handle, 1)
        '删除旧版文件
        If My.Computer.FileSystem.FileExists("chat.vbs") Then
            Try
                My.Computer.FileSystem.DeleteFile("chat.vbs")
            Catch ex As Exception

            End Try
        End If

        UnRegisterHotKey(Handle, 0)
        form_updata.Close()
    End Sub

    Sub load_server_list()
        '临时生成serverlist方便调试
        'Try
        '    System.IO.File.WriteAllText("serverlist.txt", TextBox_serverlist.Text, encoding:=System.Text.Encoding.Default)
        'Catch ex As Exception
        '    MsgBox（"升级错误，请手动执行 up_data.exe")
        'End Try

        '处理列表

        Dim i = -1 '临时统计文件有几行.-1为校正数组从0开始
        FileOpen(1, "serverlist.txt", OpenMode.Input)
        Do While Not EOF(1)

            Dim temp
            temp = LineInput(1)
            i = i + 1
        Loop
        FileClose()
        ' MsgBox(i)

        Dim serverlist(i, 3) As String
        FileOpen(1, "serverlist.txt", OpenMode.Input)
        Dim temp2
        Do While Not EOF(1)
            For x = 0 To i
                temp2 = LineInput(1)
                Dim arr As String() = temp2.Split(vbTab) '放入arr数组
                For y As Integer = 0 To 3
                    serverlist(x, y) = arr(y)
                    'MsgBox(serverlist(x, y))
                Next
            Next
            i = i + 1
        Loop
        FileClose()
        i = i - 1 '校正最后一次循环
        '处理完毕

        '按照数组，添加serverlist到listview控件
        For x = 0 To i
            ListView1.Items.Add(serverlist(x, 0))
            For y As Integer = 1 To 3
                ListView1.Items(x).SubItems.Add(serverlist(x, y))
            Next
        Next
        ' ListView1.Items（0）.ForeColor = Color.Red
        ListView1.Items(0).Selected = True
        ListView1.Focus()
        Button_join.Text = "请选择进入"
        Button_join.Enabled = True

    End Sub

    Private Sub Button_updata_Click(sender As Object, e As EventArgs) Handles Button_updata.Click
        form_updata.Show()
    End Sub

    Private Sub BackgroundWorker_download_serverlist_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker_download_serverlist.DoWork
        Dim dFile As New System.Net.WebClient
        Dim upUri_serverlist As New Uri(up_root & "serverlist.txt")
        Try
            dFile.DownloadFile(upUri_serverlist, "serverlist.txt")
        Catch ex As Exception
            Button_join.Text = "下载失败!"
        End Try
    End Sub

    Private Sub BackgroundWorker_download_serverlist_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker_download_serverlist.RunWorkerCompleted
        '下载完成开始load serverlist
        If Button_join.Text = "下载失败!" Then
        Else
            load_server_list()
        End If
    End Sub

    Private Sub Button_join_Click(sender As Object, e As EventArgs) Handles Button_join.Click
        Dim server_select = ListView1.FocusedItem.Index
        MsgBox(ListView1.Items(server_select).)


    End Sub
End Class