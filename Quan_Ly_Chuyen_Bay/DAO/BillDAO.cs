using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class BillDAO
    {
        #region TẠO SINGLETON
        private static BillDAO instance;

        public static BillDAO Instance { get { if (instance == null) instance = new BillDAO(); return instance; }  private set => instance = value; }
        private BillDAO() { }
        #endregion

        //THỐNG KÊ DOANH THU DỰA TRÊN NĂM (fAdmin - Thống kê doanh thu)
        public DataTable GetTurnoverByYear(int year) 
        {
            string query = "EXEC USP_GetListBillByYear @year";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { year });
        }

        public object GetAmountMoneyByYearBillDAO(int year)
        {
            string query = "EXEC USP_GetAmountMoneyByYear @year";
            if (DataProvider.Instance.ExecuteScalar(query, new object[] { year }) == null)
                return 0;
            return DataProvider.Instance.ExecuteScalar(query, new object[] { year });
        }

        public DataTable GetTurnoverByDate(DateTime checkIn, DateTime checkOut)
        {
            string query = "EXEC USP_GetListBillByDate @checkIn , @checkOut";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { checkIn, checkOut });
        }

        public object GetAmountMoneyByMonthBillDAO(DateTime checkIn, DateTime checkOut)
        {
            string query = "EXEC USP_GetAmountMoneyByMonth @checkIn , @checkOut";
            if (DataProvider.Instance.ExecuteScalar(query, new object[] { checkIn, checkOut }) == null)
                return 0;
            return DataProvider.Instance.ExecuteScalar(query, new object[] { checkIn, checkOut });
        }

        public DataTable GetChartByYear(int year)
        {
            string query = "EXEC USP_ChartByYear @year";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { year });
        }
    }
}
