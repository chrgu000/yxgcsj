Imports System.IO

Public Class Form_main
    'Public upsrc = "http://code.taobao.org/svn/yxgcsj/trunk/serverlist/"
    Public upsrc = "https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/updatafiles/"
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
        '如果有更新文件，先更新

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



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'ListView1.Items.Add(item(0))
        'ListView1.Items(0).SubItems.Add(item(1))
        'ListView1.Items(0).SubItems.Add(item(2))
        'ListView1.Items(0).SubItems.Add(item(3))
        'ListView1.Items（0）.ForeColor = Color.Red
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '上传ip 文件
    End Sub

    Sub load_server_list()
        '临时生成serverlist方便调试
        Try
            System.IO.File.WriteAllText("serverlist.txt", TextBox_serverlist.Text, encoding:=System.Text.Encoding.Default)
        Catch ex As Exception
            MsgBox（"升级错误，请手动执行 up_data.exe")
        End Try

        ''删除旧列表
        'If My.Computer.FileSystem.FileExists("serverlist.txt") Then
        '    Try
        '        My.Computer.FileSystem.DeleteFile("serverlist.txt")
        '    Catch ex As Exception

        '    End Try
        'End If
        'Dim dFile As New System.Net.WebClient

        '下载新列表
        'Try
        'Dim myUri As New Uri(form_updata.upsrc + "serverlist.txt")
        'dFile.DownloadFile(myUri, "serverlist.txt")

        ' Catch ex As Exception
        'MsgBox("服务器列表下载失败！")
        ' Exit Sub
        ' End Try

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


        For x = 0 To i
            ListView1.Items.Add(serverlist(x, 0))
            For y As Integer = 1 To 3
                ListView1.Items(x).SubItems.Add(serverlist(x, y))

            Next
        Next
        ' ListView1.Items（0）.ForeColor = Color.Red
        ListView1.Items(0).Selected = True
        ListView1.Focus()

        'ListView1.Items.Add(item(0))
        'ListView1.Items(0).SubItems.Add(item(1))
        'ListView1.Items(0).SubItems.Add(item(2))
        'ListView1.Items(0).SubItems.Add(item(3))





    End Sub

    Private Sub Form_main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        load_server_list()
        Button_join.Text = "进入"
    End Sub

    Private Sub Button_join_Click(sender As Object, e As EventArgs) Handles Button_join.Click

        '两秒后检查更新
        Timer1.Enabled = True
        'MsgBox(ListView1.SelectedIndices.Item(0))

        Try
            Shell(".\bin\x64\factorio.exe", Style:=AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox("没找到异星工厂的可执行文件，请把本程序放进异星工厂游戏根目录，例如：D: \Factorio_0.15.37")
        End Try

    End Sub

    Private Sub Button_updata_Click(sender As Object, e As EventArgs) Handles Button_updata.Click
        form_updata.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        form_updata.Show()
    End Sub
    Private Sub Check_ver()


        Dim dFile As New System.Net.WebClient
        Dim myUri_version As New Uri(upsrc + "version.txt")
        l_version = Form_main.Label_Ver_No.Text

        Try
            r_version = dFile.DownloadString(myUri_version)
        Catch ex As Exception
            r_version = l_version
        End Try

        If l_version = r_version Then
            Me.Label_status.Text = "已是最新版本！"
            MsgBox("已是最新版本！")
            Form_main.Show()
            Form_chat.Hide()
        Else
            MsgBox（“需要升级”）
            Me.Label_status.Text = "正在下载..."
            Me.Up_autoupdata()
        End If
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
            dFile.DownloadFileAsync(myUri_up_data, "up_data.exe")
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
