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
        
        
    }
}