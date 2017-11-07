Imports System.IO

Public Class Form_main
    Public upsrc = "http://code.taobao.org/svn/yxgcsj/trunk/serverlist/"
    Dim item(0) As String
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

        '删除旧列表
        If My.Computer.FileSystem.FileExists("serverlist.txt") Then
            Try
                My.Computer.FileSystem.DeleteFile("serverlist.txt")
            Catch ex As Exception

            End Try
        End If
        Dim dFile As New System.Net.WebClient

        '下载新列表
        'Try
        '    Dim myUri As New Uri(upsrc + "serverlist.txt")
        '    dFile.DownloadFile(myUri, "serverlist.txt")

        'Catch ex As Exception
        '    MsgBox("服务器列表下载失败！")
        '    Exit Sub
        'End Try

        '处理列表

        'Dim i = 0
        'FileOpen(1, "serverlist.txt", OpenMode.Input)
        'Do While Not EOF(1)
        '    item(i) = LineInput(1)
        '    MsgBox(item(i))
        '    i = i + 1
        '    ReDim Preserve item(i)
        'Loop
        'FileClose()

        'ListView1.Items.Add(item(0))
        'ListView1.Items(0).SubItems.Add(item(1))
        'ListView1.Items(0).SubItems.Add(item(2))
        'ListView1.Items(0).SubItems.Add(item(3))
        'ListView1.Items（0）.ForeColor = Color.Red




    End Sub

    Private Sub Form_main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        load_server_list()
        Button_join.Text = "进入"
    End Sub

    Private Sub Button_join_Click(sender As Object, e As EventArgs) Handles Button_join.Click
        Try
            Shell(".\bin\x64\factorio.exe", Style:=AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox("没找到异星工厂的可执行文件，请把本程序放进异星工厂游戏根目录，例如：D: \Factorio_0.15.37")
        End Try

    End Sub

    Private Sub Button_updata_Click(sender As Object, e As EventArgs) Handles Button_updata.Click
        form_updata.Show()
    End Sub
End Class