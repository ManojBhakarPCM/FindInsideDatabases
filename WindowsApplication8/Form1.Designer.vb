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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.menuPanel = New System.Windows.Forms.Panel()
        Me.chkSearchSqlite = New System.Windows.Forms.CheckBox()
        Me.chkSearchVCF = New System.Windows.Forms.CheckBox()
        Me.chkSearchXLSX = New System.Windows.Forms.CheckBox()
        Me.chkUseCache = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.sst = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.menuPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.sst.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1308, 688)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 47)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbSearch
        '
        Me.tbSearch.BackColor = System.Drawing.Color.White
        Me.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearch.ForeColor = System.Drawing.Color.Black
        Me.tbSearch.Location = New System.Drawing.Point(20, 5)
        Me.tbSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(265, 31)
        Me.tbSearch.TabIndex = 1
        Me.tbSearch.Text = "manoj"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 190)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(568, 228)
        Me.ListBox1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(1, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(664, 771)
        Me.Panel1.TabIndex = 4
        '
        'menuPanel
        '
        Me.menuPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.menuPanel.Controls.Add(Me.chkSearchSqlite)
        Me.menuPanel.Controls.Add(Me.chkSearchVCF)
        Me.menuPanel.Controls.Add(Me.chkSearchXLSX)
        Me.menuPanel.Controls.Add(Me.chkUseCache)
        Me.menuPanel.Controls.Add(Me.ListBox1)
        Me.menuPanel.Location = New System.Drawing.Point(93, 48)
        Me.menuPanel.Name = "menuPanel"
        Me.menuPanel.Size = New System.Drawing.Size(569, 418)
        Me.menuPanel.TabIndex = 13
        Me.menuPanel.Visible = False
        '
        'chkSearchSqlite
        '
        Me.chkSearchSqlite.AutoSize = True
        Me.chkSearchSqlite.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSearchSqlite.ForeColor = System.Drawing.Color.White
        Me.chkSearchSqlite.Location = New System.Drawing.Point(13, 91)
        Me.chkSearchSqlite.Name = "chkSearchSqlite"
        Me.chkSearchSqlite.Size = New System.Drawing.Size(140, 23)
        Me.chkSearchSqlite.TabIndex = 16
        Me.chkSearchSqlite.Text = "Search Sqlite db"
        Me.chkSearchSqlite.UseVisualStyleBackColor = True
        '
        'chkSearchVCF
        '
        Me.chkSearchVCF.AutoSize = True
        Me.chkSearchVCF.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSearchVCF.ForeColor = System.Drawing.Color.White
        Me.chkSearchVCF.Location = New System.Drawing.Point(13, 64)
        Me.chkSearchVCF.Name = "chkSearchVCF"
        Me.chkSearchVCF.Size = New System.Drawing.Size(105, 23)
        Me.chkSearchVCF.TabIndex = 15
        Me.chkSearchVCF.Text = "Search VCF"
        Me.chkSearchVCF.UseVisualStyleBackColor = True
        '
        'chkSearchXLSX
        '
        Me.chkSearchXLSX.AutoSize = True
        Me.chkSearchXLSX.Checked = True
        Me.chkSearchXLSX.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchXLSX.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSearchXLSX.ForeColor = System.Drawing.Color.White
        Me.chkSearchXLSX.Location = New System.Drawing.Point(13, 38)
        Me.chkSearchXLSX.Name = "chkSearchXLSX"
        Me.chkSearchXLSX.Size = New System.Drawing.Size(113, 23)
        Me.chkSearchXLSX.TabIndex = 14
        Me.chkSearchXLSX.Text = "Search XLSX"
        Me.chkSearchXLSX.UseVisualStyleBackColor = True
        '
        'chkUseCache
        '
        Me.chkUseCache.AutoSize = True
        Me.chkUseCache.Checked = True
        Me.chkUseCache.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseCache.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseCache.ForeColor = System.Drawing.Color.White
        Me.chkUseCache.Location = New System.Drawing.Point(13, 12)
        Me.chkUseCache.Name = "chkUseCache"
        Me.chkUseCache.Size = New System.Drawing.Size(183, 23)
        Me.chkUseCache.TabIndex = 13
        Me.chkUseCache.Text = "Use Cached Search List"
        Me.chkUseCache.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1064, 478)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.btnMenu)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(664, 45)
        Me.Panel2.TabIndex = 6
        '
        'btnMenu
        '
        Me.btnMenu.BackColor = System.Drawing.Color.Gray
        Me.btnMenu.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnMenu.FlatAppearance.BorderSize = 0
        Me.btnMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu.Image = CType(resources.GetObject("btnMenu.Image"), System.Drawing.Image)
        Me.btnMenu.Location = New System.Drawing.Point(612, 0)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(52, 45)
        Me.btnMenu.TabIndex = 1
        Me.btnMenu.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.tbSearch)
        Me.Panel3.Location = New System.Drawing.Point(3, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(318, 42)
        Me.Panel3.TabIndex = 0
        '
        'sst
        '
        Me.sst.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.sst.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1})
        Me.sst.Location = New System.Drawing.Point(0, 822)
        Me.sst.Name = "sst"
        Me.sst.Size = New System.Drawing.Size(665, 22)
        Me.sst.TabIndex = 7
        Me.sst.Text = "Status Strip"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1145, 478)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 844)
        Me.Controls.Add(Me.menuPanel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.sst)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Find Row inside Databases"
        Me.menuPanel.ResumeLayout(False)
        Me.menuPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.sst.ResumeLayout(False)
        Me.sst.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents tbSearch As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents sst As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Button3 As Button
    Friend WithEvents menuPanel As Panel
    Friend WithEvents chkSearchSqlite As CheckBox
    Friend WithEvents chkSearchVCF As CheckBox
    Friend WithEvents chkSearchXLSX As CheckBox
    Friend WithEvents chkUseCache As CheckBox
    Friend WithEvents btnMenu As Button
End Class
