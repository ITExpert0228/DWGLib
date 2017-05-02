
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection.Emit;


using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Shell;

using DwgLib;
using DwgLib.Controls;
using DwgLib.Dialog;
namespace DwgLib.Class
{
    class _Palette
    {
        public PaletteSet PaletteLibrary;
        public _Palette()
        {
            this.PaletteLibrary = new PaletteSet("中建深圳装饰", Guid.NewGuid());
            this.PaletteLibrary.Size = new Size(600, 600);
            this.PaletteLibrary.MinimumSize = new Size(260, 400);
            this.PaletteLibrary.Icon = DwgLib.Properties.Resources.logo;
            InitLibrary(this.PaletteLibrary);
        }
        private static void InitLibrary(PaletteSet myPaletteSet)
        {
            string libraryPath;
            if (GetLibPath() != "")
            {
                libraryPath = GetLibPath();
            }
            else
            {
                MessageBox.Show("无法加载图库文件，请指定正确的图库加载路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] strArr = Directory.GetDirectories(libraryPath);
            for (int i = 0; i < strArr.Length; i++)
            {
                Panel customPanel = new Panel();
                string paletteName = Path.GetFileNameWithoutExtension(strArr[i]);

                myPaletteSet.Add(paletteName, customPanel);
                string[] strArr2 = Directory.GetDirectories(strArr[i]);

                if (strArr2.Length != 0)
                {
                    TabControl Tab = new TabControl();
                    Tab.Dock = DockStyle.Fill;
                    for (int j = 0; j < strArr2.Length; j++)
                    {
                        string tabName = Path.GetFileNameWithoutExtension(strArr2[j]);
                        TabPage tabPage = new TabPage(tabName);
                        Tab.Multiline = true;
                        Tab.Controls.Add(tabPage);

                        FlowLayoutPanel floatPanel = new FlowLayoutPanel();

                        floatPanel.Dock = DockStyle.Fill;
                        floatPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;

                        Panel panel = new Panel();
                        panel.Dock = DockStyle.Fill;
                        panel.BackColor = Color.White;
                        panel.AutoScroll = true;

                        panel.Controls.Add(floatPanel);
                        tabPage.Controls.Add(panel);
                        panel.Padding = new Padding(20, 20, 20, 20);
                        string[] filePath = Directory.GetFiles(strArr2[j]);
                        if (filePath.Length != 0)
                        {
                            List<Control> ItemList = new List<Control>();
                            for (int k = 0; k < filePath.Length; k++)
                            {
                                string FileExtension = Path.GetExtension(filePath[k]).ToLower();
                                string FileName = Path.GetFileNameWithoutExtension(filePath[k]);
                                string Directory = Path.GetDirectoryName(filePath[k]);

                                if (FileExtension == ".jpg")
                                {
                                    DwgThumnail item = new DwgThumnail();
                                    item.Width = 70;
                                    item.Height = 80;
                                    item.filePath = Directory + "/" + FileName + ".dwg";
                                    item.FileName.Text = FileName;
                                    item.Thumnail.Height = 60;
                                    item.Thumnail.Width = 70;
                                    item.Thumnail.BackgroundImage = Bitmap.FromFile(filePath[k]);
                                    floatPanel.Controls.Add(item);

                                }
                            }
                        }
                    }
                    customPanel.Controls.Add(Tab);
                }
                else
                {
                    string[] filePath = Directory.GetFiles(strArr[i]);
                    if (filePath.Length != 0)
                    {
                        FlowLayoutPanel floatPanel = CreateFloatLayoutPanel();
                        floatPanel.AutoScroll = true;
                        floatPanel.Dock = DockStyle.Fill;
                        floatPanel.Padding = new Padding(20, 20, 20, 20);
                        customPanel.Controls.Add(floatPanel);
                        for (int k = 0; k < filePath.Length; k++)
                        {
                            string FileExtension = Path.GetExtension(filePath[k]).ToLower();
                            string FileName = Path.GetFileNameWithoutExtension(filePath[k]);
                            string Directory = Path.GetDirectoryName(filePath[k]);
                            if (FileExtension == ".jpg")
                            {
                                DwgThumnail item = new DwgThumnail();
                                item.Width = 70;
                                item.Height = 80;
                                item.filePath = Directory + "/" + FileName + ".dwg";
                                item.FileName.Text = FileName;
                                item.Thumnail.Height = 60;
                                item.Thumnail.Width = 70;
                                item.Thumnail.BackgroundImage = Bitmap.FromFile(filePath[k]);
                                floatPanel.Controls.Add(item);

                            }
                        }
                    }
                }
            }
        }
        public static string GetLibPath()
        {
            string settingPath = Directory.GetCurrentDirectory() + @"\" + "setting.xml";
            string libraryPath = Directory.GetCurrentDirectory() + @"\" + "library";
            if (!File.Exists(settingPath))
            {
                Setting.WritePathInXML(libraryPath);
            }
            else
            {
                libraryPath = Setting.GetDwgLibPath();
            }
            libraryPath = Path.GetFullPath(libraryPath);
            if (!Directory.Exists(libraryPath))
            {
                return "";
            }
            else
            {
                return libraryPath;
            }
        }
        private static Database GetFileByPrefix(string path, string prefix)
        {

            Database db = new Database(false, false);
            if (Path.GetExtension(path).ToLower() == prefix)
            {
                try
                {
                    db.ReadDwgFile(path, FileOpenMode.OpenForReadAndReadShare, true, "");
                    db.UpdateThumbnail = 1;
                    db.CloseInput(true);
                }
                catch
                {

                }
            }
            return db;
        }
        private static FlowLayoutPanel CreateFloatLayoutPanel()
        {
            FlowLayoutPanel floatPanel = new FlowLayoutPanel();
            floatPanel.Dock = DockStyle.Fill;
            floatPanel.AutoScroll = true;
            floatPanel.BackColor = Color.White;
            floatPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;

            return floatPanel;
        }
    }
}
