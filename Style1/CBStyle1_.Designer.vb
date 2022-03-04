<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CBStyle1_
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.txtHeaderVal = New System.Windows.Forms.TextBox()
        Me.btOpen = New System.Windows.Forms.PictureBox()
        Me.bck_STart = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.btOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHeaderVal
        '
        Me.txtHeaderVal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeaderVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeaderVal.Location = New System.Drawing.Point(0, 0)
        Me.txtHeaderVal.Name = "txtHeaderVal"
        Me.txtHeaderVal.ReadOnly = True
        Me.txtHeaderVal.Size = New System.Drawing.Size(117, 20)
        Me.txtHeaderVal.TabIndex = 1
        '
        'btOpen
        '
        Me.btOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btOpen.Image = Global.XComboGrid.My.Resources.Resources.CBGridDown
        Me.btOpen.Location = New System.Drawing.Point(117, 0)
        Me.btOpen.Name = "btOpen"
        Me.btOpen.Size = New System.Drawing.Size(23, 20)
        Me.btOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btOpen.TabIndex = 2
        Me.btOpen.TabStop = False
        '
        'bck_STart
        '
        Me.bck_STart.WorkerReportsProgress = True
        Me.bck_STart.WorkerSupportsCancellation = True
        '
        'CBStyle1_
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btOpen)
        Me.Controls.Add(Me.txtHeaderVal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CBStyle1_"
        Me.Size = New System.Drawing.Size(140, 20)
        CType(Me.btOpen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHeaderVal As System.Windows.Forms.TextBox
    Friend WithEvents btOpen As System.Windows.Forms.PictureBox
    Friend WithEvents bck_STart As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
