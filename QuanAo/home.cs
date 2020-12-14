using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using QuanAo.Data;

namespace QuanAo
{
    public partial class home : DevExpress.XtraBars.Ribbon.RibbonForm//giải thích chỗ này
    {
        public home()
        {
            InitializeComponent();
          
            

        }
        // giao diện của sự kiện khi load form lên sẽ mặc định là office 2007 green
        private void skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel def = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            def.LookAndFeel.SkinName = "Office 2007 Green";
        }
        // khi load form gọi tới skin() => để laod giao diện mặc định lên
        private void home_Load(object sender, EventArgs e)
        {
            TrangChu TC = new TrangChu();
            addpage(fr_main, "Trang chủ", TC);
            skin();
        }
        /* phương thức thêm 1 page vào xtratabcontrol 
            - xtratabcha: Tên của xtratabcontrol được dùng để thêm các tabpage con
            - tabname: Tên sẽ hiển thị ra của tabpage con
            - usetr: usercontrol được thêm vào cái page mới được tạo ra
         */
        private void addpage(DevExpress.XtraTab.XtraTabControl xtratabCha, string tabNameAdd, System.Windows.Forms.UserControl useCtr)
        {
            int dem = 0;        // biến đếm tabpage trùng tên
            foreach (DevExpress.XtraTab.XtraTabPage tab in fr_main.TabPages)                 // chạy vòng lặp để ktra xem form muốn add vào đã có chưa
            {
                if (tab.Name == tabNameAdd)                                                  // nếu tên form mới đã có
                {
                    fr_main.SelectedTabPage = tab;                          // focus vào page muốn tạo nhưng đã tồn tại 
                    dem = 1;                                                // thay đổi biến đếm =1
                }

            }
            // chạy xong vòng lặp, nếu dem = 1 = > page đã tồn tại, nếu dem !=1 => page chưa tồn tại nên sẽ addpage vào extratab
            if (dem != 1)
            {
                DevExpress.XtraTab.XtraTabPage TabAdd = new DevExpress.XtraTab.XtraTabPage();           // tạo ra page  để add usercontrol và sau đó add vào extratab
                TabAdd.Text = tabNameAdd;                       // gán tên của tabpage mới được tạo bằng tên mình muốn
                TabAdd.Name = tabNameAdd;                       // gán tên cho tabpage
                TabAdd.Controls.Add(useCtr);                    // add usercontrol vào tabpage vừa tạo ra
                useCtr.Dock = DockStyle.Fill;                   // fill cho nó đầy ra tabpage
                fr_main.TabPages.Add(TabAdd);                   // thêm tabpage vào xtratabcontrol 
                fr_main.SelectedTabPage = TabAdd;               // focus vào tabpage vừa được tạo ra
            }



        }

        // sự kiện khi click vào dấu x của page con trong xtratabcontrol
        private void fr_main_CloseButtonClick(object sender, EventArgs e)
        {// dong tab
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();



        }
        //  click vaò button bán hàng
        private void BTBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            // tạo usercontrol và thêm vào xtratab
            Banhang BH = new Banhang();
            addpage(fr_main, "Bán hàng", BH);

        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrangChu TC = new TrangChu();
            addpage(fr_main, "Trang chủ", TC);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            QLNhapHang NH = new QLNhapHang();
            addpage(fr_main, "Nhập hàng", NH);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            QLNhanvien NV = new QLNhanvien();
            addpage(fr_main, "Nhân viên", NV);
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            SanPham SP = new SanPham();
            addpage(fr_main, "Sản phẩm", SP);
        }
        // sự kiện khách hàng
        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            KhachHang KH = new KhachHang();
            addpage(fr_main, "Khách hàng", KH);
        }
        // sự kiện thống kê doanh thu
        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThongkeDoanhthu DT = new ThongkeDoanhthu();
            addpage(fr_main, "Thống kê doanh thu", DT);
        }
        // thống kê lợi nhuận
        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThongkeLoinhuan LN = new ThongkeLoinhuan();
            addpage(fr_main, "Thống kê lợi nhuận", LN);
        }
        // đăng xuất khỏi chương trình
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            login DN = new login();
            DN.ShowDialog();
            this.Close();


        }
        // button tạo hóa đơn trong nav
        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // tạo usercontrol và thêm vào xtratab
            Banhang BH = new Banhang();
            addpage(fr_main, "Bán hàng", BH);
        }
        // button kho hàng trong nav
        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            QLNhapHang NH = new QLNhapHang();
            addpage(fr_main, "Nhập hàng", NH);
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // button nhân viên trong nav
            QLNhanvien NV = new QLNhanvien();
            addpage(fr_main, "Nhân viên", NV);
        }
        // button hàng hóa trong nav
        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SanPham SP = new SanPham();
            addpage(fr_main, "Sản phẩm", SP);
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            KhachHang KH = new KhachHang();
            addpage(fr_main, "Khách hàng", KH);
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            XemHoadon Hd = new XemHoadon();
            addpage(fr_main, "Hóa đơn", Hd);
        }

    }
}