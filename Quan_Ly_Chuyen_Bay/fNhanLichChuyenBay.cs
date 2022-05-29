using Quan_Ly_Chuyen_Bay.DAO;
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
    public partial class fNhanLichChuyenBay : Form
    {
        BindingSource listChuyenBay = new BindingSource();
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
            LoadFlightSchedule();
            LoadSLGhe();
            LoadSanBay();
        }
        void LoadFlightSchedule()
        {
            string query = "Select * from CHUYENBAYY";
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
        void LoadSLGhe()
        {
            int n = 4;
            lbSLHangVe.Text = "Số lượng hạng vé: " + n + " hạng vé";
        }
        void AddPlaneBinding()
        {
            txbMaChuyenBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaChuyenBay",true,DataSourceUpdateMode.Never));
            txbThoiGianBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "ThoiGianBay", true, DataSourceUpdateMode.Never));
            txbGiaVe.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "GiaVe", true, DataSourceUpdateMode.Never));
            dateTime.DataBindings.Add(new Binding("Value", dtgvDSChuyenBay.DataSource, "NgayKhoiHanh", true, DataSourceUpdateMode.Never));
            txbGioBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "GioKhoiHanh", true, DataSourceUpdateMode.Never));

        }
        #endregion


        void LoadSanBay()
        {
            string query = "Select * from CHUYENBAYY";
            
            comboBox1.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
            comboBox1.DisplayMember = "SanBayDi";
            comboBox2.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
            comboBox2.DisplayMember = "SanBayDen";
        }

        private void txbMaChuyenBay_TextChanged(object sender, EventArgs e)
        {
            if(dtgvDSChuyenBay.SelectedCells.Count> 0)
            {
                string query = " Select * from CHUYENBAYY ";
                DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);

                int index = -1;
                int i = 0;
                foreach(DataRow item in data.Rows)
                {
                    if (item["MaChuyenBay"].ToString() == txbMaChuyenBay.Text)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comboBox1.SelectedIndex = index;
                comboBox2.SelectedIndex = index;
            }
        }
        public bool InsertChuyenBay(string machuyenbay, float giave, string sanbaydi, string sanbayden,DateTime ngaybay, string giobay,int thoigianbay, int soghehang1, int soghehang2)
        {
            string query = string.Format("INSERT INTO CHUYENBAYY values('{0}', {1}, '{2}', '{3}', '{4}', '{5}',{6},{7}, {8})", machuyenbay, giave, sanbaydi, sanbayden, dateTime.Value, giobay,thoigianbay, soghehang1, soghehang2);
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateChuyeBay(string machuyenbay, float giave, string sanbaydi, string sanbayden, DateTime ngaybay, string giobay, int thoigianbay, int soghehang1, int soghehang2)
        {
            string query = string.Format("UPDATE  CHUYENBAYY SET  GiaVe = {1}, SanBayDi = '{2}',SanBayDen = '{3}',NgayKhoiHanh = '{4}',GioKhoiHanh = '{5}', ThoiGianBay ={6}, SoLuongGheHang1 = {7},SoLuongGheHang2 = {8} WHERE MaChuyenBay = '{0}'", machuyenbay, giave, sanbaydi, sanbayden, dateTime.Value, giobay, thoigianbay, soghehang1, soghehang2);
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteChuyenBay(string machuyenbay)
        {
            //Delete Cac chuyen bay co lien quan
            string query = string.Format("DELETE CHUYENBAYY WHERE MaChuyenBay = '{0}'", machuyenbay);
            int result = DAO.DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #region Events
        private void nutThem_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            float giave = float.Parse(txbGiaVe.Text);
            string sanbaydi = comboBox1.SelectedItem.ToString();
            string sanbayden = comboBox2.SelectedItem.ToString();
            string giobay = txbGioBay.Text;
            string[] tabs = txbGheTungHangVe.Text.Split(',');
            int thoigianbay = int.Parse(txbThoiGianBay.Text);
            int soghehang1 = int.Parse(tabs[0]);
            int soghehang2 = int.Parse(tabs[1]);
            if (InsertChuyenBay(machuyenbay, giave, sanbaydi, sanbayden,dateTime.Value, giobay,thoigianbay, soghehang1, soghehang2))
            {
                MessageBox.Show("Thêm chuyến bay thành công");
                LoadFlightSchedule();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm chuyến bay");
            }    
        }
        #endregion

        private void nutSua_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            float giave = float.Parse(txbGiaVe.Text);
            string sanbaydi = comboBox1.Items.ToString();
            string sanbayden = comboBox2.Items.ToString();
            string giobay = txbGioBay.Text;
            string[] tabs = txbGheTungHangVe.Text.Split(',');
            int thoigianbay = int.Parse(txbThoiGianBay.Text);
            int soghehang1 = int.Parse(tabs[0]);
            int soghehang2 = int.Parse(tabs[1]);
            if (UpdateChuyeBay(machuyenbay, giave, sanbaydi, sanbayden, dateTime.Value, giobay, thoigianbay, soghehang1, soghehang2))
            {
                MessageBox.Show("Sửa chuyến bay thành công");
                LoadFlightSchedule();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa chuyến bay");
            }
        }

        private void nutXoa_Click(object sender, EventArgs e)
        {
            string machuyenbay = txbMaChuyenBay.Text;
            if(DeleteChuyenBay(machuyenbay))
            {
                MessageBox.Show("Xóa chuyến bay thành công");
                LoadFlightSchedule();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa chuyến bay");
            }
        }
    }
   
}
