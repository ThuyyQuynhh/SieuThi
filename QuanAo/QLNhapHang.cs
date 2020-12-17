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
        // kiểm tra xem nhập đủ thông tin chưa mới cho phép nhập kho
        bool ktra()
        {
            if (txbMaSP.Text == "" || txbMaSP.Text == "" || txbTenSP.Text == "" || txbDanhmuc.Text == "" || txbThuonghieu.Text == "" || txbMota.Text == "" || txbDonvi.Text == "" || txbGiaNhap.Text == "" || txbLoinhuan.Text == "")
            {

                return false;
            }
            return true;

        }
        // click vào button nhập kho
        [Obsolete]
        private void button2_Click(object sender, EventArgs e)
        {
            // nếu nhập đủ thông tin thì cho phép cập nhật
            if (ktra())
            {


                // nhập sản phẩm đã có trong kho
                if (check == 1)
                {

                    try
                    {
                        byte[] b = imagetoarray(HinhAnhSP.Image);
                        SqlConnection conect = new SqlConnection(dataProvider.connectionSTR);
                        conect.Open();
                        float gia = Convert.ToInt32(txbGiaNhap.Text) * (1 + float.Parse(txbLoinhuan.Text));
                        string query = string.Format("update SanPham set NgayCapNhat = '{0}', GiaNhap = {1},Nhap = Nhap + {2}, Ton = Ton+{3},Hinh = @Hinh ,Gia ={4} where MaSP = '{5}' ", dtpNgayUpdate.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(txbGiaNhap.Text), Convert.ToInt32(numNhapthem.Value), Convert.ToInt32(numNhapthem.Value), gia, txbMaSP.Text);
                        SqlCommand cmd = new SqlCommand(query, conect);
                        cmd.Parameters.Add("@Hinh", b);
                        cmd.ExecuteNonQuery();
                        conect.Close();
                        dtgvListSP.DataSource = dataProvider.GetDataTable("select * from SanPham");
                    }
                    catch (Exception ex)
                    {
                        float gia = Convert.ToInt32(txbGiaNhap.Text) * (1 + float.Parse(txbLoinhuan.Text));
                        string query2 = string.Format("update SanPham set NgayCapNhat = '{0}', GiaNhap ={1},Nhap = Nhap + {2}, Ton = Ton+{3},Gia ={4}, Hinh = null where MaSP = '{5}' select * from SanPham", dtpNgayUpdate.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(txbGiaNhap.Text), Convert.ToInt32(numNhapthem.Value), Convert.ToInt32(numNhapthem.Value), gia, txbMaSP.Text);
                        dtgvListSP.DataSource = dataProvider.GetDataTable(query2);

                    }

                }
                // nhập sản phẩm mới
                else
                {
                    // kiểm tra mã sản phẩm đã tồn tại chưa
                    DataTable checkma = dataProvider.GetDataTable("select * from SanPham where MaSP = N'" + txbMaSP.Text.ToString() + "'");
                    if (checkma.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại");

                    }
                    else
                    {
                        // kiểm tra xem đã tồn tại danh mục chưa, nếu chưa thì tạo danh mục trong database
                        DataTable data = dataProvider.GetDataTable("select * from DanhMuc where MaDM = '" + txbDanhmuc.Text.ToString() + "'");
                        // chưa tồn tại danh mục
                        if (data.Rows.Count == 0)
                        {
                            txtendanhmuc.Enabled = true;


                            if (txtendanhmuc.Text != "")
                            {

                                string query = "insert into DanhMuc values('" + txbDanhmuc.Text + "',N'" + txtendanhmuc.Text + "')";
                                dataProvider.exc(query);

                                try
                                {
                                    float gia = Convert.ToInt32(txbGiaNhap.Text) * (1 + float.Parse(txbLoinhuan.Text));
                                    byte[] b = imagetoarray(HinhAnhSP.Image);
                                    SqlConnection conect = new SqlConnection(dataProvider.connectionSTR);
                                    conect.Open();
                                    string query2 = string.Format("insert into SanPham values ('{0}',N'{1}','{2}',N'{3}','{4}',N'{5}',N''{6}',{7},{8},{9},@Hinh,{10},0,{11}) ", txbMaSP.Text, txbTenSP.Text, txbDanhmuc.Text, txbThuonghieu.Text, dtpNgayUpdate.Value, txbMota.Text, txbDonvi.Text, Convert.ToInt32(txbGiaNhap.Text), txbLoinhuan.Text, gia, Convert.ToInt32(numNhapthem.Value), Convert.ToInt32(numNhapthem.Value));
                                    SqlCommand cmd = new SqlCommand(query2, conect);
                                    cmd.Parameters.Add("@Hinh", b);
                                    cmd.ExecuteNonQuery();
                                    conect.Close();
                                    dtgvListSP.DataSource = dtgvListSP.DataSource = dataProvider.GetDataTable("select * from SanPham");
                                }
                                catch (Exception ex)
                                {
                                    float gia = Convert.ToInt32(txbGiaNhap.Text) * (1 + float.Parse(txbLoinhuan.Text));
                                    string query2 = string.Format("insert into SanPham(MaSP,TenSP,MaDM ,ThuongHieu,NgayCapNhat,Mota,Donvi,GiaNhap,LoiNhuan,Gia,Nhap,Ban,Ton) values('{0}',N'{1}','{2}',N'{3}','{4}',N'{5}',N'{6}',{7},{8},{9},null,{10},0,{11}) select *from SanPham", txbMaSP.Text, txbTenSP.Text, txbDanhmuc.Text, txbThuonghieu.Text, dtpNgayUpdate.Value, txbMota.Text, txbDonvi.Text, Convert.ToInt32(txbGiaNhap.Text), txbLoinhuan.Text, gia, Convert.ToInt32(numNhapthem.Value), Convert.ToInt32(numNhapthem.Value));
                                    dtgvListSP.DataSource = dataProvider.GetDataTable(query2);

                                }
                                txbMaSP.Text = "";
                                txbTenSP.Text = "";
                                txbDanhmuc.Text = "";
                                txbThuonghieu.Text = "";
                                txbMota.Text = "";
                                txbDonvi.Text = "";
                                txbGiaNhap.Text = "";
                                txbLoinhuan.Text = "";
                                numNhapthem.Value = 0;
                                txtendanhmuc.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Danh mục mới, yêu cầu nhập tên danh mục");
                            }
                        }
                        // nếu đã tồn tại danh mục
                        else
                        {
                            try
                            {
                                float gia = Convert.ToInt32(txbGiaNhap.Text) * (1 + float.Parse(txbLoinhuan.Text));
                                byte[] b = imagetoarray(HinhAnhSP.Image);
                                SqlConnection conect = new SqlConnection(dataProvider.connectionSTR);
                                conect.Open();
                                string query2 = string.Format("insert into SanPham values ('{0}',N'{1}','{2}',N'{3}','{4}',N'{5}',N'{6}',{7},{8},{9},@Hinh,{10},0,{11}) ", txbMaSP.Text, txbTenSP.Text, txbDanhmuc.Text, txbThuonghieu.Text, dtpNgayUpdate.Value, txbMota.Text, txbDonvi.Text, Convert.ToInt32(txbGiaNhap.Text), txbLoinhuan.Text, gia, Convert.ToInt32(numNhapthem.Value), Convert.ToInt32(numNhapthem.Value));
                                SqlCommand cmd = new SqlCommand(query2, conect);
                                cmd.Parameters.Add("@Hinh", b);
                                cmd.ExecuteNonQuery();
                                conect.Close();
                                dtgvListSP.DataSource = dtgvListSP.DataSource = dataProvider.GetDataTable("select * from SanPham");
                            }
                            catch (Exception ex)
                            {

                                float gia = Convert.ToInt32(txbGiaNhap.Text) * (1 + float.Parse(txbLoinhuan.Text));
                                string query2 = string.Format("insert into SanPham(MaSP,TenSP,MaDM ,ThuongHieu,NgayCapNhat,Mota,Donvi,GiaNhap,LoiNhuan,Gia,Nhap,Ban,Ton) values('{0}',N'{1}','{2}',N'{3}','{4}',N'{5}',N'{6}',{7},{8},{9},{10},0,{11}) select *from SanPham", txbMaSP.Text, txbTenSP.Text, txbDanhmuc.Text, txbThuonghieu.Text, dtpNgayUpdate.Value, txbMota.Text, txbDonvi.Text, Convert.ToInt32(txbGiaNhap.Text), txbLoinhuan.Text, gia, Convert.ToInt32(numNhapthem.Value), Convert.ToInt32(numNhapthem.Value));
                                dtgvListSP.DataSource = dataProvider.GetDataTable(query2);

                            }
                            txbMaSP.Text = "";
                            txbTenSP.Text = "";
                            txbDanhmuc.Text = "";
                            txbThuonghieu.Text = "";
                            txbMota.Text = "";
                            txbDonvi.Text = "";
                            txbGiaNhap.Text = "";
                            txbLoinhuan.Text = "";
                            numNhapthem.Value = 0;
                            txtendanhmuc.Enabled = false;
                        }




                    }





                }


            }
            // chưa nhập đủ thì đưa ra thông báo
            else
            {
                MessageBox.Show("Nhập đủ thông tin sản phẩm trước khi nhập kho");
            }
        }
        // sự kiện load form lên
        private void QLNhapHang_Load(object sender, EventArgs e)
        {
            string query = string.Format("select *from SanPham ");

            dtgvListSP.DataSource = dataProvider.GetDataTable(query);
            ThongTinSP.Enabled = false;
        }
        // click vào button tìm kiếm sản phẩm
        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            string query = string.Format("select *from SanPham SP where SP.TenSP like N'%{0}%'", txbNameSP.Text);

            dtgvListSP.DataSource = dataProvider.GetDataTable(query);
        }
        // click button thêm mới
        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            txbMaSP.Text = "";
            txbTenSP.Text = "";
            txbDanhmuc.Text = "";
            txbThuonghieu.Text = "";
            txbMota.Text = "";
            txbDonvi.Text = "";
            txbGiaNhap.Text = "";
            txbLoinhuan.Text = "";
            numNhapthem.Value = 0;
            HinhAnhSP.Image = null;
            ThongTinSP.Enabled = true;
            txbMaSP.Enabled = true;
            txbDanhmuc.Enabled = true;
            check = 0;



        }
        // chuyển image thành byte[]
        byte[] imagetoarray(Image img)
        {
            if (img != null)
            {
                MemoryStream m = new MemoryStream();
                img.Save(m, img.RawFormat);
                return m.ToArray();
            }
            else return null;
        }
        // chuyển byte[] về image
        Image byteToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        // sự kiện click vào button chọn hình ảnh
        private void dockPanel2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                HinhAnhSP.Image = Image.FromFile(open.FileName);
            }
        }
        // click vào button xóa ảnh
        private void groupControl3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            HinhAnhSP.Image = null;
        }
        // chỉ cho nhập số vào ô giá
        private void txbGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbLoinhuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 46) && !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
