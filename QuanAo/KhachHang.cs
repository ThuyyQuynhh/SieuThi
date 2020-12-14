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
            
        }


        
        
    }
}
