using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAo.Data
{
    class dataProvider
    {
        //// chuỗi liên kết tới database
        //public static string connectionSTR = "Data Source=DESKTOP-0JUE26U\\SQLEXPRESS;Initial Catalog=ShopQuanAo;Integrated Security=True";
        //// phương thức lấy datatable khi đưa 1 câu query vào
        //public static DataTable GetDataTable(string query , object[] parameter = null )
        //{
        //    // tạo ra đối tượng datatable để lưu data
        //    DataTable data = new DataTable();
        //    // dùng using để khi kết nối nếu có xảy ra lỗi hay khi kết thúc sẽ tự hủy đi kết nối
        //    using(SqlConnection connection = new SqlConnection(connectionSTR))
        //    {
        //        // mở kết nối
        //        connection.Open();
        //        // lệnh cmd để thực thi query
        //        SqlCommand command = new SqlCommand(query, connection);
        //        // nếu trường hợp query gọi đến product store và truyền vào parameter
        //        if(parameter != null)
        //        {
        //            // chuỗi cắt nhỏ query theo dấu " " => trong query phải viết dấu phải cách 2 phía nếu không sẽ lỗi
        //            string[] listpara = query.Split(' ');
        //            // biến đếm vị trí para trong listpara
        //            int i = 0; 
        //            // duyệt xem phần tử nào trong listpara là parameter
        //            foreach(string item in listpara)
        //            {
        //                if (item.Contains('@'))
        //                {
        //                    // gán giá trị cho parameter
        //                    command.Parameters.AddWithValue(item, parameter[i]);
        //                    i++;
        //                }
        //            }

        //        }
        //        // adapter để lưu tạm dữ liệu và đổ vào datatable bằng phương thức fill
        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //         adapter.Fill(data);
        //        // đóng kết nối
        //        connection.Close();
        //    }


        //    // trả về datatable
        //    return data;

        //}
        //public static void exc(string query , object[] parameter = null)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionSTR))
        //    {
        //        // mở kết nối
        //        connection.Open();
        //        // lệnh cmd để thực thi query
        //        SqlCommand command = new SqlCommand(query, connection);
        //        // nếu trường hợp query gọi đến product store và truyền vào parameter
        //        if (parameter != null)
        //        {
        //            // chuỗi cắt nhỏ query theo dấu " " => trong query phải viết dấu phải cách 2 phía nếu không sẽ lỗi
        //            string[] listpara = query.Split(' ');
        //            // biến đếm vị trí para trong listpara
        //            int i = 0;
        //            // duyệt xem phần tử nào trong listpara là parameter
        //            foreach (string item in listpara)
        //            {
        //                if (item.Contains('@'))
        //                {
        //                    // gán giá trị cho parameter
        //                    command.Parameters.AddWithValue(item, parameter[i]);
        //                    i++;
        //                }
        //            }

        //        }
        //        command.ExecuteNonQuery();
        //        // đóng kết nối
        //        connection.Close();
        //    }
        //}

        //khai báo một chuỗi kết nối và tạo kết nối
        public string connectionSTR = "Data Source= Quynh\\SQLEXPRESS;Initial Catalog = QLSieuThi;Integrated Security = True";
        public DataTable GetDataTable(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))//du lieu duoc khai bao trong ngoac tu duoc giai phong
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);//thuc thi query tren ket noi connection
                SqlDataAdapter adapter = new SqlDataAdapter(command);//trung gian dua ra ket qua
                adapter.Fill(data);
                connection.Close();
            }


            return data;

        }
        public DataTable exc(string query)
        {
            DataTable data = new DataTable();
            // string connectionSTR = "Data Source= DESKTOP-0JUE26U\\SQLEXPRESS;Initial Catalog = QuanLiquanCafe;Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionSTR))//du lieu duoc khai bao trong ngoac tu duoc giai phong
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);//thuc thi query tren ket noi connection
                command.ExecuteNonQuery();
               // SqlDataAdapter adapter = new SqlDataAdapter(command);//trung gian dua ra ket qua
                //adapter.Fill(data);
                connection.Close();
            }


            return data;

        }


    }
}
//sqlCommand: thực thi SQL query, câu lệnh hoặc lưu trữ thủ tục
//sqlConnection: tạo kết nối với SQL Server
//SQL Adapter: cầu nối trung gian giữa dataset và data source
