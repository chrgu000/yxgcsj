<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_updata
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_updata))
        Me.Label_status = New System.Windows.Forms.Label()
        Me.TextBox_up_com = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker_check_ver = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_download_updata = New System.ComponentModel.BackgroundWorker()
        Me.Timer_chech_ver_time_out = New System.Windows.Forms.Timer(Me.components)
        Me.Button_fix = New System.Windows.Forms.Button()
        Me.Button_hide = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label_status
        '
        Me.Label_status.AutoSize = True
        Me.Label_status.Location = New System.Drawing.Point(128, 23)
        Me.Label_status.Name = "Label_status"
        Me.Label_status.Size = New System.Drawing.Size(23, 12)
        Me.Label_status.TabIndex = 1
        Me.Label_status.Text = "..."
        Me.Label_status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox_up_com
        '
        Me.TextBox_up_com.Enabled = False
        Me.TextBox_up_com.Location = New System.Drawing.Point(236, 12)
        Me.TextBox_up_com.Multiline = True
        Me.TextBox_up_com.Name = "TextBox_up_com"
        Me.TextBox_up_com.Size = New System.Drawing.Size(91, 135)
        Me.TextBox_up_com.TabIndex = 11
        Me.TextBox_up_com.Text = "@echo off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "echo 正在更新..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 2 >nul" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "up_data.exe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 2 > nul" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "del up_dat" &
    "a.exe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "rd .\data\facw\web /s /q" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "echo 更新完成" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 1 > nul" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "start 工厂世界服务端.exe"
        Me.TextBox_up_com.Visible = False
        '
        'BackgroundWorker_check_ver
        '
        Me.BackgroundWorker_check_ver.WorkerReportsProgress = True
        Me.BackgroundWorker_check_ver.WorkerSupportsCancellation = True
        '
        'Timer_chech_ver_time_out
        '
        Me.Timer_chech_ver_time_out.Enabled = True
        Me.Timer_chech_ver_time_out.Interval = 30000
        '
        'Button_fix
        '
        Me.Button_fix.Location = New System.Drawing.Point(63, 105)
        Me.Button_fix.Name = "Button_fix"
        Me.Button_fix.Size = New System.Drawing.Size(75, 23)
        Me.Button_fix.TabIndex = 12
        Me.Button_fix.Text = "强制修复"
        Me.Button_fix.UseVisualStyleBackColor = True
        '
        'Button_hide
        '
        Me.Button_hide.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_hide.Location = New System.Drawing.Point(198, 105)
        Me.Button_hide.Name = "Button_hide"
        Me.Button_hide.Size = New System.Drawing.Size(75, 23)
        Me.Button_hide.TabIndex = 13
        Me.Button_hide.Text = "关闭"
        Me.Button_hide.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(63, 59)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar1.TabIndex = 14
        '
        'form_updata
        '
        Me.AcceptButton = Me.Button_fix
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_hide
        Me.ClientSize = New System.Drawing.Size(337, 159)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button_hide)
        Me.Controls.Add(Me.Button_fix)
        Me.Controls.Add(Me.TextBox_up_com)
        Me.Controls.Add(Me.Label_status)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "form_updata"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工厂世界更新工具"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_status As Label
    Friend WithEvents TextBox_up_com As TextBox
    Friend WithEvents BackgroundWorker_check_ver As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_download_updata As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer_chech_ver_time_out As Timer
    Friend WithEvents Button_fix As Button
    Friend WithEvents Button_hide As Button
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
