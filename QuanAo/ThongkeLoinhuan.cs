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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(chon == 0)
            {
                
                string query = string.Format("select HD.MaHD,CT.MaSP, SP.TenSP, CT.SLBan, SP.Gia ,SP.Loinhuan, (SP.Gia*SP.Loinhuan) as Thuve " +
                    "from HoaDon HD, ChiTiet CT, SanPham SP where HD.MaHD = CT.MaHD and CT.MaSP = SP.MaSP and  HD.NgayTao = '{0}'", dtpChonngay.Value);

                dtgvLoinhuan.DataSource = dataProvider.GetDataTable(query);
                dtpChonngay.Enabled = false;
            }
            if(chon == 1)
            {
                
                string query = string.Format("select HD.MaHD,CT.MaSP, SP.TenSP, CT.SLBan, SP.Gia ,SP.Loinhuan, (SP.Gia*SP.Loinhuan) as Thuve " +
                    "from HoaDon HD, ChiTiet CT, SanPham SP where HD.MaHD = CT.MaHD and CT.MaSP = SP.MaSP and MONTH(HD.NgayTao) = '{0}' and YEAR(HD.NgayTao) = '{1}'", cmbChonthang.Text, cmbChonnam.Text);

                dtgvLoinhuan.DataSource = dataProvider.GetDataTable(query);
                
                cmbChonthang.Enabled = false;
                cmbChonnam.Enabled = false;
            }
            if(chon == 2)
            {
                
                string query = string.Format("select HD.MaHD,CT.MaSP, SP.TenSP, CT.SLBan, SP.Gia ,SP.Loinhuan, (SP.Gia*SP.Loinhuan) as Thuve " +
                    "from HoaDon HD, ChiTiet CT, SanPham SP where HD.MaHD = CT.MaHD and CT.MaSP = SP.MaSP and YEAR(HD.NgayTao) = '{0}'", cmbChonnam.Text);

                dtgvLoinhuan.DataSource = dataProvider.GetDataTable(query);
                
                cmbChonnam.Enabled = false;
            }
            int loinhuan = 0;
            for (int i = 0; i < dtgvLoinhuan.RowCount; i++)
            {
                loinhuan = loinhuan + Convert.ToInt32(dtgvLoinhuan.Rows[i].Cells[6].Value);
            }
            txbLoinhuan.Text = loinhuan.ToString();

        }
    }
}
