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
using System.IO;
using System.Data.SqlClient;

namespace QuanAo
{
    public partial class SanPham : DevExpress.XtraEditors.XtraUserControl
    {
        public SanPham()
        {
            InitializeComponent();
        }
        dataProvider dataProvider = new dataProvider();


        private void SanPham_Load(object sender, EventArgs e)
        {
            

            // load danh mục lên combobox các danh mục tìm kiếm
            string query = "SELECT * FROM DanhMuc";
            cbdanhmuc.DataSource = dataProvider.GetDataTable(query);
            // hiển thị ra tên các danh mục
            cbdanhmuc.DisplayMember = "TenDM";
            // giá trị của mỗi tên danh mục sẽ được đại diện bằng value của danh mục đó là MaDm
            cbdanhmuc.ValueMember = "MaDM";
            // load data lên bảng sản phẩm
            string querydata = "select * from SanPham ";

            // laod lại data lên bảng tìm kiếm
            datasp.DataSource = dataProvider.GetDataTable(querydata);
        }

        //private void cbdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //    // tìm kiếm các sản phẩm phù hợp với điều kiện
        //    string query = "select * from SanPham where MaDM = '" + cbdanhmuc.SelectedValue.ToString() + "'";
        //    DataTable data = dataProvider.GetDataTable(query);
        //    // laod lại data lên bảng tìm kiếm
        //    datasp.DataSource = data;

        //}

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string querytimkiem = "select * from SanPham where TenSP like N'%" + txTimKiem.Text.ToString() + "%'";
            datasp.DataSource = dataProvider.GetDataTable(querytimkiem);
        }

       

        private void datasp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = datasp.CurrentRow.Index; 
            btcapnhat.Enabled = true;
            btxoa.Enabled = true;
            txmaSP.Text = datasp.Rows[i].Cells[0].Value.ToString();
            txTenSP.Text = datasp.Rows[i].Cells[1].Value.ToString();
            txThuongHieu.Text = datasp.Rows[i].Cells[3].Value.ToString();
            numDonGia.Value = Convert.ToInt32( datasp.Rows[i].Cells[9].Value);
            txLoiNhuan.Text = datasp.Rows[i].Cells[8].Value.ToString();
            NgayCapNhat.Text = datasp.Rows[i].Cells[4].Value.ToString();
            txMoTa.Text = datasp.Rows[i].Cells[5].Value.ToString();
            txDonvi.Text = datasp.Rows[i].Cells[6].Value.ToString();
            try
            {
                byte[] b = (byte[])(datasp.Rows[i].Cells[10].Value);
                HinhSP.Image = byteToImage(b);
            }
            catch
            {
                HinhSP.Image = null;
            }


            string query = "select TenDM from DanhMuc where MaDM = '" + datasp.Rows[i].Cells[2].Value.ToString() + "'";
            DataTable data = dataProvider.GetDataTable(query);
            cbdanhmuc.Text = data.Rows[0][0].ToString();
        }

    }
}
