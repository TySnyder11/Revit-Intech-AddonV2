using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Intech;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Intech
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]//EVERY COMMAND REQUIRES THIS!
    public class linkUI : IExternalCommand
    {
        public static Document doc = null;
        public static UIDocument uidoc = null;
        public static string settingsFile = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\LinkSettings.txt";

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            uidoc = uiApp.ActiveUIDocument;
            doc = uidoc.Document;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Transaction t = new Transaction(doc, "Excel Link");
            Excel_Link.ExcelLinkUI excelLinkUI = new Excel_Link.ExcelLinkUI(t);
            excelLinkUI.ShowDialog();

            return Result.Succeeded;
        }

        public static string getCurrentSheetName()
        {
            ViewSheet sheet = doc.ActiveView as ViewSheet;
            if (sheet != null)
            {
                return sheet.SheetNumber + " - " + sheet.Name;
            }
            return null;
        }

        public static ViewSheet getSheetFromName(string sheetName)
        {
            ViewSheet sheet = null;
            foreach (ViewSheet e in new FilteredElementCollector(doc).OfClass(typeof(ViewSheet))
                .WhereElementIsNotElementType().ToElements())
            {
                if ((e.SheetNumber + " - " + e.Name).Equals(sheetName))
                {
                    //get schedule
                    sheet = e;
                }
            }
            return sheet;
        }

        public static Element revitElementCollect(string name, Type type)
        {
            Element elem = null;
            foreach (Element e in new FilteredElementCollector(doc).OfClass(type)
                .WhereElementIsNotElementType().ToElements())
            {
                if (e.Name.Equals(name))
                {
                    //get schedule
                    elem = e;
                }
            }
            return elem;
        }

        public static ViewSchedule getScheduleFromName(string scheduleName)
        {
            ViewSchedule schedule = null;
            foreach (ViewSchedule e in new FilteredElementCollector(doc).OfClass(typeof(ViewSchedule))
                .WhereElementIsNotElementType().ToElements())
            {
                if (e.Name.Equals(scheduleName))
                {
                    //get schedule
                    schedule = e;
                }
            }
            return schedule;
        }

        public static void setActiveViewSheet(string sheetName)
        {
            ViewSheet sheet = getSheetFromName(sheetName);
            if (sheet != null)
            {
                uidoc.ActiveView = sheet;
            }
            else
            {
                MessageBox.Show("Sheet not found: " + sheetName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string[][] readSave()
        {
            string[] localSettings = File.ReadAllText(settingsFile).Split('\n');
            string saveFile = localSettings[1].Trim();
            if (File.Exists(saveFile))
            {
                string[] lines = File.ReadAllLines(saveFile);
                List<string[]> data = new List<string[]>();
                foreach (string line in lines)
                {
                    string[] lineData = line.Split('\t');
                    if (!string.IsNullOrWhiteSpace(line) && lineData[0].Equals(doc.Title))
                    {
                        data.Add(line.Split('\t'));
                    }
                }
                return data.ToArray();
            }
            else
            {
                createSaveFile();
            }
            return new string[0][];
        }

        public static void appendSave(string[] data)
        {
            string[] localSettings = File.ReadAllText(settingsFile).Split('\n');
            string saveFile = localSettings[1].Trim();
            if (File.Exists(saveFile))
            {
                using (StreamWriter sw = new StreamWriter(saveFile, true))
                {
                    sw.WriteLine(string.Join("\t", data));
                }
            }
            else
            {
                MessageBox.Show("Save file not found: " + saveFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void removeLineFromSave(int lineVal)
        {
            string[] localSettings = File.ReadAllText(settingsFile).Split('\n');
            string saveFile = localSettings[1].Trim();
            if (File.Exists(saveFile))
            {
                List<string> lines = new List<string>(File.ReadAllLines(saveFile));
                if (lineVal >= 0 && lineVal < lines.Count)
                {
                    lines.RemoveAt(lineVal);
                    File.WriteAllLines(saveFile, lines);
                }
                else
                {
                    MessageBox.Show("Invalid line number: " + lineVal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Save file not found: " + saveFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void newLink(string path, string workSheet, string area, string viewSheet, string schedule)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(workSheet) || string.IsNullOrEmpty(area))
            {
                MessageBox.Show("All fields must be filled out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //get system time to be able to check if file is out of date in the future
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string user = Environment.UserName; // Get the current user's name

            // Append the new link to the save file
            appendSave(new string[] { doc.Title, path, workSheet, area, viewSheet, timeStamp, user, schedule });
        }

        public static void createSaveFile()
        {
            string[] localSettings = File.ReadAllLines(settingsFile);
            string saveFile = localSettings[1].Trim();
            if (!File.Exists(saveFile))
            {
                using (StreamWriter sw = new StreamWriter(saveFile, false))
                {
                    sw.WriteLine("Project\tPath\tWorksheet\tArea\tViewSheet\tTimestamp\tUser\tSchedule");
                }
            }
        }

        public static string getSaveFile()
        {
            string[] localSettings = File.ReadAllLines(settingsFile);
            return localSettings[1].Trim();
        }

        public static int findLineIndexFromDataRow(string[] dataRow)
        {
            string[] localSettings = File.ReadAllText(settingsFile).Split('\n');
            string saveFile = localSettings[1].Trim();
            if (File.Exists(saveFile))
            {
                string[] lines = File.ReadAllLines(saveFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] lineData = lines[i].Split('\t');
                    if (dataRow.SequenceEqual(lineData))
                    {
                        return i; // Return the index of the matching line
                    }
                }
            }
            return -1;
        }

        public static void changeSaveFile(string newPath)
        {
            string[] localSettings = File.ReadAllLines(settingsFile);
            localSettings[1] = newPath;
            File.WriteAllLines(settingsFile, localSettings);
        }
    }
}