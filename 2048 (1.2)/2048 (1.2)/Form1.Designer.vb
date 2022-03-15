<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Background = New System.Windows.Forms.PictureBox()
        Me.Right_M = New System.Windows.Forms.Timer(Me.components)
        Me.Left_M = New System.Windows.Forms.Timer(Me.components)
        Me.Down_M = New System.Windows.Forms.Timer(Me.components)
        Me.Up_M = New System.Windows.Forms.Timer(Me.components)
        Me.Go_to_the_blocks = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Background, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Background
        '
        Me.Background.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Background.BackgroundImage = Global._2048__1._2_.My.Resources.Resources.Grid_removebg_preview
        Me.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Background.Location = New System.Drawing.Point(0, 28)
        Me.Background.Name = "Background"
        Me.Background.Size = New System.Drawing.Size(520, 519)
        Me.Background.TabIndex = 5
        Me.Background.TabStop = False
        '
        'Right_M
        '
        Me.Right_M.Interval = 25
        '
        'Left_M
        '
        Me.Left_M.Interval = 25
        '
        'Down_M
        '
        Me.Down_M.Interval = 25
        '
        'Up_M
        '
        Me.Up_M.Interval = 25
        '
        'Go_to_the_blocks
        '
        Me.Go_to_the_blocks.Interval = 1000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ExitToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(520, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.NewGameToolStripMenuItem.Text = "New Game"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(38, 20)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 548)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Background)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Background, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents Background As System.Windows.Forms.PictureBox
    Friend WithEvents Right_M As System.Windows.Forms.Timer
    Friend WithEvents Left_M As System.Windows.Forms.Timer
    Friend WithEvents Down_M As System.Windows.Forms.Timer
    Friend WithEvents Up_M As System.Windows.Forms.Timer
    Friend WithEvents Go_to_the_blocks As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents NewGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As ToolStripMenuItem
End Class
