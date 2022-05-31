using Quan_Ly_Chuyen_Bay.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fNhanLichChuyenBay : Form
    {
        BindingSource listChuyenBay = new BindingSource();
        public fNhanLichChuyenBay()
        {
            InitializeComponent();
            LoadFunction();
            AddPlaneBinding();
            
        }

        #region Function
        void LoadFunction()
        {
            dtgvDSChuyenBay.DataSource = listChuyenBay;
            LoadFlightSchedule();

            LoadSanBay();
        }
        void LoadFlightSchedule()
        {
            string query = "Select * from CHUYENBAY";
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
        void AddPlaneBinding()
        {
            txbMaChuyenBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaChuyenBay",true,DataSourceUpdateMode.Never));
            txbThoiGianBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "ThoiGianBay", true, DataSourceUpdateMode.Never));
            txbGiaVe.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "GiaVe", true, DataSourceUpdateMode.Never));
            dateTime.DataBindings.Add(new Binding("Value", dtgvDSChuyenBay.DataSource, "NgayGioKhoiHanh", true, DataSourceUpdateMode.Never));
            txbSanBayDen.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaSanBayDen", true, DataSourceUpdateMode.Never));
            txbSanBayDi.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaSanBayDi", true, DataSourceUpdateMode.Never));
        }
        #endregion


        void LoadSanBay()
        {
            AutoCompleteStringCollection DataCollection2 = new AutoCompleteStringCollection();
            getData(DataCollection2, "MaSanBay");
            txbSanBayDi.AutoCompleteCustomSource = DataCollection2;

            AutoCompleteStringCollection DataCollection3 = new AutoCompleteStringCollection();
            getData(DataCollection3, "MaSanBay");
            txbSanBayDen.AutoCompleteCustomSource = DataCollection3;
        }

        void getData(AutoCompleteStringCollection DataCollection, string name)
        {
            string query = string.Format(" Select * from SANBAY ");
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DataCollection.Add(item[name].ToString());
            }
        }
        public bool InsertChuyenBay(string machuyenbay, float giave, string sanbaydi, string sanbayden,DateTime ngaybay,int thoigianbay)
        {
            string query = string.Format("INSERT INTO CHUYENBAY(GiaVe,MaSanBayDi,MaSanBayDen,NgayGioKhoiHanh,ThoiGianBay) values({0}, '{1}', '{2}', '{3}', {4})", giave, sanbaydi, sanbayden, dateTime.Value, thoigianbay);
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateChuyeBay(string machuyenbay, float giave, string sanbaydi, string sanbayden, DateTime ngaybay, int thoigianbay)
        {
            string query = string.Format("UPDATE  CHUYENBAY SET  GiaVe = {1}, MaSanBayDi = '{2}',MaSanBayDen = '{3}',NgayGioKhoiHanh = '{4}', ThoiGianBay ={5} WHERE MaChuyenBay = '{0}'", machuyenbay, giave, sanbaydi, sanbayden, dateTime.Value, thoigianbay);
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteChuyenBay(string machuyenbay)
        {
            //Delete Cac chuyen bay co lien quan
            string query = string.Format("DELETE CHUYENBAY WHERE MaChuyenBay = '{0}'", machuyenbay);
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #region Events

        private void nutThem_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            float giave = float.Parse(txbGiaVe.Text);
            string sanbaydi = txbSanBayDi.Text;
            string sanbayden = txbSanBayDen.Text;
            int thoigianbay = int.Parse(txbThoiGianBay.Text);

            if (InsertChuyenBay(machuyenbay, giave, sanbaydi, sanbayden,dateTime.Value ,thoigianbay))
            {
                MessageBox.Show("Thêm chuyến bay thành công");
                LoadFlightSchedule();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm chuyến bay");
            }    
        }
        #endregion

        private void nutSua_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            float giave = float.Parse(txbGiaVe.Text);
            string sanbaydi = txbSanBayDi.Text;
            string sanbayden = txbSanBayDen.Text;
            int thoigianbay = int.Parse(txbThoiGianBay.Text);

            if (UpdateChuyeBay(machuyenbay, giave, sanbaydi, sanbayden, dateTime.Value, thoigianbay))
            {
                MessageBox.Show("Sửa chuyến bay thành công");
                LoadFlightSchedule();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa chuyến bay");
            }
        }

        private void nutXoa_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            if(DeleteChuyenBay(machuyenbay))
            {
                MessageBox.Show("Xóa chuyến bay thành công");
                LoadFlightSchedule();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa chuyến bay");
            }
        }


    }
   
}
