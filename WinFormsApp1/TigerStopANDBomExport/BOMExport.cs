using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Intech
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]//EVERY COMMAND REQUIRES THIS!
    public class ExportBOM : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;

            //utility.GetScheduleData(doc); //temp test
            string baseFolder = string.Empty;
            List<ViewSchedule> Allschedules;//list of scheduled
            List<ViewSchedule> selected = new List<ViewSchedule>();  //List of selected schedules
            Dictionary<ViewSchedule, string> displayNames = new Dictionary<ViewSchedule, string>(); //to display proper name in the checkedlistbox.

            //we now have the location where the file will be saved.
            // Create a form to select schedules.
            DialogResult result2 = System.Windows.Forms.DialogResult.None;

            Allschedules = new FilteredElementCollector(doc).OfClass(typeof(ViewSchedule)).WhereElementIsNotElementType().Cast<ViewSchedule>().ToList();
            List<ViewSchedule> schedules = new List<ViewSchedule>();
            List<string> txtschedules = new List<string>();
            foreach (ViewSchedule i in Allschedules)
            {
                if (!i.IsTemplate)
                {
                    if (i.LookupParameter("IMC_ExportReady") == null)
                    {
                        schedules.Add(i);
                        txtschedules.Add(i.Name.Replace("'", ""));
                    }

                    else if (i.LookupParameter("IMC_ExportReady").AsInteger() == 1 && i.LookupParameter("IMC_ExportComplete").AsInteger() == 0)
                    {
                        schedules.Add(i);
                        txtschedules.Add(i.Name.Replace("'", ""));
                    }
                }
            }

            SelectionForm selectionForm = new SelectionForm(txtschedules);

            result2 = selectionForm.ShowDialog(); //shows dialog selection windoe
            // Determine if there are any items checked.  
            if (selectionForm.checkedListBox.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items   

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
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1; // Set the default filter to Excel files
                saveFileDialog1.DefaultExt = "xlsx"; // Set the default extension

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    baseFolder = saveFileDialog1.FileName;


                }
                if (string.IsNullOrEmpty(baseFolder))
                {
                    return Result.Cancelled;
                }

                try
                {
                    //convert selected schexdule to excel
                    utility.exportSchedulesToCSV(doc, ref message, baseFolder, result2, schedules, selected);
                }
                catch (Exception ex)
                {
                    // If any error, give error information and return failed
                    Autodesk.Revit.UI.TaskDialog.Show("Error", ex.ToString());
                    return Autodesk.Revit.UI.Result.Failed;
                }
            }
            else
            {
                return Result.Cancelled;
            }
            return Result.Succeeded;
        }
    }

    public static class utility
    {

        public static DataTable GetScheduleData(ViewSchedule vs)
        {

            TableData table = vs.GetTableData();
            TableSectionData section = table.GetSectionData(SectionType.Body);
            int nRows = section.NumberOfRows;
            int nColumns = section.NumberOfColumns;

            //valueData.Add(viewSchedule.Name);

            DataTable scheduleData = new DataTable();

            for (int i = 0; i < nColumns; i++)
            {
                scheduleData.Columns.Add(vs.GetCellText(SectionType.Body, 0, i));
            }

            for (int x = 0; x < nRows; x++)
            {
                DataRow newRow = scheduleData.NewRow();
                scheduleData.Rows.Add(newRow);
                for (int y = 0; y < nColumns; y++)
                {
                    string data = vs.GetCellText(SectionType.Body, x, y);
                    scheduleData.Rows[x][y] = data;

                }
            }

            return scheduleData;
        }
        static int numOfHeaders;
        public static void addToHeader(int columns, ExcelWorksheet excel, string text)
        {
            excel.Cells[numOfHeaders, 1].Value = text;
            excel.Cells[numOfHeaders, 1, numOfHeaders, columns].Merge = true;
            // Create a new ExcelStyle object to define cell formatting.
            ExcelStyle cellStyle = excel.Cells[numOfHeaders, 1, numOfHeaders, columns].Style;

            // Set cell properties.
            cellStyle.Font.Bold = true;
            cellStyle.Font.Name = "Calibri";
            cellStyle.Font.Size = 14;
            cellStyle.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cellStyle.Border.Top.Style = ExcelBorderStyle.Medium;
            cellStyle.Border.Bottom.Style = ExcelBorderStyle.Medium;
            cellStyle.Border.Left.Style = ExcelBorderStyle.Medium;
            cellStyle.Border.Right.Style = ExcelBorderStyle.Medium;
            numOfHeaders += 1;
        }

        public static Result exportSchedulesToCSV(Document doc, ref string message, string saveFolder, DialogResult result,
                                List<ViewSchedule> schedules,
                                List<ViewSchedule> selected
                               )
        {
            if (result == DialogResult.None || result == DialogResult.Retry || result == DialogResult.Cancel)
            {
                //now we have a list of selected schedules.
                //we need to export these schedules
                var roamingApplicationPath = Environment.ExpandEnvironmentVariables("%appdata%");
                var fullPath = roamingApplicationPath + @"\Autodesk\Revit\temp";
                Directory.CreateDirectory(fullPath);
                string excelFileName = saveFolder;

                //change this to selected directory in step 1

                string basepath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                string template = basepath + @"\BOMtemplate.xlsx";
                string HeaderPath = basepath + @"\header.png";

                if (!File.Exists(template))
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Error", "The template file does not exist.");
                }
                var format = new ExcelTextFormat
                {
                    Delimiter = ',',
                    TextQualifier = '"',     // format.TextQualifier = '"';
                    EOL = "\n"              // DEFAULT IS "\r\n";
                };


                using (ExcelPackage templatePackage = new ExcelPackage(template))
                {
                    // Copy the single wor0ksheet from the template workbook to the new workbook.
                    ExcelWorksheet templateWorksheet = templatePackage.Workbook.Worksheets[0]; // Assuming it's the first worksheet
                    int tableNum = 1;
                    foreach (ViewSchedule vs2 in selected)
                    {
                        using (ExcelPackage newPackage = new ExcelPackage(excelFileName))
                        {
                            string pattern = @"[\\/:*?""<>|]";
                            System.String name = Regex.Replace(vs2.Name, pattern, "");
                            string csvFileName = fullPath + @"\" + name + @".csv";
                            ExcelWorksheet copiedWorksheet = newPackage.Workbook.Worksheets.Add(name, templateWorksheet);

                            TableData tableData = vs2.GetTableData();
                            TableSectionData section = tableData.GetSectionData(SectionType.Body);
                            TableSectionData header = tableData.GetSectionData(SectionType.Header);
                            int nRows = section.NumberOfRows;
                            int nColumns = section.NumberOfColumns;

                            //export data to csv
                            //GetScheduleData(vs2, csvFileName);

                            //Add header
                            numOfHeaders = 1;
                            for (int i = 0; i < header.NumberOfRows; i++)
                            {
                                addToHeader(nColumns, copiedWorksheet, vs2.GetCellText(SectionType.Header, i, 0));
                            }
                            // Define the range where you want to start loading the data (e.g., C1)

                            ExcelRangeBase startCell = copiedWorksheet.Cells[numOfHeaders, 1];
                            // Load data from the CSV, skipping the first row and setting the second row as the column headers.
                            ExcelRangeBase range = copiedWorksheet.Cells[startCell.Address].LoadFromDataTable(GetScheduleData(vs2));


                            //add's image inside the header
                            var img = copiedWorksheet.HeaderFooter.OddHeader.InsertPicture(
                                new FileInfo(HeaderPath), PictureAlignment.Centered
                                );
                            // Iterate through rows until an empty row is encountered.
                            int currentColumn = 1; // Start from the first colums
                            while (!string.IsNullOrWhiteSpace(copiedWorksheet.Cells[2, currentColumn].Text))
                            {
                                currentColumn++; // Move to the next row
                            }

                            //Add a table onto the data

                            var dataRange = copiedWorksheet.Cells[numOfHeaders, 1 , nRows + numOfHeaders - 1, nColumns];

                            dataRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            ExcelTable table = copiedWorksheet.Tables.Add(dataRange, "Table" + tableNum);
                            table.TableStyle = OfficeOpenXml.Table.TableStyles.Medium1;
                            table.ShowHeader = true;
                            tableNum++;

                            //autofit cell columns
                            copiedWorksheet.Cells[copiedWorksheet.Dimension.Address].AutoFitColumns();

                            // Get the height of the row in points.
                            double rowWidth = 0;
                            for (int i = currentColumn; i != 1; i--)
                            {
                                ExcelColumn row = copiedWorksheet.Column(i);
                                rowWidth += row.Width;
                            }
                            if (rowWidth > 100)
                            {
                                copiedWorksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                            }
                            else
                            {
                                copiedWorksheet.PrinterSettings.Orientation = eOrientation.Portrait;
                            }

                            File.Delete(csvFileName); //Remove Temporary File
                            try
                            {
                                newPackage.Save();
                            }
                            catch (Exception e)
                            {
                                Autodesk.Revit.UI.TaskDialog.Show("Error", e.ToString());
                                return Autodesk.Revit.UI.Result.Failed;

                            }
                        }
                    }
                    foreach (ViewSchedule i in schedules)
                    {
                        Transaction complete = new Transaction(doc, "Change Complete Parameter");
                        complete.Start();
                        if (i.LookupParameter("IMC_ExportComplete") != null)
                            i.LookupParameter("IMC_ExportComplete").Set(1);
                        complete.Commit();
                    }
                }
            }
            Autodesk.Revit.UI.TaskDialog.Show("Success", "File saved");
            return Autodesk.Revit.UI.Result.Succeeded;

        }

    }
}