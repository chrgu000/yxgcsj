Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class Form_main
    'Public upsrc = "http://code.taobao.org/svn/yxgcsj/trunk/updatafiles/"
    Public up_root = "https://raw.githubusercontent.com/yjfyy/yxgcsj/master/%E6%9B%B4%E6%96%B0%E7%B3%BB%E7%BB%9F/trunk/serverlist/"
    Public r_version = "0"
    Public l_version = "0"
    Dim server_select = 0

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

End Class