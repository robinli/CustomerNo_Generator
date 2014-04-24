using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Groupage_client_coder
{
    public partial class Form1 : Form
    {
        CustomerBLL BLL = new CustomerBLL();

        public Form1()
        {
            InitializeComponent();
        }

        private void butReadExcel_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                BLL.Readdata(this.openFileDialog1.FileName);
                this.dataGridView1.DataSource = BLL.CurrentData;
            }
        }

        private void butCalc_Click(object sender, EventArgs e)
        {
            BLL.CalcNewCode();
            this.dataGridView1.DataSource = BLL.CurrentData;
        }

        private void butSaveAs_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BLL.Export(this.saveFileDialog1.FileName);
                MessageBox.Show("done.");
            }
        }
    }
}
