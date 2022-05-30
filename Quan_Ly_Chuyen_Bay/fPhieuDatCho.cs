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
        BindingSource listChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay);
        public SendMaChuyenBay Sender;
        public fPhieuDatCho()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
            LoadF();
        }
        private void GetMessage(string MaChuyenBay)
        {
            txbMaChuyenBay.Text = MaChuyenBay;
            string query = string.Format("SELECT * FROM CHUYENBAYY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                dtimeNgayBay.Value = DateTime.Parse(item["NgayKhoiHanh"].ToString());
                txbSanBayDen.Text = item["SanBayDen"].ToString();
                txbSanBayDi.Text = item["SanBayDi"].ToString();
            }
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadF()
        {
            LoadHangVe();
            LoadSLGheTongTien();
        }
        void ThongTinKhachHang()
        {

        }
        void LoadHangVe()
        {
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData(DataCollection1, "TenHangVe");
            txbHangVe.AutoCompleteCustomSource = DataCollection1;
        }
        void LoadSLGheTongTien()
        {
            string query = string.Format("SELECT * FROM dbo.HANGVE where TenHangVe = N'{0}'", txbHangVe.Text);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                lbSoGheTrong.Text = item["SLGheTrong"].ToString();
                int GiaTien = int.Parse(item["PhanTramDonGia"].ToString()) * 100000;
                lbTongTien.Text = GiaTien.ToString();
            }
        }
        void getData(AutoCompleteStringCollection DataCollection, string name)
        {
            string query = string.Format(" Select * from HANGVE ");
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DataCollection.Add(item[name].ToString());
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadSLGheTongTien();
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            fChiTietChuyenBay Child = new fChiTietChuyenBay();
            Child.Sender(txbMaChuyenBay.Text);
            Child.Show();
        }
    }
}
