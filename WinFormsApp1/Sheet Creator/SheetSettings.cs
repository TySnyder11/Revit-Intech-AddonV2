using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Intech
{
    public partial class SheetSettings : System.Windows.Forms.Form
    {
        Dictionary<string, List<string>> titleblockFamily = new Dictionary<string, List<string>>();
        Document doc;
        public SheetSettings(ExternalCommandData commandData)
        {
            InitializeComponent();
            this.CenterToParent();

            UIApplication uiapp = commandData.Application;
            doc = uiapp.ActiveUIDocument.Document;
            Transaction trans = new Transaction(doc);
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //Get txt Path
            string BasePath = typeof(RibbonTab).Assembly.Location.Replace("RibbonSetup.dll", "SheetSettings.txt");

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
                        List<string> rows = i.Split('\t').ToList();
                        TradeAbriviation.Text = rows[0];
                        MiddleSheetNumber.Text = rows[1];
                        TitleBlockFamily.Text = rows[2];
                        TitleBlockType.Text = rows[3];
                    }
                }
                else if (Columns[0].Contains("Nonstandard Level Info"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        LevelGrid.Rows.Add(rows[0], rows[1], rows[2]);
                        x++;
                    }
                }
                else if (Columns[0].Contains("Nonstandard Scopebox Info"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        AreaGrid.Rows.Add(rows[0], rows[1], rows[2]);
                        x++;
                    }
                }
                else if (Columns[0].Contains("Sheet Sub Discipline"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        SubDisciplineGrid.Rows.Add(rows[0]);
                        x++;
                    }
                }
                else if (Columns[0].Contains("Sheet Discipline"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        DisciplineGrid.Rows.Add(rows[0], rows[1], rows[2]);
                        x++;
                    }
                }
                else if (Columns[0].Contains("Scale"))
                {
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(0);
                    Columns.RemoveAt(Columns.Count - 1);
                    Columns.RemoveAt(Columns.Count - 1);
                    int x = 0;
                    foreach (string i in Columns)
                    {
                        List<string> rows = i.Split('\t').ToList();
                        ScaleGrid.Rows.Add(rows[0], rows[1], rows[2]);
                        x++;
                    }
                }
            }

            List<Element> titleblocktypes = new FilteredElementCollector(doc)
            .OfCategory(BuiltInCategory.OST_TitleBlocks)
            .WhereElementIsElementType()
            .ToElements() as List<Element>;

            foreach (FamilySymbol i in titleblocktypes)
            {
                if (!titleblockFamily.Keys.Contains(i.FamilyName))
                {
                    titleblockFamily.Add(i.FamilyName, new List<string>());
                    titleblockFamily[i.FamilyName].Add(i.Name);
                }
                else if (titleblockFamily.Keys.Contains(i.Category.Name) && !titleblockFamily[i.Category.Name].Contains(i.Name))
                {
                    titleblockFamily[i.Category.Name].Add(i.Name);
                }
            }

            foreach (string i in titleblockFamily.Keys)
                TitleBlockFamily.Items.Add(i);

            if (TitleBlockFamily.Text != "")
                try
                {
                    foreach (string i in titleblockFamily[TitleBlockFamily.Text])
                        TitleBlockType.Items.Add(i);
                }
                catch { }

        }

        private void Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog Browser = new OpenFileDialog();

            if (Browser.ShowDialog(this) == DialogResult.OK)
            {
                string importpath = Browser.FileName;
                File.Copy(importpath, Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt", true);
            }
            this.Close();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            var data = GetData();
            SaveFileDialog Browser = new SaveFileDialog();
            Browser.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            Browser.FilterIndex = 1; // Set the default filter to txt files
            Browser.DefaultExt = ".txt"; // Set the default extension

            if (Browser.ShowDialog(this) == DialogResult.OK)
            {
                string Folder = Browser.FileName;
                using (FileStream fs = File.Create(Folder))
                {

                }
                System.IO.File.WriteAllText(Folder, data);
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            var data = GetData();
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\SheetSettings.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            var newLines = new string[] { data };
            System.IO.File.WriteAllLines(path, newLines);
            this.Close();
        }

        protected string GetData()
        {
            string baseData = "@Sheet Creator Base Settings\n* Trade Abriviation\tMiddle Sheet Number\tTitleBlockFamily\tTitleBlockType\n"
                + TradeAbriviation.Text + "\t"
                + MiddleSheetNumber.Text + "\t"
                + TitleBlockFamily.Text + "\t"
                + TitleBlockType.Text;

            string levelData = "@Nonstandard Level Info\r\n*Level Name\tTitle Block Parameter Name\tSheet Number Value";
            for (int row = 0; row < LevelGrid.Rows.Count - 1; row++)
            {
                if (LevelGrid.Rows[row].Cells[0].Value == null);
                else if (LevelGrid.Rows[row].Cells[0].Value.ToString() == "" || LevelGrid.Rows[row].Cells[0].Value.ToString() == "\t") { }
                //Breaks into individual cells
                else
                {
                    for (int col = 0; col < LevelGrid.Rows[row].Cells.Count; col++)
                    {
                        string value;
                        if (LevelGrid.Rows[row].Cells[col].Value == null) value = "";
                        else value = LevelGrid.Rows[row].Cells[col].Value.ToString().Replace("\n", "");
                        if (col == 0) { levelData += "\n" + value; }
                        else { levelData += '\t' + value; }
                    }
                }
            }

            string areaData = "@Nonstandard Scopebox Info\r\n*ScopeBox Name\tTitle Block Parameter Name\tSheet Number Value";
            for (int row = 0; row < AreaGrid.Rows.Count - 1; row++)
            {
                if (AreaGrid.Rows[row].Cells[0].Value == null) ;
                else if (AreaGrid.Rows[row].Cells[0].Value.ToString() == "" || AreaGrid.Rows[row].Cells[0].Value.ToString() == "\t") { }
                //Breaks into individual cells
                else
                {
                    for (int col = 0; col < AreaGrid.Rows[row].Cells.Count; col++)
                    {

                        string value;
                        if (AreaGrid.Rows[row].Cells[col].Value == null) value = "";
                        else value = AreaGrid.Rows[row].Cells[col].Value.ToString().Replace("\n", "");
                        if (col == 0) { areaData += "\n" + value; }
                        else { areaData += '\t' + value; }
                    }
                }
            }

            string scaleData = "@Scale\r\n*FeetInch\tViewportId\tRevitScaleValue";
            for (int row = 0; row < ScaleGrid.Rows.Count - 1; row++)
            {
                if (ScaleGrid.Rows[row].Cells[0].Value == null);
                else if (ScaleGrid.Rows[row].Cells[0].Value.ToString() == "" || ScaleGrid.Rows[row].Cells[0].Value.ToString() == "\t");
                //Breaks into individual cells
                else
                {
                    for (int col = 0; col < ScaleGrid.Rows[row].Cells.Count; col++)
                    {
                        string value = ScaleGrid.Rows[row].Cells[col].Value.ToString().Replace("\n", "");
                        if (col == 0) { scaleData += "\n" + value; }
                        else { scaleData += '\t' + value; }
                    }
                }
            }

            string disciplineData = "@Sheet Discipline\r\n*Discipline Name\tDiscipline#";
            for (int row = 0; row < DisciplineGrid.Rows.Count - 1; row++)
            {
                if (DisciplineGrid.Rows[row].Cells[0].Value == null) ;
                else if (DisciplineGrid.Rows[row].Cells[0].Value.ToString() == "" || DisciplineGrid.Rows[row].Cells[0].Value.ToString() == "\t") { }
                //Breaks into individual cells
                else
                {
                    for (int col = 0; col < DisciplineGrid.Rows[row].Cells.Count; col++)
                    {
                        string value = DisciplineGrid.Rows[row].Cells[col].Value.ToString().Replace("\n", "");
                        if (col == 0) { disciplineData += "\n" + value; }
                        else { disciplineData += '\t' + value; }
                    }
                }
            }

            string subDisciplineData = "@Sheet Sub Discipline\r\n*Disipline";
            for (int row = 0; row < SubDisciplineGrid.Rows.Count - 1; row++)
            {
                if (SubDisciplineGrid.Rows[row].Cells[0].Value == null) ;
                else if (SubDisciplineGrid.Rows[row].Cells[0].Value.ToString() == "" || SubDisciplineGrid.Rows[row].Cells[0].Value.ToString() == "\t") { }
                //Breaks into individual cells
                else
                {
                    for (int col = 0; col < SubDisciplineGrid.Rows[row].Cells.Count; col++)
                    {
                        string value = SubDisciplineGrid.Rows[row].Cells[col].Value.ToString().Replace("\n", "");
                        if (col == 0) { subDisciplineData += "\n" + value; }
                        else { subDisciplineData += '\t' + value; }
                    }
                }
            }


            string checkSubDisciplineData = "@Sub Discipline check\r\n";
            if (SubDisciplineCheck.Checked)
                checkSubDisciplineData += "True\r\n";
            else
                checkSubDisciplineData += "False\r\n";

            string wholeSheet = baseData + "\n\n" + levelData + "\n\n" + areaData + "\n\n" + scaleData + "\n\n" + disciplineData + "\n\n" + subDisciplineData + "\n\n" + checkSubDisciplineData + "\n";

            return (wholeSheet);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TitleBlockType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BaseControlTab_Click(object sender, EventArgs e)
        {

        }

        private void TitleBlockFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            TitleBlockType.Items.Clear();
            TitleBlockType.Text = "";
            Transaction temp = new Transaction(doc, "Temp");
            if (TitleBlockFamily.Text != "")
                foreach (string i in titleblockFamily[TitleBlockFamily.Text])
                {
                    TitleBlockType.Items.Add(i);
                }
        }

        private void ScaleGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
