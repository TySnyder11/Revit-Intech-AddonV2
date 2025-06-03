using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
namespace Intech
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    //Settings
    public class DependentView : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;

            //collect planviews and area list
            List<Element> planViews = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewPlan))
                .WhereElementIsNotElementType()
                .ToElements() as List<Element>;
            List<Element> areaList = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_VolumeOfInterest).
                WhereElementIsNotElementType().
                ToElements() as List<Element>;
            //collect scale information
            var sizes = SettingsRead.Scale();

            //start ui form
            DependentViewForm dependentViewForm = new DependentViewForm(planViews, areaList, sizes.Keys.ToList());
            var result = dependentViewForm.ShowDialog();

            //make sure all required information was collected
            if (dependentViewForm.PlanViewCheckBox.CheckedItems.Count == 0
                || (dependentViewForm.AreaCheckBox.CheckedItems.Count == 0
                && dependentViewForm.checkBox1.Checked == false))
                return Result.Cancelled;

            List<Autodesk.Revit.DB.View> selectedViewPlans = new List<Autodesk.Revit.DB.View>();

            //get planviews with matching name to selected
            for (int x = 0; x < dependentViewForm.PlanViewCheckBox.CheckedItems.Count; x++)
            {
                foreach (Autodesk.Revit.DB.View w in planViews)
                {
                    //if schedule name is in the CheckedItems list, add schedule to selected list.
                    if (w.Name.Equals((dependentViewForm.PlanViewCheckBox.CheckedItems[x] as DataRowView).Row[0]))
                    {
                        selectedViewPlans.Add(w);
                        break;
                    }
                }
            }

            List<Element> selectedAreas = new List<Element>();

            //get scopeboxes with matching name
            for (int x = 0; x < dependentViewForm.AreaCheckBox.CheckedItems.Count; x++)
            {
                foreach (Element w in areaList)
                {
                    if (w.Name.Equals(dependentViewForm.AreaCheckBox.CheckedItems[x]))
                    {
                        
                        selectedAreas.Add(w);
                        break;
                    }
                }
            }

            List<ViewPlan> createdViews = new List<ViewPlan>();

            //set up transaction
            Transaction tranDependentView = new Transaction(doc, "create dependent views");
            tranDependentView.Start();


            foreach (Autodesk.Revit.DB.View i in selectedViewPlans)
            {
                //Standard dependent
                foreach (Element x in selectedAreas)
                {
                    try
                    {
                        //create copy
                        ElementId NewViewID = i.Duplicate(ViewDuplicateOption.AsDependent);
                        Element NewView = doc.GetElement(NewViewID);

                        //name and apply scope box
                        NewView.Name = i.Name + " - " + x.Name;
                        createdViews.Add(NewView as ViewPlan);
                        (NewView as Element).get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP).Set(x.Id);
                    }
                    catch (Exception ex)
                    {
                        Autodesk.Revit.UI.TaskDialog.Show("Error", ex.ToString());
                    }
                }

                //Overall
                if (dependentViewForm.checkBox1.Checked == true)
                {
                    ElementId NewViewID = i.Duplicate(ViewDuplicateOption.Duplicate);
                    Element NewView = doc.GetElement(NewViewID);
                    NewView.Name = i.Name + " - OVERALL";
                    createdViews.Add(NewView as ViewPlan);
                    tranDependentView.Commit();
                    tranDependentView.Start();
                    Debug.WriteLine(dependentViewForm.OverallView.SelectedItem.ToString());
                    (NewView as Autodesk.Revit.DB.View).Scale = int.Parse(sizes[dependentViewForm.OverallView.SelectedItem.ToString()].Item2);
                }
            }
            tranDependentView.Commit();

            //if create sheet selected export creative sheets and run sheet create
            if (dependentViewForm.CreateSheet.Checked)
                SheetActualCreate.Run(commandData, createdViews);

            return Result.Succeeded;
        }
    }
}
