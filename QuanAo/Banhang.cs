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


        
    }
}
