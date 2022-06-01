using System;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fNhanLichChuyenBay : Form
    {
        BindingSource listChuyenBay = new BindingSource();
        BindingSource listHangVe = new BindingSource();
        BindingSource listSanBayTrungGian = new BindingSource();
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
            dtgvHangVe.DataSource = listHangVe;
            dtgvSBTG.DataSource = listSanBayTrungGian;
            LoadFlightSchedule();
            LoadSBTG(); ;
            LoadSanBay();
            LoadHangVe();
        }
        void LoadFlightSchedule()
        {
            string query = "Select * from CHUYENBAY";
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }

        void AddPlaneBinding()
        {
            txbMaChuyenBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaChuyenBay", true, DataSourceUpdateMode.Never));
            txbThoiGianBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "ThoiGianBay", true, DataSourceUpdateMode.Never));
            txbGiaVe.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "GiaVe", true, DataSourceUpdateMode.Never));
            dateTime.DataBindings.Add(new Binding("Value", dtgvDSChuyenBay.DataSource, "NgayGioKhoiHanh", true, DataSourceUpdateMode.Never));
            txbSanBayDen.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaSanBayDen", true, DataSourceUpdateMode.Never));
            txbSanBayDi.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaSanBayDi", true, DataSourceUpdateMode.Never));
            txbSanBayTrungGian.DataBindings.Add(new Binding("Text", dtgvSBTG.DataSource, "MaSanBay", true, DataSourceUpdateMode.Never));
            txbTenSanBay.DataBindings.Add(new Binding("Text", dtgvSBTG.DataSource, "TenSanBay", true, DataSourceUpdateMode.Never));
            txbHangVe.DataBindings.Add(new Binding("Text", dtgvHangVe.DataSource, "MaHangVe", true, DataSourceUpdateMode.Never));
            txbTenHangVe.DataBindings.Add(new Binding("Text", dtgvHangVe.DataSource, "TenHangVe", true, DataSourceUpdateMode.Never));
            txbSLGhe.DataBindings.Add(new Binding("Text", dtgvHangVe.DataSource, "SoLuongGhe", true, DataSourceUpdateMode.Never));
            txbPhanTramDonGia.DataBindings.Add(new Binding("Text", dtgvHangVe.DataSource, "PhanTramDonGia", true, DataSourceUpdateMode.Never));
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
        void LoadSBTG()
        {
            string query = "SELECT * FROM SANBAY";
            listSanBayTrungGian.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadHangVe()
        {
            string query = "SELECT * FROM SOLUONGGHE";
            listHangVe.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
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
        public bool InsertChuyenBay(string machuyenbay, float giave, string sanbaydi, string sanbayden, DateTime ngaybay, int thoigianbay)
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
        void NhapSanBayTrungGian(string machuyenbay, string masanbay, string tensanbay, string masanbaytruoc, string masanbaysau, string thoigiandung)
        {
            string query = string.Format("INSERT INTO SANBAYTRUNGGIAN VALUES({0}, '{1}', '{2}', '{3}', '{4}','{5}','{6}')", machuyenbay, masanbay, tensanbay, masanbaytruoc, masanbaysau, thoigiandung, "");
            DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }
        #region Events
        void NhapHangVe(string machuyenbay, string mahangve, string tenhangve, string phantramdongia, string soluongghe)
        {
            string query = string.Format("INSERT INTO HANGVE VALUES({0}, N'{1}', '{2}', '{3}', '{4}','{5}')", machuyenbay, tenhangve, phantramdongia, soluongghe, 0, soluongghe);
            DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }
        void NhapGhe(string machuyenbay, string mahangve, string soluongghe)
        {
            string query = string.Format("DECLARE @i INT = 0 WHILE @i<{2} BEGIN 	INSERT VITRIGHE(MaHangVe,TinhTrang,MaChuyenBay) VALUES ('{0}',0,'{1}')	SET @i = @i + 1 END	", mahangve, machuyenbay, soluongghe);
            DAO.DataProvider.Instance.ExecuteNonQuery(query);
        }
        private void nutThem_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            string sanbaydi = txbSanBayDi.Text;
            string sanbayden = txbSanBayDen.Text;
            int thoigianbay;
            float giave;
            if (!float.TryParse(txbGiaVe.Text, out giave) || !int.TryParse(txbThoiGianBay.Text, out thoigianbay))
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                if (KiemTraTuNhien())
                {
                    if (InsertChuyenBay(machuyenbay, giave, sanbaydi, sanbayden, dateTime.Value, thoigianbay))
                    {
                        MessageBox.Show("Thêm chuyến bay thành công");
                        LoadFlightSchedule();

                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm chuyến bay");
                    }
                }
                else
                    MessageBox.Show("Nhập lại dữ liệu chuyến bay");
            }
        }
        #endregion

        private void nutSua_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            string sanbaydi = txbSanBayDi.Text;
            string sanbayden = txbSanBayDen.Text;
            int thoigianbay;
            float giave;
            if (!float.TryParse(txbGiaVe.Text, out giave) || !int.TryParse(txbThoiGianBay.Text, out thoigianbay))
            {
                MessageBox.Show("Kiểm tra lại thông tin");
            }
            else
            {
                if (KiemTraTuNhien() == true)
                {
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
                else
                    MessageBox.Show("Nhập lại dữ liệu chuyến bay");
            }
        }
        bool KiemTraTuNhien()
        {
            string laythamso = string.Format("SELECT * FROM THAMSO");
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(laythamso);
            int sbmax = 0;
            foreach (DataRow item in data.Rows)
            {
                sbmax = int.Parse(item["ThoiGianBayToiThieu"].ToString());
            }
            if (DateTime.Compare(dateTime.Value, DateTime.Now) == -1)
                return false;
            if (int.Parse(txbThoiGianBay.Text) <= sbmax || int.Parse(txbGiaVe.Text) < 0)
                return false;
            return true;
        }
        private void nutXoa_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            if (DeleteChuyenBay(machuyenbay))
            {
                MessageBox.Show("Xóa chuyến bay thành công");
                LoadFlightSchedule();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa chuyến bay");
            }

        }
        bool KiemTraSoSanBayTG(string machuyenbay)
        {
            string query = string.Format("SELECT * FROM SANBAYTRUNGGIAN WHERE MaChuyenBay = '{0}'", machuyenbay);
            string laythamso = string.Format("SELECT * FROM THAMSO");
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(laythamso);
            int sbmax = 0;
            foreach (DataRow item in data.Rows)
            {
                sbmax = int.Parse(item["SoSanBayTrungGianToiDa"].ToString());
            }
            DataTable data1 = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            int i = 1;
            foreach (DataRow item in data1.Rows)
            {
                i++;
            }
            if (i <= sbmax)
                return true;
            else
                return false;
        }
        private void btnThemSanBayTG_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            string sanbaydi = txbSanBayDi.Text;
            string sanbayden = txbSanBayDen.Text;
                if (KiemTraSoSanBayTG(txbMaChuyenBay.Text))
                {
                    if (txbThoiGianDung.Text == "")
                        MessageBox.Show("Nhập lại thời gian dừng");
                    else
                    {
                        if (int.Parse(txbThoiGianDung.Text) >= 10 && int.Parse(txbThoiGianDung.Text) < 21)
                        {
                            NhapSanBayTrungGian(machuyenbay, txbSanBayTrungGian.Text, txbTenSanBay.Text, sanbaydi, sanbayden, txbThoiGianDung.Text);
                            MessageBox.Show("Nhập sân bay trung gian thành công");
                        }
                        else
                            MessageBox.Show("Nhập lại thời gian dừng");
                    }
                }
                else
                    MessageBox.Show("Không thể thêm sân bay mới");
        }
        bool KiemTraTonTaiHangVe(string tenhangve)
        {
            string query = string.Format("SELECT * FROM HANGVE WHERE MaChuyenBay = '{0}'",txbMaChuyenBay.Text);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                if (tenhangve == item["TenHangVe"].ToString())
                    return true;
            }
            return false;
        }
        private void btnThemHangVe_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTaiHangVe(txbTenHangVe.Text) == true)
                MessageBox.Show("Không thể thêm hạng vé");
            else
            {
                NhapHangVe(txbMaChuyenBay.Text, txbHangVe.Text, txbTenHangVe.Text, txbPhanTramDonGia.Text, txbSLGhe.Text);
                NhapGhe(txbMaChuyenBay.Text, txbHangVe.Text, txbSLGhe.Text);
                MessageBox.Show("Thêm hạng vé thành công");
            }
        }
    }

}
