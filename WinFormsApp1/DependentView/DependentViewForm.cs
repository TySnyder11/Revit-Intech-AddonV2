using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Intech
{
    public partial class DependentViewForm : System.Windows.Forms.Form
    {
        public DataTable dt = new DataTable();
        public DependentViewForm(List<Element> planViewList, List<Element> areaList, List<string> scales)
        {
            InitializeComponent();
            this.CenterToParent();


            DataTable dt = new DataTable();

            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("Checked", typeof(bool));

            foreach (Element i in planViewList) dt.Rows.Add(i.Name, false);

            dt.AcceptChanges();

            PlanViewCheckBox.DataSource = dt.DefaultView;
            PlanViewCheckBox.DisplayMember = "Item";
            PlanViewCheckBox.ValueMember = "Item";

            PlanViewCheckBox.ItemCheck += PlanViewCheckBox_ItemCheck;

            List<string> list = new List<string>();
            foreach (Element i in areaList) list.Add(i.Name);
            list.Sort();
            foreach (string i in list) AreaCheckBox.Items.Add(i);

            foreach (string i in scales) OverallView.Items.Add(i);
        }

        private void PlanViewCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var dv = PlanViewCheckBox.DataSource as DataView;
            var drv = dv[e.Index];
            drv["Checked"] = e.NewValue == CheckState.Checked ? true : false;

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            var dv = PlanViewCheckBox.DataSource as DataView;
            string filter = "";
            if (SearchBox.Text.Trim().Length > 0)
            {
                //filter = $"Item LIKE '{textBox1.Text}*'";
                foreach (DataRow i in dv.Table.Rows)
                {
                    object[] Items = i.ItemArray;
                    string name = Items[0].ToString();
                    if (name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                        filter = filter + $"(Item LIKE '{name}*') OR ";
                }
                if (filter == "")
                {
                    filter = $"(Item LIKE 'doesnotexcist*')";
                }
                else
                {
                    int length = filter.Count() - 4;
                    filter = filter.Substring(0, length);
                }


            }
            else
            {
                filter = null;
            }

            if (string.IsNullOrEmpty(filter))
                dv.RowFilter = "";
            else if (filter.Length < 30000)
                dv.RowFilter = filter;

            for (var i = 0; i < PlanViewCheckBox.Items.Count; i++)
            {
                var drv = PlanViewCheckBox.Items[i] as DataRowView;
                var chk = Convert.ToBoolean(drv["Checked"]);
                PlanViewCheckBox.SetItemChecked(i, chk);
            }
        }

        private void CreateSheet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OverallScaleLabel.Visible = checkBox1.Checked;
            OverallView.Visible = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void OverallView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
