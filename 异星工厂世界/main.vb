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

        '判断目录正确，调试时关闭
        If My.Computer.FileSystem.FileExists(".\bin\x64\factorio.exe") Then

        Else
            MsgBox("工厂世界安装的目录不正确，请确认安装到异星工厂的游戏根目录，而不是bin\x64目录下！")
            Me.Close()
        End If

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

            '载入完成,控件变为可用
            Button_select_server.Enabled = True
            Button_run_game.Enabled = True

            Button_readme.Enabled = True
            Button_updata.Enabled = True

            CheckBox_chinese_chat.Enabled = True
            TextBox_game_ver.Enabled = True

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


    Private Sub Button_join_Click(sender As Object, e As EventArgs) Handles Button_run_game.Click
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
            'MsgBox(Environ("SYSTEMROOT"))
            Dim sr = New StreamReader(Environ("SYSTEMROOT") & "\System32\drivers\etc\hosts", encoding:=System.Text.Encoding.Default)

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
        System.IO.File.WriteAllText(Environ("SYSTEMROOT") & "\System32\drivers\etc\hosts", hosts_file_string, encoding:=System.Text.Encoding.Default)
        Threading.Thread.Sleep(200)
    End Sub
    Private Sub edit_player_data_json()
        Dim player_data_file(0)
        Dim player_data_file_hang = -1     '临时统计文件有几行.-1为校正数组从0开始

        If My.Computer.FileSystem.FileExists(Environ("AppData") & "\Factorio\player-data.json") Then
            Try
                Dim sr = New StreamReader(Environ("AppData") & "\Factorio\player-data.json")

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
            Try
                System.IO.File.WriteAllText(Environ("AppData") & "\Factorio\player-data.json", hosts_file_string, encoding:=System.Text.Encoding.Default)
            Catch ex As Exception

            End Try

            Threading.Thread.Sleep(500)

        End If

        If My.Computer.FileSystem.FileExists("player-data.json") Then
            ReDim player_data_file(0)
            player_data_file_hang = -1
            Try
                Dim sr = New StreamReader("player-data.json")

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
            Try
                System.IO.File.WriteAllText("player-data.json", hosts_file_string, encoding:=System.Text.Encoding.Default)
            Catch ex As Exception

            End Try

            Threading.Thread.Sleep(500)
        End If

    End Sub

    Private Sub Button_refresh_serverlist_Click(sender As Object, e As EventArgs)
        Button_run_game.Text = "正在载入服务器列表"
        Button_run_game.Enabled = False

        BackgroundWorker_download_serverlist.RunWorkerAsync()
    End Sub

    Private Sub delete_files()
        '删除旧版vbs文件
        'If My.Computer.FileSystem.FileExists("chat.vbs") Then
        '    Try
        '        My.Computer.FileSystem.DeleteFile("chat.vbs")
        '    Catch ex As Exception

        '    End Try
        'End If

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

        'If My.Computer.FileSystem.FileExists("./data/facw/sl/sl.txt") Then
        '    Try
        '        My.Computer.FileSystem.DeleteFile("./data/facw/sl/sl.txt")
        '    Catch ex As Exception

        '    End Try
        'End If

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



    Private Sub Timer_load_sl_Tick(sender As Object, e As EventArgs) Handles Timer_load_sl.Tick, Button_reload_serverlist.Click
        '清空列表
        ListView1.Items.Clear()

        '界面全部禁用
        Timer_load_sl.Enabled = False

        Button_select_server.Enabled = False
        Button_run_game.Enabled = False
        Button_reload_serverlist.Enabled = False
        Button_reload_serverlist.Text = "正在刷新,请稍后"
        Button_readme.Enabled = False
        Button_updata.Enabled = False

        CheckBox_chinese_chat.Enabled = False
        TextBox_game_ver.Enabled = False

        '载入服务器列表
        '后台开始下载serverlist文件
        'Shell("./data/facw/svn co http://code.taobao.org/svn/yxgcipup/trunk ./data/facw", AppWinStyle.Hide, True, 30000)
        'load_server_list()

        BackgroundWorker_download_serverlist.RunWorkerAsync()
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
            Me.Button_run_game.Text = "下载失败!"
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



    Private Sub Timer_enable_reload_serverlist_Tick(sender As Object, e As EventArgs) Handles Timer_enable_reload_serverlist.Tick
        Dim tishi = "刷新服务器列表 "
        miao = miao - 1
        Button_reload_serverlist.Text = tishi & miao.ToString
        If miao <= 0 Then
            Button_reload_serverlist.Enabled = True
            Button_reload_serverlist.Text = tishi
            Timer_enable_reload_serverlist.Enabled = False
            miao = 30
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button_readme.Click
        Process.Start("使用说明.txt")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Process.Start("mailto://yjfyy@163.com")
        Process.Start("http://mail.qq.com")
    End Sub



    Private Sub Button_select_server_Click(sender As Object, e As EventArgs) Handles Button_select_server.Click
        server_select = ListView1.FocusedItem.Index
        '修改host文件
        edit_hosts()
    End Sub

    Private Sub Button_test_mode_Click(sender As Object, e As EventArgs) Handles Button_test_mode.Click
        If TextBox_test_mode_pass.Text = "bohui" Then
            LinkLabel_game_download_url.Visible = True
        End If
    End Sub

    Private Sub LinkLabel_game_download_url_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_game_download_url.LinkClicked
        Process.Start("https://pan.baidu.com/s/1sk95K5Z")
    End Sub
End Class