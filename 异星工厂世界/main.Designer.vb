<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_main))
        Me.Button_updata = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_client = New System.Windows.Forms.TabPage()
        Me.Button_select_server = New System.Windows.Forms.Button()
        Me.Button_reload_serverlist = New System.Windows.Forms.Button()
        Me.Button_run_game = New System.Windows.Forms.Button()
        Me.TabPage_server = New System.Windows.Forms.TabPage()
        Me.LinkLabel_game_download_url = New System.Windows.Forms.LinkLabel()
        Me.Button_test_mode = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_test_mode_pass = New System.Windows.Forms.TextBox()
        Me.TextBox_serverlist = New System.Windows.Forms.TextBox()
        Me.CheckBox_chinese_chat = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker_download_serverlist = New System.ComponentModel.BackgroundWorker()
        Me.Timer_sync_server = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_load_sl = New System.Windows.Forms.Timer(Me.components)
        Me.Button_readme = New System.Windows.Forms.Button()
        Me.Timer_enable_reload_serverlist = New System.Windows.Forms.Timer(Me.components)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label_ver = New System.Windows.Forms.Label()
        Me.BackgroundWorker_creact_dsl = New System.ComponentModel.BackgroundWorker()
        Me.Timer_Thank_list = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox_game_ver = New System.Windows.Forms.TextBox()
        Me.Label_ver_status = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_client.SuspendLayout()
        Me.TabPage_server.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_updata
        '
        Me.Button_updata.Enabled = False
        Me.Button_updata.Location = New System.Drawing.Point(371, 419)
        Me.Button_updata.Name = "Button_updata"
        Me.Button_updata.Size = New System.Drawing.Size(75, 23)
        Me.Button_updata.TabIndex = 3
        Me.Button_updata.Text = "更新程序"
        Me.Button_updata.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(370, 454)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ver:"
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(473, 304)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "服务器名称"
        Me.ColumnHeader1.Width = 104
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "介绍"
        Me.ColumnHeader2.Width = 191
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "最后报告正常时间"
        Me.ColumnHeader3.Width = 172
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ping"
        Me.ColumnHeader4.Width = 54
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_client)
        Me.TabControl1.Controls.Add(Me.TabPage_server)
        Me.TabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TabControl1.ItemSize = New System.Drawing.Size(240, 18)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(487, 368)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 1
        '
        'TabPage_client
        '
        Me.TabPage_client.Controls.Add(Me.Button_select_server)
        Me.TabPage_client.Controls.Add(Me.Button_reload_serverlist)
        Me.TabPage_client.Controls.Add(Me.Button_run_game)
        Me.TabPage_client.Controls.Add(Me.ListView1)
        Me.TabPage_client.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_client.Name = "TabPage_client"
        Me.TabPage_client.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_client.Size = New System.Drawing.Size(479, 342)
        Me.TabPage_client.TabIndex = 0
        Me.TabPage_client.Text = "连接服务器"
        Me.TabPage_client.UseVisualStyleBackColor = True
        '
        'Button_select_server
        '
        Me.Button_select_server.Enabled = False
        Me.Button_select_server.Location = New System.Drawing.Point(6, 311)
        Me.Button_select_server.Name = "Button_select_server"
        Me.Button_select_server.Size = New System.Drawing.Size(119, 23)
        Me.Button_select_server.TabIndex = 12
        Me.Button_select_server.Text = "切换到选定服务器"
        Me.Button_select_server.UseVisualStyleBackColor = True
        '
        'Button_reload_serverlist
        '
        Me.Button_reload_serverlist.Enabled = False
        Me.Button_reload_serverlist.Location = New System.Drawing.Point(353, 311)
        Me.Button_reload_serverlist.Name = "Button_reload_serverlist"
        Me.Button_reload_serverlist.Size = New System.Drawing.Size(119, 23)
        Me.Button_reload_serverlist.TabIndex = 11
        Me.Button_reload_serverlist.Text = "刷新服务器列表 0"
        Me.Button_reload_serverlist.UseVisualStyleBackColor = True
        '
        'Button_run_game
        '
        Me.Button_run_game.Enabled = False
        Me.Button_run_game.Location = New System.Drawing.Point(177, 311)
        Me.Button_run_game.Name = "Button_run_game"
        Me.Button_run_game.Size = New System.Drawing.Size(127, 23)
        Me.Button_run_game.TabIndex = 7
        Me.Button_run_game.Text = "启动游戏"
        Me.Button_run_game.UseVisualStyleBackColor = True
        '
        'TabPage_server
        '
        Me.TabPage_server.Controls.Add(Me.LinkLabel_game_download_url)
        Me.TabPage_server.Controls.Add(Me.Button_test_mode)
        Me.TabPage_server.Controls.Add(Me.Label1)
        Me.TabPage_server.Controls.Add(Me.TextBox_test_mode_pass)
        Me.TabPage_server.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_server.Name = "TabPage_server"
        Me.TabPage_server.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_server.Size = New System.Drawing.Size(479, 342)
        Me.TabPage_server.TabIndex = 1
        Me.TabPage_server.Text = "工具"
        Me.TabPage_server.UseVisualStyleBackColor = True
        '
        'LinkLabel_game_download_url
        '
        Me.LinkLabel_game_download_url.AutoSize = True
        Me.LinkLabel_game_download_url.Location = New System.Drawing.Point(7, 277)
        Me.LinkLabel_game_download_url.Name = "LinkLabel_game_download_url"
        Me.LinkLabel_game_download_url.Size = New System.Drawing.Size(89, 12)
        Me.LinkLabel_game_download_url.TabIndex = 3
        Me.LinkLabel_game_download_url.TabStop = True
        Me.LinkLabel_game_download_url.Text = "最新版游戏下载"
        Me.LinkLabel_game_download_url.Visible = False
        '
        'Button_test_mode
        '
        Me.Button_test_mode.Location = New System.Drawing.Point(178, 313)
        Me.Button_test_mode.Name = "Button_test_mode"
        Me.Button_test_mode.Size = New System.Drawing.Size(75, 23)
        Me.Button_test_mode.TabIndex = 2
        Me.Button_test_mode.Text = "打开"
        Me.Button_test_mode.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "测试功能:"
        '
        'TextBox_test_mode_pass
        '
        Me.TextBox_test_mode_pass.Location = New System.Drawing.Point(72, 315)
        Me.TextBox_test_mode_pass.Name = "TextBox_test_mode_pass"
        Me.TextBox_test_mode_pass.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_test_mode_pass.TabIndex = 0
        '
        'TextBox_serverlist
        '
        Me.TextBox_serverlist.Enabled = False
        Me.TextBox_serverlist.Location = New System.Drawing.Point(236, 421)
        Me.TextBox_serverlist.Multiline = True
        Me.TextBox_serverlist.Name = "TextBox_serverlist"
        Me.TextBox_serverlist.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_serverlist.TabIndex = 10
        Me.TextBox_serverlist.Text = "服1" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍1" & Global.Microsoft.VisualBasic.ChrW(9) & "时间1" & Global.Microsoft.VisualBasic.ChrW(9) & "183.185.183.37" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服2" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍2" & Global.Microsoft.VisualBasic.ChrW(9) & "时间2" & Global.Microsoft.VisualBasic.ChrW(9) & "192.168.2.10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服3" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍3" & Global.Microsoft.VisualBasic.ChrW(9) & "时间3" & Global.Microsoft.VisualBasic.ChrW(9) & "ip3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服4" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍4" & Global.Microsoft.VisualBasic.ChrW(9) & "时间4" & Global.Microsoft.VisualBasic.ChrW(9) & "ip" &
    "4"
        Me.TextBox_serverlist.Visible = False
        '
        'CheckBox_chinese_chat
        '
        Me.CheckBox_chinese_chat.AutoSize = True
        Me.CheckBox_chinese_chat.Checked = True
        Me.CheckBox_chinese_chat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_chinese_chat.Enabled = False
        Me.CheckBox_chinese_chat.Location = New System.Drawing.Point(12, 390)
        Me.CheckBox_chinese_chat.Name = "CheckBox_chinese_chat"
        Me.CheckBox_chinese_chat.Size = New System.Drawing.Size(300, 16)
        Me.CheckBox_chinese_chat.TabIndex = 9
        Me.CheckBox_chinese_chat.Text = "中文聊天支持（Ctrl+~激活输入窗口），游戏版本："
        Me.CheckBox_chinese_chat.UseVisualStyleBackColor = True
        '
        'BackgroundWorker_download_serverlist
        '
        '
        'Timer_sync_server
        '
        Me.Timer_sync_server.Interval = 180000
        '
        'Timer_load_sl
        '
        Me.Timer_load_sl.Interval = 500
        '
        'Button_readme
        '
        Me.Button_readme.Enabled = False
        Me.Button_readme.Location = New System.Drawing.Point(79, 419)
        Me.Button_readme.Name = "Button_readme"
        Me.Button_readme.Size = New System.Drawing.Size(75, 23)
        Me.Button_readme.TabIndex = 11
        Me.Button_readme.Text = "使用说明"
        Me.Button_readme.UseVisualStyleBackColor = True
        '
        'Timer_enable_reload_serverlist
        '
        Me.Timer_enable_reload_serverlist.Interval = 1000
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(38, 454)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(245, 12)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "意见、建议、问题欢迎发信 57832091@qq.com"
        '
        'Label_ver
        '
        Me.Label_ver.AutoSize = True
        Me.Label_ver.Location = New System.Drawing.Point(401, 454)
        Me.Label_ver.Name = "Label_ver"
        Me.Label_ver.Size = New System.Drawing.Size(29, 12)
        Me.Label_ver.TabIndex = 13
        Me.Label_ver.Text = "0.15"
        '
        'Timer_Thank_list
        '
        Me.Timer_Thank_list.Enabled = True
        Me.Timer_Thank_list.Interval = 200
        '
        'TextBox_game_ver
        '
        Me.TextBox_game_ver.Enabled = False
        Me.TextBox_game_ver.Location = New System.Drawing.Point(308, 388)
        Me.TextBox_game_ver.Name = "TextBox_game_ver"
        Me.TextBox_game_ver.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_game_ver.TabIndex = 16
        Me.TextBox_game_ver.Text = "0.15.37"
        '
        'Label_ver_status
        '
        Me.Label_ver_status.AutoSize = True
        Me.Label_ver_status.Location = New System.Drawing.Point(430, 454)
        Me.Label_ver_status.Name = "Label_ver_status"
        Me.Label_ver_status.Size = New System.Drawing.Size(11, 12)
        Me.Label_ver_status.TabIndex = 17
        Me.Label_ver_status.Text = "."
        '
        'Form_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 479)
        Me.Controls.Add(Me.Label_ver_status)
        Me.Controls.Add(Me.TextBox_serverlist)
        Me.Controls.Add(Me.TextBox_game_ver)
        Me.Controls.Add(Me.Label_ver)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button_readme)
        Me.Controls.Add(Me.CheckBox_chinese_chat)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button_updata)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工厂世界"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_client.ResumeLayout(False)
        Me.TabPage_server.ResumeLayout(False)
        Me.TabPage_server.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_updata As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_client As TabPage
    Friend WithEvents TabPage_server As TabPage
    Friend WithEvents Button_run_game As Button
    Friend WithEvents CheckBox_chinese_chat As CheckBox
    Friend WithEvents TextBox_serverlist As TextBox
    Friend WithEvents BackgroundWorker_download_serverlist As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer_sync_server As Timer
    Friend WithEvents Timer_load_sl As Timer
    Friend WithEvents Button_readme As Button
    Friend WithEvents Button_reload_serverlist As Button
    Friend WithEvents Timer_enable_reload_serverlist As Timer
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label_ver As Label
    Friend WithEvents BackgroundWorker_creact_dsl As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer_Thank_list As Timer
    Friend WithEvents TextBox_game_ver As TextBox
    Friend WithEvents Label_ver_status As Label
    Friend WithEvents Button_select_server As Button
    Friend WithEvents Button_test_mode As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_test_mode_pass As TextBox
    Friend WithEvents LinkLabel_game_download_url As LinkLabel
End Class
