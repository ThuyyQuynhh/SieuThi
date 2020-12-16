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
        // xóa sản phẩm
        private void btxoa_Click(object sender, EventArgs e)
        {
            int i = datasp.CurrentRow.Index;
            datasp.DataSource = dataProvider.GetDataTable("delete from SanPham where MaSP = '" + datasp.Rows[i].Cells[0].Value.ToString() + "' select * from SanPham");
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }
        // button chọn hình ảnh
        private void dockPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                HinhSP.Image = Image.FromFile(open.FileName);
                
            }

        }

        private void btcapnhat_Click(object sender, EventArgs e)
        {
            if(txTenSP.Text =="" || cbdanhmuc.Text =="" || txThuongHieu.Text==""||numDonGia.Value==0 || txLoiNhuan.Text ==""||NgayCapNhat.Text ==""||txDonvi.Text=="")
            {
                MessageBox.Show("Điền đủ thông tin trước khi cập nhật");
            }
            else
            {
                try
                {
                    byte[] b = imagetoarray(HinhSP.Image);
                    SqlConnection conect = new SqlConnection(dataProvider.connectionSTR);
                    conect.Open();
                    string query = "update SanPham set Hinh = @Hinh ,TenSP=N'"+txTenSP.Text.ToString()+"', MaDM ='"+cbdanhmuc.SelectedValue.ToString()+"',ThuongHieu = '"+txThuongHieu.Text.ToString() + "',Donvi = '" + txDonvi.Text.ToString() + "', Gia= "+numDonGia.Value.ToString()+" ,LoiNhuan = "+txLoiNhuan.Text.ToString()+" ,NgayCapNhat = '"+NgayCapNhat.Text.ToString()+"',Mota =N'"+txMoTa.Text.ToString()+"' where MaSP= '" + txmaSP.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conect);
                    cmd.Parameters.Add("@Hinh", b);
                    cmd.ExecuteNonQuery();
                    conect.Close();
                    datasp.DataSource = dataProvider.GetDataTable("select * from SanPham");

                }
                catch
                {
                    dataProvider.exc("update SanPham set Hinh= null, TenSP=N'" + txTenSP.Text.ToString() + "', MaDM ='" + cbdanhmuc.SelectedValue.ToString() + "',ThuongHieu = '" + txThuongHieu.Text.ToString() + "',Donvi = '" + txDonvi.Text.ToString() + "', Gia= " + numDonGia.Value.ToString() + " ,LoiNhuan = " + txLoiNhuan.Text.ToString() + " ,NgayCapNhat = '" + NgayCapNhat.Text.ToString() + "',Mota =N'" + txMoTa.Text.ToString() + "' where MaSP= '" + txmaSP.Text + "'");
                    datasp.DataSource = dataProvider.GetDataTable("select * from SanPham");
                }
            }
            


        }
        // chuyển image thành byte[]
        byte[] imagetoarray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        // chuyển byte[] về image
        Image byteToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

      
        // click button xóa ảnh
        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            HinhSP.Image = null;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
