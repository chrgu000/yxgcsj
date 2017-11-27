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
    'Public up_root = "https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/serverlist/"
    Public sl_root = "http://code.taobao.org/svn/yxgcipup/trunk/"
    Public up_root = "http://code.taobao.org/svn/yxgcsj/trunk/updatafiles/"
    Public r_version = "0"
    Public l_version = "0"
    Dim server_select = 0
    Dim server_id
    Dim miao = 30
    Dim err = 0

    'serverlist数组 x0为服务器名称，x1为介绍，x2时间（暂时无用）,x3 ip x4 ping 暂时无用
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

        '注册聊天热键
        RegisterHotKey(Handle, 0, MOD_CONTROL, 192)

        '0.5秒后开始载入sl.txt
        Timer_load_sl.Enabled = True

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

    Private Sub load_server_list()
        '临时生成serverlist方便调试
        'Try
        '    System.IO.File.WriteAllText("serverlist.txt", TextBox_serverlist.Text, encoding:=System.Text.Encoding.Default)
        'Catch ex As Exception
        '    MsgBox（"升级错误，请手动执行 up_data.exe")
        'End Try


        '处理列表
        '判断是否有serverlist
        ReDim serverlist(4, 0)
        If My.Computer.FileSystem.FileExists("sl.txt") Then
            Dim i = -1 '临时统计文件有几行.-1为校正数组从0开始
            FileOpen(1, "sl.txt", OpenMode.Input)
            Do While Not EOF(1)

                Dim temp
                temp = LineInput(1)
                i = i + 1
            Loop
            FileClose()
            ' MsgBox(i)

            ReDim serverlist(4, i)
            FileOpen(1, "sl.txt", OpenMode.Input)
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
            If My.Computer.FileSystem.FileExists("sl.txt") Then
                Try
                    My.Computer.FileSystem.DeleteFile("sl.txt")
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


        Else
            MsgBox(“请重新刷新服务器列表”)

        End If

    End Sub

    Private Sub Button_updata_Click(sender As Object, e As EventArgs) Handles Button_updata.Click
        form_updata.Show()
    End Sub

    Private Sub BackgroundWorker_download_serverlist_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker_download_serverlist.DoWork
        'svn下载方式
        'Shell("""./data/facw/svn.exe""  cleanup  ./data/facw/sl", AppWinStyle.Hide, True)
        'Threading.Thread.Sleep(200)
        'Shell("""./data/facw/svn.exe""  co  http://code.taobao.org/svn/yxgcipup/trunk  ./data/facw/sl", AppWinStyle.Hide, True)
        'Threading.Thread.Sleep(200)
        'If My.Computer.FileSystem.FileExists("data/facw/sl/sl.txt") Then
        'Else
        '    Button_join.Text = "下载失败!"
        'End If

        '--------------原来，直接下载方式
        Dim dFile As New System.Net.WebClient
        '完整url http://code.taobao.org/svn/yxgcipup/trunk/sl.txt
        Dim upUri_serverlist As New Uri(sl_root & "sl.txt")
        Try
            dFile.DownloadFile(upUri_serverlist, "sl.txt")
        Catch ex As Exception

        End Try
        '----------原来，直接下载方式结束。

        '检测更新

        Dim upUri_version As New Uri(up_root + "version.txt")
        Try
            r_version = dFile.DownloadString(upUri_version)
        Catch ex As Exception
            r_version = "0"
        End Try


    End Sub

    Private Sub BackgroundWorker_download_serverlist_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker_download_serverlist.RunWorkerCompleted
        '下载完成开始load serverlist
        If My.Computer.FileSystem.FileExists("sl.txt") Then
            load_server_list()
        Else
            Me.Button_join.Text = "下载失败!"
            miao = 1

        End If
        Timer_enable_reload_serverlist.Enabled = True

        '判断更新
        If r_version = "0" Then
            Label_ver_status.Text = "检测失败"
        Else
            l_version = Label_ver.Text
            If l_version = r_version Then
                Label_ver_status.Text = "已是最新版本！"
            Else
                Label_ver_status.Text = "需要升级"
                Label_ver_status.ForeColor = Color.Red
            End If

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
        'If err = 0 Then
        Shell(".\bin\x64\factorio.exe", Style:=AppWinStyle.NormalFocus)
        'End If



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
        Threading.Thread.Sleep(200)
    End Sub
    Private Sub edit_player_data_json()
        Dim player_data_file(0)
        Dim player_data_file_hang = -1     '临时统计文件有几行.-1为校正数组从0开始

        If My.Computer.FileSystem.FileExists(Environ("AppData") & "\Factorio\player-data.json") Then


            Try
                Dim sr = New StreamReader(Environ("AppData") & "\Factorio\player-data.json", encoding:=System.Text.Encoding.Default)

                Do
                    player_data_file_hang = player_data_file_hang + 1
                    ReDim Preserve player_data_file(player_data_file_hang)
                    player_data_file(player_data_file_hang) = sr.ReadLine()

                Loop Until player_data_file(player_data_file_hang) Is Nothing
                sr.Close()

                Dim lmc = 0 'latest-multiplayer-connections所在行数
                For i = 0 To UBound(player_data_file)
                    If InStr(player_data_file（i）, "latest-multiplayer-connections"） > 0 Then
                        lmc = i
                    End If
                Next
                If lmc > 0 Then
                    player_data_file(lmc + 2) = "      ""address"": ""工厂世界"""
                Else
                    '如果没有，找 service-username所在行，顺延5
                    '
                    Dim su 'service-usernames所在行
                    For i = 0 To UBound(player_data_file)
                        If InStr(player_data_file（i）, "service-username"） > 0 Then
                            su = i
                        End If
                    Next

                    If su > 0 Then

                        Dim org_hang = UBound(player_data_file) '原来的行数
                        ReDim Preserve player_data_file(org_hang + 5)

                        For y = org_hang To su Step -1
                            player_data_file(y + 5) = player_data_file(y)
                        Next
                        player_data_file(su) = "  ""latest-multiplayer-connections"": ["
                        player_data_file(su + 1) = "    {"
                        player_data_file(su + 2) = "      ""address"": ""工厂世界"""
                        player_data_file(su + 3) = "    }"
                        player_data_file(su + 4) = "  ],"
                    Else
                        'service-username也找不到，报错
                        err = 1
                        'MsgBox（“错误编号 2”）
                        Exit Sub
                    End If

                End If

            Catch ex As Exception
                ' MsgBox("错误编号2")
                err = 1
            End Try

            Dim hosts_file_string = ""
            For i = 0 To UBound(player_data_file)
                hosts_file_string = (hosts_file_string & player_data_file(i) & vbCrLf)
            Next
            System.IO.File.WriteAllText(Environ("AppData") & "\Factorio\player-data.json", hosts_file_string, encoding:=System.Text.Encoding.Default)
            Threading.Thread.Sleep(200)

        End If

        If My.Computer.FileSystem.FileExists("player-data.json") Then
            ReDim player_data_file(0)
            player_data_file_hang = -1
            Try
                Dim sr = New StreamReader("player-data.json", encoding:=System.Text.Encoding.Default)

                Do
                    player_data_file_hang = player_data_file_hang + 1
                    ReDim Preserve player_data_file(player_data_file_hang)
                    player_data_file(player_data_file_hang) = sr.ReadLine()

                Loop Until player_data_file(player_data_file_hang) Is Nothing
                sr.Close()



                'For i = 0 To UBound(player_data_file)
                '    If InStr(player_data_file（i）, "service-username"） > 0 Then
                '        su = i
                '    End If
                'Next
                'If su > 0 Then
                '    Dim temp
                '    temp = Split(player_data_file(su), """")
                '    temp(3) = 'temp(3)=原来的用户名


                'Else
                '    err = 1
                '    MsgBox（“错误编号 1”）
                '    Exit Sub
                'End If


                Dim lmc = 0 'latest-multiplayer-connections所在行数
                For i = 0 To UBound(player_data_file)
                    If InStr(player_data_file（i）, "latest-multiplayer-connections"） > 0 Then
                        lmc = i
                    End If
                Next
                If lmc > 0 Then
                    player_data_file(lmc + 2) = "      ""address"": ""工厂世界"""
                Else
                    '如果没有，找 service-username所在行，顺延5
                    '
                    Dim su 'service-usernames所在行
                    For i = 0 To UBound(player_data_file)
                        If InStr(player_data_file（i）, "service-username"） > 0 Then
                            su = i
                        End If
                    Next
                    If su > 0 Then

                        Dim org_hang = UBound(player_data_file) '原来的行数
                        ReDim Preserve player_data_file(org_hang + 5)

                        For y = org_hang To su Step -1
                            player_data_file(y + 5) = player_data_file(y)
                        Next
                        player_data_file(su) = "  ""latest-multiplayer-connections"": ["
                        player_data_file(su + 1) = "    {"
                        player_data_file(su + 2) = "      ""address"": ""工厂世界"""
                        player_data_file(su + 3) = "    }"
                        player_data_file(su + 4) = "  ],"
                    Else
                        'service-username也找不到，报错
                        err = 1
                        ' MsgBox（“错误编号 1”）
                        Exit Sub
                    End If

                End If

            Catch ex As Exception
                'MsgBox("错误编号1")
                err = 1
            End Try

            Dim hosts_file_string = ""
            For i = 0 To UBound(player_data_file)
                hosts_file_string = (hosts_file_string & player_data_file(i) & vbCrLf)
            Next
            System.IO.File.WriteAllText("player-data.json", hosts_file_string, encoding:=System.Text.Encoding.Default)
            Threading.Thread.Sleep(200)
        End If

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
        If My.Computer.FileSystem.FileExists("./data/facw/sl/sl.txt") Then
            Try
                My.Computer.FileSystem.DeleteFile("./data/facw/sl/sl.txt")
            Catch ex As Exception

            End Try
        End If

        If My.Computer.FileSystem.DirectoryExists(".\data\facw\sl") Then
            Try
                Shell("cmd  /c rd /s /q data\facw\sl", AppWinStyle.Hide, True)
                'MsgBox("清理完成！")
            Catch ex As Exception
                'MsgBox("清理失败，请重试！")
            End Try
        Else
            'MsgBox("无需清理！")
        End If


    End Sub

    Private Sub LinkLabel_ver_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        'Process.Start("https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/updatafiles/%E6%9B%B4%E6%96%B0%E6%97%A5%E5%BF%97.txt")
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
        If TextBox_server_intro.Text = "" Or TextBox_server_name.Text = "" Or TextBox_IP.Text = "" Then
            MsgBox("请输入服务器名称和介绍")
            Exit Sub
        End If

        Button_create_server.Text = "正在创建"
        Button_create_server.Enabled = False

        '创建server-settings.example.json。
        create_server_settings()

        '执行服务器启动命令。
        run_server()

        Button_create_server.Text = "正在运行"

        '开始同步serverlist。
        Timer_sync_server_Tick(sender, e)
        Timer_sync_server.Enabled = True

        '方便调试
        'edit_server_list()

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
        Directory.CreateDirectory("data/facw")
        System.IO.File.WriteAllText("data/facw/fs.json", server_settings_file_string, encoding:=System.Text.Encoding.Default)
    End Sub
    Private Sub run_server()

        'server_id = Shell("cmd /c .\bin\x64\factorio.exe --start-server " & TextBox_saves.Text & " --server-settings data/fs/fs.json", Style:=AppWinStyle.NormalFocus)
        server_id = Shell("cmd /c.\bin\x64\factorio.exe --start-server " & TextBox_saves.Text & " --server-settings data/facw/fs.json", AppWinStyle.NormalNoFocus)
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        ComboBox_auto_pause.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer_sync_server.Enabled = False
        Try
            AppActivate(server_id)
            Threading.Thread.Sleep(200)
            SendKeys.Send("^C")
            'Threading.Thread.Sleep(100)
            'SendKeys.Send("/save")
            'Threading.Thread.Sleep(100)
            'SendKeys.Send("{ENTER}")

        Catch ex As Exception
            MsgBox（"服务已停止！")
        End Try
        Button_create_server.Text = "创建"
        Button_create_server.Enabled = True
    End Sub


    Private Sub Timer_sync_server_Tick(sender As Object, e As EventArgs) Handles Timer_sync_server.Tick
        '生成serverlist
        'serverlist（0, server_select) 服务器名称
        'serverlist（1, server_select) 服务器介绍
        'serverlist（2, server_select) 服务器最后激活时间
        'serverlist（3, server_select) ip 不显示
        'serverlist（4, server_select) ping
        '确定最新1维下标


        '下载serverlist
        BackgroundWorker_creact_dsl.RunWorkerAsync()

        '变换sl到数组

        '添加自服务器到数组

        '处理sl

        '上传sl




    End Sub


    Private Sub Timer_load_sl_Tick(sender As Object, e As EventArgs) Handles Timer_load_sl.Tick, Button_reload_serverlist.Click
        ListView1.Items.Clear()
        Timer_load_sl.Enabled = False
        Button_reload_serverlist.Enabled = False
        Button_join.Enabled = False
        Button_join.Text = "正在载入服务器列表"
        '载入服务器列表
        '后台开始下载serverlist文件
        'Shell("./data/facw/svn co http://code.taobao.org/svn/yxgcipup/trunk ./data/facw", AppWinStyle.Hide, True, 30000)
        'load_server_list()

        '判断目录正确，调试时关闭
        If My.Computer.FileSystem.FileExists(".\bin\x64\factorio.exe") Then
            BackgroundWorker_download_serverlist.RunWorkerAsync()
        Else
            MsgBox("工厂世界安装的目录不正确，请确认安装到异星工厂的游戏根目录，而不是bin\x64目录下！")
            Me.Close()
        End If

    End Sub

    Private Sub edit_server_list()
        Dim this_server = UBound(serverlist， 2) + 1
        ReDim Preserve serverlist(4, this_server)
        serverlist(0, this_server) = TextBox_server_name.Text
        serverlist(1, this_server) = TextBox_server_intro.Text
        'serverlist(2, this_server) = Format(Now, "MMddHHmm")2017/11/15 19:22:31
        serverlist(2, this_server) = Format(Now, "yyyy/MM/dd HH:mm:ss")
        serverlist(3, this_server) = TextBox_IP.Text





        Dim temp_serverlist(4, 0)


        'IP重复的去时间靠前的
        For i = 0 To UBound(serverlist, 2)
            For y = i + 1 To UBound(serverlist, 2)
                If serverlist(3, i) = serverlist(3, y) Then
                    If DateDiff("n", CDate(serverlist(2, i)), CDate(serverlist(2, y)）） > 0 Then
                        serverlist(2, i) = "2017/01/01 00:00:00"
                    Else
                        serverlist(2, y) = "2017/01/01 00:00:00"
                    End If
                End If

            Next
        Next

        '删除十分钟没有报告的服务器
        For i = 0 To UBound(serverlist, 2)
            If DateDiff("n", CDate(serverlist(2, i)）， Now) > 10 Then
                serverlist(2, i) = "2017/01/01 00:00:00"
            End If

        Next

delete:'删除时间为"2017/01/01 00:00:00"的
        For i = 0 To UBound(serverlist, 2)
            If serverlist（2， i） = "2017/01/01 00:00:00" Then
                If i < UBound(serverlist, 2) Then
                    For y = i To UBound(serverlist, 2） - 1
                        serverlist（0， y） = serverlist（0， y + 1）
                        serverlist（1， y） = serverlist（1， y + 1）
                        serverlist（2， y） = serverlist（2， y + 1）
                        serverlist（3， y） = serverlist（3， y + 1）
                        serverlist（4， y） = serverlist（4， y + 1）
                    Next
                End If
                i = i - 1
                ReDim Preserve serverlist(4, UBound(serverlist, 2) - 1)
                GoTo delete '删除时间为"2017/01/01 00:00:00"的
            End If
        Next


        '按时间排序
        For y = 2 To UBound(serverlist, 2)
            For i = 2 To UBound(serverlist, 2)
                If serverlist(2, i - 1) > serverlist(2, i) Then
                Else
                    For l = 0 To 4
                        temp_serverlist(l, 0) = serverlist(l, i)
                        serverlist(l, i) = serverlist(l, i - 1)
                        serverlist(l, i - 1) = temp_serverlist(l, 0)
                    Next


                End If
            Next
        Next

        '如果超过20个，删除后面的

        If UBound(serverlist, 2) > 30 Then
            ReDim Preserve serverlist(4, 20)
        End If

        Dim serverlist_file_string = ""
        For i = 0 To UBound(serverlist, 2)
            serverlist_file_string = (serverlist_file_string & serverlist(0, i) & vbTab & serverlist(1, i) & vbTab & serverlist(2, i) & vbTab & serverlist(3, i) & vbTab & serverlist(4, i) & vbCrLf)
        Next
        System.IO.File.WriteAllText("./data/facw/sl/sl.txt", serverlist_file_string, encoding:=System.Text.Encoding.Default)


        '上传sl
        Shell("""./data/facw/svn.exe""  cleanup  ./data/facw/sl", AppWinStyle.Hide, True)
        Threading.Thread.Sleep(200)
        Threading.Thread.Sleep(200)
        Shell("""data/facw/svn.exe"" ci ./data/facw/sl -m ""new"" --username ipuppublic --password 1234abcD", AppWinStyle.Hide, True, 30000)
        Threading.Thread.Sleep(200)


    End Sub

    Private Sub Timer_enable_reload_serverlist_Tick(sender As Object, e As EventArgs) Handles Timer_enable_reload_serverlist.Tick
        Dim tishi = "刷新服务器列表 "
        miao = miao - 1
        Button_reload_serverlist.Text = tishi & miao.ToString
        If miao <= 0 Then
            Button_reload_serverlist.Enabled = True
            Timer_enable_reload_serverlist.Enabled = False
            miao = 30
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start("使用说明.txt")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Process.Start("mailto://yjfyy@163.com")
        Process.Start("http://mail.qq.com")
    End Sub

    Private Sub BackgroundWorker_creact_dsl_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker_creact_dsl.DoWork
        Shell("""./data/facw/svn.exe""  cleanup  ./data/facw/sl", AppWinStyle.Hide, True)
        Threading.Thread.Sleep(200)
        Shell("""./data/facw/svn.exe""  co  http://code.taobao.org/svn/yxgcipup/trunk  ./data/facw/sl", AppWinStyle.Hide, True)
        Threading.Thread.Sleep(200)
    End Sub

    Private Sub BackgroundWorker_creact_dsl_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker_creact_dsl.RunWorkerCompleted
        sltoarr()
    End Sub
    Private Sub sltoarr()
        '判断是否有serverlist
        ReDim serverlist(4, 0)
        If My.Computer.FileSystem.FileExists("./data/facw/sl/sl.txt") Then
            Dim i = -1 '临时统计文件有几行.-1为校正数组从0开始
            FileOpen(1, "./data/facw/sl/sl.txt", OpenMode.Input)
            Do While Not EOF(1)
                Dim temp
                temp = LineInput(1)
                i = i + 1
            Loop
            FileClose()
            ' MsgBox(i)

            ReDim serverlist(4, i)
            FileOpen(1, "./data/facw/sl/sl.txt", OpenMode.Input)
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
            If My.Computer.FileSystem.FileExists("./data/facw/sl/sl.txt") Then
                Try
                    My.Computer.FileSystem.DeleteFile("./data/facw/sl/sl.txt")
                Catch ex As Exception
                End Try
            End If
        End If
        edit_server_list()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer_Thank_list_Tick(sender As Object, e As EventArgs) Handles Timer_Thank_list.Tick
        'Dim old_x = Label_thank_list.Location.X
        Label_thank_list.Location = New Point(Label_thank_list.Location.X - 5, Label_thank_list.Location.Y)
        If Label_thank_list.Size.Width + Label_thank_list.Location.X < 0 Then
            Label_thank_list.Location = New Point(Me.Size.Width, Label_thank_list.Location.Y)

        End If

    End Sub


End Class