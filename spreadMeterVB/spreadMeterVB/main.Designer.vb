<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.updateButton = New System.Windows.Forms.Button()
        Me.IPsprMax = New System.Windows.Forms.TextBox()
        Me.IPsprMin = New System.Windows.Forms.TextBox()
        Me.IPsprVal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.comCombo = New System.Windows.Forms.ComboBox()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.manualButton = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'updateButton
        '
        Me.updateButton.Enabled = False
        Me.updateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updateButton.Location = New System.Drawing.Point(350, 241)
        Me.updateButton.Name = "updateButton"
        Me.updateButton.Size = New System.Drawing.Size(107, 32)
        Me.updateButton.TabIndex = 0
        Me.updateButton.Text = "Update gauge"
        Me.updateButton.UseVisualStyleBackColor = True
        '
        'IPsprMax
        '
        Me.IPsprMax.Enabled = False
        Me.IPsprMax.Location = New System.Drawing.Point(277, 112)
        Me.IPsprMax.Name = "IPsprMax"
        Me.IPsprMax.Size = New System.Drawing.Size(67, 20)
        Me.IPsprMax.TabIndex = 3
        Me.IPsprMax.Text = "0"
        '
        'IPsprMin
        '
        Me.IPsprMin.Enabled = False
        Me.IPsprMin.Location = New System.Drawing.Point(277, 86)
        Me.IPsprMin.Name = "IPsprMin"
        Me.IPsprMin.Size = New System.Drawing.Size(67, 20)
        Me.IPsprMin.TabIndex = 2
        Me.IPsprMin.Text = "0"
        '
        'IPsprVal
        '
        Me.IPsprVal.Enabled = False
        Me.IPsprVal.Location = New System.Drawing.Point(277, 60)
        Me.IPsprVal.Name = "IPsprVal"
        Me.IPsprVal.Size = New System.Drawing.Size(67, 20)
        Me.IPsprVal.TabIndex = 1
        Me.IPsprVal.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Current spread:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(163, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Max. gauge value:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(166, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Min. gauge value:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(155, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Spread-o-meter control"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "v1.0"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.windowsApplication1.My.Resources.Resources.side
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(134, 290)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(155, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Status:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(155, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Communication port:"
        '
        'comCombo
        '
        Me.comCombo.Enabled = False
        Me.comCombo.FormattingEnabled = True
        Me.comCombo.Location = New System.Drawing.Point(277, 138)
        Me.comCombo.Name = "comCombo"
        Me.comCombo.Size = New System.Drawing.Size(92, 21)
        Me.comCombo.TabIndex = 14
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusLabel.Location = New System.Drawing.Point(155, 195)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(107, 13)
        Me.statusLabel.TabIndex = 15
        Me.statusLabel.Text = "Status text goes here"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Spread-o-meter control"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemShow, Me.itemUpdate, Me.itemExit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 92)
        '
        'itemShow
        '
        Me.itemShow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.itemShow.Name = "itemShow"
        Me.itemShow.Size = New System.Drawing.Size(164, 22)
        Me.itemShow.Text = "Show controls"
        '
        'itemUpdate
        '
        Me.itemUpdate.Name = "itemUpdate"
        Me.itemUpdate.Size = New System.Drawing.Size(164, 22)
        Me.itemUpdate.Text = "Update gauge"
        '
        'itemExit
        '
        Me.itemExit.Name = "itemExit"
        Me.itemExit.Size = New System.Drawing.Size(164, 22)
        Me.itemExit.Text = "Exit"
        '
        'manualButton
        '
        Me.manualButton.Enabled = False
        Me.manualButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.manualButton.Location = New System.Drawing.Point(237, 241)
        Me.manualButton.Name = "manualButton"
        Me.manualButton.Size = New System.Drawing.Size(107, 32)
        Me.manualButton.TabIndex = 16
        Me.manualButton.Text = "Manual update"
        Me.manualButton.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 285)
        Me.Controls.Add(Me.manualButton)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.comCombo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IPsprVal)
        Me.Controls.Add(Me.IPsprMin)
        Me.Controls.Add(Me.IPsprMax)
        Me.Controls.Add(Me.updateButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Spread-o-meter control"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents updateButton As System.Windows.Forms.Button
    Friend WithEvents IPsprMax As System.Windows.Forms.TextBox
    Friend WithEvents IPsprMin As System.Windows.Forms.TextBox
    Friend WithEvents IPsprVal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents comCombo As System.Windows.Forms.ComboBox
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents manualButton As System.Windows.Forms.Button

End Class
