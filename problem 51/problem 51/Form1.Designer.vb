﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Problem51
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
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblAnswer = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.txtAnswer = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(11, 46)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(93, 13)
        Me.lblTime.TabIndex = 11
        Me.lblTime.Text = "Time Taken (sec):"
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Location = New System.Drawing.Point(11, 15)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(45, 13)
        Me.lblAnswer.TabIndex = 10
        Me.lblAnswer.Text = "Answer:"
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(110, 43)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(115, 20)
        Me.txtTime.TabIndex = 9
        '
        'txtAnswer
        '
        Me.txtAnswer.Location = New System.Drawing.Point(62, 12)
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.Size = New System.Drawing.Size(163, 20)
        Me.txtAnswer.TabIndex = 8
        '
        'Problem51
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 95)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblAnswer)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.txtAnswer)
        Me.Name = "Problem51"
        Me.Text = "Problem51"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblAnswer As System.Windows.Forms.Label
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents txtAnswer As System.Windows.Forms.TextBox

End Class
