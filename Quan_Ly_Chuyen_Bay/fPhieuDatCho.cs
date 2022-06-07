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
    public partial class fPhieuDatCho : Form
    {

        BindingSource listGheChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay);
        public SendMaChuyenBay Sender;
        public fPhieuDatCho()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
            dtgvViTriGhe.DataSource = listGheChuyenBay;
        }
        private void GetMessage(string MaChuyenBay)
        {
            txbMaChuyenBay.Text = MaChuyenBay;
            string query = string.Format("SELECT * FROM CHUYENBAY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                dtimeNgayBay.Value = DateTime.Parse(item["NgayGioKhoiHanh"].ToString());
                txbSanBayDen.Text = item["MaSanBayDen"].ToString();
                txbSanBayDi.Text = item["MaSanBayDi"].ToString();
            }
            LoadF();
            panel1.Enabled = false;
            AddBindings();
            LoadGhe();
        }
        void LoadF()
        {
            LoadHangVe();
        }
        void LoadHangVe()
        {
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData(DataCollection1, "TenHangVe");
            txbHangVe.AutoCompleteCustomSource = DataCollection1;
        }
        void LoadGhe()
        {
            string query = string.Format("Select * from VITRIGHE WHERE MaChuyenBay = '{0}'", txbMaChuyenBay.Text);
            listGheChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        void AddBindings()
        {
            txbViTriGhe.DataBindings.Add(new Binding("Text", dtgvViTriGhe.DataSource, "MaGhe", true, DataSourceUpdateMode.Never));
        }
        void LoadSLGheTongTien()
        {
            string query = string.Format("SELECT * FROM HANGVE where TenHangVe = N'{0}' and MaChuyenBay = '{1}'", txbHangVe.Text, txbMaChuyenBay.Text);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                mahangve = item["MaHangVe"].ToString();
                string queryr = string.Format("SELECT * FROM CHUYENBAY where MaChuyenBay = '{0}'", txbMaChuyenBay.Text);
                DataTable data1 = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(queryr);
                foreach (DataRow items in data1.Rows)
                {
                    lbSoGheTrong.Text = item["SLGheTrong"].ToString();
                    float GiaTien = float.Parse(item["PhanTramDonGia"].ToString()) * float.Parse(items["GiaVe"].ToString());
                    lbTongTien.Text = GiaTien.ToString();
                }
            }
        }
        string mahangve;
        string LayMaHangVe()
        {
            string query = string.Format("SELECT * FROM HANGVE where TenHangVe = '{0}' and MaChuyenBay = '{1}'", txbHangVe.Text, txbMaChuyenBay.Text);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                mahangve = item["MaHangVe"].ToString();
            }
            return mahangve;
        }
        void getData(AutoCompleteStringCollection DataCollection, string name)
        {
            string query = string.Format(" Select * from HANGVE where MaChuyenBay = '{0}' ", txbMaChuyenBay.Text);
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DataCollection.Add(item[name].ToString());
            }
        }

        private void btnXem_Click_1(object sender, EventArgs e)
        {
            LoadSLGheTongTien();
        }
        bool AddPhieuDatCho(string mahangve, string cmnd, string machuyenbay, float giatien, DateTime ngaydat, DateTime ngayhethan)
        {
            string query = string.Format("INSERT INTO dbo.PHIEUDATCHO(MaHangVe,MaGhe,CMND,MaChuyenBay,GiaTien,NgayDat,NgayHetHanTT) VALUES('{0}','{1}','{2}',{3} ,'{4}','{5}','{6}')", mahangve,txbViTriGhe.Text, cmnd, machuyenbay, giatien, ngaydat.ToString(),ngayhethan.ToString());
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        bool KiemTraCMND(string CMND)
        {
            if (tbcmnd.Text.Length != 10)
            {
                MessageBox.Show("Chứng minh nhân dân không hợp lệ!");
                return false;
            }

            if (txbSoDienThoai.Text == "" || txbHoTen.Text == ""  || txbHangVe.Text == "" || txbCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                return false;
            }
            string query = string.Format("SELECT * FROM PHIEUDATCHO WHERE MaChuyenBay = '{0}'",txbMaChuyenBay.Text);
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                if (CMND == item["CMND"].ToString())
                {
                    MessageBox.Show("Đã tồn tại CMND");
                    return false;
                }
            }
            return true;
        }
        void UpdateGhe()
        {
            string query = string.Format("UPDATE VITRIGHE SET TINHTRANG = '{2}' WHERE MaChuyenBay = '{0}'AND MaGhe = '{1}';", txbMaChuyenBay.Text, txbViTriGhe.Text, 1);
            DAO.DataProvider.Instance.ExecuteQuery(query);
            LoadGhe();
        }
        bool KiemTraTinhTrangGhe()
        {
            string query = string.Format("Select * from VITRIGHE WHERE MaChuyenBay = '{0}' And MaGhe = '{1}'", txbMaChuyenBay.Text, txbViTriGhe.Text);
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                if (item["TinhTrang"].ToString() == "1")
                {
                    MessageBox.Show("Ghế không còn trống");
                    return false;
                }
            }
            return true;
        }
        int ThoiGianHuyDatVe()
        {
            string query = "select * from THAMSO";
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);
            int t = 0;
            foreach(DataRow item in data.Rows)
            {
                t = int.Parse(item["TGChamNhatDatVe"].ToString());
            }
            return t;
        }
        private void btnDatVe_Click_1(object sender, EventArgs e)
        {
            if (KiemTraCMND(tbcmnd.Text) != false)
            {
                if (KiemTraTinhTrangGhe() == true)
                {
                    string machuyenbay = txbMaChuyenBay.Text;
                    string cmnd = tbcmnd.Text;
                    float giave = int.Parse(lbTongTien.Text);
                    DateTime ngayhethan = DateTime.Now.AddHours(ThoiGianHuyDatVe());
                    mahangve = LayMaHangVe();
                    if (AddPhieuDatCho(mahangve, cmnd, machuyenbay, giave, DateTime.Now, ngayhethan))
                    {
                        string query = string.Format("INSERT INTO KHACHHANG VALUES ('{0}','{1}',N'{2}')", tbcmnd.Text, txbSoDienThoai.Text, txbHoTen.Text);
                        DAO.DataProvider.Instance.ExecuteQuery(query);
                        MessageBox.Show("Đặt chỗ thành công");
                        UpdateGhe();
                        fThanhToanPhieuDatCho child = new fThanhToanPhieuDatCho();
                        child.Sender(machuyenbay, cmnd,txbViTriGhe.Text);
                        child.Show();   
                    }
                    else
                        MessageBox.Show("Đặt chỗ không thành công");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadGhe();
        }
    }
}
