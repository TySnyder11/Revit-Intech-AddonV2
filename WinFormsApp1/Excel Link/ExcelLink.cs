using Autodesk.Revit.DB;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Excel_Link
{
    public partial class ExcelLinkUI : System.Windows.Forms.Form
    {
        Transaction t;
        string[][] data = null;
        public ExcelLinkUI(Autodesk.Revit.DB.Transaction t)
        {
            InitializeComponent();
            this.t = t;
            this.CenterToParent();
            loadSaveFile();
        }

        private void create_Click(object sender, EventArgs e)
        {
            AddLink addLinkForm = new AddLink(t);
            addLinkForm.ShowDialog(this);
            InfoGrid.Rows.Clear();
            loadSaveFile();
        }
        private void loadSaveFile()
        {
            data = Intech.linkUI.readSave();
            for (int i = 0; i < data.Length; i++)
            {
                string[] instance = data[i];
                if (Intech.linkUI.doc.Title == instance[0])
                {
                    string excelPath = instance[1];
                    string fileName = Path.GetFileNameWithoutExtension(excelPath);
                    string sheet = instance[7];
                    string lastUpdate = instance[5];
                    DateTime lastImport = DateTime.ParseExact(lastUpdate, "yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
                    string time = lastImport.ToString("g");
                    if (File.Exists(excelPath))
                    {
                        DateTime lastModified = File.GetLastWriteTime(excelPath);
                        if (lastModified < lastImport)
                        {
                            //file is up to date
                            appendInfoGrid(sheet, "Up to Date", time, fileName);
                        }
                        else
                        {
                            //file is out of date
                            appendInfoGrid(sheet, "Out of Date", time, fileName);
                        }
                    }
                    else
                    {
                        appendInfoGrid(sheet, "File not found", time, fileName);
                    }
                }
            }

            FolderTextBox.Text = string.Empty;
            FileTextBox.Text = string.Empty;
            StatusTextBox.Text = string.Empty;
            workSheetTextBox.Text = string.Empty;
            AreaTextBox.Text = string.Empty;
            ScheduleTextBox.Text = string.Empty;
            ViewTextBox.Text = string.Empty;
        }

        private void appendInfoGrid(string name, string status, string lastUpdate, string fileName)
        {
            InfoGrid.Rows.Add(name, status, lastUpdate, fileName);
        }
        string[] selected = null;
        private void InfoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row == -1) return;
            selected = data[row];
            string excelPath = selected[1];
            string workSheet = selected[2];
            string area = selected[3];
            string viewSheet = selected[4];
            string lastUpdate = selected[5];
            string user = selected[6];
            string sheet = selected[7];

            FolderTextBox.Text = Path.GetDirectoryName(excelPath);
            FileTextBox.Text = Path.GetFileName(excelPath);
            ScheduleTextBox.Text = sheet;
            AreaTextBox.Text = area;
            workSheetTextBox.Text = workSheet;

            //get schedule
            Document doc = Intech.linkUI.doc;
            ViewSheet elm = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet))
                .WhereElementIsNotElementType()
                .ToElements()
                .Cast<ViewSheet>()
                .FirstOrDefault(vs => (vs.SheetNumber + " - " + vs.Name) == viewSheet);
            if (elm != null)
            {
                ViewTextBox.Text = elm.SheetNumber + " - " + elm.Name;
            }
            else
            {
                ViewTextBox.Text = "Schedule not sunk. You or " + user + " needs to sink to populate.";
            }


            //get status

            DateTime lastImport = DateTime.ParseExact(lastUpdate, "yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
            string status = "";
            if (File.Exists(excelPath))
            {
                DateTime lastModified = File.GetLastWriteTime(excelPath);
                if (lastModified < lastImport)
                {
                    status = "Up to Date";
                }
                else
                {
                    status = "Out of Date";
                }
            }
            else
            {
                status = "File not found." + "Might be in local files of " + user + ".";
            }

            StatusTextBox.Text = status;
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StatusTextBox.Text) && !StatusTextBox.Text.Contains("File not found."))
            {
                t.Start("Update Schedule");
                Intech.Excel.Update(FolderTextBox.Text + '\\' + FileTextBox.Text,
                    ScheduleTextBox.Text, workSheetTextBox.Text, AreaTextBox.Text);
                t.Commit();
                int line = Intech.linkUI.findLineIndexFromDataRow(selected);
                Intech.linkUI.removeLineFromSave(line);
                Intech.linkUI.newLink(FolderTextBox.Text + '\\' + FileTextBox.Text,
                    workSheetTextBox.Text, AreaTextBox.Text, ViewTextBox.Text, ScheduleTextBox.Text);
                InfoGrid.Rows.Clear();
                loadSaveFile();
            }
        }

        private void RemLnk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StatusTextBox.Text))
            {
                ViewSchedule schedule = Intech.linkUI.getScheduleFromName(ScheduleTextBox.Text);
                if (schedule == null || Intech.linkUI.doc.ActiveView.Id != schedule.Id)
                {
                    if (schedule != null)
                    {
                        t.Start("Remove Sheet");
                        Intech.linkUI.doc.Delete(schedule.Id);
                        t.Commit();
                    }
                    int line = Intech.linkUI.findLineIndexFromDataRow(selected);
                    Intech.linkUI.removeLineFromSave(line);

                    InfoGrid.Rows.Clear();
                    loadSaveFile();
                }
                else
                {
                    MessageBox.Show("Please close view before deleting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpEx_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StatusTextBox.Text))
            {
                string path = FolderTextBox.Text + '\\' + FileTextBox.Text;
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = path,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("File not found: " + path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NewLnk_Click(object sender, EventArgs e)
        {
            EditLink editLinkForm = new EditLink(FolderTextBox.Text + '\\' + FileTextBox.Text,
                workSheetTextBox.Text, AreaTextBox.Text, ScheduleTextBox.Text, ViewTextBox.Text);
            if (editLinkForm.ShowDialog(this) == DialogResult.OK)
            {
                string path = editLinkForm.pathTextBox.Text;
                string workSheet = editLinkForm.workSheetSelect.Text;
                string area = editLinkForm.areaSelect.Text;
                string name = editLinkForm.nameTextBox.Text;
                string sheet = editLinkForm.sheetSelect.Text;

                t.Start("Edit Link Schedule");
                string scheduleName = Intech.Excel.Update(path, ScheduleTextBox.Text, name, workSheet, area);
                t.Commit();

                if (scheduleName != null)
                {
                    int line = Intech.linkUI.findLineIndexFromDataRow(selected);
                    Intech.linkUI.removeLineFromSave(line);
                    Intech.linkUI.newLink(path, workSheet, area, sheet, scheduleName);
                    InfoGrid.Rows.Clear();
                    loadSaveFile();
                }
            }
        }

        private void OpSh_Click(object sender, EventArgs e)
        {
            Intech.linkUI.setActiveViewSheet(ViewTextBox.Text);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            linkSettings settingsForm = new linkSettings();
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                Intech.linkUI.changeSaveFile(settingsForm.pathTextBox.Text);
                InfoGrid.Rows.Clear();
                loadSaveFile();
            }
        }
    }
}
