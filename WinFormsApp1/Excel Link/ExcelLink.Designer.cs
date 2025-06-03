namespace Excel_Link
{
    partial class ExcelLinkUI
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
            this.InfoGrid = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.OpEx = new System.Windows.Forms.Button();
            this.OpSh = new System.Windows.Forms.Button();
            this.RemLnk = new System.Windows.Forms.Button();
            this.NewLnk = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.nt1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.Settings = new System.Windows.Forms.Button();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            this.ViewTextBox = new System.Windows.Forms.TextBox();
            this.AreaTextBox = new System.Windows.Forms.TextBox();
            this.ScheduleTextBox = new System.Windows.Forms.TextBox();
            this.workSheetTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoGrid
            // 
            this.InfoGrid.AllowUserToAddRows = false;
            this.InfoGrid.AllowUserToDeleteRows = false;
            this.InfoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.InfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.Status,
            this.LastUpdate,
            this.PathColumn});
            this.InfoGrid.Location = new System.Drawing.Point(12, 12);
            this.InfoGrid.Name = "InfoGrid";
            this.InfoGrid.Size = new System.Drawing.Size(819, 249);
            this.InfoGrid.TabIndex = 0;
            this.InfoGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InfoGrid_CellClick);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Schedule Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 75;
            // 
            // LastUpdate
            // 
            this.LastUpdate.HeaderText = "Last Update";
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.ReadOnly = true;
            this.LastUpdate.Width = 200;
            // 
            // PathColumn
            // 
            this.PathColumn.HeaderText = "Excel Path";
            this.PathColumn.Name = "PathColumn";
            this.PathColumn.ReadOnly = true;
            this.PathColumn.Width = 350;
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.create.Location = new System.Drawing.Point(15, 407);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 1;
            this.create.Text = "Create...";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close.Location = new System.Drawing.Point(756, 410);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 2;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            // 
            // OpEx
            // 
            this.OpEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OpEx.Location = new System.Drawing.Point(96, 407);
            this.OpEx.Name = "OpEx";
            this.OpEx.Size = new System.Drawing.Size(75, 23);
            this.OpEx.TabIndex = 3;
            this.OpEx.Text = "Open Excel";
            this.OpEx.UseVisualStyleBackColor = true;
            this.OpEx.Click += new System.EventHandler(this.OpEx_Click);
            // 
            // OpSh
            // 
            this.OpSh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OpSh.Location = new System.Drawing.Point(177, 407);
            this.OpSh.Name = "OpSh";
            this.OpSh.Size = new System.Drawing.Size(75, 23);
            this.OpSh.TabIndex = 4;
            this.OpSh.Text = "Open Sheet";
            this.OpSh.UseVisualStyleBackColor = true;
            this.OpSh.Click += new System.EventHandler(this.OpSh_Click);
            // 
            // RemLnk
            // 
            this.RemLnk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemLnk.Location = new System.Drawing.Point(603, 407);
            this.RemLnk.Name = "RemLnk";
            this.RemLnk.Size = new System.Drawing.Size(85, 23);
            this.RemLnk.TabIndex = 7;
            this.RemLnk.Text = "Remove";
            this.RemLnk.UseVisualStyleBackColor = true;
            this.RemLnk.Click += new System.EventHandler(this.RemLnk_Click);
            // 
            // NewLnk
            // 
            this.NewLnk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewLnk.Location = new System.Drawing.Point(519, 407);
            this.NewLnk.Name = "NewLnk";
            this.NewLnk.Size = new System.Drawing.Size(78, 23);
            this.NewLnk.TabIndex = 6;
            this.NewLnk.Text = "Reload From";
            this.NewLnk.UseVisualStyleBackColor = true;
            this.NewLnk.Click += new System.EventHandler(this.NewLnk_Click);
            // 
            // Up
            // 
            this.Up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Up.Location = new System.Drawing.Point(438, 407);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(75, 23);
            this.Up.TabIndex = 5;
            this.Up.Text = "Reload";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // nt1
            // 
            this.nt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nt1.BackColor = System.Drawing.SystemColors.Menu;
            this.nt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nt1.Cursor = System.Windows.Forms.Cursors.Default;
            this.nt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nt1.Location = new System.Drawing.Point(15, 267);
            this.nt1.Name = "nt1";
            this.nt1.ReadOnly = true;
            this.nt1.Size = new System.Drawing.Size(75, 16);
            this.nt1.TabIndex = 9;
            this.nt1.Text = "Link Info";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(26, 289);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(86, 115);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "Folder:\n\nFile:\n\nStatus:\n\nWorksheet:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(457, 289);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(71, 85);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "Shedule:\n\nArea:\n\nView:";
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(756, 381);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(75, 23);
            this.Settings.TabIndex = 14;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.FolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FolderTextBox.Location = new System.Drawing.Point(96, 291);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.Size = new System.Drawing.Size(355, 13);
            this.FolderTextBox.TabIndex = 15;
            // 
            // FileTextBox
            // 
            this.FileTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.FileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileTextBox.Location = new System.Drawing.Point(96, 320);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.Size = new System.Drawing.Size(355, 13);
            this.FileTextBox.TabIndex = 16;
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.StatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusTextBox.Location = new System.Drawing.Point(96, 351);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(355, 13);
            this.StatusTextBox.TabIndex = 17;
            // 
            // ViewTextBox
            // 
            this.ViewTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.ViewTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ViewTextBox.Location = new System.Drawing.Point(519, 350);
            this.ViewTextBox.Name = "ViewTextBox";
            this.ViewTextBox.Size = new System.Drawing.Size(217, 13);
            this.ViewTextBox.TabIndex = 20;
            // 
            // AreaTextBox
            // 
            this.AreaTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.AreaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AreaTextBox.Location = new System.Drawing.Point(519, 320);
            this.AreaTextBox.Name = "AreaTextBox";
            this.AreaTextBox.Size = new System.Drawing.Size(217, 13);
            this.AreaTextBox.TabIndex = 19;
            // 
            // ScheduleTextBox
            // 
            this.ScheduleTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.ScheduleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScheduleTextBox.Location = new System.Drawing.Point(519, 290);
            this.ScheduleTextBox.Name = "ScheduleTextBox";
            this.ScheduleTextBox.Size = new System.Drawing.Size(217, 13);
            this.ScheduleTextBox.TabIndex = 18;
            // 
            // workSheetTextBox
            // 
            this.workSheetTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.workSheetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.workSheetTextBox.Location = new System.Drawing.Point(96, 382);
            this.workSheetTextBox.Name = "workSheetTextBox";
            this.workSheetTextBox.Size = new System.Drawing.Size(355, 13);
            this.workSheetTextBox.TabIndex = 21;
            // 
            // ExcelLinkUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Close;
            this.ClientSize = new System.Drawing.Size(843, 445);
            this.Controls.Add(this.workSheetTextBox);
            this.Controls.Add(this.ViewTextBox);
            this.Controls.Add(this.AreaTextBox);
            this.Controls.Add(this.ScheduleTextBox);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.FileTextBox);
            this.Controls.Add(this.FolderTextBox);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.nt1);
            this.Controls.Add(this.RemLnk);
            this.Controls.Add(this.NewLnk);
            this.Controls.Add(this.Up);
            this.Controls.Add(this.OpSh);
            this.Controls.Add(this.OpEx);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.create);
            this.Controls.Add(this.InfoGrid);
            this.MaximumSize = new System.Drawing.Size(859, 484);
            this.MinimumSize = new System.Drawing.Size(859, 484);
            this.Name = "ExcelLinkUI";
            this.Text = "Linked Excel Manager";
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView InfoGrid;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button OpEx;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button OpSh;
        private System.Windows.Forms.Button RemLnk;
        private System.Windows.Forms.Button NewLnk;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.TextBox nt1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathColumn;
        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.TextBox StatusTextBox;
        private System.Windows.Forms.TextBox ViewTextBox;
        private System.Windows.Forms.TextBox AreaTextBox;
        private System.Windows.Forms.TextBox ScheduleTextBox;
        private System.Windows.Forms.TextBox workSheetTextBox;
    }
}