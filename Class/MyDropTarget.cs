using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;
using System.Windows.Forms;
using Autodesk.AutoCAD.GraphicsInterface;
using System.IO;

namespace DwgLib.Class
{
    public class MyDropTarget : Autodesk.AutoCAD.Windows.DropTarget
    {
        public string filePath;
        Editor Ed;
        DocumentLock DocLock;
        Database currentDwg ;
        Transaction trans;
        public MyDropTarget(string filePath) : base()
        {
            this.filePath = filePath;
            this.Ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            this.DocLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();
            this.currentDwg = Ed.Document.Database;
            this.trans = currentDwg.TransactionManager.StartTransaction();
        }
        public override void OnDragLeave()
        {
            base.OnDragLeave();
        }
        public override void OnDragOver(DragEventArgs e)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            Point3d position = ed.PointToWorld(new System.Windows.Point(e.X, e.Y));
          //  DisplayDwgFile(position);
        }
        public override void OnDrop(DragEventArgs e)
        {
            try
            {
                Point3d position = this.Ed.PointToWorld(new System.Windows.Point(e.X, e.Y));
                //PromptKeywordOptions getAppendMethod = new PromptKeywordOptions("指定以何种方式插入CAD文件，连接（L），直接插入（I）默认（Link）? [Link/Insert] : ", "Link Insert");
                //getAppendMethod.AllowNone = true;
                //PromptResult appendMethodResult = this.Ed.GetKeywords(getAppendMethod);
                //switch (appendMethodResult.StringResult)
                //{
                //   case "Link":
                //        LinkDwgFile(position);
                //       break;
                //    case "Insert":
                InsertDwgFile(position);
                //        break;
                //    case "":
                //        LinkDwgFile(position);
                //        break;
                //    default:
                //        this.Ed.WriteMessage("未识别命令");
                //        break;
                //}
                trans.Commit();
                trans.Dispose();
                DocLock.Dispose();
            }
            catch (System.Exception ex)
            {
                trans.Abort();
                trans.Dispose();
                DocLock.Dispose();
            }
        }
        private void InsertDwgFile(Point3d Position)
        {
            string BlockName = Path.GetFileNameWithoutExtension(this.filePath);
            BlockTable blockTable = trans.GetObject(currentDwg.BlockTableId, OpenMode.ForWrite) as BlockTable;
            BlockTableRecord modelSpace = (BlockTableRecord)SymbolUtilityServices.GetBlockModelSpaceId(currentDwg).GetObject(OpenMode.ForWrite);
            if (!File.Exists(this.filePath))
            {
                Ed.WriteMessage("Error404: 文件" + this.filePath + "未找到" + "\n");
                return;
            }else
            {
                Database insertDb = this.GetDwgFile(this.filePath);
                try
                {
                    ObjectId id = blockTable[BlockName];
                //    if (!((BlockTableRecord)SymbolUtilityServices.GetBlockModelSpaceId(currentDwg).GetObject(OpenMode.ForRead)).GetType())
                    Ed.WriteMessage("插入失败，当前已存在名为：" + BlockName + "的块参照" + "\n");
                }
                catch
                {
                    ObjectId id = currentDwg.Insert(Path.GetFileNameWithoutExtension(this.filePath)+"_I", insertDb, true);
                    //ObjectId id = currentDwg.OverlayXref(this.filePath, Path.GetDirectoryName(this.filePath)+"_I");
                    BlockReference br = new BlockReference(Position, id);
                    modelSpace.AppendEntity(br);
                    trans.AddNewlyCreatedDBObject(br, true);
                }
            }
        }
        private void LinkDwgFile(Point3d Position)
        {
            string ReferenceName = Path.GetFileNameWithoutExtension(this.filePath);
            BlockTable blockTable = this.trans.GetObject(currentDwg.BlockTableId, OpenMode.ForWrite) as BlockTable;
            BlockTableRecord modelSpace = (BlockTableRecord)SymbolUtilityServices.GetBlockModelSpaceId(currentDwg).GetObject(OpenMode.ForWrite);
            LayerTableRecord currentTable = this.trans.GetObject(currentDwg.Clayer, OpenMode.ForRead, true) as LayerTableRecord;
            BlockTableRecord btr = (BlockTableRecord)trans.GetObject(currentDwg.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;

            if (!File.Exists(this.filePath))
            {
                this.Ed.WriteMessage("Error404: 文件" + this.filePath + "未找到" + "\n");
                return;
            }else
            {
                try
                {
                    ObjectId id = blockTable[ReferenceName];
                    this.Ed.WriteMessage("链接失败，当前已存在名为：" + ReferenceName + "的块参照" + "\n");
                }catch
                {
                    ObjectId id = btr.Database.AttachXref(this.filePath, ReferenceName + "_L");
                    BlockReference br = new BlockReference(Position, id);
                    br.Color = currentTable.Color;
                    modelSpace.AppendEntity(br);
                    trans.AddNewlyCreatedDBObject(br, true);
                }
            }
        }
        private void DisplayDwgFile(Point3d Position)
        {
            string BlockName = Path.GetFileNameWithoutExtension(this.filePath);
            BlockTable blockTable = trans.GetObject(currentDwg.BlockTableId, OpenMode.ForWrite) as BlockTable;
            BlockTableRecord modelSpace = (BlockTableRecord)SymbolUtilityServices.GetBlockModelSpaceId(currentDwg).GetObject(OpenMode.ForWrite);

            if (!File.Exists(this.filePath))
            {
                Ed.WriteMessage("Error404: 文件" + this.filePath + "未找到" + "\n");
                return;
            }
            else
            {
                Database insertDb = this.GetDwgFile(this.filePath);

                ObjectId id = currentDwg.Insert(Path.GetFileNameWithoutExtension(this.filePath), insertDb, true);
                BlockReference br = new BlockReference(Position, id);
                modelSpace.AppendEntity(br);
                trans.AddNewlyCreatedDBObject(br, true);
            }
        }
        private Database GetDwgFile(string path)
        {

            Database db = new Database(false, false);
            if (Path.GetExtension(path).ToLower() == ".dwg")
            {
                try
                {
                    db.ReadDwgFile(path, FileOpenMode.OpenForReadAndReadShare, true, "");
                    db.UpdateThumbnail = 1;
                    db.CloseInput(true);
                }
                catch
                {
                    //TODO
                }
            }
            return db;
        }
        public override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
        }
    }
}

