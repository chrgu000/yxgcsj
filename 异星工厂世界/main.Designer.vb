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
        Me.Button_reload_serverlist = New System.Windows.Forms.Button()
        Me.TextBox_serverlist = New System.Windows.Forms.TextBox()
        Me.Button_join = New System.Windows.Forms.Button()
        Me.TabPage_server = New System.Windows.Forms.TabPage()
        Me.TextBox_server_intro = New System.Windows.Forms.TextBox()
        Me.TextBox_server_name = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button_check_ip = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox_IP = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox_auto_pause = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_afk_autokick_interval = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_autosave_slots = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_autosave_interval = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_max_players = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_saves = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_create_server = New System.Windows.Forms.Button()
        Me.CheckBox_chinese_chat = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker_download_serverlist = New System.ComponentModel.BackgroundWorker()
        Me.Timer_sync_server = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_load_sl = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer_enable_reload_serverlist = New System.Windows.Forms.Timer(Me.components)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label_ver = New System.Windows.Forms.Label()
        Me.BackgroundWorker_creact_dsl = New System.ComponentModel.BackgroundWorker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_client.SuspendLayout()
        Me.TabPage_server.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_updata
        '
        Me.Button_updata.Location = New System.Drawing.Point(312, 412)
        Me.Button_updata.Name = "Button_updata"
        Me.Button_updata.Size = New System.Drawing.Size(75, 23)
        Me.Button_updata.TabIndex = 3
        Me.Button_updata.Text = "检测更新"
        Me.Button_updata.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 418)
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
        Me.TabPage_client.Controls.Add(Me.Button_reload_serverlist)
        Me.TabPage_client.Controls.Add(Me.TextBox_serverlist)
        Me.TabPage_client.Controls.Add(Me.Button_join)
        Me.TabPage_client.Controls.Add(Me.ListView1)
        Me.TabPage_client.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_client.Name = "TabPage_client"
        Me.TabPage_client.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_client.Size = New System.Drawing.Size(479, 342)
        Me.TabPage_client.TabIndex = 0
        Me.TabPage_client.Text = "连接服务器"
        Me.TabPage_client.UseVisualStyleBackColor = True
        '
        'Button_reload_serverlist
        '
        Me.Button_reload_serverlist.Location = New System.Drawing.Point(252, 311)
        Me.Button_reload_serverlist.Name = "Button_reload_serverlist"
        Me.Button_reload_serverlist.Size = New System.Drawing.Size(178, 23)
        Me.Button_reload_serverlist.TabIndex = 11
        Me.Button_reload_serverlist.Text = "刷新服务器列表 0"
        Me.Button_reload_serverlist.UseVisualStyleBackColor = True
        '
        'TextBox_serverlist
        '
        Me.TextBox_serverlist.Enabled = False
        Me.TextBox_serverlist.Location = New System.Drawing.Point(365, 313)
        Me.TextBox_serverlist.Multiline = True
        Me.TextBox_serverlist.Name = "TextBox_serverlist"
        Me.TextBox_serverlist.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_serverlist.TabIndex = 10
        Me.TextBox_serverlist.Text = "服1" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍1" & Global.Microsoft.VisualBasic.ChrW(9) & "时间1" & Global.Microsoft.VisualBasic.ChrW(9) & "183.185.183.37" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服2" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍2" & Global.Microsoft.VisualBasic.ChrW(9) & "时间2" & Global.Microsoft.VisualBasic.ChrW(9) & "192.168.2.10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服3" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍3" & Global.Microsoft.VisualBasic.ChrW(9) & "时间3" & Global.Microsoft.VisualBasic.ChrW(9) & "ip3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服4" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍4" & Global.Microsoft.VisualBasic.ChrW(9) & "时间4" & Global.Microsoft.VisualBasic.ChrW(9) & "ip" &
    "4"
        Me.TextBox_serverlist.Visible = False
        '
        'Button_join
        '
        Me.Button_join.Enabled = False
        Me.Button_join.Location = New System.Drawing.Point(75, 311)
        Me.Button_join.Name = "Button_join"
        Me.Button_join.Size = New System.Drawing.Size(127, 23)
        Me.Button_join.TabIndex = 7
        Me.Button_join.Text = "正在载入服务器列表"
        Me.Button_join.UseVisualStyleBackColor = True
        '
        'TabPage_server
        '
        Me.TabPage_server.Controls.Add(Me.TextBox_server_intro)
        Me.TabPage_server.Controls.Add(Me.TextBox_server_name)
        Me.TabPage_server.Controls.Add(Me.Label15)
        Me.TabPage_server.Controls.Add(Me.Label14)
        Me.TabPage_server.Controls.Add(Me.Button1)
        Me.TabPage_server.Controls.Add(Me.Button_check_ip)
        Me.TabPage_server.Controls.Add(Me.Label13)
        Me.TabPage_server.Controls.Add(Me.TextBox_IP)
        Me.TabPage_server.Controls.Add(Me.Label12)
        Me.TabPage_server.Controls.Add(Me.Label11)
        Me.TabPage_server.Controls.Add(Me.Label10)
        Me.TabPage_server.Controls.Add(Me.Label9)
        Me.TabPage_server.Controls.Add(Me.Label8)
        Me.TabPage_server.Controls.Add(Me.ComboBox_auto_pause)
        Me.TabPage_server.Controls.Add(Me.Label7)
        Me.TabPage_server.Controls.Add(Me.TextBox_afk_autokick_interval)
        Me.TabPage_server.Controls.Add(Me.Label6)
        Me.TabPage_server.Controls.Add(Me.TextBox_autosave_slots)
        Me.TabPage_server.Controls.Add(Me.Label5)
        Me.TabPage_server.Controls.Add(Me.TextBox_autosave_interval)
        Me.TabPage_server.Controls.Add(Me.Label4)
        Me.TabPage_server.Controls.Add(Me.TextBox_max_players)
        Me.TabPage_server.Controls.Add(Me.Label3)
        Me.TabPage_server.Controls.Add(Me.TextBox_saves)
        Me.TabPage_server.Controls.Add(Me.Label1)
        Me.TabPage_server.Controls.Add(Me.Button_create_server)
        Me.TabPage_server.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_server.Name = "TabPage_server"
        Me.TabPage_server.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_server.Size = New System.Drawing.Size(479, 342)
        Me.TabPage_server.TabIndex = 1
        Me.TabPage_server.Text = "创建服务器"
        Me.TabPage_server.UseVisualStyleBackColor = True
        '
        'TextBox_server_intro
        '
        Me.TextBox_server_intro.Location = New System.Drawing.Point(49, 146)
        Me.TextBox_server_intro.Name = "TextBox_server_intro"
        Me.TextBox_server_intro.Size = New System.Drawing.Size(238, 21)
        Me.TextBox_server_intro.TabIndex = 40
        '
        'TextBox_server_name
        '
        Me.TextBox_server_name.Location = New System.Drawing.Point(85, 115)
        Me.TextBox_server_name.Name = "TextBox_server_name"
        Me.TextBox_server_name.Size = New System.Drawing.Size(135, 21)
        Me.TextBox_server_name.TabIndex = 39
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 12)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "简介:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 118)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 12)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "服务器名称:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(269, 313)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 23)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "保存并停止服务"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_check_ip
        '
        Me.Button_check_ip.Location = New System.Drawing.Point(179, 9)
        Me.Button_check_ip.Name = "Button_check_ip"
        Me.Button_check_ip.Size = New System.Drawing.Size(75, 23)
        Me.Button_check_ip.TabIndex = 35
        Me.Button_check_ip.Text = "自动检测"
        Me.Button_check_ip.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(8, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(269, 12)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "如自动检测不正确请输入正确IP，否则别人连不上"
        '
        'TextBox_IP
        '
        Me.TextBox_IP.Location = New System.Drawing.Point(61, 11)
        Me.TextBox_IP.Name = "TextBox_IP"
        Me.TextBox_IP.Size = New System.Drawing.Size(112, 21)
        Me.TextBox_IP.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 12)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "外网IP:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(195, 211)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "0为不限制"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(191, 242)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "分钟"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(8, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(221, 12)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "先在游中创建存档，再此输入，注意路径"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(179, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 12)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "分钟   0为不踢"
        '
        'ComboBox_auto_pause
        '
        Me.ComboBox_auto_pause.FormattingEnabled = True
        Me.ComboBox_auto_pause.Items.AddRange(New Object() {"是", "否"})
        Me.ComboBox_auto_pause.Location = New System.Drawing.Point(133, 270)
        Me.ComboBox_auto_pause.Name = "ComboBox_auto_pause"
        Me.ComboBox_auto_pause.Size = New System.Drawing.Size(60, 20)
        Me.ComboBox_auto_pause.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 273)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 12)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "服务器无人自动暂停:"
        '
        'TextBox_afk_autokick_interval
        '
        Me.TextBox_afk_autokick_interval.Location = New System.Drawing.Point(73, 177)
        Me.TextBox_afk_autokick_interval.Name = "TextBox_afk_autokick_interval"
        Me.TextBox_afk_autokick_interval.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_afk_autokick_interval.TabIndex = 21
        Me.TextBox_afk_autokick_interval.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "挂机踢出:"
        '
        'TextBox_autosave_slots
        '
        Me.TextBox_autosave_slots.Location = New System.Drawing.Point(315, 239)
        Me.TextBox_autosave_slots.Name = "TextBox_autosave_slots"
        Me.TextBox_autosave_slots.Size = New System.Drawing.Size(95, 21)
        Me.TextBox_autosave_slots.TabIndex = 19
        Me.TextBox_autosave_slots.Text = "5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(226, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "自动存盘数量:"
        '
        'TextBox_autosave_interval
        '
        Me.TextBox_autosave_interval.Location = New System.Drawing.Point(121, 239)
        Me.TextBox_autosave_interval.Name = "TextBox_autosave_interval"
        Me.TextBox_autosave_interval.Size = New System.Drawing.Size(64, 21)
        Me.TextBox_autosave_interval.TabIndex = 17
        Me.TextBox_autosave_interval.Text = "30"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "自动存盘间隔时间:"
        '
        'TextBox_max_players
        '
        Me.TextBox_max_players.Location = New System.Drawing.Point(85, 208)
        Me.TextBox_max_players.Name = "TextBox_max_players"
        Me.TextBox_max_players.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_max_players.TabIndex = 15
        Me.TextBox_max_players.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "最大玩家数:"
        '
        'TextBox_saves
        '
        Me.TextBox_saves.Location = New System.Drawing.Point(73, 65)
        Me.TextBox_saves.Name = "TextBox_saves"
        Me.TextBox_saves.Size = New System.Drawing.Size(195, 21)
        Me.TextBox_saves.TabIndex = 13
        Me.TextBox_saves.Text = "saves/_autosave1.zip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "存档文件:"
        '
        'Button_create_server
        '
        Me.Button_create_server.Location = New System.Drawing.Point(85, 313)
        Me.Button_create_server.Name = "Button_create_server"
        Me.Button_create_server.Size = New System.Drawing.Size(75, 23)
        Me.Button_create_server.TabIndex = 0
        Me.Button_create_server.Text = "创建"
        Me.Button_create_server.UseVisualStyleBackColor = True
        '
        'CheckBox_chinese_chat
        '
        Me.CheckBox_chinese_chat.AutoSize = True
        Me.CheckBox_chinese_chat.Checked = True
        Me.CheckBox_chinese_chat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_chinese_chat.Location = New System.Drawing.Point(12, 390)
        Me.CheckBox_chinese_chat.Name = "CheckBox_chinese_chat"
        Me.CheckBox_chinese_chat.Size = New System.Drawing.Size(354, 16)
        Me.CheckBox_chinese_chat.TabIndex = 9
        Me.CheckBox_chinese_chat.Text = "中文聊天支持（Ctrl+~激活输入窗口），目前只支持0.15.37版"
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
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(72, 412)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "使用说明"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer_enable_reload_serverlist
        '
        Me.Timer_enable_reload_serverlist.Interval = 1000
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(266, 442)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(245, 12)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "意见、建议、问题欢迎发信 57832091@qq.com"
        '
        'Label_ver
        '
        Me.Label_ver.AutoSize = True
        Me.Label_ver.Location = New System.Drawing.Point(424, 418)
        Me.Label_ver.Name = "Label_ver"
        Me.Label_ver.Size = New System.Drawing.Size(23, 12)
        Me.Label_ver.TabIndex = 13
        Me.Label_ver.Text = "0.8"
        '
        'BackgroundWorker_creact_dsl
        '
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(192, 412)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "清理缓存"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 463)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label_ver)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button2)
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
        Me.TabPage_client.PerformLayout()
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
    Friend WithEvents Button_join As Button
    Friend WithEvents Button_create_server As Button
    Friend WithEvents CheckBox_chinese_chat As CheckBox
    Friend WithEvents TextBox_serverlist As TextBox
    Friend WithEvents BackgroundWorker_download_serverlist As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBox_auto_pause As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox_afk_autokick_interval As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox_autosave_slots As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_autosave_interval As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_max_players As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_saves As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Button_check_ip As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox_IP As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox_server_intro As TextBox
    Friend WithEvents TextBox_server_name As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Timer_sync_server As Timer
    Friend WithEvents Timer_load_sl As Timer
    Friend WithEvents Button2 As Button
    Friend WithEvents Button_reload_serverlist As Button
    Friend WithEvents Timer_enable_reload_serverlist As Timer
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label_ver As Label
    Friend WithEvents BackgroundWorker_creact_dsl As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button3 As Button
End Class
