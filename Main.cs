
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
using DwgLib.Class;
using DwgLib.Dialog;
using DwgLib.Controls;
/*
[assembly:CommandClass(typeof(DwgLib.Command.About))]
[assembly:CommandClass(typeof(DwgLib.Command.DwgPalette))]
[assembly:CommandClass(typeof(DwgLib.Command.LibConfig))]
[assembly:CommandClass(typeof(DwgLib.Command.ThumnailProcess))]
*/
namespace DwgLib.Command
{
    public static class DwgPalette
    {
        public static PaletteSet PaletteLibrary;
        static DwgPalette()
        {
            _Palette Palette = new _Palette();
            PaletteLibrary = Palette.PaletteLibrary;
        }
        [CommandMethod("hudson")]
        public static void DwgLibrary()
        {
            if (PaletteLibrary.Visible == false)
            {
                PaletteLibrary.Visible = true;
            }else
            {
                PaletteLibrary.Visible = false;
            }
        }
    }
    public static class About
    {
        [CommandMethod("libabout")]
        public static void ShowAbout()
        {
            AboutDlg AboutDlg = new AboutDlg();
            AboutDlg.Icon = Properties.Resources.logo;
            AboutDlg.ShowDialog();
        }
    }
    public class LibConfig
    {
        [CommandMethod("libconfig")]
        public static void SettingDialog()
        {
            Form form = new Form();
            Setting settingControl = new Setting();
            form.MaximumSize = new Size(360, 600);
            form.MinimumSize = new Size(200, 550);
            form.Icon = Properties.Resources.logo;
            settingControl.Dock = DockStyle.Fill;
            form.Controls.Add(settingControl);
            form.ShowDialog();
        }
    }
    public class ThumnailProcess
    {

        private Editor ed;
        private ThumnailProcessDlg thumnailProcessDlg;
        public ThumnailProcess(){
            this.thumnailProcessDlg = new ThumnailProcessDlg(0, false, "");
        }
        [CommandMethod("thumnailprocess")]
        public void ShowProcessingDialog()
        {
            if (thumnailProcessDlg.IsDisposed)
            {
                this.thumnailProcessDlg = new ThumnailProcessDlg(0, false, "");
            }
            thumnailProcessDlg.RootPath.Text = "这里显示CAD文件夹路径";
            thumnailProcessDlg.Show();
        }
    }
}



