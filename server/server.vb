Imports System.ComponentModel
Imports System.IO

Public Class server


    '声明INI配置文件读写API函数,lpApplicationName节名称， lpKeyName键名称，lpString是键值
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    '定义读取配置文件函数
    Public Function GetINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String
        Dim Str As String = LSet(Str, 256)
        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)
        Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)
    End Function
    '定义写入配置文件函数
    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long
        WriteINI = WritePrivateProfileString(Section, AppName, lpDefault, FileName)
    End Function


    '十分钟上传一次,18分钟无消息删除.
    Dim server_id
    'serverlist数组 x0为服务器名称，x1为介绍，x2时间,x3 ip x4 端口 x5 游戏版本,x6 是否使用mods
    Public serverlist(6, 0)
    Public modsconfig(1, 0)
    Public mods_config_up_string = ""
    Private Sub Button_create_server_Click(sender As Object, e As EventArgs) Handles Button_create_server.Click

        If TextBox_server_intro.Text = "" Or TextBox_server_name.Text = "" Or TextBox_IP.Text = "" Or TextBox_game_ver.Text = "" Then
            MsgBox("请输入服务器IP、名称、介绍、游戏版本")
            Exit Sub
        End If
        If CheckBox_user_game_password.Checked = True And TextBox_game_password.Text = "" Then
            MsgBox("请输入游戏密码或取消使用密码")
            Exit Sub
        End If
        Button_create_server.Text = "正在创建"
        Button_create_server.Enabled = False


        Label1_status.Text = Now.ToString & "正在生成服务器配置文件"
        '创建server-settings.example.json。
        create_server_settings()

        'Label1_status.Text = "正在生成模组配置文件"
        '创建模组配置文件。
        'create_mods_config()

        Label1_status.Text = Now.ToString & "正在启动异星工厂服务"
        '执行服务器启动命令。
        run_server()

        Button_create_server.Text = "正在运行"

        '开始同步serverlist。
        Label1_status.Text = Now.ToString & "正在同步服务器列表"
        Timer_sync_server_Tick(sender, e)
        Timer_sync_server.Enabled = True

        '方便调试
        'edit_server_list()
    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog_open_save_zip.InitialDirectory = Application.StartupPath & "\saves\"
        OpenFileDialog_open_save_zip.ShowDialog()
        TextBox_source_save.Text = OpenFileDialog_open_save_zip.FileName
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(".\data\facw\sl") Then
            Try
                Shell("cmd  /c rd /s /q data\facw\sl", AppWinStyle.MaximizedFocus, True)
                'System.IO.Directory.Delete(".\data\face\sl", True)

                'MsgBox("清理完成！")
            Catch ex As Exception
                MsgBox("清理失败，请重试！")
                MsgBox(ex.ToString)
            End Try
        Else
            'MsgBox("无需清理！")
        End If
        load_ini()
        'If My.Computer.FileSystem.FileExists(".\bin\x64\factorio.exe") Then
        '    If My.Computer.FileSystem.DirectoryExists(".\my") = False Then
        '        My.Computer.FileSystem.CreateDirectory("my")
        '    End If
        'Else
        '    MsgBox("工厂世界安装的目录不正确，请确认安装到异星工厂的游戏根目录，而不是bin\x64目录下！")
        '    Me.Close()
        'End If

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            System.IO.File.WriteAllText("config-path.cfg", TextBox_config_path_cfg.Text, encoding:=System.Text.Encoding.Default)
            MsgBox（"修改成功"）
        Catch ex As Exception
            MsgBox（"未能修改")
        End Try
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

        If CheckBox_pppoe.Checked = True Then
            Button_check_ip_Click(sender, e)
        Else

        End If


        '生成serverlist
        'serverlist（0, server_select) 服务器名称
        'serverlist（1, server_select) 服务器介绍
        'serverlist（2, server_select) 服务器最后激活时间
        'serverlist（3, server_select) ip 不显示
        'serverlist（4, server_select) x4 端口 x5 游戏版本,x6 是否使用mods
        '确定最新1维下标
        '结束svn进程
        Dim i As Integer
        Dim proc As Process()




        Label1_status.Text = Now.ToString & "正在清理同步进程"
        '判断excel进程是否存在
        If System.Diagnostics.Process.GetProcessesByName("svn").Length > 0 Then
            proc = Process.GetProcessesByName("svn")
            '得到名为excel进程个数，全部关闭
            For i = 0 To proc.Length - 1
                proc(i).Kill()
            Next
        End If
        proc = Nothing

        '下载serverlist
        Label1_status.Text = Now.ToString & "开始下载服务器列表"
        BackgroundWorker_creact_dsl.RunWorkerAsync()

        '变换sl到数组

        '添加自服务器到数组

        '处理sl

        '上传sl



    End Sub

    Private Sub create_server_settings()
        Dim server_settings(62)
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

        If CheckBox_user_game_password.Checked = True Then
            server_settings(23) = "  ""game_password"": """ & TextBox_game_password.Text & ""","
        Else
            server_settings(23) = "  ""game_password"": """","
        End If
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
        server_settings(46) = "  ""_comment_afk_autokick_interval"": ""How many minutes until someone is kicked when doing nothing, 0 for never."","
        server_settings(47) = "  ""afk_autokick_interval"": " & TextBox_afk_autokick_interval.Text & ","
        server_settings(48) = ""
        server_settings(49) = "  ""_comment_auto_pause"": ""Whether should the server be paused when no players are present."","
        If CheckBox_auto_pause.Checked Then
            server_settings(50) = "  ""auto_pause"": true,"
        Else
            server_settings(50) = "  ""auto_pause"": false,"
        End If
        server_settings(51) = ""
        server_settings(52) = "  ""only_admins_can_pause_the_game"": true,"
        server_settings(53) = ""
        server_settings(54) = "  ""_comment_autosave_only_on_server"": ""Whether autosaves should be saved only on server or also on all connected clients. Default is true."","
        server_settings(55) = "  ""autosave_only_on_server"": true,"
        server_settings(56) = ""
        server_settings(57) = "  ""_comment_non_blocking_saving"": ""Highly experimental feature, enable only at your own risk of losing your saves. On UNIX systems, server will fork itself to create an autosave. Autosaving on connected Windows clients will be disabled regardless of autosave_only_on_server option."","
        server_settings(58) = "  ""non_blocking_saving"": false,"
        server_settings(59) = ""
        server_settings(60) = "  ""_comment_admins"": ""List of case insensitive usernames, that will be promoted immediately"","
        server_settings(61) = "  ""admins"": []"
        server_settings(62) = "}"

        Dim server_settings_file_string = ""
        For i = 0 To UBound(server_settings)
            server_settings_file_string = (server_settings_file_string & server_settings(i) & vbCrLf)
        Next
        Directory.CreateDirectory("data/facw")
        System.IO.File.WriteAllText("data/facw/fs.json", server_settings_file_string, encoding:=System.Text.Encoding.Default)
    End Sub

    Private Sub run_server()

        'server_id = Shell("cmd /c .\bin\x64\factorio.exe --start-server " & TextBox_saves.Text & " --server-settings data/fs/fs.json", Style:=AppWinStyle.NormalFocus)
        server_id = Shell("cmd /c .\bin\x64\factorio.exe --start-server " & TextBox_saves.Text & " --server-settings data/facw/fs.json", AppWinStyle.NormalNoFocus)
    End Sub

    Private Sub BackgroundWorker_creact_dsl_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_creact_dsl.DoWork
        'Label1_status.Text = "正在删除旧服务器列表"
        If My.Computer.FileSystem.DirectoryExists(".\data\facw\sl") Then
            Try
                'Shell("cmd  /c rd /s /q data\facw\sl", AppWinStyle.MaximizedFocus, True)
                System.IO.Directory.Delete("data\face\sl", True)
                'MsgBox("清理完成！")
            Catch ex As Exception
                'MsgBox("清理失败，请重试！")
            End Try
        Else
            'MsgBox("无需清理！")
        End If


        'Shell("""./data/facw/svn.exe""  cleanup  ./data/facw/sl", AppWinStyle.Hide, True)
        'Label1_status.Text = "正在下载服务器列表"
        Threading.Thread.Sleep(200)
        'Shell("""./data/facw/svn.exe""  co  http://code.taobao.org/svn/yxgcip/trunk  ./data/facw/sl", AppWinStyle.Hide, True)
        Shell("""./data/facw/svn.exe""  co  svn://gitee.com/ipup/yxgcip  ./data/facw/sl --username ipuppublic --password 1234abcD", AppWinStyle.Hide, True)
        Threading.Thread.Sleep(200)
    End Sub

    Private Sub edit_server_list()
        Dim this_server = UBound(serverlist， 2) + 1
        ReDim Preserve serverlist(6, this_server)
        serverlist(0, this_server) = TextBox_server_name.Text
        serverlist(1, this_server) = TextBox_server_intro.Text
        'serverlist(2, this_server) = Format(Now, "MMddHHmm")2017/11/15 19:22:31
        serverlist(2, this_server) = Format(Now, "yyyy-MM-dd HH:mm:ss")
        serverlist(3, this_server) = TextBox_IP.Text
        serverlist(4, this_server) = TextBox_port.Text
        serverlist(5, this_server) = TextBox_game_ver.Text

        If CheckBox_user_mods.Checked Then
            serverlist(6, this_server) = "1"
        Else
            serverlist(6, this_server) = "0"
        End If

        Dim temp_serverlist(4, 0)


        'IP重复的去时间靠前的
        For i = 0 To UBound(serverlist, 2)
            For y = i + 1 To UBound(serverlist, 2)
                If (serverlist(3, i) = serverlist(3, y)) And (serverlist(4, i) = serverlist(4, y)) Then
                    If DateDiff("n", CDate(serverlist(2, i)), CDate(serverlist(2, y)）） > 0 Then
                        serverlist(2, i) = "2017-01-01 00:00:00"
                    Else
                        serverlist(2, y) = "2017-01-01 00:00:00"
                    End If
                End If

            Next
        Next

        '删除18分钟没有报告的服务器
        For i = 0 To UBound(serverlist, 2)
            If DateDiff("n", CDate(serverlist(2, i)）， Now) > 18 Then
                serverlist(2, i) = "2017-01-01 00:00:00"
            End If

        Next

delete:'删除时间为"2017/01/01 00:00:00"的
        For i = 0 To UBound(serverlist, 2)
            If serverlist（2， i） = "2017-01-01 00:00:00" Then
                If i < UBound(serverlist, 2) Then
                    For y = i To UBound(serverlist, 2） - 1
                        serverlist（0， y） = serverlist（0， y + 1）
                        serverlist（1， y） = serverlist（1， y + 1）
                        serverlist（2， y） = serverlist（2， y + 1）
                        serverlist（3， y） = serverlist（3， y + 1）
                        serverlist（4， y） = serverlist（4， y + 1）
                        serverlist（5， y） = serverlist（5， y + 1）
                        serverlist（6， y） = serverlist（6， y + 1）
                    Next
                End If
                i = i - 1
                ReDim Preserve serverlist(6, UBound(serverlist, 2) - 1)
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
            serverlist_file_string = (serverlist_file_string & serverlist(0, i) & vbTab & serverlist(1, i) & vbTab & serverlist(2, i) & vbTab & serverlist(3, i) & vbTab & serverlist(4, i) & vbTab & serverlist(5, i) & vbTab & serverlist(6, i) & vbCrLf)
        Next
        System.IO.File.WriteAllText("./data/facw/sl/sl.txt", serverlist_file_string, encoding:=System.Text.Encoding.UTF8)
        Threading.Thread.Sleep(500)


        '        '处理mc.txt文件
        '        Dim mods_this_server = UBound(modsconfig, 2) + 1
        '        ReDim Preserve modsconfig(1, this_server)
        '        modsconfig(0, mods_this_server) = TextBox_IP.Text & ":" & TextBox_port.Text
        '        '生成mods_配置字符串.
        '        Create_mods_confg_string()
        '        modsconfig(1, mods_this_server) = mods_config_up_string

        '        Dim temp_modsconfg(1, 0)


        '        'IP重复删除
        '        For i = 0 To UBound(modsconfig, 2)
        '            For y = i + 1 To UBound(modsconfig, 2)
        '                If modsconfig(0, i) = modsconfig(0, y) Then
        '                    modsconfig(0, i) = "0.0.0.0"

        '                End If

        '            Next
        '        Next


        'deletemod:'删除ip=0.0.0.0的
        '        For i = 0 To UBound(modsconfig, 2)
        '            If modsconfig（0， i） = "0.0.0.0" Then
        '                If i < UBound(modsconfig, 2) Then
        '                    For y = i To UBound(modsconfig, 2） - 1
        '                        modsconfig（0， y） = modsconfig（0， y + 1）
        '                        modsconfig（1， y） = modsconfig（1， y + 1）
        '                    Next
        '                End If
        '                i = i - 1
        '                ReDim Preserve modsconfig(1, UBound(modsconfig, 2) - 1)
        '                GoTo deletemod '删除ip=0.0.0.0的
        '            End If
        '        Next

        '        Dim mc_file_string = ""
        '        For i = 0 To UBound(modsconfig, 2)
        '            mc_file_string = (mc_file_string & modsconfig(0, i) & vbTab & modsconfig(1, i) & vbCrLf)
        '        Next
        '        System.IO.File.WriteAllText("./data/facw/sl/mc.txt", mc_file_string, encoding:=System.Text.Encoding.Default)
        '        Threading.Thread.Sleep(500)


        Label1_status.Text = Now.ToString & "生成新服务器列表完毕"
        '上传sl
        Label1_status.Text = Now.ToString & "开始上传新服务器列表"
        Shell("""./data/facw/svn.exe""  cleanup  ./data/facw/sl", AppWinStyle.Hide, True)
        Threading.Thread.Sleep(500)
        Shell("""data/facw/svn.exe"" ci ./data/facw/sl -m ""new"" --username ipuppublic --password 1234abcD", AppWinStyle.Hide, True)
        Threading.Thread.Sleep(200)
        Label1_status.Text = Now.ToString & "上传服务器列表完毕"
    End Sub

    Private Sub sltoarr()
        Label1_status.Text = Now.ToString & "正在生成新服务器列表"

        'sl文件转到数组.
        '判断是否有serverlist
        ReDim serverlist(6, 0)
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

            ReDim serverlist(6, i)
            Dim fileReader = My.Computer.FileSystem.OpenTextFileReader("./data/facw/sl/sl.txt", encoding:=System.Text.Encoding.UTF8)
            'FileOpen(1, "./data/facw/sl/sl.txt", OpenMode.Input)
            Dim temp2 As String

            Do While fileReader.Peek() >= 0
                For l = 0 To i
                    temp2 = fileReader.ReadLine()
                    'temp2 = LineInput(1)
                    Dim arr As String() = temp2.Split(vbTab) '放入arr数组
                    For h As Integer = 0 To 6
                        serverlist(h, l) = arr(h)
                        'MsgBox(serverlist(h, l))
                    Next
                    'If serverlist(6, l) = "0" Then
                    '    serverlist(6, l) = "否"
                    'Else
                    '    serverlist(6, l) = "是"
                    'End If
                Next
            Loop
            fileReader.Close()

            'Do While Not EOF(1)
            '    For l = 0 To i
            '        temp2 = LineInput(1)
            '        Dim arr As String() = temp2.Split(vbTab) '放入arr数组
            '        For h As Integer = 0 To 4
            '            serverlist(h, l) = arr(h)
            '            'MsgBox(serverlist(h, l))
            '        Next
            '    Next
            '    i = i + 1
            'Loop
            'FileClose()
            'i = i - 1 '校正最后一次循环
            '处理完毕
            '删除serverlist.txt文件
            'If My.Computer.FileSystem.FileExists("./data/facw/sl/sl.txt") Then
            '    Try
            '        My.Computer.FileSystem.DeleteFile("./data/facw/sl/sl.txt")
            '    Catch ex As Exception
            '    End Try
            'End If
        End If

        'mods_config_files 转到数组

        ReDim modsconfig(1, 0)
        If My.Computer.FileSystem.FileExists("./data/facw/sl/mc.txt") Then
            Dim i = -1 '临时统计文件有几行.-1为校正数组从0开始
            FileOpen(1, "./data/facw/sl/mc.txt", OpenMode.Input)
            Do While Not EOF(1)
                Dim temp
                temp = LineInput(1)
                i = i + 1
            Loop
            FileClose()
            ' MsgBox(i)

            ReDim modsconfig(1, i)
            FileOpen(1, "./data/facw/sl/mc.txt", OpenMode.Input)
            Dim temp2
            Do While Not EOF(1)
                For l = 0 To i
                    temp2 = LineInput(1)
                    Dim arr As String() = temp2.Split(vbTab) '放入arr数组
                    For h As Integer = 0 To 1
                        modsconfig(h, l) = arr(h)
                        'MsgBox(modsconfig(h, l))
                    Next
                Next
                i = i + 1
            Loop
            FileClose()
            i = i - 1 '校正最后一次循环
            '处理完毕
            '删除serverlist.txt文件
            'If My.Computer.FileSystem.FileExists("./data/facw/sl/sl.txt") Then
            '    Try
            '        My.Computer.FileSystem.DeleteFile("./data/facw/sl/sl.txt")
            '    Catch ex As Exception
            '    End Try
            'End If
        End If


        edit_server_list()


    End Sub

    Private Sub BackgroundWorker_creact_dsl_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker_creact_dsl.RunWorkerCompleted
        Label1_status.Text = Now.ToString & "开始生成新服务器列表"
        sltoarr()
    End Sub

    'new------------------------------------------

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            System.IO.File.WriteAllText("config-path.cfg", TextBox_config_path_cfg.Text, encoding:=System.Text.Encoding.Default)
            MsgBox（"修改成功"）
        Catch ex As Exception
            MsgBox（"未能修改")
        End Try


    End Sub





    Private Sub Button_copy_save_Click(sender As Object, e As EventArgs) Handles Button_copy_save.Click
        Dim fugai As DialogResult
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & TextBox_saves.Text) Then
            fugai = MessageBox.Show(Application.StartupPath & "\" & TextBox_saves.Text & "文件已存在是否覆盖?", "文件已存在", MessageBoxButtons.OKCancel)
        End If

        If fugai = DialogResult.Cancel Then

        Else
            Try
                FileIO.FileSystem.CopyFile(TextBox_source_save.Text, TextBox_saves.Text, True)
            Catch ex As Exception
                MsgBox("复制失败")
                Exit Sub
            End Try
            MsgBox("复制成功")
        End If

    End Sub



    Private Sub Button_readme_Click(sender As Object, e As EventArgs) Handles Button_readme.Click
        Process.Start("使用说明服务端.txt")
    End Sub

    Private Sub CheckBox_user_game_password_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_user_game_password.CheckedChanged
        If CheckBox_user_game_password.Checked = True Then
            TextBox_game_password.Enabled = True
        Else
            TextBox_game_password.Text = ""
            TextBox_game_password.Enabled = False
        End If
    End Sub



    Private Sub CheckBox_custom_port_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_custom_port.CheckedChanged
        If CheckBox_custom_port.Checked Then
            TextBox_port.Enabled = True
        Else
            TextBox_port.Enabled = False
            TextBox_port.Text = "34197"
        End If
    End Sub


    Private Sub Create_mods_confg_string()
        Dim mods_config_file(0)
        Dim mods_config_file_hang = -1     '临时统计文件有几行.-1为校正数组从0开始
        mods_config_up_string = ""
        If My.Computer.FileSystem.FileExists(Environ("AppData") & "\Factorio\mods\mod-list.json") Then
            Try
                Dim sr = New StreamReader(Environ("AppData") & "\Factorio\mods\mod-list.json")

                Do
                    mods_config_file_hang = mods_config_file_hang + 1
                    ReDim Preserve mods_config_file(mods_config_file_hang)
                    mods_config_file(mods_config_file_hang) = sr.ReadLine()
                Loop Until mods_config_file(mods_config_file_hang) Is Nothing
                sr.Close()

                Dim mods_name = 7 '第一个mod所在行数
                For i = 7 To UBound(mods_config_file)
                    If mods_config_file(i) <> "}" And mods_config_file(i + 1) = "      ""enabled"": true" Then

                        If mods_config_up_string = "" Then
                            mods_config_up_string = Mid(mods_config_file(i), 16)
                        Else
                            mods_config_up_string = mods_config_up_string & Mid(mods_config_file(i), 16)
                        End If

                        ' MsgBox(mods_config_up_string)
                        i = i + 3
                    End If

                Next

            Catch ex As Exception
                ' MsgBox("错误编号2")

            End Try


            'Try
            '    System.IO.File.WriteAllText("./data/facw/sl/" & TextBox_IP.Text & "_" & TextBox_port.Text & "mods_config.txt", mods_config_up_string, encoding:=System.Text.Encoding.Default)
            'Catch ex As Exception

            'End Try

            'Threading.Thread.Sleep(500)

        End If

        '    If My.Computer.FileSystem.FileExists("player-data.json") Then
        '        ReDim mods_config_file(0)
        '        mods_config_file_hang = -1
        '        Try
        '            Dim sr = New StreamReader("player-data.json")

        '            Do
        '                mods_config_file_hang = mods_config_file_hang + 1
        '                ReDim Preserve mods_config_file(mods_config_file_hang)
        '                mods_config_file(mods_config_file_hang) = sr.ReadLine()

        '            Loop Until mods_config_file(mods_config_file_hang) Is Nothing
        '            sr.Close()



        '            'For i = 0 To UBound(mods_config_file)
        '            '    If InStr(mods_config_file（i）, "service-username"） > 0 Then
        '            '        su = i
        '            '    End If
        '            'Next
        '            'If su > 0 Then
        '            '    Dim temp
        '            '    temp = Split(mods_config_file(su), """")
        '            '    temp(3) = 'temp(3)=原来的用户名


        '            'Else
        '            '    err = 1
        '            '    MsgBox（“错误编号 1”）
        '            '    Exit Sub
        '            'End If


        '            Dim lmc = 0 'latest-multiplayer-connections所在行数
        '            For i = 0 To UBound(mods_config_file)
        '                If InStr(mods_config_file（i）, "latest-multiplayer-connections"） > 0 Then
        '                    lmc = i
        '                End If
        '            Next
        '            If lmc > 0 Then
        '                mods_config_file(lmc + 2) = "      ""address"": ""工厂世界"""
        '            Else
        '                '如果没有，找 service-username所在行，顺延5
        '                '
        '                Dim su 'service-usernames所在行
        '                For i = 0 To UBound(mods_config_file)
        '                    If InStr(mods_config_file（i）, "service-username"） > 0 Then
        '                        su = i
        '                    End If
        '                Next
        '                If su > 0 Then

        '                    Dim org_hang = UBound(mods_config_file) '原来的行数
        '                    ReDim Preserve mods_config_file(org_hang + 5)

        '                    For y = org_hang To su Step -1
        '                        mods_config_file(y + 5) = mods_config_file(y)
        '                    Next
        '                    mods_config_file(su) = "  ""latest-multiplayer-connections"": ["
        '                    mods_config_file(su + 1) = "    {"
        '                    mods_config_file(su + 2) = "      ""address"": ""工厂世界"""
        '                    mods_config_file(su + 3) = "    }"
        '                    mods_config_file(su + 4) = "  ],"
        '                Else
        '                    'service-username也找不到，报错
        '                    err = 1
        '                    ' MsgBox（“错误编号 1”）
        '                    Exit Sub
        '                End If

        '            End If

        '        Catch ex As Exception
        '            'MsgBox("错误编号1")
        '            err = 1
        '        End Try

        '        Dim hosts_file_string = ""
        '        For i = 0 To UBound(mods_config_file)
        '            hosts_file_string = (hosts_file_string & mods_config_file(i) & vbCrLf)
        '        Next
        '        Try
        '            System.IO.File.WriteAllText("player-data.json", hosts_file_string, encoding:=System.Text.Encoding.Default)
        '        Catch ex As Exception

        '        End Try

        '        Threading.Thread.Sleep(500)
        '    End If
    End Sub

    Sub load_ini()
        TextBox_IP.Text = GetINI("server", "ip", "", ".\工厂世界.ini")
        TextBox_port.Text = GetINI("server", "port", "34197", ".\工厂世界.ini")
        TextBox_source_save.Text = GetINI("server", "source_save", "", ".\工厂世界.ini")
        TextBox_saves.Text = GetINI("server", "save", "my\my.zip", ".\工厂世界.ini")
        TextBox_server_name.Text = GetINI("server", "server_name", "", ".\工厂世界.ini")
        TextBox_server_intro.Text = GetINI("server", "server_intro", "", ".\工厂世界.ini")
        TextBox_game_password.Text = GetINI("server", "game_password", "", ".\工厂世界.ini")
        TextBox_afk_autokick_interval.Text = GetINI("server", "afk_autokick_interval", "0", ".\工厂世界.ini")
        TextBox_max_players.Text = GetINI("server", "max_players", "0", ".\工厂世界.ini")
        TextBox_autosave_interval.Text = GetINI("server", "autosave_interval", "60", ".\工厂世界.ini")
        TextBox_autosave_slots.Text = GetINI("server", "autosave_slots", "20", ".\工厂世界.ini")
        TextBox_game_ver.Text = GetINI("server", "game_ver", "0.16.37", ".\工厂世界.ini")

        If GetINI("server", "auto_pause", "0", ".\工厂世界.ini") = "0" Then
            CheckBox_auto_pause.Checked = False
        Else
            CheckBox_auto_pause.Checked = True
        End If

        If GetINI("server", "custom_port", "0", ".\工厂世界.ini") = "0" Then
            CheckBox_custom_port.Checked = False
        Else
            CheckBox_custom_port.Checked = True
        End If

        If GetINI("server", "pppoe", "0", ".\工厂世界.ini") = "0" Then
            CheckBox_pppoe.Checked = False
        Else
            CheckBox_pppoe.Checked = True
        End If

        If GetINI("server", "user_game_password", "0", ".\工厂世界.ini") = "0" Then
            CheckBox_user_game_password.Checked = False
        Else
            CheckBox_user_game_password.Checked = True
        End If

        If GetINI("server", "user_mods", "0", ".\工厂世界.ini") = "0" Then
            CheckBox_user_mods.Checked = False
        Else
            CheckBox_user_mods.Checked = True
        End If

    End Sub
    Sub save_ini()
        WriteINI("server", "ip", TextBox_IP.Text, ".\工厂世界.ini")
        WriteINI("server", "port", TextBox_port.Text, ".\工厂世界.ini")
        WriteINI("server", "source_save", TextBox_source_save.Text, ".\工厂世界.ini")
        WriteINI("server", "save", TextBox_saves.Text, ".\工厂世界.ini")
        WriteINI("server", "server_name", TextBox_server_name.Text, ".\工厂世界.ini")
        WriteINI("server", "server_intro", TextBox_server_intro.Text, ".\工厂世界.ini")
        WriteINI("server", "game_password", TextBox_game_password.Text, ".\工厂世界.ini")
        WriteINI("server", "afk_autokick_interval", TextBox_afk_autokick_interval.Text, ".\工厂世界.ini")
        WriteINI("server", "max_players", TextBox_max_players.Text, ".\工厂世界.ini")
        WriteINI("server", "autosave_interval", TextBox_autosave_interval.Text, ".\工厂世界.ini")
        WriteINI("server", "autosave_slots", TextBox_autosave_slots.Text, ".\工厂世界.ini")
        WriteINI("server", "game_ver", TextBox_game_ver.Text, ".\工厂世界.ini")


        If CheckBox_auto_pause.Checked = False Then
            WriteINI("server", "auto_pause", "0", ".\工厂世界.ini")
        Else
            WriteINI("server", "auto_pause", "1", ".\工厂世界.ini")
        End If

        If CheckBox_custom_port.Checked = False Then
            WriteINI("server", "custom_port", "0", ".\工厂世界.ini")
        Else
            WriteINI("server", "custom_port", "1", ".\工厂世界.ini")
        End If

        If CheckBox_pppoe.Checked = False Then
            WriteINI("server", "pppoe", "0", ".\工厂世界.ini")
        Else
            WriteINI("server", "pppoe", "1", ".\工厂世界.ini")
        End If

        If CheckBox_user_game_password.Checked = False Then
            WriteINI("server", "user_game_password", "0", ".\工厂世界.ini")
        Else
            WriteINI("server", "user_game_password", "1", ".\工厂世界.ini")
        End If

        If CheckBox_user_mods.Checked = False Then
            WriteINI("server", "user_mods", "0", ".\工厂世界.ini")
        Else
            WriteINI("server", "user_mods", "1", ".\工厂世界.ini")
        End If

        'WriteINI("Language", "Language", "CHV", ".\conquer.ini")

    End Sub

    Private Sub server_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        save_ini()
        If My.Computer.FileSystem.DirectoryExists(".\data\facw\sl") Then
            Try
                'Shell("cmd  /c rd /s /q data\facw\sl", AppWinStyle.MaximizedFocus, True)
                System.IO.Directory.Delete("data\face\sl", True)
                'MsgBox("清理完成！")
            Catch ex As Exception
                'MsgBox("清理失败，请重试！")
            End Try
        Else
            'MsgBox("无需清理！")
        End If
    End Sub

End Class