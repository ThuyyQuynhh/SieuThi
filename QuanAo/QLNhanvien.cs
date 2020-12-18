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
        public int Add_change = 0;//tạo một biến để xem click vào thêm hay sửa, thêm = 0, sửa = 1
        private void btnAdd_Click(object sender, EventArgs e)//thêm mới
        {
            //reset các ô cho phép nhập thông tin
            txbMaNV.ReadOnly = false;
            txbTenNV.ReadOnly = false;
            txbSDT.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            txbLuong.ReadOnly = false;


        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            txbMaNV.ReadOnly = true;
            //reset các ô cho phép sửa
            txbTenNV.ReadOnly = false;
            txbSDT.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            txbLuong.ReadOnly = false;
            Add_change = 1;

        }

        private void txbMaNV_TextChanged(object sender, EventArgs e)
        {

        }
        private void btUpdate_Click(object sender, EventArgs e)//sửa thành public để gọi biến Add_Change
        {
            //if (KtrTontai())
            //{
            //    MessageBox.Show("Nhân viên này đã tồn tại");
            //}
            //else
            //{
            if (Add_change == 0)
            {
                if (KtrTontai())
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại");
                }
                else
                {

                    string query2 = string.Format(" insert into NhanVien values ('{0}',N'{1}',N'{2}','{3}','{4}',N'{5}','{6}',N'{7}') select *from NhanVien",
                         txbMaNV.Text, txbTenNV.Text, cbGioitinh.Text, dtpNgaysinh.Value, txbSDT.Text, txtDiachi.Text, txbLuong.Text, cbQuyenhan.Text);
                    dtgvNhanVien.DataSource = dataProvider.GetDataTable(query2);
                }

            }
            else
            {

                string query = string.Format(" update NhanVien set TenNV = N'{0}', GioiTinh = N'{1}', NgaySinh = '{2}', SDT = '{3}', DiaChi = N'{4}', Luong = '{5}',  Chucvu = N'{6}' where MaNV = '{7}' select *from NhanVien",
                      txbTenNV.Text, cbGioitinh.Text, dtpNgaysinh.Value, txbSDT.Text, txtDiachi.Text, txbLuong.Text, cbQuyenhan.Text, txbMaNV.Text);
                dtgvNhanVien.DataSource = dataProvider.GetDataTable(query);
            }
            //}

        }
        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {

        }
        public string MaNVcu;
        private void txbMaNV_Click(object sender, EventArgs e)
        {
            MaNVcu = txbMaNV.Text;
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn đổi mã nhân viên?", "Chú ý", MessageBoxButtons.OKCancel);
            if (dlr == DialogResult.Cancel)
            {
                txbMaNV.ReadOnly = true;
            }
        }
        // public string Taikhoancu;
        private void txtDisplayName_Click(object sender, EventArgs e)
        {

        }
    }
}
