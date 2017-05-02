using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DwgLib.Class;

namespace DwgLib.Dialog
{
    public partial class ThumnailProcessDlg : Form
    {
        public int ProcessPercent;
        public bool isProcessed;
        public string CurrentProcess;
        ThumnailProcess thumnailProcess;
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "output.log";
        private StreamWriter StreamWriter;
        List<string> fileList;
        public ThumnailProcessDlg(int ProcessPercent,bool isProcess,string CurrentProcess)
        {
            InitializeComponent();
            this.thumnailProcess = new ThumnailProcess();
        }
        private void Folder_Browser(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                this.RootPath.Text = folderDlg.SelectedPath;
            }
        }
        private void Start_Process(object sender, EventArgs e)
        {
            this.startProcess.Enabled = false;
            this.isProcessed = true;
            this.bgWorker.RunWorkerAsync();
            this.Create_LogFile(this.filePath);
        }
        private void Create_LogFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            this.StreamWriter = File.CreateText(path);
        }
        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int hasComplete = Convert.ToInt32(100 * Convert.ToDouble(e.ProgressPercentage) / fileList.Count);
            this.progressBar.Value = hasComplete;
            this.CurrentProcessLabel.Text = fileList[e.ProgressPercentage];
            this._processPer.Text = String.Format("{0} %", hasComplete);
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            fileList = this.thumnailProcess.GetAllDwgFilesByPath(this.RootPath.Text);
            int fileTotal = fileList.Count;
            for(int i = 0; i < fileTotal; i++)
            {
                this.CurrentProcess = fileList[i];
                if (thumnailProcess.Processing(fileList[i]) == 1){
                    this.StreamWriter.WriteLine(fileList[i] + " 处理成功");
                }else if(thumnailProcess.Processing(fileList[i]) == 0) { 
                    this.StreamWriter.WriteLine(fileList[i] + " 处理失败," + "无法获取缩略图");
                }
                this.bgWorker.ReportProgress(i);
                System.Threading.Thread.Sleep(500);
            }
        }
        private void Dialog_Close(object sender, FormClosingEventArgs e)
        {
            if (this.isProcessed) {
                if(MessageBox.Show("文件正在处理当中，确定关闭?", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign) == DialogResult.Yes)
                {
                    bgWorker.CancelAsync();
                    this.DialogResult = DialogResult.Cancel;
                }else
                {
                    this.isProcessed = false;
                    this.DialogResult = DialogResult.OK;
                }

            }
        }
        private void BgWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this._processPer.Text = "100%";
            this.progressBar.Value = 100;
            this.CurrentProcessLabel.Text = "处理完成";
            this.startProcess.Enabled = true;
            this.StreamWriter.Close();
            this.StreamWriter.Dispose();
            this.isProcessed = false;
            MessageBox.Show("处理完成");
        }

        private void ThumnailProcessDlg_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
