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
    public partial class QLNhanvien : DevExpress.XtraEditors.XtraUserControl
    {
        dataProvider dataProvider = new dataProvider();
        public QLNhanvien()
        {
            InitializeComponent();
            string query = "select *from NhanVien";

            dtgvNhanVien.DataSource = dataProvider.GetDataTable(query);
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //sự kiện khi click vào một cột thì cập nhật dữ liệu vào các ô trống
        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow row in dtgvNhanVien.SelectedRows)
            {
                txbMaNV.Text = row.Cells[0].Value.ToString();
                txbTenNV.Text = row.Cells[1].Value.ToString();
                cbGioitinh.Text = row.Cells[2].Value.ToString();
                dtpNgaysinh.Text = row.Cells[3].Value.ToString();
                txbSDT.Text = row.Cells[4].Value.ToString();
                txtDiachi.Text = row.Cells[5].Value.ToString();
                txbLuong.Text = row.Cells[6].Value.ToString();
                cbQuyenhan.Text = row.Cells[7].Value.ToString();
                i++;
            }
        }
        //ktra mã nhân viên có trùng nhau không
        bool KtrTontai()
        {

            string query1 = string.Format("select NV.MaNV from NhanVien NV where NV.MaNV = '{0}' and exists (select *from NhanVien NX where NV.MaNV = NX.MaNV )", txbMaNV.Text);
            if (dataProvider.GetDataTable(query1).Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
