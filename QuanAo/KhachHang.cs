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
using DevExpress.XtraReports.UI;

namespace QuanAo
{
    public partial class KhachHang : DevExpress.XtraEditors.XtraUserControl
    {
       dataProvider dataProvider = new dataProvider();
        public KhachHang()
        {
            InitializeComponent();
            //load danh sách khách hàng 
            string query = string.Format("select *from KhachHang");

            dtgvListKH.DataSource = dataProvider.GetDataTable(query);

        }
        // giao diện của sự kiện khi load form lên sẽ mặc định là office 2007 green
        private void skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel def = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            def.LookAndFeel.SkinName = "Office 2007 Green";
        }
        // khi load form gọi tới skin() => để laod giao diện mặc định lên
        private void dtgvListKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //sự kiện khi click vào một cột của bảng danh sách khách hàng
        private void dtgvListKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //sử dụng try catch để xử lý ngoại lệ khi click vào tên cột
            try
            {
                int i = 0;
                //load dữ liệu vào các ô trong phiếu thông tin khách hàng
                foreach (DataGridViewRow row in dtgvListKH.SelectedRows)
                {
                    txbMaKH.Text = row.Cells[0].Value.ToString();
                    txbTenKH.Text = row.Cells[1].Value.ToString();
                    txbSDT.Text = row.Cells[2].Value.ToString();
                    i++;
                    //khi click vào khách hàng thì hiển thị những hoá đơn khách hàng đã mua vào dtgv đơn đã mua
                    string query1 = string.Format("select KH.MaKH, KH.TenKH, HD.MaHD, HD.MaNV,HD.Ngaytao, HD.TongGia from HoaDon HD, KhachHang KH where HD.MaKH = KH.MaKH and KH.MaKH = '{0}'", txbMaKH.Text);

                    dtgvDamua.DataSource = dataProvider.GetDataTable(query1);
                }
            }
            catch
            {

            }

        }
        




    }
}
