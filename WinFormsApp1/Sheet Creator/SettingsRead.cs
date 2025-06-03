using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Intech
{
    public class SettingsRead
    {
        public static (string tradeAbbreviation, string SheetNumber, string titleBlockFamily, string titleBlockType) BaseControls()
        {

            string tradeAbbreviation = "";
            string SheetNumber = "";
            string titleBlockFamily = "";
            string titleBlockType = "";

            //Get txt Path
            string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt";

            //Get Rows
            string fileContents = File.ReadAllText(BasePath);
            foreach (string e in fileContents.Split('@').ToList())
            {
                e.Replace("@", "");
                List<string> Columns = e.Split('\n').ToList();
                if (Columns[0].Contains("Sheet Creator Base Settings"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    foreach (string i in Columns)
                    {
                        i.Remove('\r');
                        List<string> rows = i.Split('\t').ToList();
                        tradeAbbreviation = rows[0];
                        SheetNumber = rows[1];
                        titleBlockFamily = rows[2];
                        titleBlockType = rows[3];
                    }
                }
            }
            return (tradeAbbreviation,SheetNumber, titleBlockFamily, titleBlockType);
        }
        public static Dictionary<string,(string, string)> Scale ()
        {

            Dictionary<string, (string, string)> scale = new Dictionary<string, (string, string)> ();

            //Get txt Path
            string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt";

            //Get Rows
            string fileContents = File.ReadAllText(BasePath);
            foreach (string e in fileContents.Split('@').ToList())
            {
                e.Replace("@", "");
                List<string> Columns = e.Split('\n').ToList();
                if (Columns[0].Contains("Scale"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        i.Remove('\r');
                        List<string> rows = i.Split('\t').ToList();
                        scale.Add (rows[0],(rows[1] , rows[2]));
                        x++;
                    }
                }
            }
            return scale;
        }

        public static Dictionary<string, (string, string)> NonstandardLevels()
        {

            Dictionary<string, (string, string)> nonstandardLevels = new Dictionary<string, (string, string)>();

            //Get txt Path
            string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt";

            //Get Rows
            string fileContents = File.ReadAllText(BasePath);
            foreach (string e in fileContents.Split('@').ToList())
            {
                e.Replace("@", "");
                List<string> Columns = e.Split('\n').ToList();
                if (Columns[0].Contains("Nonstandard Level Info"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        i.Remove('\r');
                        List<string> rows = i.Split('\t').ToList();
                        nonstandardLevels.Add(rows[0],( rows[1], rows[2]));
                        x++;
                    }
                }
            }
            return nonstandardLevels;
        }

        public static Dictionary<string, (string, string)> NonstandardArea()
        {

            Dictionary<string, (string, string)> nonstandardArea = new Dictionary<string, (string, string)>();

            //Get txt Path
            string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt";

            //Get Rows
            string fileContents = File.ReadAllText(BasePath);
            foreach (string e in fileContents.Split('@').ToList())
            {
                e.Replace("@", "");
                List<string> Columns = e.Split('\n').ToList();
                if (Columns[0].Contains("Nonstandard Scopebox Info"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        nonstandardArea.Add(rows[0], (rows[1], rows[2]));
                        x++;
                    }
                }
            }
            return nonstandardArea;
        }

        public static Dictionary<string, (string, string)> Discipline()
        {

            Dictionary<string, (string, string)> discipline = new Dictionary<string, (string, string)>();

            //Get txt Path
            string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt";

            //Get Rows
            string fileContents = File.ReadAllText(BasePath);
            foreach (string e in fileContents.Split('@').ToList())
            {
                e.Replace("@", "");
                List<string> Columns = e.Split('\n').ToList();
                if (Columns[0].Contains("Sheet Discipline"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        discipline.Add(rows[0], (rows[1], rows[2]));
                        x++;
                    }
                }
            }
            return discipline;
        }

        public static (List<string>, bool) SubDiscipline()
        {

            List<string> subDiscipline = new List<string>();
            bool check = false;

            //Get txt Path
            string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt";

            //Get Rows
            string fileContents = File.ReadAllText(BasePath);
            foreach (string e in fileContents.Split('@').ToList())
            {
                e.Replace("@", "");
                List<string> Columns = e.Split('\n').ToList();
                if (Columns[0].Contains("Sheet Sub Discipline"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        subDiscipline.Add(rows[0]);
                        x++;
                    }
                }
                if (Columns[0].Contains("Sub Discipline check"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        if (rows[0].Replace("\r", "") == "True") check = true;
                        x++;
                    }
                }
            }
            return (subDiscipline,check);
        }
    }
}