using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class CustomersDAO
    {
        #region TẠO SINGGLETON 
        private static CustomersDAO instance;

        public static CustomersDAO Instance { get { if (instance == null) instance = new CustomersDAO(); return instance; } private set => instance = value; }
        private CustomersDAO() { }
        #endregion

        public DataTable GetListNameCustomers()
        {
            string query = "SELECT	KH.CMND, TenKH, DienThoai AS [Số điện thoại], MaChuyenBay AS [Mã chuyến bay], MaGhe AS 'Mã ghế', GiaTien AS 'Giá tiền', NgayHetHanTT AS 'Hạn thanh toán', TrangThai AS 'Trạng thái'" +
            "FROM KHACHHANG KH LEFT JOIN PHIEUDATCHO PDC ON KH.CMND = PDC.CMND";
            return (DataTable)DataProvider.Instance.ExecuteQuery(query);
        }

        //public DataTable GetListCustomInForByName(string name)
        //{
        //    string query = "EXEC USP_GetListCustomInForByName @name";
        //    return (DataTable)DataProvider.Instance.ExecuteQuery(query, new object[] { name });
        //}

        public DataTable GetCustomerInfoByName(string name)
        {
            string query = string.Format("SELECT KH.CMND, TenKH, DienThoai AS [Số điện thoại], MaChuyenBay AS [Mã chuyến bay], MaGhe AS 'Mã ghế', GiaTien AS 'Giá tiền', NgayHetHanTT AS 'Hạn thanh toán', TrangThai AS 'Trạng thái' FROM KHACHHANG KH LEFT JOIN PHIEUDATCHO PDC ON KH.CMND = PDC.CMND WHERE TenKH like '{0}'", name);
            return (DataTable)DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
