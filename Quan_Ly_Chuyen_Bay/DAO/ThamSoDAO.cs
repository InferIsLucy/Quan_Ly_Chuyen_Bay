using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class ThamSoDAO
    {
        private static ThamSoDAO instance;

        public static ThamSoDAO Instance { get { if (instance == null) instance = new ThamSoDAO(); return instance; } private set => instance = value; }
        public ThamSoDAO() { }

        public bool UpdateMinFlightTime(int minFlightTime)
        {
            string query = string.Format("UPDATE dbo.THAMSO SET ThoiGianBayToiThieu = {0}", minFlightTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateMaxBreakAirport(int maxBreakAirport)
        {
            string query = string.Format("UPDATE dbo.THAMSO SET SoSanBayTrungGianToiDa = {0}", maxBreakAirport);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateBreakTimeMin(int minBreakTime)
        {
            string query = string.Format("UPDATE dbo.THAMSO SET ThoiGianDungToiThieu = {0}", minBreakTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateBreakTimeMax(int maxBreakTime)
        {
            string query = string.Format("UPDATE dbo.THAMSO SET ThoiGianDungToiThieu = {0}", maxBreakTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable GetListAirport()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.SANBAY");
        }
    }
}
