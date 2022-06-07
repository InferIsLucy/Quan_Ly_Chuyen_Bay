using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class SoLuongGheDAO
    {
        private static SoLuongGheDAO instance;

        public static SoLuongGheDAO Instance { get { if (instance == null) instance = new SoLuongGheDAO(); return instance; } private set => instance = value; }

        private SoLuongGheDAO() { }

        public DataTable GetListHangVe()
        {
            return (DataTable)DataProvider.Instance.ExecuteQuery("SELECT * FROM SOLUONGGHE");
        }

        public bool InsertHangVe(string tenHangVe, float phanTramDonGia, int soLuongGhe)
        {
            string query = string.Format("INSERT dbo.SOLUONGGHE (TenHangVe, PhanTramDonGia, SoLuongGhe) VALUES (N'{0}', {1}, {2})", tenHangVe, phanTramDonGia, soLuongGhe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateHangVe(string tenHangVe, float phanTramDonGia, int soLuongGhe)
        {
            string query = string.Format("UPDATE dbo.SOLUONGGHE SET PhanTramDonGia = {1} , SoLuongGhe = {2} WHERE TenHangVe = N'{0}'", tenHangVe, phanTramDonGia, soLuongGhe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteHangVe(string tenHangVe)
        {
            string query = string.Format("DELETE dbo.SOLUONGGHE WHERE TenHangVe = N'{0}'", tenHangVe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable GetAllTenHangVe()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT TenHangVe FROM SOLUONGGHE");
        }

        public int GetSLHVMax()
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT SLHangVeToiDa FROM THAMSO");
        }

        public int GetSLHV()
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(MaHangVe) FROM SOLUONGGHE");
        }
    }
}
