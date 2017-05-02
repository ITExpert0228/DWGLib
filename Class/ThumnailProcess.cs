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
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Shell;

using DwgLib.Dialog;

namespace DwgLib.Class
{
    public class ThumnailProcess
    {
        public ThumnailProcessDlg thumnailProcessDlg;
        Editor ed = null;
        List<string> Files = new List<string>();
        int DirectoryCount = 1;
        public ThumnailProcess()
        {
        }
        public int Processing(string file)
        {
            if (!Directory.Exists(file))
            {
                if (Path.GetExtension(file).ToLower() == ".dwg")
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (GernateDwgThumnail(file)) return 1;
                    else return 0;
                }else
                {
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("DWG 路径不存在", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return -1;
            }
        }
        //root为一级目录
        private void SearchDWGFile(string root)
        {

            string[] strArr = Directory.GetDirectories(root);
            string[] files = Directory.GetFiles(root);
            List<string> _files = new List<string>() { };
            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]).ToLower() == ".dwg")
                {
                    _files.Add(files[i]);
                }
            }
            this.Files.AddRange(_files);
            for (int i = 0; i < strArr.Length; i++)
            {
                SearchDWGFile(strArr[i]);
            }
        }
        public List<string> GetAllDwgFilesByPath(string root)
        {
            //应用递归获取文件夹目录下的文件
            if (!Directory.Exists(root))
            {
                MessageBox.Show("选择的路径名称无效");
                return Files;
            }
            if (this.DirectoryCount > 3)
            {
                MessageBox.Show("搜索路径过长，请减少文件路径长度");
            }
            this.SearchDWGFile(root);
            return this.Files;
        }
        private bool GernateDwgThumnail(string path)
        {

            string fileName = Path.GetFileNameWithoutExtension(path);
            string dir = Path.GetDirectoryName(path);
            Database db = new Database(false, true);

            try
            {
                db.ReadDwgFile(path, FileOpenMode.OpenForReadAndReadShare, true, "13343408355x");
                db.UpdateThumbnail = 1;
                db.CloseInput(true);
                //Transaction tra = db.TransactionManager.StartOpenCloseTransaction();
                Transaction tra = db.TransactionManager.StartTransaction();
                try
                {
                    BlockTableRecord mSpaceRecord = tra.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForRead) as BlockTableRecord;
                    if (mSpaceRecord != null)
                    {
                        Layout msLayout = tra.GetObject(mSpaceRecord.LayoutId, OpenMode.ForRead) as Layout;
                        if (msLayout != null)
                        {
                            Bitmap thumnail = db.ThumbnailBitmap;
                            if (thumnail != null)
                            {
                                Bitmap newThumnail = ResizeTo(thumnail, new Size(thumnail.Width * 4, thumnail.Height * 4));
                                newThumnail.Save(dir + "/" + fileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                tra.Commit();
                                return true;
                            }
                            else
                            {
                                tra.Commit();
                                return false;
                            }
                        }
                        else
                        {
                            tra.Commit();
                            return false;
                        }
                    }
                    else
                    {
                        tra.Commit();
                        return false;
                    }
                }
                catch (Autodesk.AutoCAD.Runtime.Exception e)
                {
                    tra.Abort();
                    return false;
                }
                db.Dispose();
            }
            catch (Autodesk.AutoCAD.Runtime.Exception e)
            {
                return false;
            }
        }
        private static Bitmap ResizeTo(Bitmap bitmap, Size size)
        {
            Bitmap newImage = new Bitmap(size.Width * 3, size.Height * 3);
            Graphics graphic = Graphics.FromImage((System.Drawing.Image)newImage);
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            graphic.DrawImage(bitmap, 0, 0, newImage.Width, newImage.Height);
            return newImage;
        }
    }
}
