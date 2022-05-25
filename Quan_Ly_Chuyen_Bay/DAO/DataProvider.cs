using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class DataProvider
    {
        private static DataProvider Instance; //Ctrl + R + E
        private string connectionStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLYBANVECHUYENBAY;Integrated Security=True";

        public static DataProvider Instance1 { get { if (Instance != null) Instance = new DataProvider(); return DataProvider.Instance; } private set => Instance = value; }
        private DataProvider() { }

        /// <summary>
        /// Thực hiện truy vấn và tra ra một bảng dữ liệu
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlcon = new SqlConnection(connectionStr))
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand(query, sqlcon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                if(parameter != null)
                {
                    int i = 0;
                    string[] para = query.Split(' ');
                    foreach(string item in para)
                    {
                        if (item.Contains('@'))
                        {
                            //Lưu ý khi viết query nên cách biến với dấu phẩy ra.
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                adapter.Fill(data);

                sqlcon.Close();
            }
            return data;
        }
        /// <summary>
        /// Thực hiện truy vấn và trả ra số dòng thành công
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection sqlcon = new SqlConnection(connectionStr))
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand(query, sqlcon);
                
                if (parameter != null)
                {
                    int i = 0;
                    string[] para = query.Split(' ');
                    foreach (string item in para)
                    {
                        if (item.Contains('@'))
                        {
                            //Lưu ý khi viết query nên cách biến với dấu phẩy ra.
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            return data;
        }
        /// <summary>
        /// Thực hiện truy vấn và trả ra một kết quả ví dụ như truy vấn sum, count, avg
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection sqlcon = new SqlConnection(connectionStr))
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand(query, sqlcon);
                if (parameter != null)
                {
                    int i = 0;
                    string[] para = query.Split(' ');
                    foreach (string item in para)
                    {
                        if (item.Contains('@'))
                        {
                            //Lưu ý khi viết query nên cách biến với dấu phẩy ra.
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                sqlcon.Close();
            }
            return data;
        }
    }
}
