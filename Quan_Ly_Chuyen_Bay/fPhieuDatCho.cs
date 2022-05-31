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
            string query = string.Format("SELECT * FROM CHUYENBAY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                dtimeNgayBay.Value = DateTime.Parse(item["NgayGioKhoiHanh"].ToString());
                txbSanBayDen.Text = item["MaSanBayDen"].ToString();
                txbSanBayDi.Text = item["MaSanBayDi"].ToString();
            }
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadF()
        {
            LoadHangVe();
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



        private void btnDatVe_Click(object sender, EventArgs e)
        {
            fChiTietChuyenBay Child = new fChiTietChuyenBay();
            Child.Sender(txbMaChuyenBay.Text);
            Child.Show();
        }

        private void btnXem_Click_1(object sender, EventArgs e)
        {
            LoadSLGheTongTien();
        }
        bool AddPhieuDatCho(string mahangve, string cmnd, string machuyenbay, float giatien, DateTime ngaydat)
        {
            string query = string.Format("INSERT INTO dbo.PHIEUDATCHO(MaHangVe,CMND,MaChuyenBay,GiaTien,NgayDat) VALUES('{0}','{1}','{2}',{3} ,'{4}')", mahangve, cmnd, machuyenbay, giatien, ngaydat.ToString());
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        private void btnDatVe_Click_1(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            string cmnd = tbcmnd.Text;
            float giave = int.Parse(lbTongTien.Text);
            string mahangve = "1";
            if(AddPhieuDatCho(mahangve,cmnd,machuyenbay,giave, DateTime.Now))
            {
                MessageBox.Show("Đặt chỗ thành công");
                fThanhToanPhieuDatCho Child = new fThanhToanPhieuDatCho();
                Child.Sender(txbMaChuyenBay.Text,tbcmnd.Text);
                Child.Show();
            }
            else
                MessageBox.Show("Đặt chỗ không thành công");

        }
    }
}
