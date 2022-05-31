using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fThanhToanPhieuDatCho : Form
    {

        BindingSource listGheChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay,string CMND,string maghe);
        string cmnd;
        string MaGhe;
        public SendMaChuyenBay Sender;
        public fThanhToanPhieuDatCho()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
            CountDown();
        }
        private void GetMessage(string MaChuyenBay,string CMND,string maghe)
        {
            MaGhe = maghe;
            panel1.Enabled = false;
            cmnd = CMND;
            txbMaChuyenBay.Text = MaChuyenBay;
            string query = string.Format("SELECT * FROM CHUYENBAY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                dtimeNgayBay.Value = DateTime.Parse(item["NgayGioKhoiHanh"].ToString());
                txbSanBayDen.Text = item["MaSanBayDen"].ToString();
                txbSanBayDi.Text = item["MaSanBayDi"].ToString();
            }
            listGheChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
            LoadSanBayTrungGian(MaChuyenBay);
            LoadGhe();
            AddBindings();
            ThoiGianHuyDatVe();
        }
        int h = 0, m = 0, s = 0, sum = 0;
        void LoadGhe()
        {
            string query = string.Format("Select * from VITRIGHE WHERE MaChuyenBay = '{0}'", txbMaChuyenBay.Text);
            listGheChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        private void btDatVe_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            string query = string.Format("UPDATE PHIEUDATCHO SET TrangThai = {2} WHERE MaChuyenBay = '{0}' and CMND = '{1}' ", txbMaChuyenBay.Text, cmnd, 1);
            DAO.DataProvider.Instance.ExecuteQuery(query);
            this.Close();
        }
        int ThoiGianHuyDatVe()
        {
            string query = "select * from THAMSO";
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                h = int.Parse(item["TGChamNhatDatVe"].ToString());
            }
            return h;
        }
        void AddBindings()
        {
            txbMaSanBayTrungGian.DataBindings.Add(new Binding("Text", dtgvSanBayTG.DataSource, "MaSanBay", true, DataSourceUpdateMode.Never));
            txbSanBayTrungGian.DataBindings.Add(new Binding("Text", dtgvSanBayTG.DataSource, "TenSanBay", true, DataSourceUpdateMode.Never));
        }
        void LoadSanBayTrungGian(string MaChuyenBay)
        {
            string query = string.Format("Select * from SANBAYTRUNGGIAN WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            dtgvSanBayTG.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            s--;
            if (s < 0)
            {
                s = 59;
                m--;
            }
            if (m < 0)
            {
                m = 59;
                h--;
            }
            sum++;
            lbClock.Text = h.ToString() + ":" + m.ToString() + ":" + s.ToString();
            if (sum == 5)//Thay bang thoi gian toi da co the cho trong thay doi quy dinh
            {
                string query = string.Format("UPDATE VITRIGHE SET TinhTrang = {2} WHERE MaChuyenBay = '{0}' and MaGhe = '{1}' ", txbMaChuyenBay.Text, MaGhe, 0);
                DAO.DataProvider.Instance.ExecuteQuery(query); 
                this.Close();
            }
        }
        void CountDown()
        {
            timer1.Start();
        }
    }
}
