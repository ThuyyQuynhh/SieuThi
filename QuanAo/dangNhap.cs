using QuanAo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanAo
{
    public partial class login : DevExpress.XtraEditors.XtraForm
    {
        public login()
        {
            InitializeComponent();
           
        }
        dataProvider dataProvider = new dataProvider();



        // Kiểm tra tài khoản mật khẩu đăng nhập có chính xác hay không
        private bool DangNhap()
        {
            string query = "SELECT * from admin where Taikhoan = '" + taikhoan.Text + "' and Password = '" + matkhau.Text + "'";
            // lấy data từ database 
            DataTable result = dataProvider.GetDataTable(query);
            // nếu có trường dữ liệu trùng với tài khoản và mật khẩu thì datatable sẽ có dữ liệu => row > 0
            return result.Rows.Count > 0;
        }

        // sự kiện click vào bouton đăng nhập
        private void dangnhap_Click(object sender, EventArgs e)
        {
            if (taikhoan.Text == "" || matkhau.Text == "")
            {
                MessageBox.Show("Nhập tài khoản mật khẩu ");
            }

            else
            {
                if (DangNhap())
                {
                    //home hm = new home();
                    //this.Hide();//ẩn form login
                    //hm.ShowDialog();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản đăng nhập không đúng !!!");
                }
            }



        }
        // button thoát form đăng nhập = > thoát chương trình
        private void thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // sự kiện khi click vào checkbox hiện mật khẩu
        private void showmk_CheckedChanged(object sender, EventArgs e)
        {
            // nếu chọn hiện mật khẩu => cấu hình lại thuộc tính password
            if (showmk.Checked)
            {
                matkhau.PasswordChar = (Char)0;//hiển thị lại mật khẩu nhập
            }
            // bỏ chọn chức năng hiện mật khẩu = > cấu hình lại thuộc tính password
            else
            {

                matkhau.PasswordChar = '*';//hiện thị mật khẩu bằng dấu *
            }


        }
    }
}
