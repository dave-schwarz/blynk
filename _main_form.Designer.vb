<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _initial_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_initial_Form))
        Me._Notify_Icon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me._chkbox_Never_Green = New System.Windows.Forms.CheckBox()
        Me._radio_button_Presence = New System.Windows.Forms.RadioButton()
        Me._radio_button_Call_Status = New System.Windows.Forms.RadioButton()
        Me._Color_Status_Box = New System.Windows.Forms.PictureBox()
        Me._label_Status = New System.Windows.Forms.Label()
        Me._Flash_Timer = New System.Timers.Timer()
        Me._Chk_box_Auto_start = New System.Windows.Forms.CheckBox()
        Me._btn_Minimise = New System.Windows.Forms.Button()
        Me._menu_Main = New System.Windows.Forms.MenuStrip()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutBlynkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me._Color_Status_Box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Flash_Timer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._menu_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        '_Notify_Icon
        '
        Me._Notify_Icon.Icon = CType(resources.GetObject("_Notify_Icon.Icon"), System.Drawing.Icon)
        Me._Notify_Icon.Text = "Blynk"
        Me._Notify_Icon.Visible = True
        '
        '_chkbox_Never_Green
        '
        Me._chkbox_Never_Green.AccessibleDescription = "Never change color to Green, handles laptops that may be unpluged and leave the b" & _
    "link in a default color like green for ever"
        Me._chkbox_Never_Green.AutoSize = True
        Me._chkbox_Never_Green.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._chkbox_Never_Green.Location = New System.Drawing.Point(36, 132)
        Me._chkbox_Never_Green.Name = "_chkbox_Never_Green"
        Me._chkbox_Never_Green.Size = New System.Drawing.Size(142, 24)
        Me._chkbox_Never_Green.TabIndex = 2
        Me._chkbox_Never_Green.Text = "Never go Green"
        Me._chkbox_Never_Green.UseVisualStyleBackColor = True
        '
        '_radio_button_Presence
        '
        Me._radio_button_Presence.AutoSize = True
        Me._radio_button_Presence.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._radio_button_Presence.Location = New System.Drawing.Point(36, 68)
        Me._radio_button_Presence.Name = "_radio_button_Presence"
        Me._radio_button_Presence.Size = New System.Drawing.Size(265, 24)
        Me._radio_button_Presence.TabIndex = 3
        Me._radio_button_Presence.TabStop = True
        Me._radio_button_Presence.Text = "Enable Presence and Call Status"
        Me._radio_button_Presence.UseVisualStyleBackColor = True
        '
        '_radio_button_Call_Status
        '
        Me._radio_button_Call_Status.AutoSize = True
        Me._radio_button_Call_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._radio_button_Call_Status.Location = New System.Drawing.Point(36, 100)
        Me._radio_button_Call_Status.Name = "_radio_button_Call_Status"
        Me._radio_button_Call_Status.Size = New System.Drawing.Size(198, 24)
        Me._radio_button_Call_Status.TabIndex = 4
        Me._radio_button_Call_Status.TabStop = True
        Me._radio_button_Call_Status.Text = "Enable Call Status Only"
        Me._radio_button_Call_Status.UseVisualStyleBackColor = True
        '
        '_Color_Status_Box
        '
        Me._Color_Status_Box.Location = New System.Drawing.Point(350, 72)
        Me._Color_Status_Box.Name = "_Color_Status_Box"
        Me._Color_Status_Box.Size = New System.Drawing.Size(309, 54)
        Me._Color_Status_Box.TabIndex = 5
        Me._Color_Status_Box.TabStop = False
        '
        '_label_Status
        '
        Me._label_Status.AutoSize = True
        Me._label_Status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._label_Status.Location = New System.Drawing.Point(345, 25)
        Me._label_Status.Name = "_label_Status"
        Me._label_Status.Size = New System.Drawing.Size(0, 20)
        Me._label_Status.TabIndex = 6
        '
        '_Flash_Timer
        '
        Me._Flash_Timer.AutoReset = False
        Me._Flash_Timer.Interval = 2000.0R
        Me._Flash_Timer.SynchronizingObject = Me
        '
        '_Chk_box_Auto_start
        '
        Me._Chk_box_Auto_start.AutoSize = True
        Me._Chk_box_Auto_start.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Chk_box_Auto_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._Chk_box_Auto_start.Location = New System.Drawing.Point(36, 166)
        Me._Chk_box_Auto_start.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me._Chk_box_Auto_start.Name = "_Chk_box_Auto_start"
        Me._Chk_box_Auto_start.Size = New System.Drawing.Size(98, 24)
        Me._Chk_box_Auto_start.TabIndex = 7
        Me._Chk_box_Auto_start.Text = "Auto Run"
        Me._Chk_box_Auto_start.UseVisualStyleBackColor = True
        '
        '_btn_Minimise
        '
        Me._btn_Minimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._btn_Minimise.Location = New System.Drawing.Point(512, 152)
        Me._btn_Minimise.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me._btn_Minimise.Name = "_btn_Minimise"
        Me._btn_Minimise.Size = New System.Drawing.Size(147, 72)
        Me._btn_Minimise.TabIndex = 9
        Me._btn_Minimise.Text = "Minimise"
        Me._btn_Minimise.UseVisualStyleBackColor = True
        '
        '_menu_Main
        '
        Me._menu_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem, Me.FileToolStripMenuItem})
        Me._menu_Main.Location = New System.Drawing.Point(0, 0)
        Me._menu_Main.Name = "_menu_Main"
        Me._menu_Main.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me._menu_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._menu_Main.Size = New System.Drawing.Size(707, 35)
        Me._menu_Main.TabIndex = 10
        Me._menu_Main.Text = "Menu"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewHelpToolStripMenuItem, Me.ToolStripMenuItem1, Me.AboutBlynkToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(58, 29)
        Me.HelpToolStripMenuItem.Text = "help"
        '
        'ViewHelpToolStripMenuItem
        '
        Me.ViewHelpToolStripMenuItem.Name = "ViewHelpToolStripMenuItem"
        Me.ViewHelpToolStripMenuItem.Size = New System.Drawing.Size(181, 30)
        Me.ViewHelpToolStripMenuItem.Text = "View Help"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(178, 6)
        '
        'AboutBlynkToolStripMenuItem
        '
        Me.AboutBlynkToolStripMenuItem.Name = "AboutBlynkToolStripMenuItem"
        Me.AboutBlynkToolStripMenuItem.Size = New System.Drawing.Size(181, 30)
        Me.AboutBlynkToolStripMenuItem.Text = "About Blynk"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(50, 29)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(111, 30)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        Me.ExitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        '_initial_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(707, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me._btn_Minimise)
        Me.Controls.Add(Me._Chk_box_Auto_start)
        Me.Controls.Add(Me._label_Status)
        Me.Controls.Add(Me._Color_Status_Box)
        Me.Controls.Add(Me._radio_button_Call_Status)
        Me.Controls.Add(Me._radio_button_Presence)
        Me.Controls.Add(Me._chkbox_Never_Green)
        Me.Controls.Add(Me._menu_Main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me._menu_Main
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "_initial_Form"
        Me.Text = "Blynk(1) - A lync light for blink"
        CType(Me._Color_Status_Box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Flash_Timer, System.ComponentModel.ISupportInitialize).EndInit()
        Me._menu_Main.ResumeLayout(False)
        Me._menu_Main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _Notify_Icon As System.Windows.Forms.NotifyIcon
    Friend WithEvents _chkbox_Never_Green As System.Windows.Forms.CheckBox
    Friend WithEvents _radio_button_Presence As System.Windows.Forms.RadioButton
    Friend WithEvents _radio_button_Call_Status As System.Windows.Forms.RadioButton
    Friend WithEvents _Color_Status_Box As System.Windows.Forms.PictureBox
    Friend WithEvents _label_Status As System.Windows.Forms.Label
    Friend WithEvents _Flash_Timer As System.Timers.Timer
    Friend WithEvents _Chk_box_Auto_start As System.Windows.Forms.CheckBox
    Friend WithEvents _btn_Minimise As System.Windows.Forms.Button
    Friend WithEvents _menu_Main As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutBlynkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
