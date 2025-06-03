﻿using Autodesk.Revit.DB;
using OfficeOpenXml;
using System.IO;

namespace Excel_Link
{
    public partial class AddLink : System.Windows.Forms.Form
    {
        ExcelPackage excelPackage = null;
        Transaction trans;
        public AddLink(Autodesk.Revit.DB.Transaction t)
        {
            InitializeComponent();
            this.CenterToParent();
            trans = t;

            currentSheetCheck.Checked = true;
        }

        private void fileDialogButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls|All Files|*.*";
            openFileDialog1.Title = "Select an Excel File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = openFileDialog1.FileName;
                if (Path.GetExtension(pathTextBox.Text).EndsWith("xls")) 
                {
                    MessageBox.Show("Please convert xls to xlsx. You can do this by opening file in excel and clicking SaveAs then select file type as xlsx.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pathTextBox.Text = string.Empty;
                    return;
                }
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
                excelPackage = new ExcelPackage(new FileInfo(pathTextBox.Text));
                ExcelWorksheets worksheets = excelPackage.Workbook.Worksheets;
                foreach (ExcelWorksheet ws in worksheets)
                {
                    workSheetSelect.Items.Add(ws.Name);
                }
                workSheetSelect.Enabled = true;
                workSheetSelect.Text = workSheetSelect.Items[0].ToString();
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
            ExcelWorksheets worksheets = excelPackage.Workbook.Worksheets;
            ExcelWorksheet worksheet = null;
            foreach (ExcelWorksheet ws in worksheets)
            {
                if (ws.Name == workSheetSelect.Text)
                {
                    worksheet = ws;
                    break;
                }
            }

            foreach (ExcelNamedRange namedRange in worksheet.Names)
            {
                areaSelect.Items.Add(namedRange.Name);
                if(namedRange.Name.Equals("_xlnm.Print_Area"))
                {
                    areaSelect.Text = "_xlnm.Print_Area";
                }
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
                    sheetSelect.Items.Add( sheet.SheetNumber + " - " + sheet.Name );
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
            if (string.IsNullOrEmpty(nameTextBox.Text)) { 
                nameTextBox.Text = workSheetSelect.Text;  
            }
            trans.Start();
            string scheduleName = Intech.Excel.newLink(pathTextBox.Text, nameTextBox.Text, 
                                    workSheetSelect.Text, areaSelect.Text, sheetSelect.Text);
            Intech.linkUI.newLink(pathTextBox.Text, workSheetSelect.Text, areaSelect.Text, sheetSelect.Text, scheduleName);
            workSheetSelect.Text = String.Empty;
            areaSelect.Text = String.Empty;
            nameTextBox.Text = String.Empty;
            trans.Commit();
        }
    }
}