using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class SanBayDAO
    {
        private static SanBayDAO instance;

        public static SanBayDAO Instance { get { if (instance == null) instance = new SanBayDAO(); return instance; } private set => instance = value; }

        private SanBayDAO() { }

        public DataTable GetListSanBay()
        {
            return (DataTable)DataProvider.Instance.ExecuteQuery("SELECT * FROM SANBAY");
        }

        public bool InsertSanBay(string maSanBay, string tenSanBay)
        {
            string query = string.Format("INSERT dbo.SANBAY (MaSanBay, TenSanBay) VALUES ('{0}', '{1}')", maSanBay, tenSanBay);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateSanBay(string maSanBay, string tenSanBay)
        {
            string query = string.Format("UPDATE dbo.SANBAY SET TenSanBay = '{1}' WHERE MaSanBay = '{0}'", maSanBay, tenSanBay);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteSanBay(string maSanBay)
        {
            string query = string.Format("DELETE dbo.SANBAY WHERE MaSanBay = N'{0}'", maSanBay);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable GetAllMaSB()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MaSanBay FROM SANBAY");
        }
    }
}
