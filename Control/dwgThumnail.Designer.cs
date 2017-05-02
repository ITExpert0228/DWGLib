namespace DwgLib.Controls
{
    partial class DwgThumnail
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.Thumnail = new System.Windows.Forms.PictureBox();
        this.FileName = new System.Windows.Forms.Label();
        this.DwgTooltip = new System.Windows.Forms.ToolTip(this.components);
        this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.LinkBlock = new System.Windows.Forms.ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)(this.Thumnail)).BeginInit();
        this.ContextMenuStrip.SuspendLayout();
        this.SuspendLayout();
        // 
        // Thumnail
        // 
        this.Thumnail.BackColor = System.Drawing.Color.Transparent;
        this.Thumnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.Thumnail.Cursor = System.Windows.Forms.Cursors.Arrow;
        this.Thumnail.Dock = System.Windows.Forms.DockStyle.Top;
        this.Thumnail.Location = new System.Drawing.Point(0, 0);
        this.Thumnail.Margin = new System.Windows.Forms.Padding(0);
        this.Thumnail.Name = "Thumnail";
        this.Thumnail.Padding = new System.Windows.Forms.Padding(2);
        this.Thumnail.Size = new System.Drawing.Size(70, 50);
        this.Thumnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        this.Thumnail.TabIndex = 0;
        this.Thumnail.TabStop = false;
        this.Thumnail.Click += new System.EventHandler(this.DwgThumnail_Click);
        this.Thumnail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Thumbnail_MouseDown);
        this.Thumnail.MouseEnter += new System.EventHandler(this.Thumnail_Mouse_Enter);
        this.Thumnail.MouseLeave += new System.EventHandler(this.Thumbnail_MouseLeave);
        this.Thumnail.MouseHover += new System.EventHandler(this.DwgThumnail_MouseHover);
        this.Thumnail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragDwgFile);
        this.Thumnail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Thumbnail_MouseUp);
        // 
        // FileName
        // 
        this.FileName.AccessibleName = "FileName";
        this.FileName.AutoEllipsis = true;
        this.FileName.Dock = System.Windows.Forms.DockStyle.Fill;
        this.FileName.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        this.FileName.ForeColor = System.Drawing.Color.Black;
        this.FileName.Location = new System.Drawing.Point(0, 50);
        this.FileName.Margin = new System.Windows.Forms.Padding(0);
        this.FileName.Name = "FileName";
        this.FileName.Size = new System.Drawing.Size(70, 20);
        this.FileName.TabIndex = 1;
        this.FileName.Text = "DWG文件名称";
        this.FileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // DwgTooltip
        // 
        this.DwgTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        // 
        // ContextMenuStrip
        // 
        this.ContextMenuStrip.AllowDrop = true;
        this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LinkBlock});
        this.ContextMenuStrip.Name = "ContextMenuStrip";
        this.ContextMenuStrip.ShowCheckMargin = true;
        this.ContextMenuStrip.Size = new System.Drawing.Size(149, 26);
        this.ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
        this.ContextMenuStrip.Click += new System.EventHandler(this._ContextMenu_Item_Click);
        // 
        // LinkBlock
        // 
        this.LinkBlock.Name = "LinkBlock";
        this.LinkBlock.Size = new System.Drawing.Size(148, 22);
        this.LinkBlock.Text = "链接图块";
        // 
        // DwgThumnail
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.Controls.Add(this.FileName);
        this.Controls.Add(this.Thumnail);
        this.Cursor = System.Windows.Forms.Cursors.Arrow;
        this.DoubleBuffered = true;
        this.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        this.Name = "DwgThumnail";
        this.Size = new System.Drawing.Size(70, 70);
        this.Click += new System.EventHandler(this.DwgThumnail_Click);
        this.MouseClick += new System.Windows.Forms.MouseEventHandler(this._Context_Menu);
        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragDwgFile);
        ((System.ComponentModel.ISupportInitialize)(this.Thumnail)).EndInit();
        this.ContextMenuStrip.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ToolTip DwgTooltip;
    public System.Windows.Forms.Label FileName;
    public System.Windows.Forms.PictureBox Thumnail;
    public System.Windows.Forms.ToolStripMenuItem LinkBlock;
    public System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
}
}
