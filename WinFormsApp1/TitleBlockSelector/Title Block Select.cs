using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Diagnostics;
namespace Intech
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class TitleBlockSelector : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //Revit pre setup stuff
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Transaction trans = new Transaction(doc);
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //Get element ID of selected
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();

            if (selectedIds.Count == 0 )
            {
                return Result.Cancelled;
            }
            //filter out all elements that is not a sheet
            var sheet = new FilteredElementCollector(doc, selectedIds).OfCategory(BuiltInCategory.OST_Sheets).WhereElementIsNotElementType().ToElementIds();

            //Make sure you have something selected
            if (sheet.Count == 0)
            {
                return Result.Failed;
            }

            //Define title block list
            IList<ElementId> tb = new List<ElementId>();

            //for each sheet get the title block inside and add to title block list
            foreach (ElementId i in sheet)
            {
                var title_block = new FilteredElementCollector(doc, i).OfCategory(BuiltInCategory.OST_TitleBlocks).WhereElementIsNotElementType().ToElementIds();
                foreach (ElementId f in title_block)
                {
                    tb.Add(f);
                }
            }

            //Set selection to new element id and print on debug screen to make sure selected element Id has changes
            uidoc.Selection.SetElementIds(tb);

            return Result.Succeeded;
        }
    }
}
