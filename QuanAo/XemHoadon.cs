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
    public partial class XemHoadon : DevExpress.XtraEditors.XtraUserControl
    {
        public XemHoadon()
        {
            InitializeComponent();
        }
        dataProvider dataProvider = new dataProvider();



        public int click = 0;
       


        // tìm kiếm hóa đơn
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string query = string.Format("select *from HoaDon HD where HD.Ngaytao between '{0}' and '{1}'", tungay.Value, denngay.Value);

            datahoadon.DataSource = dataProvider.GetDataTable(query);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (click == 1)
            {

                //show ra hoá đơn tương ứng với hàng được chọn
                int i = datahoadon.CurrentRow.Index;
                ReportHD report = new ReportHD();


                string query = "exec Report '" + datahoadon.Rows[i].Cells[0].Value.ToString()+ "'";
                DataTable dataHD = dataProvider.GetDataTable(query);
                report.DataSource = dataHD;
                report.ShowPreviewDialog();
            }
        }

        private void datahoadon_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            click = 1; //tức là đã chọn ra một hàng để xem hoá đơn
        }
    }
}
