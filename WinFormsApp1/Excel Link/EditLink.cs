using Autodesk.Revit.DB;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Excel_Link
{
    public partial class EditLink : System.Windows.Forms.Form
    {
        IXLWorkbook excelPackage = null;
        public static string path = null;
        public static string workSheet = null;
        public static string area = null;
        public static string name = null;
        public static string sheet = null;
        public EditLink(string path, string workSheet, string area, string Name, string sheet)
        {
            InitializeComponent();
            this.CenterToParent();

            pathTextBox.Text = path;
            workSheetSelect.Text = workSheet;
            areaSelect.Text = area;
            nameTextBox.Text = Name;
            sheetSelect.Text = sheet;
        }

        private void fileDialogButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls|All Files|*.*";
            openFileDialog1.Title = "Select an Excel File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {
            workSheetSelect.Items.Clear();
            workSheetSelect.Text = string.Empty;
            workSheetSelect.Enabled = false;
            excelPackage = null;
            if (IsExcelFile(pathTextBox.Text))
            {
                excelPackage = new XLWorkbook(pathTextBox.Text);
                IXLWorksheets worksheets = excelPackage.Worksheets;
                foreach (IXLWorksheet ws in worksheets)
                {
                    workSheetSelect.Items.Add(ws.Name);
                }
                workSheetSelect.Enabled = true;
            }
        }

        static bool IsExcelFile(string fileName)
        {
            string extension = Path.GetExtension(fileName)?.ToLower();
            return extension == ".xls" || extension == ".xlsx";
        }

        private void workSheetSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            areaSelect.Items.Clear();
            areaSelect.Text = string.Empty;
            areaSelect.Enabled = false;
            IXLWorksheets worksheets = excelPackage.Worksheets;
            IXLWorksheet worksheet = null;
            foreach (IXLWorksheet ws in worksheets)
            {
                if (ws.Name == workSheetSelect.Text)
                {
                    worksheet = ws;
                    break;
                }
            }

            foreach (IXLDefinedName namedRange in worksheet.DefinedNames)
            {
                areaSelect.Items.Add(namedRange.Name);
            }
            if (areaSelect.Items.Count > 0)
            {
                areaSelect.Enabled = true;
            }
        }

        private void currentSheetCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!currentSheetCheck.Checked)
            {
                sheetSelect.Text = string.Empty;
                sheetSelect.Enabled = true;
                sheetSelect.Items.Clear();
                Document doc = Intech.linkUI.doc;
                IList<Element> sheets = new FilteredElementCollector(doc)
                    .OfClass(typeof(ViewSheet)).WhereElementIsNotElementType().ToElements();
                foreach (ViewSheet sheet in sheets)
                {
                    sheetSelect.Items.Add(sheet.SheetNumber + " - " + sheet.Name);
                }
            }
            else
            {
                sheetSelect.Enabled = false;
                sheetSelect.Text = Intech.linkUI.getCurrentSheetName();
                if (string.IsNullOrEmpty(sheetSelect.Text))
                {
                    currentSheetCheck.Checked = false;
                    currentSheetCheck.Enabled = false;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathTextBox.Text) || string.IsNullOrEmpty(sheetSelect.Text) ||
                string.IsNullOrEmpty(workSheetSelect.Text) || string.IsNullOrEmpty(areaSelect.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                nameTextBox.Text = workSheetSelect.Text;
            }

            path = pathTextBox.Text;
            workSheet = workSheetSelect.Text;
            area = areaSelect.Text;
            name = nameTextBox.Text;
            sheet = sheetSelect.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
