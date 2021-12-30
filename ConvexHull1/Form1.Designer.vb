<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnConvexHull = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConvexHull
        '
        Me.btnConvexHull.Location = New System.Drawing.Point(474, 13)
        Me.btnConvexHull.Name = "btnConvexHull"
        Me.btnConvexHull.Size = New System.Drawing.Size(107, 35)
        Me.btnConvexHull.TabIndex = 0
        Me.btnConvexHull.Text = "Convex Hull"
        Me.btnConvexHull.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 384)
        Me.Controls.Add(Me.btnConvexHull)
        Me.Name = "Form1"
        Me.Text = "Convex Hull"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConvexHull As System.Windows.Forms.Button

End Class
