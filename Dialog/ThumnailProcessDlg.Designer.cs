namespace DwgLib.Dialog
{
    partial class ThumnailProcessDlg
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThumnailProcessDlg));
            this.FileBrowser = new System.Windows.Forms.Button();
            this.startProcess = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.RootPath = new System.Windows.Forms.Label();
            this.CurrentProcessLabel = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this._processPer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileBrowser
            // 
            this.FileBrowser.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileBrowser.Location = new System.Drawing.Point(26, 42);
            this.FileBrowser.Name = "FileBrowser";
            this.FileBrowser.Size = new System.Drawing.Size(88, 31);
            this.FileBrowser.TabIndex = 7;
            this.FileBrowser.Text = "选择文件夹";
            this.FileBrowser.UseVisualStyleBackColor = true;
            this.FileBrowser.Click += new System.EventHandler(this.Folder_Browser);
            // 
            // startProcess
            // 
            this.startProcess.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startProcess.Location = new System.Drawing.Point(133, 41);
            this.startProcess.Name = "startProcess";
            this.startProcess.Size = new System.Drawing.Size(73, 32);
            this.startProcess.TabIndex = 12;
            this.startProcess.Text = "处理";
            this.startProcess.UseVisualStyleBackColor = true;
            this.startProcess.Click += new System.EventHandler(this.Start_Process);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(26, 138);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(475, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 13;
            // 
            // RootPath
            // 
            this.RootPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootPath.AutoEllipsis = true;
            this.RootPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RootPath.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RootPath.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RootPath.Location = new System.Drawing.Point(23, 86);
            this.RootPath.Name = "RootPath";
            this.RootPath.Size = new System.Drawing.Size(425, 37);
            this.RootPath.TabIndex = 14;
            this.RootPath.Text = "这里显示文件处理根目录";
            this.RootPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentProcessLabel
            // 
            this.CurrentProcessLabel.AutoEllipsis = true;
            this.CurrentProcessLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentProcessLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CurrentProcessLabel.Location = new System.Drawing.Point(23, 171);
            this.CurrentProcessLabel.Name = "CurrentProcessLabel";
            this.CurrentProcessLabel.Size = new System.Drawing.Size(478, 41);
            this.CurrentProcessLabel.TabIndex = 15;
            this.CurrentProcessLabel.Text = "这里显示当前处理文件";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorker_Completed);
            // 
            // _processPer
            // 
            this._processPer.AutoSize = true;
            this._processPer.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._processPer.Location = new System.Drawing.Point(475, 106);
            this._processPer.Name = "_processPer";
            this._processPer.Size = new System.Drawing.Size(26, 17);
            this._processPer.TabIndex = 16;
            this._processPer.Text = "0%";
            this._processPer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ThumnailProcessDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(527, 231);
            this.Controls.Add(this._processPer);
            this.Controls.Add(this.CurrentProcessLabel);
            this.Controls.Add(this.RootPath);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startProcess);
            this.Controls.Add(this.FileBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(543, 270);
            this.MinimumSize = new System.Drawing.Size(543, 270);
            this.Name = "ThumnailProcessDlg";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "缩略图生成工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_Close);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ThumnailProcessDlg_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button FileBrowser;
        public System.Windows.Forms.Button startProcess;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Label RootPath;
        private System.Windows.Forms.Label CurrentProcessLabel;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label _processPer;
    }
}