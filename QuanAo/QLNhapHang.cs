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
    public partial class QLNhapHang : DevExpress.XtraEditors.XtraUserControl
    {
        int check = 0;          // biến để ktra xem thêm mới sản phẩm hay nhập hàng đã có trong kho
                                // 1: đã có trong kho , 0: nhập mới sản phẩm
        public QLNhapHang()
        {
            InitializeComponent();
        }

        dataProvider dataProvider = new dataProvider();
        private void dtgvListSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // khi chọn 1 sp đã có trong số những sản phẩm của kho thì k cho phép đổi mã danh mục và mã sản phẩm
            ThongTinSP.Enabled = true;
            txbMaSP.Enabled = false;
            txbDanhmuc.Enabled = false;
            txtendanhmuc.Enabled = false;
            check = 1;      // gán biến check =1 để biết đây là sản phẩm đã có trong kho
            // lấy index của hàng hiện tại
            int i = 0;
            i = dtgvListSP.CurrentRow.Index;
            // gán các text thành các dữu liệu của sản phẩm được nhập vào
            txbMaSP.Text = dtgvListSP.Rows[i].Cells[0].Value.ToString();
            txbTenSP.Text = dtgvListSP.Rows[i].Cells[1].Value.ToString();
            txbDanhmuc.Text = dtgvListSP.Rows[i].Cells[2].Value.ToString();
            txbThuonghieu.Text = dtgvListSP.Rows[i].Cells[3].Value.ToString();
            txbMota.Text = dtgvListSP.Rows[i].Cells[5].Value.ToString();
            txbDonvi.Text = dtgvListSP.Rows[i].Cells[6].Value.ToString();
            txbGiaNhap.Text = dtgvListSP.Rows[i].Cells[7].Value.ToString();
            txbLoinhuan.Text = dtgvListSP.Rows[i].Cells[8].Value.ToString();
            // nếu có ảnh thì sẽ convert từ kiểu byte trong database -> image để hiển thị ra
            try
            {
                byte[] b = (byte[])(dtgvListSP.Rows[i].Cells[10].Value);
                HinhAnhSP.Image = byteToImage(b);

            }
            // nếu sản phẩm k có hình ảnh thì k in ra
            catch
            {
                HinhAnhSP.Image = null;
            }
        }
    }
}
