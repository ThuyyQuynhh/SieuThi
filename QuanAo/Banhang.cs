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
    public partial class Banhang : DevExpress.XtraEditors.XtraUserControl
    {
        public Banhang()
        {
            InitializeComponent();
        }
        dataProvider dataProvider = new dataProvider();//tạo mới một đối tượng lớp kết nối

        private string mahd;                // lưu tạm mã hóa đơn khi tạo hóa đơn mới, sẽ quyết định có ghi ra database không sau


        // load các dữ liệu ban đầu khi form được load lên
        private void Banhang_Load(object sender, EventArgs e)
        {
            //load ngày bán là ngày đăng nhập
            txNgayNhap.Text = DateTime.Now.ToString();  
            // load danh mục lên combobox các danh mục tìm kiếm
            string query = "SELECT * FROM DanhMuc";
            CBSP.DataSource = dataProvider.GetDataTable(query);
            // hiển thị ra tên các danh mục
            CBSP.DisplayMember = "TenDM";
            // giá trị của mỗi tên danh mục sẽ được đại diện bằng value của danh mục đó là MaDm
            CBSP.ValueMember = "MaDM";
            // load các tên nhân viên trong công ty lên combobox nhân viên
            string query1 = "select * from NhanVien";
            CBNV.DataSource = dataProvider.GetDataTable(query1);
            CBNV.DisplayMember = "TenNV";
            CBNV.ValueMember = "MaNV";
            // load sản phẩm lên datatimkiem trước khi tìm kiếm lần đầu tiên
            string query3 = "select MaSP, TenSP , ThuongHieu,Donvi,Gia ,Ton from SanPham";
            dataTimKiem.DataSource = dataProvider.GetDataTable(query3);
            // gán mã hóa đơn để thao tác sau
            mahd = "HD" +( dataProvider.GetDataTable("select * from HoaDon").Rows.Count + 1).ToString();
            txMaHD.Text = mahd;                 // gán mặc định mã hóa đơn cho text MaHd và không sửa được
        }

     

      

      
        // click vào button làm mới hóa đơn
        private void BTLamMoi_Click_1(object sender, EventArgs e)
        {
            // set các text và về null để nhập lại
            
            txSDT.Text = "";
            numSoLuong.Value = 0;
            numKhuyenMai.Value = 0;
            txNgayNhap.Text = "";
            // duyệt bảng các sản phẩm đã được chọn để thanh toán trả về cho kho
            for(int  i = 0 ; i < dataSP.Rows.Count -1; i++)
            {
                // update số lượng sản phẩm còn tồn trong kho
                string queryupdate = "update SanPham set Ton =Ton +" + dataSP.Rows[i].Cells[5].Value.ToString() + "where MaSP = '" + dataSP.Rows[i].Cells[0].Value.ToString() + "' select MaSP, TenSP , ThuongHieu,Donvi,Gia ,Ton from SanPham";
                dataTimKiem.DataSource = dataProvider.GetDataTable(queryupdate);
            }
            // load lại bảng dữ liệu tìm kiếm để cập nhật số lượng mới
            dataTimKiem.DataSource = dataProvider.GetDataTable("select MaSP, TenSP , ThuongHieu,Donvi,Gia,Ton from SanPham");
            dataSP.Rows.Clear();

        }
        // sự kiện khi chọn vào 1 thuộc tính nào đó trong combobox loại sản phẩm
        private void CBSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSP.SelectedValue.ToString() == "DMALL")
            {
                // set tên sản phẩm về null
                txTenSP.Text = "";
                // tìm kiếm các sản phẩm phù hợp với điều kiện
                string query = "select MaSP, TenSP , ThuongHieu,Donvi,Gia,Ton from SanPham  ";
                DataTable data = dataProvider.GetDataTable(query);
                // load lại data lên bảng tìm kiếm
                dataTimKiem.DataSource = data;
            }
            else
            {
                // set tên sản phẩm về null
                txTenSP.Text = "";
                // tìm kiếm các sản phẩm phù hợp với điều kiện
                string query = "select MaSP, TenSP ,ThuongHieu,Donvi,Gia,Ton from SanPham where MaDM = '" + CBSP.SelectedValue.ToString() + "'";
                DataTable data = dataProvider.GetDataTable(query);
                // load lại data lên bảng tìm kiếm
                dataTimKiem.DataSource = data;
            }
            
        }
        // click button tìm kiếm => tìm kiếm trong database các sản phẩm phù hợp
        private void TimKiem_Click(object sender, EventArgs e)
        {
            string query = "select MaSP, TenSP , ThuongHieu,Donvi,Gia,Ton from SanPham where TenSP like N'%" + txTenSP.Text.ToString() + "%'";
            DataTable data = dataProvider.GetDataTable(query);
            dataTimKiem.DataSource = data;
        }
        //sự kiện click vào 1 hàng trong datagridview tìm kiếm
        private void dataTimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            // lưu index của hàng hiện tại ra biến i;
            int i;
            i = dataTimKiem.CurrentRow.Index;
            
            
            // cho phép nhận button thêm
            Them.Enabled = true;
            // không cho phép bấm button xóa
            Xoa.Enabled = false;
            

            
        }
       
        int TongGia()
        {
            int tong = 0;
            for(int  i = 0; i<dataSP.Rows.Count -1; i++)
            {
                tong += Convert.ToInt32(dataSP.Rows[i].Cells[4].Value) * Convert.ToInt32(dataSP.Rows[i].Cells[5].Value);
            }
            return tong;
        }
        // khi chọn 1 sản phẩm bên hóa đơn thì cho phép xóa và không cho phép thêm
        private void dataSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            Them.Enabled = false;
            Xoa.Enabled = true;
            

        }
        
        // button thêm
        
    }
}
