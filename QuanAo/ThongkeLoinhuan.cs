using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanAo.Data;

namespace QuanAo
{
    public partial class ThongkeLoinhuan : DevExpress.XtraEditors.XtraUserControl
    {
        public ThongkeLoinhuan()
        {
            InitializeComponent();
        }
        dataProvider dataProvider = new dataProvider();
        public int chon = 0;
        private void raBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raBtn_Click(object sender, EventArgs e)
        {
            dtpChonngay.Enabled = true;
            chon = 0;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            cmbChonthang.Enabled = true;
            cmbChonnam.Enabled = true;
            chon = 1;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            cmbChonnam.Enabled = true;
            chon = 2;
        }

    }
}
