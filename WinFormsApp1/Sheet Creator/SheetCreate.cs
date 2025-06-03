using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
namespace Intech
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class SheetCreateInit : IExternalCommand
    {
        //Run without previously selected sheets
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return SheetActualCreate.Run( commandData, new List <ViewPlan> ());
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    //Settings
    public class SheetSettingsMenu : IExternalCommand
    {
        //Open settings
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            SheetSettings sheetSettings = new SheetSettings(commandData);
            sheetSettings.ShowDialog();
            return Result.Succeeded;
        }
    }

    
    public class SheetActualCreate
    {
        public static string renumbHelper(List<ViewSheet> viewSheets, string number)
        {
            foreach (ViewSheet viewSheet in viewSheets)
            {
                if (viewSheet.SheetNumber.Equals(number))
                {
                    number += "(copy)";
                    renumbHelper(viewSheets, number);
                }
            }
            return number;
        }
        public static Result Run(ExternalCommandData commandData, List<ViewPlan> Selected)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Transaction trans = new Transaction(doc, "Create Sheet");

            //start forn
            SheetCreateForm form = new SheetCreateForm(commandData, Selected);
            form.ShowDialog();

            //check required boxes are filled
            if (
                form.PlanViewCheckList.CheckedItems.Count == 0 ||
                string.IsNullOrEmpty(form.TradeAbriviation.Text) ||
                string.IsNullOrEmpty(form.MiddleSheetNumber.Text) ||
                string.IsNullOrEmpty(form.SheetName.Text) ||
                string.IsNullOrEmpty(form.TitleBlockFamily.Text) ||
                string.IsNullOrEmpty(form.TitleBlockType.Text)
                )
                return Result.Cancelled;

            //collect all plan viwes in project that are not templates
            List<Element> AllViews = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewPlan))
                .WhereElementIsNotElementType()
                .ToElements() as List<Element>;

            List<Element> selectedViews = new List<Element>();

            //find the view with the same name as the selected
            foreach (DataRowView selectedName in form.PlanViewCheckList.CheckedItems)
                foreach (Element element in AllViews)
                {
                    if (element.Name.Equals(selectedName.Row[0]))
                        selectedViews.Add(element);
                }

            //set up lists for later
            List<Viewport> viewports = new List<Viewport>();
            List<Parameter> levelParameter = new List<Parameter>();
            List<ViewSheet> viewsheets = new List<ViewSheet>();

            trans.Start();
            foreach (Element planview in selectedViews)
            {
                //get all title blocks
                var alltitle_blocks = new FilteredElementCollector(doc)
                            .OfCategory(BuiltInCategory.OST_TitleBlocks)
                            .WhereElementIsElementType()
                            .ToElements();

                //get title block from selected string
                Element titleblock = null;
                foreach (FamilySymbol element in alltitle_blocks)
                    if (element.FamilyName.Contains(form.TitleBlockFamily.Text) && form.TitleBlockType.Text.Contains(element.Name))
                        titleblock = element;

                //make sure title block was found
                if (titleblock == null)
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Failed", "Could not find title block. If you are using your base select title block in settings make sure it is in this project.");
                    return Result.Failed;
                }

                //create sheet
                ViewSheet newsheet = ViewSheet.Create(doc, titleblock.Id);
                viewsheets.Add(newsheet);
                newsheet.Name = form.SheetName.Text;
                //Number sheet on or near line 233


                var title_block = new FilteredElementCollector(doc, newsheet.Id)
                            .OfCategory(BuiltInCategory.OST_TitleBlocks)
                            .WhereElementIsNotElementType()
                            .ToElements();

                //Set selected parameters
                foreach (Parameter p in title_block[0].Parameters)
                {
                    if (form.ParameterCheckList.CheckedItems.Contains(p.Definition.Name) && !p.IsReadOnly)
                        p.Set(1);
                    else if (!p.IsReadOnly)
                        p.Set(0);
                }


                string areaNumber = "";
                var nonStandardAreas = SettingsRead.NonstandardArea();
                string o = planview.get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP).AsValueString();
                //Set area parameter
                if (form.AreaOverride.Checked)
                {
                    if (nonStandardAreas.Keys.Contains(planview.get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP).AsValueString()))
                        foreach (string key in nonStandardAreas.Keys)
                        {
                            if (key.Contains(form.AreaOverrideComboBox.Text))
                            {
                                areaNumber = nonStandardAreas[key].Item2;
                                title_block[0].LookupParameter(nonStandardAreas[key].Item1).Set(1);
                            }
                        }
                    else
                    {
                        string par = form.AreaOverrideComboBox.Text;
                        string[] area = par.Split(' ');
                        areaNumber = area[area.Count() - 1];
                        foreach (Parameter p in title_block[0].Parameters)
                        {
                            string[] areaREF = p.Definition.Name.Split('-');
                            if (p.Definition.Name.Contains(area[area.Count() - 1]))
                                p.Set(1);
                        }
                    }
                }
                else if (nonStandardAreas.Keys.Contains(planview.get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP).AsValueString()))
                    foreach (string key in nonStandardAreas.Keys)
                    {
                        if (key.Equals(planview.get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP).AsValueString()))
                        {
                            areaNumber = nonStandardAreas[key].Item2;
                            title_block[0].LookupParameter(nonStandardAreas[key].Item1).Set(1);
                        }
                    }
                else
                {
                    string par = planview.get_Parameter(BuiltInParameter.VIEWER_VOLUME_OF_INTEREST_CROP).AsValueString();
                    string[] area = par.Split(' ');
                    areaNumber = area[area.Count() - 1];
                    foreach (Parameter p in title_block[0].Parameters)
                    {
                        string[] areaREF = p.Definition.Name.Split('-');
                        if (areaREF.Length == 0) ;
                        else if (areaREF[areaREF.Count() - 1].Equals(area[area.Count() - 1]))
                            p.Set(1);
                    }
                        
                }

                string levelNumber = "";
                var nonStandardLevels = SettingsRead.NonstandardLevels();
                //Set Level parameter
                if (form.LevelOverride.Checked)
                {
                    if (nonStandardLevels.Keys.Contains(form.LevelOverrideComboBox.Text))
                        foreach (string key in nonStandardLevels.Keys)
                        {
                            if (key.Equals(form.LevelOverrideComboBox.Text))
                            {
                                levelNumber = nonStandardLevels[key].Item2.Replace("\n", "");
                                levelParameter.Add(title_block[0].LookupParameter(nonStandardLevels[key].Item1));
                            }
                        }
                    else
                    {
                        string par = form.LevelOverrideComboBox.Text;
                        string[] area = par.Split(' ');
                        areaNumber = area[area.Count() - 1];
                        foreach (Parameter p in title_block[0].Parameters)
                            if (p.Definition.Name.Contains(area[area.Count() - 1]))
                                p.Set(1);
                    }
                }
                else if (nonStandardLevels.Keys.Contains(planview.LookupParameter("Associated Level").AsValueString()))
                    foreach (string key in nonStandardLevels.Keys)
                    {
                        if (key.Equals(planview.LookupParameter("Associated Level").AsValueString()))
                        {
                            levelNumber = nonStandardLevels[key].Item2.Replace("\n", "");
                            levelParameter.Add(title_block[0].LookupParameter(nonStandardLevels[key].Item1));
                        }
                    }
                else
                {
                    string par = planview.LookupParameter("Associated Level").AsValueString();
                    string[] level = par.Split(' ');
                    levelNumber = level[level.Count() - 1];
                    foreach (Parameter p in title_block[0].Parameters)
                        if (p.Definition.Name.Contains("Level"))
                            if (p.Definition.Name.Contains(level[level.Count() - 1]))
                                levelParameter.Add(p);
                }

                //set discipline
                var DisciplineValue = SettingsRead.Discipline();
                if (!string.IsNullOrEmpty(form.Discipline.Text))
                {
                    newsheet.LookupParameter("Discipline").Set(form.Discipline.Text);
                    try
                    {
                        string e = DisciplineValue[form.Discipline.Text].Item2.Replace("\r", "");
                        title_block[0].LookupParameter(e).Set(1);
                    }
                    catch { }
                }
               
                //set sub discipline
                var subDisiplineValue = SettingsRead.SubDiscipline();
                if (!string.IsNullOrEmpty(form.SubDiscipline.Text) || subDisiplineValue.Item2)
                    newsheet.LookupParameter("Discipline Order").Set(form.SubDiscipline.Text);

                //Set sheet number
                string numb = form.TradeAbriviation.Text + DisciplineValue[form.Discipline.Text].Item1.ToString().Replace("\r", "") + form.MiddleSheetNumber.Text + levelNumber + "." + areaNumber;

                List<ViewSheet> sheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet))
                    .WhereElementIsNotElementType()
                    .ToElements()
                    .Cast<ViewSheet>()
                    .ToList();

                newsheet.SheetNumber = renumbHelper(sheets, numb);

                //get center of sheet
                XYZ xYZ = new XYZ();
                BoundingBoxXYZ boundingBoxXYZ = title_block[0].get_BoundingBox(newsheet);
                XYZ max = boundingBoxXYZ.Max;
                XYZ min = boundingBoxXYZ.Min;
                double X = (max.X + min.X) / 2;
                double Y = (max.Y + min.Y) / 2;

                XYZ viewportxyz = new XYZ(X, Y, 0);

                //create view port
                Viewport viewport = Viewport.Create(doc, newsheet.Id, planview.Id, viewportxyz);
                viewports.Add(viewport);
            }


            trans.Commit();
            trans.Start();

            //set previously stored level parameters to true due to needing transaction reload
            foreach (Parameter p in levelParameter)
                p.Set(1);

            int x = 0;
            foreach (Viewport viewport in viewports)
            {
                //read scales from settings
                var scales = SettingsRead.Scale();

                //get scale from planview
                ElementId sheetId = viewport.SheetId;
                string sheetscale = viewsheets[x].get_Parameter(BuiltInParameter.SHEET_SCALE).AsValueString();
                try
                {
                    //change viewport to correct scale
                    viewport.ChangeTypeId(new ElementId(Int64.Parse(scales[sheetscale.Remove(0, 1).Remove(sheetscale.Length - 2, 1)].Item1)));
                }
                catch
                {
                    //in case the viewport IDs breaks this will give you the new element IDs you need (they will break in revit 2025 or 2026 due to revit changing elements from a 32 bit system to 64 bit)
                    List<ElementId> workTypes = viewport.GetValidTypes() as List<ElementId>;
                    string stringworking = "";
                    foreach (ElementId workType in workTypes) stringworking += doc.GetElement(workType).Name + "   " + workType.ToString() + "\n";
                    Autodesk.Revit.UI.TaskDialog.Show("Unable to apply Viewport", "Make sure to be using valid element Id. Searching for viewscale" + sheetscale + "\n Valid sheet scale Ids are - \n" + stringworking);
                }
                x++;
            }
            
            trans.Commit();

            Autodesk.Revit.UI.TaskDialog.Show("Success", "Sheets Created");
            return Result.Succeeded;
        }
    }
}
