using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace DwgLib.Dialog
{
    public partial class Setting : UserControl
    {
        //
        public static string SettingPath =  Directory.GetCurrentDirectory() + "/" + "setting.xml";
        public Setting()
        {
            string libraryPath = "";
            InitializeComponent();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(SettingPath);
                libraryPath = GetDwgLibPath();
                this.PathShow.Text = libraryPath;
            }
            catch (System.Exception)
            {
                this.PathShow.Text = Directory.GetCurrentDirectory() +@"\"+"library";
            }
        }
        private void SelectDirectory(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDlg = new FolderBrowserDialog();
            FolderDlg.ShowNewFolderButton = true;
            FolderDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            
            if(FolderDlg.ShowDialog() == DialogResult.OK)
            {
                string pathStr = FolderDlg.SelectedPath;
                this.PathShow.Text = pathStr;      
                WritePathInXML(pathStr);
                MessageBox.Show("设置成功，要应用更改，请关闭CAD程序，然后重新启动");
            }
        }
        public static string GetDwgLibPath()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(SettingPath);
            XmlNodeList nodeList = xmlDoc.SelectNodes("meta/librarypath/directory");
            if(nodeList != null)
            {
                string path = nodeList[0].Attributes["path"].Value;
                return path;
            }else
            {
                return "null";
            }
        }
        public static void WritePathInXML(string pathStr)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDirect =  xmlDoc.CreateXmlDeclaration("1.0","UTF-8","yes");

            XmlNode rootNode = xmlDoc.CreateElement("meta");
            
            XmlAttribute time = xmlDoc.CreateAttribute("time");
            time.Value = DateTime.Now.ToString();

            XmlAttribute user = xmlDoc.CreateAttribute("user");
            user.Value = System.Environment.UserName;

            rootNode.Attributes.Append(time);
            rootNode.Attributes.Append(user);

            XmlNode libraryNode = xmlDoc.CreateElement("librarypath");
            XmlNode pathNode = xmlDoc.CreateElement("directory");
            XmlAttribute path = xmlDoc.CreateAttribute("path");
            path.Value = pathStr;

            pathNode.Attributes.Append(path);
            libraryNode.AppendChild(pathNode);

            rootNode.AppendChild(libraryNode);
            xmlDoc.AppendChild(rootNode);
            //xmlDoc.AppendChild(xmlDirect);
            MessageBox.Show(SettingPath);
            xmlDoc.Save(SettingPath);            
        }
        private void About(object sender, EventArgs e)
        {
            AboutDlg aboutDlg = new AboutDlg();
            aboutDlg.ShowDialog();
        }

        private void ReStore(object sender, EventArgs e)
        {
            if (File.Exists(SettingPath))
            {
                File.Delete(SettingPath);
                string path = Directory.GetCurrentDirectory() + @"/" + "library";
                PathShow.Text = path;
                WritePathInXML(path);
            }
        }
    }
}
