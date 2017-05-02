using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Customization;

namespace DWGLib
{
    class LoadMenu
    {
        const string CUIPATH = "./gui/ui.cuix";
        Editor ed;
        string mainCui;
        CustomizationSection cs;
        PartialCuiFileCollection pcfc;
        public LoadMenu()
        {
            Menu mainMenu = Autodesk.AutoCAD.ApplicationServices.Application.MenuBar as Menu;
            MenuItem item1 = new MenuItem("Hudson");
            mainMenu.MenuItems.Add(item1);
        }
        protected void InitializeRibbonMenu()
        {
            if (!pcfc.Contains(CUIPATH))
            {
                
            }
        }
        protected void LoadCUI()
        {
            
        }
        protected void CreateNormalMenu()
        {

        }
    }
}
