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
    public partial class fVeChuyenBay : Form
    {
        BindingSource listChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay);
        public SendMaChuyenBay Sender;
        public fVeChuyenBay()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
            
        }
        private void GetMessage(string MaChuyenBay)
        {
            txbMaChuyenBay.Text = MaChuyenBay;
            txbMaChuyenBay.Enabled = false;
            string query = string.Format("SELECT * FROM CHUYENBAY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                dtimeNgayBay.Value = DateTime.Parse(item["NgayGioKhoiHanh"].ToString());
                txbSanBayDen.Text = item["MaSanBayDen"].ToString();
                txbSanBayDi.Text = item["MaSanBayDi"].ToString();
                dtimeNgayBay.Enabled = false;
                txbSanBayDen.Enabled = false;
                txbSanBayDi.Enabled = false;
            }
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
            LoadF();
        }
        void LoadF()
        {
            LoadHangVe();
            //LoadSLGheTongTien();
        }
        void LoadHangVe()
        {
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData(DataCollection1, "TenHangVe");
            txbHangVe.AutoCompleteCustomSource = DataCollection1;
        }
        string mahangve;
        void LoadSLGheTongTien()
        {
            string query = string.Format("SELECT * FROM HANGVE where TenHangVe = N'{0}' and MaChuyenBay = '{1}'", txbHangVe.Text, txbMaChuyenBay.Text);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                mahangve = item["MaHangVe"].ToString();
                string queryr = string.Format("SELECT * FROM CHUYENBAY where MaChuyenBay = '{0}'",txbMaChuyenBay.Text);
                DataTable data1 = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(queryr);
                foreach (DataRow items in data1.Rows)
                {
                    lbSoGheTrong.Text = item["SLGheTrong"].ToString();
                    float GiaTien = float.Parse(item["PhanTramDonGia"].ToString()) * float.Parse(items["GiaVe"].ToString());
                    lbTongTien.Text = GiaTien.ToString();
                }
            }    
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadSLGheTongTien();
        }

        bool KiemTraCMND(string CMND)
        {
            if (txbSoDienThoai.Text == "" || txbHoTen.Text == "" || txbHangVe.Text == "" || txbCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                return false;
            }
            string query = string.Format("SELECT * FROM VECHUYENBAY WHERE MaChuyenBay = '{0}'",txbMaChuyenBay.Text);
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                if (CMND == item["CMND"].ToString())
                {
                    MessageBox.Show("Đã tồn tại CMND");
                    return false;
                }
            }
            return true;
        }
        string LayMaHangVe()
        {
            string query = string.Format("SELECT * FROM HANGVE where TenHangVe = '{0}' and MaChuyenBay = '{1}'", txbHangVe.Text, txbMaChuyenBay.Text);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                 mahangve = item["MaHangVe"].ToString();
            }
            return mahangve;
        }
        bool KiemTraTrungCMND(string cmnd)
        {
            string query = string.Format("SELECT * FROM KHACHHANG");
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                if (cmnd == item["CMND"].ToString())
                {
                    MessageBox.Show("Đã tồn tại CMND");
                    return false;
                }
            }
            return true;
        }
        private void btnDatVe_Click(object sender, EventArgs e)
        {
            if (KiemTraCMND(tbCMND.Text) != false)
            {
                if (KiemTraTrungCMND(txbCMND.Text) != false)
                {
                    //string query = string.Format("INSERT INTO KHACHHANG VALUES ('{0}','{1}',N'{2}')", tbCMND.Text, txbSoDienThoai.Text, txbHoTen.Text);
                    //DAO.DataProvider.Instance.ExecuteQuery(query);
                    mahangve = LayMaHangVe();
                    fChiTietChuyenBay Child = new fChiTietChuyenBay();
                    Child.Sender(txbMaChuyenBay.Text, tbCMND.Text, txbHoTen.Text, txbSoDienThoai.Text, mahangve, float.Parse(lbTongTien.Text));
                    Child.Show();
                }
            }

        }
    }
}
