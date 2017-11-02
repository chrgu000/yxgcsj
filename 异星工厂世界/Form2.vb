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


    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HOTKEY Then
            Form_chat.Show()
            'Dim a
            'a = InputBox("发送消息",,, 20, 800)
            'Shell("cmd.exe /c ""d:\a.vbs""", vbHide)
            Try
                'Clipboard.SetText(a)

                'Clipboard.Clear()
            Catch ex As Exception

            End Try
            'MsgBox("在这里添加你要执行的代码", MsgBoxStyle.Information, "全局热键")
        End If
        MyBase.WndProc(m)
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '载入服务器列表



        '注册聊天热键
        RegisterHotKey(Handle, 0, MOD_CONTROL, 192)
        Dim chat_vbs
        chat_vbs = TextBox_chat_vbs.Text
        Try
            System.IO.File.WriteAllText("chat.vbs", chat_vbs)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '调用修改player-data.json子程序
        '调用修改host文件子程序
        '启动异星工厂

    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        '注销全局热键
        'UnRegisterHotKey(Handle, 1)
        UnRegisterHotKey(Handle, 0)
        form_updata.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button_updata.Click
        form_updata.Show()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListView1.Items.Add(item(0))
        ListView1.Items(0).SubItems.Add(item(1))
        ListView1.Items(0).SubItems.Add(item(2))
        ListView1.Items(0).SubItems.Add(item(3))
        ListView1.Items（0）.ForeColor = Color.Red
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
        Try
            Dim myUri As New Uri(upsrc + "serverlist.txt")
            dFile.DownloadFile(myUri, "serverlist.txt")

        Catch ex As Exception
            MsgBox("服务器列表下载失败！")
            Exit Sub
        End Try

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
End Class