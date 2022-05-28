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
        #region MAKE SINGLETON
        private static DataProvider instance;
        private readonly string connectionStr = @"Data Source=LAPTOP-8JOFS4BS;Initial Catalog=QLYBANVECHUYENBAY;Integrated Security=True";

        public static DataProvider Instance { get { if(instance == null) instance = new DataProvider(); return instance; } private set => instance = value; }
        private DataProvider() { }
        #endregion

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
