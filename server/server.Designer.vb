<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class server
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(server))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TextBox_port = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CheckBox_custom_port = New System.Windows.Forms.CheckBox()
        Me.CheckBox_pppoe = New System.Windows.Forms.CheckBox()
        Me.Label1_status = New System.Windows.Forms.Label()
        Me.TextBox_config_path_cfg = New System.Windows.Forms.TextBox()
        Me.CheckBox_user_game_password = New System.Windows.Forms.CheckBox()
        Me.TextBox_game_password = New System.Windows.Forms.TextBox()
        Me.Button_copy_save = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_source_save = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.OpenFileDialog_open_save_zip = New System.Windows.Forms.OpenFileDialog()
        Me.Label_ver = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Timer_sync_server = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker_creact_dsl = New System.ComponentModel.BackgroundWorker()
        Me.Button_readme = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(492, 492)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox_port)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.CheckBox_custom_port)
        Me.TabPage1.Controls.Add(Me.CheckBox_pppoe)
        Me.TabPage1.Controls.Add(Me.Label1_status)
        Me.TabPage1.Controls.Add(Me.TextBox_config_path_cfg)
        Me.TabPage1.Controls.Add(Me.CheckBox_user_game_password)
        Me.TabPage1.Controls.Add(Me.TextBox_game_password)
        Me.TabPage1.Controls.Add(Me.Button_copy_save)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TextBox_source_save)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.TextBox_server_intro)
        Me.TabPage1.Controls.Add(Me.TextBox_server_name)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button_check_ip)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.TextBox_IP)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.ComboBox_auto_pause)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.TextBox_afk_autokick_interval)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.TextBox_autosave_slots)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TextBox_autosave_interval)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TextBox_max_players)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TextBox_saves)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Button_create_server)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(484, 466)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "独立服务器"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TextBox_port
        '
        Me.TextBox_port.Enabled = False
        Me.TextBox_port.Location = New System.Drawing.Point(200, 14)
        Me.TextBox_port.Name = "TextBox_port"
        Me.TextBox_port.Size = New System.Drawing.Size(38, 21)
        Me.TextBox_port.TabIndex = 110
        Me.TextBox_port.Text = "34197"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(187, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 12)
        Me.Label18.TabIndex = 109
        Me.Label18.Text = ":"
        '
        'CheckBox_custom_port
        '
        Me.CheckBox_custom_port.AutoSize = True
        Me.CheckBox_custom_port.Location = New System.Drawing.Point(244, 17)
        Me.CheckBox_custom_port.Name = "CheckBox_custom_port"
        Me.CheckBox_custom_port.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox_custom_port.TabIndex = 108
        Me.CheckBox_custom_port.Text = "自定义端口"
        Me.CheckBox_custom_port.UseVisualStyleBackColor = True
        '
        'CheckBox_pppoe
        '
        Me.CheckBox_pppoe.AutoSize = True
        Me.CheckBox_pppoe.Location = New System.Drawing.Point(336, 41)
        Me.CheckBox_pppoe.Name = "CheckBox_pppoe"
        Me.CheckBox_pppoe.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox_pppoe.TabIndex = 107
        Me.CheckBox_pppoe.Text = "动态IP环境"
        Me.CheckBox_pppoe.UseVisualStyleBackColor = True
        '
        'Label1_status
        '
        Me.Label1_status.AutoSize = True
        Me.Label1_status.Location = New System.Drawing.Point(156, 444)
        Me.Label1_status.Name = "Label1_status"
        Me.Label1_status.Size = New System.Drawing.Size(29, 12)
        Me.Label1_status.TabIndex = 106
        Me.Label1_status.Text = "状态"
        '
        'TextBox_config_path_cfg
        '
        Me.TextBox_config_path_cfg.Location = New System.Drawing.Point(166, 441)
        Me.TextBox_config_path_cfg.Name = "TextBox_config_path_cfg"
        Me.TextBox_config_path_cfg.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_config_path_cfg.TabIndex = 104
        Me.TextBox_config_path_cfg.Text = "config-path=__PATH__executable__/../../config" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "use-system-read-write-data-directo" &
    "ries=false"
        Me.TextBox_config_path_cfg.Visible = False
        '
        'CheckBox_user_game_password
        '
        Me.CheckBox_user_game_password.AutoSize = True
        Me.CheckBox_user_game_password.Location = New System.Drawing.Point(22, 258)
        Me.CheckBox_user_game_password.Name = "CheckBox_user_game_password"
        Me.CheckBox_user_game_password.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox_user_game_password.TabIndex = 103
        Me.CheckBox_user_game_password.Text = "游戏密码:"
        Me.CheckBox_user_game_password.UseVisualStyleBackColor = True
        '
        'TextBox_game_password
        '
        Me.TextBox_game_password.Enabled = False
        Me.TextBox_game_password.Location = New System.Drawing.Point(106, 256)
        Me.TextBox_game_password.Name = "TextBox_game_password"
        Me.TextBox_game_password.Size = New System.Drawing.Size(135, 21)
        Me.TextBox_game_password.TabIndex = 102
        '
        'Button_copy_save
        '
        Me.Button_copy_save.Location = New System.Drawing.Point(389, 103)
        Me.Button_copy_save.Name = "Button_copy_save"
        Me.Button_copy_save.Size = New System.Drawing.Size(75, 23)
        Me.Button_copy_save.TabIndex = 100
        Me.Button_copy_save.Text = "复制"
        Me.Button_copy_save.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "服务器生效存档："
        '
        'TextBox_source_save
        '
        Me.TextBox_source_save.Location = New System.Drawing.Point(97, 70)
        Me.TextBox_source_save.Name = "TextBox_source_save"
        Me.TextBox_source_save.Size = New System.Drawing.Size(286, 21)
        Me.TextBox_source_save.TabIndex = 98
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(389, 68)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 97
        Me.Button2.Text = "浏览"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(347, 142)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 23)
        Me.Button3.TabIndex = 96
        Me.Button3.Text = "Steam版转Zip版"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox_server_intro
        '
        Me.TextBox_server_intro.Location = New System.Drawing.Point(106, 223)
        Me.TextBox_server_intro.Name = "TextBox_server_intro"
        Me.TextBox_server_intro.Size = New System.Drawing.Size(325, 21)
        Me.TextBox_server_intro.TabIndex = 95
        '
        'TextBox_server_name
        '
        Me.TextBox_server_name.Location = New System.Drawing.Point(106, 191)
        Me.TextBox_server_name.Name = "TextBox_server_name"
        Me.TextBox_server_name.Size = New System.Drawing.Size(135, 21)
        Me.TextBox_server_name.TabIndex = 94
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 226)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 12)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "服务器简介:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 194)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 12)
        Me.Label14.TabIndex = 92
        Me.Label14.Text = "服务器名称:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(269, 415)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 23)
        Me.Button1.TabIndex = 91
        Me.Button1.Text = "保存并停止服务"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_check_ip
        '
        Me.Button_check_ip.Location = New System.Drawing.Point(334, 12)
        Me.Button_check_ip.Name = "Button_check_ip"
        Me.Button_check_ip.Size = New System.Drawing.Size(88, 23)
        Me.Button_check_ip.TabIndex = 90
        Me.Button_check_ip.Text = "自动检测IP"
        Me.Button_check_ip.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(20, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(269, 12)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "如自动检测不正确请输入正确IP，否则别人连不上"
        '
        'TextBox_IP
        '
        Me.TextBox_IP.Location = New System.Drawing.Point(73, 14)
        Me.TextBox_IP.Name = "TextBox_IP"
        Me.TextBox_IP.Size = New System.Drawing.Size(112, 21)
        Me.TextBox_IP.TabIndex = 88
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 12)
        Me.Label12.TabIndex = 87
        Me.Label12.Text = "外网IP:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(207, 324)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "0为不限制"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(203, 354)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "分钟"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(20, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(317, 36)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "新建游戏，先在游中创建存档，在此浏览选中后，点复制。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "继续以前的游戏，确认服务器生效存档输入正确即可。"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(191, 295)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 12)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "分钟   0为不踢"
        '
        'ComboBox_auto_pause
        '
        Me.ComboBox_auto_pause.FormattingEnabled = True
        Me.ComboBox_auto_pause.Items.AddRange(New Object() {"是", "否"})
        Me.ComboBox_auto_pause.Location = New System.Drawing.Point(145, 380)
        Me.ComboBox_auto_pause.Name = "ComboBox_auto_pause"
        Me.ComboBox_auto_pause.Size = New System.Drawing.Size(60, 20)
        Me.ComboBox_auto_pause.TabIndex = 82
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 383)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 12)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "服务器无人自动暂停:"
        '
        'TextBox_afk_autokick_interval
        '
        Me.TextBox_afk_autokick_interval.Location = New System.Drawing.Point(85, 292)
        Me.TextBox_afk_autokick_interval.Name = "TextBox_afk_autokick_interval"
        Me.TextBox_afk_autokick_interval.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_afk_autokick_interval.TabIndex = 80
        Me.TextBox_afk_autokick_interval.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 295)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "挂机踢出:"
        '
        'TextBox_autosave_slots
        '
        Me.TextBox_autosave_slots.Location = New System.Drawing.Point(327, 351)
        Me.TextBox_autosave_slots.Name = "TextBox_autosave_slots"
        Me.TextBox_autosave_slots.Size = New System.Drawing.Size(95, 21)
        Me.TextBox_autosave_slots.TabIndex = 78
        Me.TextBox_autosave_slots.Text = "20"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(238, 354)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "自动存盘数量:"
        '
        'TextBox_autosave_interval
        '
        Me.TextBox_autosave_interval.Location = New System.Drawing.Point(133, 351)
        Me.TextBox_autosave_interval.Name = "TextBox_autosave_interval"
        Me.TextBox_autosave_interval.Size = New System.Drawing.Size(64, 21)
        Me.TextBox_autosave_interval.TabIndex = 76
        Me.TextBox_autosave_interval.Text = "60"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 354)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 12)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "自动存盘间隔时间:"
        '
        'TextBox_max_players
        '
        Me.TextBox_max_players.Location = New System.Drawing.Point(97, 321)
        Me.TextBox_max_players.Name = "TextBox_max_players"
        Me.TextBox_max_players.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_max_players.TabIndex = 74
        Me.TextBox_max_players.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 324)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "最大玩家数:"
        '
        'TextBox_saves
        '
        Me.TextBox_saves.Location = New System.Drawing.Point(127, 105)
        Me.TextBox_saves.Name = "TextBox_saves"
        Me.TextBox_saves.Size = New System.Drawing.Size(256, 21)
        Me.TextBox_saves.TabIndex = 72
        Me.TextBox_saves.Text = "my\my.zip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "源存档文件:"
        '
        'Button_create_server
        '
        Me.Button_create_server.Location = New System.Drawing.Point(85, 415)
        Me.Button_create_server.Name = "Button_create_server"
        Me.Button_create_server.Size = New System.Drawing.Size(75, 23)
        Me.Button_create_server.TabIndex = 70
        Me.Button_create_server.Text = "创建"
        Me.Button_create_server.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button6)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(484, 466)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "游戏内创建游戏发布"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(174, 76)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 94
        Me.Button6.Text = "发布"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(255, 21)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 93
        Me.Button5.Text = "自动检测"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(137, 23)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(112, 21)
        Me.TextBox2.TabIndex = 92
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Location = New System.Drawing.Point(84, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 12)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "外网IP:"
        '
        'OpenFileDialog_open_save_zip
        '
        Me.OpenFileDialog_open_save_zip.FileName = "*.zip"
        Me.OpenFileDialog_open_save_zip.Filter = "*.zip|"
        '
        'Label_ver
        '
        Me.Label_ver.AutoSize = True
        Me.Label_ver.Location = New System.Drawing.Point(445, 515)
        Me.Label_ver.Name = "Label_ver"
        Me.Label_ver.Size = New System.Drawing.Size(29, 12)
        Me.Label_ver.TabIndex = 15
        Me.Label_ver.Text = "0.34"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(414, 515)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 12)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Ver:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(93, 515)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(245, 12)
        Me.LinkLabel1.TabIndex = 16
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "意见、建议、问题欢迎发信 57832091@qq.com"
        '
        'Timer_sync_server
        '
        Me.Timer_sync_server.Interval = 600000
        '
        'BackgroundWorker_creact_dsl
        '
        '
        'Button_readme
        '
        Me.Button_readme.Enabled = False
        Me.Button_readme.Location = New System.Drawing.Point(12, 510)
        Me.Button_readme.Name = "Button_readme"
        Me.Button_readme.Size = New System.Drawing.Size(75, 23)
        Me.Button_readme.TabIndex = 105
        Me.Button_readme.Text = "使用说明"
        Me.Button_readme.UseVisualStyleBackColor = True
        '
        'server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 549)
        Me.Controls.Add(Me.Button_readme)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label_ver)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "server"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工厂世界服务端"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox_server_intro As TextBox
    Friend WithEvents TextBox_server_name As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
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
    Friend WithEvents Button_create_server As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents OpenFileDialog_open_save_zip As OpenFileDialog
    Friend WithEvents TextBox_source_save As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Button_copy_save As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button_check_ip As Button
    Friend WithEvents TextBox_IP As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label_ver As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents CheckBox_user_game_password As CheckBox
    Friend WithEvents TextBox_game_password As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Timer_sync_server As Timer
    Friend WithEvents BackgroundWorker_creact_dsl As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextBox_config_path_cfg As TextBox
    Friend WithEvents Button_readme As Button
    Friend WithEvents Label1_status As Label
    Friend WithEvents CheckBox_pppoe As CheckBox
    Friend WithEvents TextBox_port As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents CheckBox_custom_port As CheckBox
End Class
