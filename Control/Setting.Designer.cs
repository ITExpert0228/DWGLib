namespace DwgLib.Dialog
{
    partial class Setting
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Set = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Restore = new System.Windows.Forms.Button();
            this.DateLabel = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.PathShow = new System.Windows.Forms.RichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Set.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 108);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(3);
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择路径";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SelectDirectory);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "配置路径|SETTING";
            // 
            // Set
            // 
            this.Set.Controls.Add(this.label2);
            this.Set.Controls.Add(this.Restore);
            this.Set.Controls.Add(this.DateLabel);
            this.Set.Controls.Add(this.Version);
            this.Set.Controls.Add(this.AboutBtn);
            this.Set.Controls.Add(this.PathShow);
            this.Set.Controls.Add(this.button1);
            this.Set.Controls.Add(this.label1);
            this.Set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Set.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Set.Location = new System.Drawing.Point(15, 15);
            this.Set.Margin = new System.Windows.Forms.Padding(15);
            this.Set.Name = "Set";
            this.Set.Padding = new System.Windows.Forms.Padding(15);
            this.Set.Size = new System.Drawing.Size(264, 495);
            this.Set.TabIndex = 3;
            this.Set.TabStop = false;
            this.Set.Text = "设置";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(18, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 2);
            this.label2.TabIndex = 8;
            // 
            // Restore
            // 
            this.Restore.Location = new System.Drawing.Point(169, 108);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(75, 32);
            this.Restore.TabIndex = 7;
            this.Restore.Text = "重置";
            this.Restore.UseVisualStyleBackColor = true;
            this.Restore.Click += new System.EventHandler(this.ReStore);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(16, 351);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(59, 12);
            this.DateLabel.TabIndex = 6;
            this.DateLabel.Text = "2017.3.28";
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(16, 323);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(71, 12);
            this.Version.TabIndex = 5;
            this.Version.Text = "Version 1.0";
            // 
            // AboutBtn
            // 
            this.AboutBtn.Location = new System.Drawing.Point(18, 271);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(75, 32);
            this.AboutBtn.TabIndex = 4;
            this.AboutBtn.Text = "关于";
            this.AboutBtn.UseVisualStyleBackColor = true;
            this.AboutBtn.Click += new System.EventHandler(this.About);
            // 
            // PathShow
            // 
            this.PathShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathShow.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PathShow.Enabled = false;
            this.PathShow.Location = new System.Drawing.Point(18, 164);
            this.PathShow.Name = "PathShow";
            this.PathShow.Size = new System.Drawing.Size(226, 85);
            this.PathShow.TabIndex = 3;
            this.PathShow.Text = "配置的路径将显示在这里";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Set);
            this.Name = "Setting";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(294, 525);
            this.Set.ResumeLayout(false);
            this.Set.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Set;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Button AboutBtn;
        public System.Windows.Forms.RichTextBox PathShow;
        private System.Windows.Forms.Button Restore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
