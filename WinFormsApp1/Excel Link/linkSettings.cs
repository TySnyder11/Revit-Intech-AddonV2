using System;
using System.Windows.Forms;

namespace Excel_Link
{
    public partial class linkSettings : Form
    {
        public linkSettings()
        {
            InitializeComponent();
            this.CenterToParent();
            pathTextBox.Text = Intech.linkUI.getSaveFile();
        }

        private void fileDialogButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Select a Save Path",
                DefaultExt = "txt",
                AddExtension = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
