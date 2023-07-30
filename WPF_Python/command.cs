using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WPF_Python
{
    internal class command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Application app = uiapp.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var allMechanical = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipment).WhereElementIsNotElementType().ToElements();
            foreach (var element in allMechanical)
            {
                if (element.LevelId == new FilteredElementCollector(doc).OfClass(typeof(Level)).Where(x => x.Name == "E03").Select(x => x.Id).FirstOrDefault())
                {
                    var c = new Options();
                    if (doc.ActiveView.ViewType
                        == ViewType.ThreeD)
                        TaskDialog.Show("hello", "hdlle");
                    element.LevelId == new FilteredElementCollector(doc);
                    var ee = allMechanical[0]
                }
            }
                
            
            return Result.Succeeded;
        }
    }
}
