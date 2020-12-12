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

    }
}
