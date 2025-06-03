namespace Intech
{
    partial class DependentViewForm
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
            this.PlanViewCheckBox = new System.Windows.Forms.CheckedListBox();
            this.AreaCheckBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CreateSheet = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.OverallView = new System.Windows.Forms.ComboBox();
            this.OverallScaleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanViewCheckBox
            // 
            this.PlanViewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlanViewCheckBox.CheckOnClick = true;
            this.PlanViewCheckBox.FormattingEnabled = true;
            this.PlanViewCheckBox.Location = new System.Drawing.Point(12, 36);
            this.PlanViewCheckBox.Name = "PlanViewCheckBox";
            this.PlanViewCheckBox.Size = new System.Drawing.Size(248, 242);
            this.PlanViewCheckBox.TabIndex = 0;
            // 
            // AreaCheckBox
            // 
            this.AreaCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AreaCheckBox.CheckOnClick = true;
            this.AreaCheckBox.FormattingEnabled = true;
            this.AreaCheckBox.Location = new System.Drawing.Point(280, 36);
            this.AreaCheckBox.Name = "AreaCheckBox";
            this.AreaCheckBox.Size = new System.Drawing.Size(230, 242);
            this.AreaCheckBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plan Views";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Areas";
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Location = new System.Drawing.Point(65, 284);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(195, 22);
            this.SearchBox.TabIndex = 4;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(339, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateSheet
            // 
            this.CreateSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateSheet.AutoSize = true;
            this.CreateSheet.Location = new System.Drawing.Point(145, 318);
            this.CreateSheet.Name = "CreateSheet";
            this.CreateSheet.Size = new System.Drawing.Size(114, 20);
            this.CreateSheet.TabIndex = 8;
            this.CreateSheet.Text = "Create Sheets";
            this.CreateSheet.UseVisualStyleBackColor = true;
            this.CreateSheet.CheckedChanged += new System.EventHandler(this.CreateSheet_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(435, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.pictureBox1.ErrorImage = global::TitleBlockSetup.Properties.Resources.IMC_Logo;
            //this.pictureBox1.Image = global::TitleBlockSetup.Properties.Resources.IMC_Logo;
            //this.pictureBox1.InitialImage = global::TitleBlockSetup.Properties.Resources.IMC_Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 332);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 64);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 344);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Create Overall";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // OverallView
            // 
            this.OverallView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OverallView.FormattingEnabled = true;
            this.OverallView.Location = new System.Drawing.Point(280, 304);
            this.OverallView.Name = "OverallView";
            this.OverallView.Size = new System.Drawing.Size(121, 24);
            this.OverallView.TabIndex = 11;
            this.OverallView.Visible = false;
            this.OverallView.SelectedIndexChanged += new System.EventHandler(this.OverallView_SelectedIndexChanged);
            // 
            // OverallScaleLabel
            // 
            this.OverallScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OverallScaleLabel.AutoSize = true;
            this.OverallScaleLabel.Location = new System.Drawing.Point(281, 285);
            this.OverallScaleLabel.Name = "OverallScaleLabel";
            this.OverallScaleLabel.Size = new System.Drawing.Size(88, 16);
            this.OverallScaleLabel.TabIndex = 12;
            this.OverallScaleLabel.Text = "Overall Scale";
            this.OverallScaleLabel.Visible = false;
            this.OverallScaleLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // DependentViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 408);
            this.Controls.Add(this.OverallScaleLabel);
            this.Controls.Add(this.OverallView);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CreateSheet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AreaCheckBox);
            this.Controls.Add(this.PlanViewCheckBox);
            this.MinimumSize = new System.Drawing.Size(429, 253);
            this.Name = "DependentViewForm";
            this.Text = "Dependent View Creator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckedListBox PlanViewCheckBox;
        public System.Windows.Forms.CheckedListBox AreaCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckBox CreateSheet;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.ComboBox OverallView;
        private System.Windows.Forms.Label OverallScaleLabel;
    }
}