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
            string query = string.Format("SELECT * FROM CHUYENBAY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                dtimeNgayBay.Value = DateTime.Parse(item["NgayGioKhoiHanh"].ToString());
                txbSanBayDen.Text = item["MaSanBayDen"].ToString();
                txbSanBayDi.Text = item["MaSanBayDi"].ToString();
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
        void LoadSLGheTongTien()
        {
            string query = string.Format("SELECT * FROM HANGVE where TenHangVe = '{0}' and MaChuyenBay = '{1}'", txbHangVe.Text, txbMaChuyenBay.Text);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
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
                //txbMaChuyenBay.Text = item[name].ToString();
                DataCollection.Add(item[name].ToString());
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadSLGheTongTien();
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            string query = string.Format("INSERT INTO KHACHHANG VALUES ('{0}','{1}','N{2}')", tbCMND.Text, txbSoDienThoai.Text, txbHoTen.Text);
            DAO.DataProvider.Instance.ExecuteQuery(query);
            fChiTietChuyenBay Child = new fChiTietChuyenBay();
            Child.Sender(txbMaChuyenBay.Text);
            Child.Show();
        }
    }
}
