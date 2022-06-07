using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class ReverseOrderDAO
    {
        private static ReverseOrderDAO instance;

        public static ReverseOrderDAO Instance { get { if (instance == null) instance = new ReverseOrderDAO(); return instance; } private set => instance = value; }

        private ReverseOrderDAO() { }

        public int GetStatusByCMND(string id)
        {
            string query = String.Format("SELECT TrangThai FROM dbo.PHIEUDATCHO WHERE CMND = '{0}'", id);
            if (DataProvider.Instance.ExecuteScalar(query, new object[] { id }) == null)
                return 0;
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { id });
        }
    }
}
