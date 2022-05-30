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
    public partial class fChiTietChuyenBay : Form
    {
        BindingSource listChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay);
        public SendMaChuyenBay Sender;
        public fChiTietChuyenBay()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
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
                    btn.Text = items["TenSanBay"].ToString() + Environment.NewLine + item["ThoiGianDung"].ToString();
                    flbTable.Controls.Add(btn);
                }
            }
        }
    }
}
