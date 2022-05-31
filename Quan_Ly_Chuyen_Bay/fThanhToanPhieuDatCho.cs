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
        BindingSource listChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay,string CMND);
        string cmnd;
        public SendMaChuyenBay Sender;
        public fThanhToanPhieuDatCho()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
            CountDown();
        }
        private void GetMessage(string MaChuyenBay,string CMND)
        {
            txbMaChuyenBay.Text = MaChuyenBay;
            cmnd = CMND;
            string query = string.Format("SELECT * FROM CHUYENBAYY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                dtimeNgayBay.Value = DateTime.Parse(item["NgayKhoiHanh"].ToString());
                txbSanBayDen.Text = item["SanBayDen"].ToString();
                txbSanBayDi.Text = item["SanBayDi"].ToString();
            }
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
            LoadSanBayTrungGian(MaChuyenBay);
        }
        void LoadSanBayTrungGian(string MaChuyenBay)
        {
            string query = string.Format("Select * from CT_CHUYENBAY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                string queryy = string.Format("Select * from SANBAYY WHERE MaSanBay = '{0}'", item["SanBayTrungGian"].ToString());
                DataTable data1 = DAO.DataProvider.Instance.ExecuteQuery(queryy);
                foreach (DataRow items in data1.Rows)
                {
                    Button btn = new Button() { Width = 100, Height = 100 };
                    btn.Text = items["TenSanBay"].ToString() + Environment.NewLine + item["ThoiGianDung"].ToString() + " Phút";
                    btn.BackColor = Color.CornflowerBlue;
                    flbTable.Controls.Add(btn);
                }
            }
        }
        int h = 1, m = 0, s = 0, sum = 0;

        private void btDatVe_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            string query = string.Format("UPDATE PHIEUDATCHO SET TinhTrang = {2} WHERE MaChuyenBay = '{0}' and CMND = '{1}' ", txbMaChuyenBay.Text, cmnd, 1);
            DAO.DataProvider.Instance.ExecuteQuery(query);
            this.Close();
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
            if (sum == 10)//Thay bang thoi gian toi da co the cho trong thay doi quy dinh
            {
                string query = string.Format("DELETE FROM PHIEUDATCHO WHERE TinhTrang = {0}  ", 0);
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
