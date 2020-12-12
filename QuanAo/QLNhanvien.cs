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

namespace QuanAo
{
    public partial class QLNhanvien : DevExpress.XtraEditors.XtraUserControl
    {
        dataProvider dataProvider = new dataProvider();
        public QLNhanvien()
        {
            InitializeComponent();
            string query = "select *from NhanVien";

            dtgvNhanVien.DataSource = dataProvider.GetDataTable(query);
        }

    }
}
