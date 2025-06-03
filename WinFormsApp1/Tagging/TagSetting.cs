using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Intech
{
    public partial class TagSetting : Form
    {
        public TagSetting()
        {
            InitializeComponent();
            this.CenterToParent();

            //Get txt Path
            string BasePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + @"\Tag Settings.txt";

            //Get Rows
            string fileContents = File.ReadAllText(BasePath);
            List<string> Columns = fileContents.Split('\n').ToList();
            Columns.RemoveAt(0);

            //Create Table
            DataTable dt = new DataTable();
            DataColumn TrColumn = new DataColumn();
            TrColumn.ColumnName = "Trade";
            TrColumn.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(TrColumn);
            DataColumn TtColumn = new DataColumn();
            TtColumn.ColumnName = "Tag Type";
            TtColumn.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(TtColumn);
            DataColumn CaColumn = new DataColumn();
            CaColumn.ColumnName = "Category";
            dt.Columns.Add(CaColumn);
            DataColumn FaColumn = new DataColumn();
            FaColumn.ColumnName = "Family";
            dt.Columns.Add(FaColumn);
            DataColumn PaColumn = new DataColumn();
            PaColumn.ColumnName = "Path";
            dt.Columns.Add(PaColumn);
            DataColumn TfColumn = new DataColumn();
            TfColumn.ColumnName = "TagFamily";
            TfColumn.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(TfColumn);
            DataColumn LeColumn = new DataColumn();
            LeColumn.ColumnName = "Leader";
            LeColumn.DataType = System.Type.GetType("System.Boolean");
            dt.Columns.Add(LeColumn);

            //Get Columns
            if (Columns[Columns.Count - 1] == "") { Columns.RemoveAt(Columns.Count - 1); }
            foreach (string i in Columns)
            {
                List<string> rows = i.Split('\t').ToList();
                DataRow FirstRow;
                FirstRow = dt.NewRow();
                FirstRow["Trade"] = rows[0];
                FirstRow["Tag Type"] = rows[1];
                FirstRow["Category"] = rows[2];
                FirstRow["Family"] = rows[3];
                FirstRow["Path"] = rows[4];
                FirstRow["TagFamily"] = rows[5];
                Debug.WriteLine(rows[6]);
                if (rows[6].Contains("False")) { bool leader = false; FirstRow["Leader"] = leader; }
                else { bool leader = true; FirstRow["Leader"] = leader; }
                dt.Rows.Add(FirstRow);
            }

            dataGridView1.DataSource = dt;

        }
        private void ExportDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_SelectionChange(object sender, EventArgs e)
        {
            try
            {
                var cell = dataGridView1.SelectedCells[0];
                Debug.WriteLine(cell);
                if (cell.ColumnIndex == 4)
                {
                    OpenFileDialog Browser = new OpenFileDialog();
                    if (Browser.ShowDialog(this) == DialogResult.OK)
                    {
                        string path = Browser.FileName;
                        cell.Value = path;
                        int row = cell.RowIndex;
                        dataGridView1.Rows[row].Cells[5].Value = Path.GetFileNameWithoutExtension(path);
                    }
                }
            }
            catch 
            { 

            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {

        }

        private void TagSetting_Load(object sender, EventArgs e)
        {

        }

        private void Export_Click(object sender, EventArgs e)
        {
            string data = GetData(dataGridView1);
            string header = "Trade\tTagType\tCategory\tFamily\tPath\tTagFamily\tLeader\n";
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
                System.IO.File.WriteAllText(Folder + @"\Tag Setting Export.txt", header + data);
            }
        }

        private void Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog Browser = new OpenFileDialog();

            if (Browser.ShowDialog(this) == DialogResult.OK)
            {
                string importpath = Browser.FileName;
                File.Copy(importpath, typeof(RibbonTab).Assembly.Location.Replace("RibbonSetup.dll", "Tag Settings.txt"), true);
            }
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string data = GetData(dataGridView1);
            string path = typeof(RibbonTab).Assembly.Location.Replace(@"RibbonSetup.dll", @"Tag Settings.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            var newLines = new string[] { lines[0] }.Append(data);
            System.IO.File.WriteAllLines(path, newLines);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); //Closes Form
        }

        protected string GetData(DataGridView dataGrid)
        {
            string data = "";
            //Breaks into rows
            for (int row = 0; row < dataGrid.Rows.Count - 1; row++)
            {
                if (dataGrid.Rows[row].Cells[0].Value.ToString() == "" || dataGrid.Rows[row].Cells[0].Value.ToString() == "\t") { }
                //Breaks into individual cells
                else
                {
                    for (int col = 0; col < dataGrid.Rows[row].Cells.Count; col++)
                    {
                        string value = dataGrid.Rows[row].Cells[col].Value.ToString();
                        if (data == "") { data = value; }
                        else if (col == 0) { data = data + "\n" + value; }
                        else { data = data + '\t' + value; }
                    }
                }
            }
            return (data);
        }
    }
}
