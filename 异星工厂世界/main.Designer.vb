﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_main))
        Me.TextBox_chat_vbs = New System.Windows.Forms.TextBox()
        Me.Button_updata = New System.Windows.Forms.Button()
        Me.Label_Ver_No = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TextBox_serverlist = New System.Windows.Forms.TextBox()
        Me.Button_join = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CheckBox_chinese_chat = New System.Windows.Forms.CheckBox()
        Me.TextBox_up_com = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker_download_serverlist = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox_chat_vbs
        '
        Me.TextBox_chat_vbs.Location = New System.Drawing.Point(249, 387)
        Me.TextBox_chat_vbs.Name = "TextBox_chat_vbs"
        Me.TextBox_chat_vbs.Size = New System.Drawing.Size(116, 21)
        Me.TextBox_chat_vbs.TabIndex = 2
        Me.TextBox_chat_vbs.Text = resources.GetString("TextBox_chat_vbs.Text")
        Me.TextBox_chat_vbs.Visible = False
        '
        'Button_updata
        '
        Me.Button_updata.Location = New System.Drawing.Point(371, 386)
        Me.Button_updata.Name = "Button_updata"
        Me.Button_updata.Size = New System.Drawing.Size(75, 23)
        Me.Button_updata.TabIndex = 3
        Me.Button_updata.Text = "检测更新"
        Me.Button_updata.UseVisualStyleBackColor = True
        '
        'Label_Ver_No
        '
        Me.Label_Ver_No.AutoSize = True
        Me.Label_Ver_No.Location = New System.Drawing.Point(487, 391)
        Me.Label_Ver_No.Name = "Label_Ver_No"
        Me.Label_Ver_No.Size = New System.Drawing.Size(23, 12)
        Me.Label_Ver_No.TabIndex = 5
        Me.Label_Ver_No.Text = "0.4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(452, 391)
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
        Me.ColumnHeader1.Width = 130
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "介绍"
        Me.ColumnHeader2.Width = 218
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "状态"
        Me.ColumnHeader3.Width = 59
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ping"
        Me.ColumnHeader4.Width = 54
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
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
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox_serverlist)
        Me.TabPage1.Controls.Add(Me.Button_join)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(479, 342)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "连如服务器"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TextBox_serverlist
        '
        Me.TextBox_serverlist.Enabled = False
        Me.TextBox_serverlist.Location = New System.Drawing.Point(365, 313)
        Me.TextBox_serverlist.Multiline = True
        Me.TextBox_serverlist.Name = "TextBox_serverlist"
        Me.TextBox_serverlist.Size = New System.Drawing.Size(100, 21)
        Me.TextBox_serverlist.TabIndex = 10
        Me.TextBox_serverlist.Text = "服1" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍1" & Global.Microsoft.VisualBasic.ChrW(9) & "时间1" & Global.Microsoft.VisualBasic.ChrW(9) & "ip1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服2" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍2" & Global.Microsoft.VisualBasic.ChrW(9) & "时间2" & Global.Microsoft.VisualBasic.ChrW(9) & "ip2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服3" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍3" & Global.Microsoft.VisualBasic.ChrW(9) & "时间3" & Global.Microsoft.VisualBasic.ChrW(9) & "ip3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "服4" & Global.Microsoft.VisualBasic.ChrW(9) & "介绍4" & Global.Microsoft.VisualBasic.ChrW(9) & "时间4" & Global.Microsoft.VisualBasic.ChrW(9) & "ip4"
        Me.TextBox_serverlist.Visible = False
        '
        'Button_join
        '
        Me.Button_join.Enabled = False
        Me.Button_join.Location = New System.Drawing.Point(185, 313)
        Me.Button_join.Name = "Button_join"
        Me.Button_join.Size = New System.Drawing.Size(127, 23)
        Me.Button_join.TabIndex = 7
        Me.Button_join.Text = "正在载入服务器列表"
        Me.Button_join.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(479, 342)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "创建服务器"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(7, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(466, 142)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "服务器选项"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 152)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "地图选项"
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(202, 313)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "创建"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(264, 386)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "测试添加"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'CheckBox_chinese_chat
        '
        Me.CheckBox_chinese_chat.AutoSize = True
        Me.CheckBox_chinese_chat.Checked = True
        Me.CheckBox_chinese_chat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_chinese_chat.Location = New System.Drawing.Point(12, 391)
        Me.CheckBox_chinese_chat.Name = "CheckBox_chinese_chat"
        Me.CheckBox_chinese_chat.Size = New System.Drawing.Size(330, 16)
        Me.CheckBox_chinese_chat.TabIndex = 9
        Me.CheckBox_chinese_chat.Text = "中文聊天支持（Ctrl+~激活输入窗口），只支持0.15.37版"
        Me.CheckBox_chinese_chat.UseVisualStyleBackColor = True
        '
        'TextBox_up_com
        '
        Me.TextBox_up_com.Enabled = False
        Me.TextBox_up_com.Location = New System.Drawing.Point(300, 386)
        Me.TextBox_up_com.Name = "TextBox_up_com"
        Me.TextBox_up_com.Size = New System.Drawing.Size(39, 21)
        Me.TextBox_up_com.TabIndex = 10
        Me.TextBox_up_com.Text = "@echo off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "up_data.exe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "异星工厂世界.exe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "del up_data.exe"
        Me.TextBox_up_com.Visible = False
        '
        'BackgroundWorker_download_serverlist
        '
        '
        'Form_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 413)
        Me.Controls.Add(Me.TextBox_up_com)
        Me.Controls.Add(Me.CheckBox_chinese_chat)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label_Ver_No)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button_updata)
        Me.Controls.Add(Me.TextBox_chat_vbs)
        Me.Name = "Form_main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "异星工厂世界"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_chat_vbs As TextBox
    Friend WithEvents Button_updata As Button
    Friend WithEvents Label_Ver_No As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button_join As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox_chinese_chat As CheckBox
    Friend WithEvents TextBox_serverlist As TextBox
    Friend WithEvents TextBox_up_com As TextBox
    Friend WithEvents BackgroundWorker_download_serverlist As System.ComponentModel.BackgroundWorker
End Class
