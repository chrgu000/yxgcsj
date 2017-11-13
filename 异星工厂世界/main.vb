Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class Form_main
    '------------------------
    '后台按键测试
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    '常量声明 　　
    Private Const WM_LBUTTONDBLCLK = &H203
    Private Const WM_LBUTTONDOWN = &H201
    Private Const WM_LBUTTONUP = &H202
    Private Const WM_MBUTTONDBLCLK = &H209
    Private Const WM_MBUTTONDOWN = &H207
    Private Const WM_MBUTTONUP = &H208
    Private Const WM_RBUTTONDBLCLK = &H206
    Private Const WM_RBUTTONDOWN = &H204
    Private Const WM_RBUTTONUP = &H205
    '后台按键测试结束
    '--------------------


    'Public upsrc = "http://code.taobao.org/svn/yxgcsj/trunk/updatafiles/"
    Public up_root = "https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/serverlist/"
    Public r_version = "0"
    Public l_version = "0"
    Dim server_select = 0
    Dim server_id

    'serverlist数组 x0为服务器名称，x1为介绍，x2时间,x3 ping x4 ip 不显示
    Public serverlist(4, 0)
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
        '清理文件
        delete_files()

        '载入服务器列表
        '后台开始下载serverlist文件
        BackgroundWorker_download_serverlist.RunWorkerAsync()

        '注册聊天热键
        RegisterHotKey(Handle, 0, MOD_CONTROL, 192)


        '直接载入serverlist，方便调试
        'load_server_list()

    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        '注销全局热键
        'UnRegisterHotKey(Handle, 1)
        '删除旧版文件
        'delete_files()

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

        ReDim serverlist(4, i)
        FileOpen(1, "serverlist.txt", OpenMode.Input)
        Dim temp2
        Do While Not EOF(1)
            For l = 0 To i
                temp2 = LineInput(1)
                Dim arr As String() = temp2.Split(vbTab) '放入arr数组
                For h As Integer = 0 To 3
                    serverlist(h, l) = arr(h)
                    'MsgBox(serverlist(h, l))
                Next
            Next
            i = i + 1
        Loop
        FileClose()
        i = i - 1 '校正最后一次循环
        '处理完毕
        '删除serverlist.txt文件
        If My.Computer.FileSystem.FileExists("serverlist.txt") Then
            Try
                My.Computer.FileSystem.DeleteFile("serverlist.txt")
            Catch ex As Exception
            End Try
        End If


        '按照数组，添加serverlist到listview控件
        For l = 0 To i
            ListView1.Items.Add(serverlist(0, l))
            For h = 1 To 2
                ListView1.Items(l).SubItems.Add(serverlist(h, l))
            Next
        Next

        'ListView1.Items（0）.ForeColor = Color.Red

        Button_join.Text = "请选择进入"

        Button_join.Enabled = True

        ListView1.Items(0).Focused = True
        ListView1.Items(0).Selected = True
        ' ListView1.Focus()
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

        server_select = ListView1.FocusedItem.Index
        'serverlist（0, server_select) 服务器名称
        'serverlist（1, server_select) 服务器介绍
        'serverlist（2, server_select) 服务器最后激活时间
        'serverlist（3, server_select) ip 不显示
        'serverlist（4, server_select) ping

        '修改host文件
        edit_hosts()

        '修改player-data.json文件
        edit_player_data_json()

        '启动游戏
        Shell(".\bin\x64\factorio.exe", Style:=AppWinStyle.NormalFocus)


    End Sub
    Private Sub edit_hosts()
        Dim host_file(0)
        Dim host_file_hang = -1     '临时统计文件有几行.-1为校正数组从0开始
        Try
            'FileOpen(1, "C:\Windows\System32\drivers\etc\hosts", OpenMode.Input)
            'Do While Not EOF(1)

            '    host_file_hang = host_file_hang + 1
            '    ReDim Preserve host_file(host_file_hang)
            '    host_file(host_file_hang) = LineInput(1)
            '    Console.WriteLine("行" & host_file_hang.ToString)

            '    Console.WriteLine(host_file(host_file_hang))
            'Loop
            'FileClose()

            Dim sr = New StreamReader("C:\Windows\System32\drivers\etc\hosts", encoding:=System.Text.Encoding.Default)

            Do
                host_file_hang = host_file_hang + 1
                ReDim Preserve host_file(host_file_hang)
                host_file(host_file_hang) = sr.ReadLine()

            Loop Until host_file(host_file_hang） Is Nothing
            sr.Close()



            Dim gongchangshijie_chuxiancishu = 0
            For i = 0 To UBound(host_file)
                'MsgBox(InStr(host_file（i）, "工厂世界"）)
                If InStr(host_file（i）, "工厂世界"） > 0 Then
                    gongchangshijie_chuxiancishu = gongchangshijie_chuxiancishu + 1
                    'MsgBox(InStr(host_file（i）, "工厂世界"）)
                    For l = i To UBound(host_file)
                        If l = UBound(host_file) Then
                            host_file(l) = ""

                        Else
                            host_file(l) = host_file(l + 1)
                            'ReDim Preserve host_file(UBound(host_file) - 1)

                        End If
                    Next
                    i = i - 1
                End If
            Next
            ReDim Preserve host_file(UBound(host_file) - gongchangshijie_chuxiancishu)

            If host_file(UBound(host_file)) = "" Then
                host_file(UBound(host_file)) = serverlist（3, server_select) & vbTab & "工厂世界"
            Else
                ReDim Preserve host_file(UBound(host_file) + 1)
                host_file(UBound(host_file)) = serverlist（3, server_select) & vbTab & "工厂世界"
            End If
        Catch ex As Exception
            If host_file(UBound(host_file)) = "" Then
                host_file(UBound(host_file)) = serverlist（3, server_select) & vbTab & "工厂世界"
            Else
                ReDim Preserve host_file(UBound(host_file) + 1)
                host_file(UBound(host_file)) = serverlist（3, server_select) & vbTab & "工厂世界"
            End If
        End Try

        Dim hosts_file_string = ""
        For i = 0 To UBound(host_file)
            hosts_file_string = (hosts_file_string & host_file(i) & vbCrLf)
        Next
        System.IO.File.WriteAllText("C:\Windows\System32\drivers\etc\hosts", hosts_file_string, encoding:=System.Text.Encoding.Default)
    End Sub
    Private Sub edit_player_data_json()
        Dim player_data_file(0)
        Dim player_data_file_hang = -1     '临时统计文件有几行.-1为校正数组从0开始
        Try
            Dim sr = New StreamReader("player-data.json", encoding:=System.Text.Encoding.Default)

            Do
                player_data_file_hang = player_data_file_hang + 1
                ReDim Preserve player_data_file(player_data_file_hang)
                player_data_file(player_data_file_hang) = sr.ReadLine()

            Loop Until player_data_file(player_data_file_hang) Is Nothing
            sr.Close()


            Dim address_hang = 15
            For i = 0 To UBound(player_data_file)
                If InStr(player_data_file（i）, "latest-multiplayer-connections"） > 0 Then
                    address_hang = i + 2
                End If
            Next
            player_data_file(address_hang) = "      ""address"": ""工厂世界"""

        Catch ex As Exception
            MsgBox("处理错误")
        End Try

        Dim hosts_file_string = ""
        For i = 0 To UBound(player_data_file)
            hosts_file_string = (hosts_file_string & player_data_file(i) & vbCrLf)
        Next
        System.IO.File.WriteAllText("player-data.json", hosts_file_string, encoding:=System.Text.Encoding.Default)
    End Sub

    Private Sub Timer_enable_refresh_serverlist_Tick(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button_refresh_serverlist_Click(sender As Object, e As EventArgs)
        Button_join.Text = "正在载入服务器列表"
        Button_join.Enabled = False

        BackgroundWorker_download_serverlist.RunWorkerAsync()
    End Sub

    Private Sub delete_files()
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
        '删除更新残留
        If My.Computer.FileSystem.FileExists("up_data.exe") Then
            Try
                My.Computer.FileSystem.DeleteFile("up_data.exe")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub LinkLabel_ver_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_ver.LinkClicked
        Process.Start("https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/updatafiles/%E6%9B%B4%E6%96%B0%E6%97%A5%E5%BF%97.txt")
    End Sub


    Private Sub Button_check_ip_Click(sender As Object, e As EventArgs) Handles Button_check_ip.Click
        Button_check_ip.Text = "正在检测"
        Button_check_ip.Enabled = False
        Dim ip As String
        Dim dFile As New System.Net.WebClient
        Dim upUri_version As New Uri("http://www.3322.org/dyndns/getip")
        Try

            ip = dFile.DownloadString(upUri_version)
        Catch ex As Exception
            ip = "检测失败"
        End Try
        ip = Replace(ip, vbLf, "")
        TextBox_IP.Text = ip
        Button_check_ip.Text = "自动检测"
        Button_check_ip.Enabled = True
    End Sub

    Private Sub Button_create_server_Click(sender As Object, e As EventArgs) Handles Button_create_server.Click
        Button_create_server.Text = "正在创建"
        Button_create_server.Enabled = False

        '创建server-settings.example.json。
        create_server_settings()

        '执行服务器启动命令。
        run_server()

        Button_create_server.Text = "正在运行"

        '发送本机serverlist到服务器。
    End Sub

    Private Sub create_server_settings()
        Dim server_settings(59)
        server_settings(0) = "{"
        server_settings(1) = "  ""name"": ""Name of the game as it will appear in the game listing"","
        server_settings(2) = "  ""description"": ""Description of the game that will appear in the listing"","
        server_settings(3) = "  ""tags"": [""game"", ""tags""],"
        server_settings(4) = ""
        server_settings(5) = "  ""_comment_max_players"": ""Maximum number of players allowed, admins can join even a full server. 0 means unlimited."","
        server_settings(6) = "  ""max_players"": " & TextBox_max_players.Text & ","
        server_settings(7) = ""
        server_settings(8) = "  ""_comment_visibility"": [""public: Game will be published on the official Factorio matching server"","
        server_settings(9) = "                          ""lan: Game will be broadcast on LAN""],"
        server_settings(10) = "  ""visibility"":"
        server_settings(11) = "  {"
        server_settings(12) = "    ""public"": true,"
        server_settings(13) = "    ""lan"": true"
        server_settings(14) = "  },"
        server_settings(15) = ""
        server_settings(16) = "  ""_comment_credentials"": ""Your factorio.com login credentials. Required for games with visibility public"","
        server_settings(17) = "  ""username"": """","
        server_settings(18) = "  ""password"": """","
        server_settings(19) = ""
        server_settings(20) = "  ""_comment_token"": ""Authentication token. May be used instead of 'password' above."","
        server_settings(21) = "  ""token"": """","
        server_settings(22) = ""
        server_settings(23) = "  ""game_password"": """","
        server_settings(24) = ""
        server_settings(25) = "  ""_comment_require_user_verification"": ""When set to true, the server will only allow clients that have a valid Factorio.com account"","
        server_settings(26) = "  ""require_user_verification"": false,"
        server_settings(27) = ""
        server_settings(28) = "  ""_comment_max_upload_in_kilobytes_per_second"" : ""optional, default value is 0. 0 means unlimited."","
        server_settings(29) = "  ""max_upload_in_kilobytes_per_second"": 0,"
        server_settings(30) = ""
        server_settings(31) = "  ""_comment_minimum_latency_in_ticks"": ""optional one tick is 16ms in default speed, default value is 0. 0 means no minimum."","
        server_settings(32) = "  ""minimum_latency_in_ticks"": 0,"
        server_settings(33) = ""
        server_settings(34) = "  ""_comment_ignore_player_limit_for_returning_players"": ""Players that played on this map already can join even when the max player limit was reached."","
        server_settings(35) = "  ""ignore_player_limit_for_returning_players"": false,"
        server_settings(36) = ""
        server_settings(37) = "  ""_comment_allow_commands"": ""possible values are, true, false and admins-only"","
        server_settings(38) = "  ""allow_commands"": ""admins-only"","
        server_settings(39) = ""
        server_settings(40) = "  ""_comment_autosave_interval"": ""Autosave interval in minutes"","
        server_settings(41) = "  ""autosave_interval"": " & TextBox_autosave_interval.Text & ","
        server_settings(42) = ""
        server_settings(43) = "  ""_comment_autosave_slots"": ""server autosave slots, it is cycled through when the server autosaves."","
        server_settings(44) = "  ""autosave_slots"": " & TextBox_autosave_slots.Text & ","
        server_settings(45) = ""
        server_settings(46) = " ""_comment_afk_autokick_interval"": ""How many minutes until someone is kicked when doing nothing, 0 for never."","
        server_settings(47) = " ""afk_autokick_interval"": " & TextBox_afk_autokick_interval.Text & ","
        server_settings(48) = ""
        server_settings(49) = " ""_comment_auto_pause"": ""Whether should the server be paused when no players are present."","
        If ComboBox_auto_pause.Text = "否" Then
            server_settings(50) = " ""auto_pause"": false,"
        Else
            server_settings(50) = " ""auto_pause"": true,"
        End If
        server_settings(51) = ""
        server_settings(52) = "  ""only_admins_can_pause_the_game"": true,"
        server_settings(53) = ""
        server_settings(54) = "  ""_comment_autosave_only_on_server"": ""Whether autosaves should be saved only on server or also on all connected clients. Default is true."","
        server_settings(55) = "  ""autosave_only_on_server"": true,"
        server_settings(56) = ""
        server_settings(57) = "  ""_comment_admins"": ""List of case insensitive usernames, that will be promoted immediately"","
        server_settings(58) = "  ""admins"": []"
        server_settings(59) = "}"

        Dim server_settings_file_string = ""
        For i = 0 To UBound(server_settings)
            server_settings_file_string = (server_settings_file_string & server_settings(i) & vbCrLf)
        Next
        Directory.CreateDirectory("data/fs")
        System.IO.File.WriteAllText("data/fs/fs.json", server_settings_file_string, encoding:=System.Text.Encoding.Default)
    End Sub
    Private Sub run_server()

        'server_id = Shell("cmd /c .\bin\x64\factorio.exe --start-server " & TextBox_saves.Text & " --server-settings data/fs/fs.json", Style:=AppWinStyle.NormalFocus)
        server_id = Shell("cmd /c.\bin\x64\factorio.exe --start-server " & TextBox_saves.Text & " --server-settings data/fs/fs.json", AppWinStyle.MinimizedNoFocus)

    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        ComboBox_auto_pause.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            AppActivate(server_id)
            Threading.Thread.Sleep(200)
            SendKeys.Send("^C")
            'Threading.Thread.Sleep(100)
            'SendKeys.Send("/save")
            'Threading.Thread.Sleep(100)
            'SendKeys.Send("{ENTER}")
            Button_create_server.Text = "创建"
            Button_create_server.Enabled = True
        Catch ex As Exception
            MsgBox（"服务已停止！")
        End Try
    End Sub
End Class