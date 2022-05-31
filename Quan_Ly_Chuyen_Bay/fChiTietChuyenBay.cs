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

        string CMND, TenKH, SDT, MaHangVe;
        float GiaVe;
        BindingSource listGheChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay, string cmnd,string tenkh,string sdt,string mahangve,float GiaTien);
        public SendMaChuyenBay Sender;
        public fChiTietChuyenBay()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
            dtgvViTriGhe.DataSource = listGheChuyenBay;
        }

        void LoadGhe()
        {
            string query = string.Format("Select * from VITRIGHE WHERE MaChuyenBay = '{0}'", txbMaChuyenBay.Text);
            listGheChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        private void btDatVe_Click(object sender, EventArgs e)
        {
            if (KiemTraTinhTrangGhe() == true)
            {
                string query = string.Format("INSERT INTO VECHUYENBAY VALUES('{0}','{8}','{1}','{2}','{3}','{4}' ,'{5}' ,'{6}','{7}')",txbMaChuyenBay.Text,CMND,TenKH,SDT,MaHangVe,GiaVe,txbViTriGhe.Text,DateTime.Now,txbMaSanBayTrungGian.Text);
                DAO.DataProvider.Instance.ExecuteQuery(query);
                MessageBox.Show("Đặt vé thành công");
                UpdateGhe();
                LoadGhe();
                this.Close();
            }
        }
        void UpdateGhe()
        {
            string query = string.Format("UPDATE VITRIGHE SET TINHTRANG = '{2}' WHERE MaChuyenBay = '{0}'AND MaGhe = '{1}';", txbMaChuyenBay.Text, txbViTriGhe.Text, 1);
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        bool KiemTraTinhTrangGhe()
        {
            string query = string.Format("Select * from VITRIGHE WHERE MaChuyenBay = '{0}' And MaGhe = '{1}'", txbMaChuyenBay.Text, txbViTriGhe.Text );
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                if(item["TinhTrang"].ToString() == "1")
                {
                    MessageBox.Show("Ghế không còn trống");
                    return false;
                }
            }
            return true;
        }
        void AddBindings()
        {
            txbViTriGhe.DataBindings.Add(new Binding("Text", dtgvViTriGhe.DataSource, "MaGhe", true, DataSourceUpdateMode.Never));
            txbMaSanBayTrungGian.DataBindings.Add(new Binding("Text", dtgvSanBayTG.DataSource, "MaSanBay", true, DataSourceUpdateMode.Never));
            txbSanBayTrungGian.DataBindings.Add(new Binding("Text", dtgvSanBayTG.DataSource, "TenSanBay", true, DataSourceUpdateMode.Never));
        }
        void LoadSanBayTrungGian(string MaChuyenBay)
        {
            string query = string.Format("Select * from SANBAYTRUNGGIAN WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            dtgvSanBayTG.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        private void GetMessage(string MaChuyenBay, string cmnd, string tenkh, string sdt,string mahangve,float giatien)
        {
            panel1.Enabled = false;
            CMND = cmnd;
            TenKH = tenkh;
            SDT = sdt;
            MaHangVe = mahangve;
            GiaVe = giatien;
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
        }
       
        //void Insert
    }
}
