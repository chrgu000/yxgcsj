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
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_client = New System.Windows.Forms.TabPage()
        Me.Button_load_game = New System.Windows.Forms.Button()
        Me.Button_reload_serverlist = New System.Windows.Forms.Button()
        Me.Button_connect_server = New System.Windows.Forms.Button()
        Me.TabPage_server = New System.Windows.Forms.TabPage()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button_change_player_color = New System.Windows.Forms.Button()
        Me.TextBox_game_ver = New System.Windows.Forms.TextBox()
        Me.LinkLabel_game_download_url = New System.Windows.Forms.LinkLabel()
        Me.Button_test_mode = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_test_mode_pass = New System.Windows.Forms.TextBox()
        Me.TabPage_mods = New System.Windows.Forms.TabPage()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label_mods_status = New System.Windows.Forms.Label()
        Me.Button_download_mods = New System.Windows.Forms.Button()
        Me.Button_mods_list = New System.Windows.Forms.Button()
        Me.ListView_mods = New System.Windows.Forms.ListView()
        Me.ColumnHeader101 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader102 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader103 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader104 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader105 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader106 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader107 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button_select_server = New System.Windows.Forms.Button()
        Me.TextBox_serverlist = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker_download_serverlist = New System.ComponentModel.BackgroundWorker()
        Me.Timer_load_sl = New System.Windows.Forms.Timer(Me.components)
        Me.Button_readme = New System.Windows.Forms.Button()
        Me.Timer_enable_reload_serverlist = New System.Windows.Forms.Timer(Me.components)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label_ver = New System.Windows.Forms.Label()
        Me.BackgroundWorker_creact_dsl = New System.ComponentModel.BackgroundWorker()
        Me.Label_ver_status = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label_tips = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BackgroundWorker_download_mods_list = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_client.SuspendLayout()
        Me.TabPage_server.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage_mods.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_updata
        '
        Me.Button_updata.Enabled = False
        Me.Button_updata.Location = New System.Drawing.Point(430, 424)
        Me.Button_updata.Name = "Button_updata"
        Me.Button_updata.Size = New System.Drawing.Size(87, 23)
        Me.Button_updata.TabIndex = 3
        Me.Button_updata.Text = "强制更新修复"
        Me.Button_updata.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(443, 458)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ver:"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(617, 304)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "服务器名称"
        Me.ColumnHeader1.Width = 93
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "介绍"
        Me.ColumnHeader2.Width = 181
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "游戏版本"
        Me.ColumnHeader3.Width = 89
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "使用模组"
        Me.ColumnHeader4.Width = 97
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "最后报告正常时间"
        Me.ColumnHeader5.Width = 126
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_client)
        Me.TabControl1.Controls.Add(Me.TabPage_server)
        Me.TabControl1.Controls.Add(Me.TabPage_mods)
        Me.TabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TabControl1.ItemSize = New System.Drawing.Size(240, 18)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(631, 382)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage_client
        '
        Me.TabPage_client.Controls.Add(Me.Button_load_game)
        Me.TabPage_client.Controls.Add(Me.Button_reload_serverlist)
        Me.TabPage_client.Controls.Add(Me.Button_connect_server)
        Me.TabPage_client.Controls.Add(Me.ListView1)
        Me.TabPage_client.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_client.Name = "TabPage_client"
        Me.TabPage_client.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_client.Size = New System.Drawing.Size(623, 356)
        Me.TabPage_client.TabIndex = 0
        Me.TabPage_client.Text = "连接服务器"
        Me.TabPage_client.UseVisualStyleBackColor = True
        '
        'Button_load_game
        '
        Me.Button_load_game.Location = New System.Drawing.Point(489, 313)
        Me.Button_load_game.Name = "Button_load_game"
        Me.Button_load_game.Size = New System.Drawing.Size(75, 23)
        Me.Button_load_game.TabIndex = 12
        Me.Button_load_game.Text = "只引导游戏"
        Me.Button_load_game.UseVisualStyleBackColor = True
        '
        'Button_reload_serverlist
        '
        Me.Button_reload_serverlist.Enabled = False
        Me.Button_reload_serverlist.Location = New System.Drawing.Point(336, 313)
        Me.Button_reload_serverlist.Name = "Button_reload_serverlist"
        Me.Button_reload_serverlist.Size = New System.Drawing.Size(120, 23)
        Me.Button_reload_serverlist.TabIndex = 11
        Me.Button_reload_serverlist.Text = "刷新服务器列表 0"
        Me.Button_reload_serverlist.UseVisualStyleBackColor = True
        '
        'Button_connect_server
        '
        Me.Button_connect_server.Enabled = False
        Me.Button_connect_server.Location = New System.Drawing.Point(89, 313)
        Me.Button_connect_server.Name = "Button_connect_server"
        Me.Button_connect_server.Size = New System.Drawing.Size(182, 23)
        Me.Button_connect_server.TabIndex = 7
        Me.Button_connect_server.Text = "进入选定服务器"
        Me.Button_connect_server.UseVisualStyleBackColor = True
        '
        'TabPage_server
        '
        Me.TabPage_server.Controls.Add(Me.LinkLabel2)
        Me.TabPage_server.Controls.Add(Me.Label4)
        Me.TabPage_server.Controls.Add(Me.Button1)
        Me.TabPage_server.Controls.Add(Me.GroupBox1)
        Me.TabPage_server.Controls.Add(Me.LinkLabel_game_download_url)
        Me.TabPage_server.Controls.Add(Me.Button_test_mode)
        Me.TabPage_server.Controls.Add(Me.Label1)
        Me.TabPage_server.Controls.Add(Me.TextBox_test_mode_pass)
        Me.TabPage_server.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_server.Name = "TabPage_server"
        Me.TabPage_server.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_server.Size = New System.Drawing.Size(623, 356)
        Me.TabPage_server.TabIndex = 1
        Me.TabPage_server.Text = "工具"
        Me.TabPage_server.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(383, 326)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(221, 12)
        Me.LinkLabel2.TabIndex = 21
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "原地址:http://quantorio.garveen.net/"
        Me.LinkLabel2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(391, 311)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 12)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "推荐浏览器为firefox 作者:acabin"
        Me.Label4.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(268, 313)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "量化工具离线版"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button_change_player_color)
        Me.GroupBox1.Controls.Add(Me.TextBox_game_ver)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(611, 279)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "控制台命令"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "游戏版本："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "改变角色的颜色："
        '
        'Button_change_player_color
        '
        Me.Button_change_player_color.Location = New System.Drawing.Point(113, 44)
        Me.Button_change_player_color.Name = "Button_change_player_color"
        Me.Button_change_player_color.Size = New System.Drawing.Size(75, 23)
        Me.Button_change_player_color.TabIndex = 5
        Me.Button_change_player_color.Text = "选择颜色"
        Me.Button_change_player_color.UseVisualStyleBackColor = True
        '
        'TextBox_game_ver
        '
        Me.TextBox_game_ver.Enabled = False
        Me.TextBox_game_ver.Location = New System.Drawing.Point(77, 14)
        Me.TextBox_game_ver.Name = "TextBox_game_ver"
        Me.TextBox_game_ver.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_game_ver.TabIndex = 18
        Me.TextBox_game_ver.Text = "0.16.36"
        '
        'LinkLabel_game_download_url
        '
        Me.LinkLabel_game_download_url.AutoSize = True
        Me.LinkLabel_game_download_url.Location = New System.Drawing.Point(7, 288)
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
        'TabPage_mods
        '
        Me.TabPage_mods.Controls.Add(Me.ProgressBar1)
        Me.TabPage_mods.Controls.Add(Me.Label_mods_status)
        Me.TabPage_mods.Controls.Add(Me.Button_download_mods)
        Me.TabPage_mods.Controls.Add(Me.Button_mods_list)
        Me.TabPage_mods.Controls.Add(Me.ListView_mods)
        Me.TabPage_mods.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_mods.Name = "TabPage_mods"
        Me.TabPage_mods.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_mods.Size = New System.Drawing.Size(623, 356)
        Me.TabPage_mods.TabIndex = 2
        Me.TabPage_mods.Text = "下载模组"
        Me.TabPage_mods.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(339, 318)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(137, 23)
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Visible = False
        '
        'Label_mods_status
        '
        Me.Label_mods_status.AutoSize = True
        Me.Label_mods_status.ForeColor = System.Drawing.Color.Red
        Me.Label_mods_status.Location = New System.Drawing.Point(494, 323)
        Me.Label_mods_status.Name = "Label_mods_status"
        Me.Label_mods_status.Size = New System.Drawing.Size(41, 12)
        Me.Label_mods_status.TabIndex = 3
        Me.Label_mods_status.Text = "状态："
        '
        'Button_download_mods
        '
        Me.Button_download_mods.Enabled = False
        Me.Button_download_mods.Location = New System.Drawing.Point(231, 318)
        Me.Button_download_mods.Name = "Button_download_mods"
        Me.Button_download_mods.Size = New System.Drawing.Size(102, 23)
        Me.Button_download_mods.TabIndex = 2
        Me.Button_download_mods.Text = "下载选定的模组"
        Me.Button_download_mods.UseVisualStyleBackColor = True
        '
        'Button_mods_list
        '
        Me.Button_mods_list.Location = New System.Drawing.Point(59, 318)
        Me.Button_mods_list.Name = "Button_mods_list"
        Me.Button_mods_list.Size = New System.Drawing.Size(102, 23)
        Me.Button_mods_list.TabIndex = 1
        Me.Button_mods_list.Text = "载入模组列表"
        Me.Button_mods_list.UseVisualStyleBackColor = True
        '
        'ListView_mods
        '
        Me.ListView_mods.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader101, Me.ColumnHeader102, Me.ColumnHeader103, Me.ColumnHeader104, Me.ColumnHeader105, Me.ColumnHeader106, Me.ColumnHeader107})
        Me.ListView_mods.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView_mods.FullRowSelect = True
        Me.ListView_mods.GridLines = True
        Me.ListView_mods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView_mods.HideSelection = False
        Me.ListView_mods.LabelEdit = True
        Me.ListView_mods.Location = New System.Drawing.Point(3, 3)
        Me.ListView_mods.Name = "ListView_mods"
        Me.ListView_mods.Size = New System.Drawing.Size(614, 304)
        Me.ListView_mods.TabIndex = 0
        Me.ListView_mods.UseCompatibleStateImageBehavior = False
        Me.ListView_mods.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader101
        '
        Me.ColumnHeader101.Text = "中文译名"
        Me.ColumnHeader101.Width = 145
        '
        'ColumnHeader102
        '
        Me.ColumnHeader102.Text = "版本"
        Me.ColumnHeader102.Width = 54
        '
        'ColumnHeader103
        '
        Me.ColumnHeader103.Text = "详细介绍"
        Me.ColumnHeader103.Width = 265
        '
        'ColumnHeader104
        '
        Me.ColumnHeader104.Text = "官网原名"
        Me.ColumnHeader104.Width = 147
        '
        'ColumnHeader105
        '
        Me.ColumnHeader105.Text = "作者"
        Me.ColumnHeader105.Width = 49
        '
        'ColumnHeader106
        '
        Me.ColumnHeader106.Text = "官方网站"
        Me.ColumnHeader106.Width = 87
        '
        'ColumnHeader107
        '
        Me.ColumnHeader107.Text = "更新日期"
        Me.ColumnHeader107.Width = 203
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem1.Text = "复制官网"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem2.Text = "复制介绍"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem3.Text = "复制作者"
        '
        'Button_select_server
        '
        Me.Button_select_server.Enabled = False
        Me.Button_select_server.Location = New System.Drawing.Point(263, 424)
        Me.Button_select_server.Name = "Button_select_server"
        Me.Button_select_server.Size = New System.Drawing.Size(119, 23)
        Me.Button_select_server.TabIndex = 12
        Me.Button_select_server.Text = "切换到选定服务器"
        Me.Button_select_server.UseVisualStyleBackColor = True
        Me.Button_select_server.Visible = False
        '
        'TextBox_serverlist
        '
        Me.TextBox_serverlist.Enabled = False
        Me.TextBox_serverlist.Location = New System.Drawing.Point(263, 397)
        Me.TextBox_serverlist.Multiline = True
        Me.TextBox_serverlist.Name = "TextBox_serverlist"
        Me.TextBox_serverlist.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_serverlist.TabIndex = 10
        Me.TextBox_serverlist.Text = "服1" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍1" & Global.Microsoft.VisualBasic.ChrW(9) & "时间1" & Global.Microsoft.VisualBasic.ChrW(9) & "183.185.183.37" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服2" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍2" & Global.Microsoft.VisualBasic.ChrW(9) & "时间2" & Global.Microsoft.VisualBasic.ChrW(9) & "192.168.2.10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服3" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍3" & Global.Microsoft.VisualBasic.ChrW(9) & "时间3" & Global.Microsoft.VisualBasic.ChrW(9) & "ip3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服4" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍4" & Global.Microsoft.VisualBasic.ChrW(9) & "时间4" & Global.Microsoft.VisualBasic.ChrW(9) & "ip" &
    "4"
        Me.TextBox_serverlist.Visible = False
        '
        'BackgroundWorker_download_serverlist
        '
        '
        'Timer_load_sl
        '
        Me.Timer_load_sl.Interval = 500
        '
        'Button_readme
        '
        Me.Button_readme.Enabled = False
        Me.Button_readme.Location = New System.Drawing.Point(122, 424)
        Me.Button_readme.Name = "Button_readme"
        Me.Button_readme.Size = New System.Drawing.Size(87, 23)
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
        Me.LinkLabel1.Location = New System.Drawing.Point(29, 458)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(245, 12)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "意见、建议、问题欢迎发信 57832091@qq.com"
        '
        'Label_ver
        '
        Me.Label_ver.AutoSize = True
        Me.Label_ver.Location = New System.Drawing.Point(474, 458)
        Me.Label_ver.Name = "Label_ver"
        Me.Label_ver.Size = New System.Drawing.Size(29, 12)
        Me.Label_ver.TabIndex = 13
        Me.Label_ver.Text = "0.37"
        '
        'Label_ver_status
        '
        Me.Label_ver_status.AutoSize = True
        Me.Label_ver_status.Location = New System.Drawing.Point(503, 458)
        Me.Label_ver_status.Name = "Label_ver_status"
        Me.Label_ver_status.Size = New System.Drawing.Size(11, 12)
        Me.Label_ver_status.TabIndex = 17
        Me.Label_ver_status.Text = "."
        '
        'Label_tips
        '
        Me.Label_tips.AutoSize = True
        Me.Label_tips.ForeColor = System.Drawing.Color.Red
        Me.Label_tips.Location = New System.Drawing.Point(94, 403)
        Me.Label_tips.Name = "Label_tips"
        Me.Label_tips.Size = New System.Drawing.Size(53, 12)
        Me.Label_tips.TabIndex = 18
        Me.Label_tips.Text = "提示内容"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(41, 403)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 12)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "小提示:"
        '
        'BackgroundWorker_download_mods_list
        '
        '
        'Form_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 479)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label_tips)
        Me.Controls.Add(Me.Button_select_server)
        Me.Controls.Add(Me.Label_ver_status)
        Me.Controls.Add(Me.TextBox_serverlist)
        Me.Controls.Add(Me.Label_ver)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button_readme)
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage_mods.ResumeLayout(False)
        Me.TabPage_mods.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_updata As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_client As TabPage
    Friend WithEvents TabPage_server As TabPage
    Friend WithEvents Button_connect_server As Button
    Friend WithEvents TextBox_serverlist As TextBox
    Friend WithEvents BackgroundWorker_download_serverlist As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer_load_sl As Timer
    Friend WithEvents Button_readme As Button
    Friend WithEvents Button_reload_serverlist As Button
    Friend WithEvents Timer_enable_reload_serverlist As Timer
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label_ver As Label
    Friend WithEvents BackgroundWorker_creact_dsl As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label_ver_status As Label
    Friend WithEvents Button_select_server As Button
    Friend WithEvents Button_test_mode As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_test_mode_pass As TextBox
    Friend WithEvents LinkLabel_game_download_url As LinkLabel
    Friend WithEvents Button_change_player_color As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox_game_ver As TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Button_load_game As Button
    Friend WithEvents TabPage_mods As TabPage
    Friend WithEvents Label_tips As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button_download_mods As Button
    Friend WithEvents Button_mods_list As Button
    Friend WithEvents ListView_mods As ListView
    Friend WithEvents ColumnHeader101 As ColumnHeader
    Friend WithEvents ColumnHeader102 As ColumnHeader
    Friend WithEvents ColumnHeader103 As ColumnHeader
    Friend WithEvents ColumnHeader104 As ColumnHeader
    Friend WithEvents ColumnHeader105 As ColumnHeader
    Friend WithEvents ColumnHeader106 As ColumnHeader
    Friend WithEvents BackgroundWorker_download_mods_list As System.ComponentModel.BackgroundWorker
    Friend WithEvents ColumnHeader107 As ColumnHeader
    Friend WithEvents Label_mods_status As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents ColumnHeader4 As ColumnHeader
End Class
