using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Intech
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class TigerStopExport : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Transaction trans = new Transaction(doc);
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            List<ViewSchedule> Allschedules;//list of scheuled
            List<ViewSchedule> selected = new List<ViewSchedule>();  //List of selected schedules
            Dictionary<ViewSchedule, string> displayNames = new Dictionary<ViewSchedule, string>(); //to display proper name in the checkedlistbox.

            // If so, loop through all checked items   
            DialogResult result2 = System.Windows.Forms.DialogResult.None;

            Allschedules = new FilteredElementCollector(doc).OfClass(typeof(ViewSchedule)).Cast<ViewSchedule>().ToList();
            List<ViewSchedule> schedules = new List<ViewSchedule>();
            List<string> txtschedules = new List<string>();
            foreach (ViewSchedule i in Allschedules)
            {
                if (!i.IsTemplate)
                {
                    if (i.Name.IndexOf("tigerstop", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        schedules.Add(i);
                        txtschedules.Add(i.Name.Replace("'",""));
                    }
                }
            }

            SelectionForm selectionForm = new SelectionForm(txtschedules);

            result2 = selectionForm.ShowDialog(); //shows dialog selection window
            if (selectionForm.checkedListBox.CheckedItems.Count == 0) return Result.Cancelled;

            for (int x = 0; x < selectionForm.checkedListBox.CheckedItems.Count; x++)
            {
                //compare schedule name
                foreach (ViewSchedule w in schedules)
                {
                    //if schedule name is in the CheckedItems list, add schedule to selected list.
                    if (w.Name.Replace("'", "").Equals((selectionForm.checkedListBox.CheckedItems[x] as DataRowView).Row[0]))
                    {
                        selected.Add(w);
                    }
                }
            }

            //prompt user to select file save location
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                FileName = "Folder Selection"
            };

            string baseFolder = string.Empty;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                baseFolder = saveFileDialog1.FileName.Replace("Folder Selection", null);
            }
            if (baseFolder == null) return Result.Cancelled;

            Debug.WriteLine(baseFolder);

            foreach (ViewSchedule i in selected)
            {

                string pattern = @"[\\/:*?""<>|]";
                string name = Regex.Replace(i.Name, pattern, "");
                string CSV = baseFolder + name + @".csv";

                TableData table = i.GetTableData();
                TableSectionData section = table.GetSectionData(SectionType.Body);
                int nRows = section.NumberOfRows;
                int nColumns = section.NumberOfColumns;

                List<List<string>> scheduleData = new List<List<string>>();
                for (int d = 0; d < nRows; d++)
                {
                    List<string> rowData = new List<string>();

                    for (int j = 0; j < nColumns; j++)
                    {
                        rowData.Add("\"" + i.GetCellText(SectionType.Body, d, j).Replace("\"", "\"\"") + "\"");//added text qualifiers (the quotations)
                    }
                    scheduleData.Add(rowData);
                }

                try
                {
                    using (StreamWriter file = new StreamWriter(CSV))
                    {
                        foreach (List<string> row in scheduleData)
                        {
                            file.WriteLine(string.Join(",", row)); //EOL serquence
                        }

                    }

                }
                catch (Exception ex)
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Error writing to CSV file: ", ex.ToString());
                }
            }

            return Result.Succeeded;

        }
    }
}