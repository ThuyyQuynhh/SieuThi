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
    public partial class ThongkeDoanhthu : DevExpress.XtraEditors.XtraUserControl
    {
        public ThongkeDoanhthu()
        {
            InitializeComponent();
        }
        dataProvider dataProvider = new dataProvider();
        public int chon = 0;


        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (chon == 0)
            {
                
                string query = string.Format("select HD.MaHD, CT.MaCT, CT.MaSP, SP.TenSP, CT.SLBan, SP.Gia,(SP.Gia*CT.SLBan) as Trigia  " +
                    "from HoaDon HD, ChiTiet CT, SanPham SP where HD.MaHD = CT.MaHD and CT.MaSP = SP.MaSP and HD.NgayTao = '{0}'", dtpChonngay.Value);

                dtgvDoanhthu.DataSource = dataProvider.GetDataTable(query);
                dtpChonngay.Enabled = false;

            }
            if(chon == 1)
            {
                
                string query = string.Format("select HD.MaHD,HD.Ngaytao, CT.MaCT, CT.MaSP, SP.TenSP, CT.SLBan, SP.Gia , (SP.Gia*CT.SLBan) as Trigia " +
                    "from HoaDon HD, ChiTiet CT, SanPham SP where HD.MaHD = CT.MaHD and CT.MaSP = SP.MaSP and MONTH(HD.NgayTao) = '{0}' and YEAR(HD.NgayTao) = '{1}'",cmbChonthang.Text, cmbChonnam.Text);

                dtgvDoanhthu.DataSource = dataProvider.GetDataTable(query);
                cmbChonthang.Enabled = false;
                cmbChonnam.Enabled = false;
            }
            if(chon == 2)
            {
                
                string query = string.Format("select HD.MaHD, CT.MaCT, CT.MaSP, SP.TenSP, CT.SLBan, SP.Gia , (SP.Gia*CT.SLBan) as Trigia " +
                    "from HoaDon HD, ChiTiet CT, SanPham SP where HD.MaHD = CT.MaHD and CT.MaSP = SP.MaSP and YEAR(HD.NgayTao) = '{0}'", cmbChonnam.Text);

                dtgvDoanhthu.DataSource = dataProvider.GetDataTable(query);
                cmbChonnam.Enabled = false;
            }
            int doanhthu = 0;
           for(int i =0;i<dtgvDoanhthu.RowCount;i++)
            {
                doanhthu = doanhthu + Convert.ToInt32(dtgvDoanhthu.Rows[i].Cells[6].Value);
            }
            txbDoanhthu.Text = doanhthu.ToString();
        }

    }
}
