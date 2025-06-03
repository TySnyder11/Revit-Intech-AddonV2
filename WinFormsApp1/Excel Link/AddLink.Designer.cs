namespace Excel_Link
{
    partial class AddLink
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.fileDialogButton = new System.Windows.Forms.Button();
            this.areaSelect = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.workSheetSelect = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.View = new System.Windows.Forms.TextBox();
            this.sheetSelect = new System.Windows.Forms.ComboBox();
            this.currentSheetCheck = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ExcelFileDialog";
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Save.Location = new System.Drawing.Point(12, 193);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 0;
            this.Save.Text = "Save...";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(281, 193);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // fileDialogButton
            // 
            this.fileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDialogButton.Location = new System.Drawing.Point(64, 32);
            this.fileDialogButton.Name = "fileDialogButton";
            this.fileDialogButton.Size = new System.Drawing.Size(270, 23);
            this.fileDialogButton.TabIndex = 2;
            this.fileDialogButton.Text = "File Explorer...";
            this.fileDialogButton.UseVisualStyleBackColor = true;
            this.fileDialogButton.Click += new System.EventHandler(this.fileDialogButton_Click);
            // 
            // areaSelect
            // 
            this.areaSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.areaSelect.FormattingEnabled = true;
            this.areaSelect.Location = new System.Drawing.Point(73, 95);
            this.areaSelect.Name = "areaSelect";
            this.areaSelect.Size = new System.Drawing.Size(275, 21);
            this.areaSelect.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(35, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 13);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Area";
            // 
            // workSheetSelect
            // 
            this.workSheetSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.workSheetSelect.FormattingEnabled = true;
            this.workSheetSelect.Location = new System.Drawing.Point(73, 68);
            this.workSheetSelect.Name = "workSheetSelect";
            this.workSheetSelect.Size = new System.Drawing.Size(275, 21);
            this.workSheetSelect.TabIndex = 5;
            this.workSheetSelect.SelectedIndexChanged += new System.EventHandler(this.workSheetSelect_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(10, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(62, 13);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "WorkSheet";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(12, 10);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(28, 13);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Path";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(38, 6);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(322, 20);
            this.pathTextBox.TabIndex = 8;
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_TextChanged);
            // 
            // View
            // 
            this.View.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.View.BackColor = System.Drawing.SystemColors.Control;
            this.View.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.View.Location = new System.Drawing.Point(18, 171);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(35, 13);
            this.View.TabIndex = 10;
            this.View.Text = "Sheet";
            // 
            // sheetSelect
            // 
            this.sheetSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetSelect.FormattingEnabled = true;
            this.sheetSelect.Location = new System.Drawing.Point(59, 168);
            this.sheetSelect.Name = "sheetSelect";
            this.sheetSelect.Size = new System.Drawing.Size(292, 21);
            this.sheetSelect.TabIndex = 9;
            // 
            // currentSheetCheck
            // 
            this.currentSheetCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.currentSheetCheck.AutoSize = true;
            this.currentSheetCheck.Location = new System.Drawing.Point(32, 148);
            this.currentSheetCheck.Name = "currentSheetCheck";
            this.currentSheetCheck.Size = new System.Drawing.Size(91, 17);
            this.currentSheetCheck.TabIndex = 11;
            this.currentSheetCheck.Text = "Current Sheet";
            this.currentSheetCheck.UseVisualStyleBackColor = true;
            this.currentSheetCheck.CheckedChanged += new System.EventHandler(this.currentSheetCheck_CheckedChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(73, 122);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(275, 20);
            this.nameTextBox.TabIndex = 13;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(36, 125);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(35, 13);
            this.textBox5.TabIndex = 12;
            this.textBox5.Text = "Name";
            // 
            // AddLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(368, 221);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.currentSheetCheck);
            this.Controls.Add(this.View);
            this.Controls.Add(this.sheetSelect);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.workSheetSelect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.areaSelect);
            this.Controls.Add(this.fileDialogButton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.MaximumSize = new System.Drawing.Size(600, 260);
            this.MinimumSize = new System.Drawing.Size(200, 260);
            this.Name = "AddLink";
            this.Text = "AddLink";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button fileDialogButton;
        private System.Windows.Forms.ComboBox areaSelect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox workSheetSelect;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox View;
        private System.Windows.Forms.ComboBox sheetSelect;
        private System.Windows.Forms.CheckBox currentSheetCheck;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox textBox5;
    }
}