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
        Me.SuspendLayout()
        '
        'Label_status
        '
        Me.Label_status.AutoSize = True
        Me.Label_status.Location = New System.Drawing.Point(124, 70)
        Me.Label_status.Name = "Label_status"
        Me.Label_status.Size = New System.Drawing.Size(23, 12)
        Me.Label_status.TabIndex = 1
        Me.Label_status.Text = "..."
        Me.Label_status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox_up_com
        '
        Me.TextBox_up_com.Enabled = False
        Me.TextBox_up_com.Location = New System.Drawing.Point(12, 7)
        Me.TextBox_up_com.Multiline = True
        Me.TextBox_up_com.Name = "TextBox_up_com"
        Me.TextBox_up_com.Size = New System.Drawing.Size(315, 140)
        Me.TextBox_up_com.TabIndex = 11
        Me.TextBox_up_com.Text = "@echo off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "echo 正在更新..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 2 >nul" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "up_data.exe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 2 > nul" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "del up_dat" &
    "a.exe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "echo 更新完成" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timeout 1 > nul" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "start 工厂世界.exe"
        Me.TextBox_up_com.Visible = False
        '
        'BackgroundWorker_check_ver
        '
        Me.BackgroundWorker_check_ver.WorkerReportsProgress = True
        Me.BackgroundWorker_check_ver.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_download_updata
        '
        '
        'Timer_chech_ver_time_out
        '
        Me.Timer_chech_ver_time_out.Enabled = True
        Me.Timer_chech_ver_time_out.Interval = 30000
        '
        'form_updata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 159)
        Me.Controls.Add(Me.TextBox_up_com)
        Me.Controls.Add(Me.Label_status)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "form_updata"
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
End Class
