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
    public partial class fBanVeChuyenBay : Form
    {
        BindingSource listChuyenBay = new BindingSource();
        public delegate void SendMaChuyenBay(string MaChuyenBay);
        public SendMaChuyenBay Sender;
        public fBanVeChuyenBay()
        {
            InitializeComponent();
            Sender = new SendMaChuyenBay(GetMessage);
            LoadFunc();
            AddBinDing();
        }
        //Region mo form tu bang TraCuuChuyenBay
        #region 
        private void GetMessage(string MaChuyenBay)
        {
            txbMaChuyenBay.Text = MaChuyenBay;
            string query = string.Format("SELECT * FROM CHUYENBAYY WHERE MaChuyenBay = '{0}'", MaChuyenBay);
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                txbSanBayDen.Text = item["SanBayDen"].ToString();
                txbSanBayDi.Text = item["SanBayDi"].ToString();
                txbThoIGianBay.Text = item["ThoiGianBay"].ToString();
                dtimeNgayBay.Value = DateTime.Parse(item["NgayKhoiHanh"].ToString());
            }
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        #endregion

        #region
        void LoadFunc()
        {
            dtgvDSChuyenBay.DataSource = listChuyenBay;
            LoadDSChuyenBay();
            LoadDataForTextBox();
        }
        void AddBinDing()
        {
            txbMaChuyenBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "MaChuyenBay", true, DataSourceUpdateMode.Never));
            txbThoIGianBay.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "ThoiGianBay", true, DataSourceUpdateMode.Never));
            dtimeNgayBay.DataBindings.Add(new Binding("Value", dtgvDSChuyenBay.DataSource, "NgayKhoiHanh", true, DataSourceUpdateMode.Never));
            txbSanBayDen.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "SanBayDen", true, DataSourceUpdateMode.Never));
            txbSanBayDi.DataBindings.Add(new Binding("Text", dtgvDSChuyenBay.DataSource, "SanBayDi", true, DataSourceUpdateMode.Never));
        }
        void LoadDSChuyenBay()
        {
            string query = "Select * from CHUYENBAYY";
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection,"MaChuyenBay");
            txbMaChuyenBay.AutoCompleteCustomSource = DataCollection;
        }
        void LoadDataForTextBox()
        {
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData(DataCollection1, "MaChuyenBay");
            txbMaChuyenBay.AutoCompleteCustomSource = DataCollection1;

            AutoCompleteStringCollection DataCollection2 = new AutoCompleteStringCollection();
            getData(DataCollection2, "SanBayDi");
            txbSanBayDi.AutoCompleteCustomSource = DataCollection2;

            AutoCompleteStringCollection DataCollection3 = new AutoCompleteStringCollection();
            getData(DataCollection3, "SanBayDen");
            txbSanBayDen.AutoCompleteCustomSource = DataCollection3;

            AutoCompleteStringCollection DataCollection4 = new AutoCompleteStringCollection();
            getData(DataCollection4, "ThoiGianBay");
            txbThoIGianBay.AutoCompleteCustomSource = DataCollection4;
        }
        void getData(AutoCompleteStringCollection DataCollection,string name)
        {
            string query = string.Format(" Select * from CHUYENBAYY ");
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DataCollection.Add(item[name].ToString());
            }
        }
        #endregion

        void SearchChuyenBay(string machuyenbay, string sanbaydi, string sanbayden)
        {
            string query = string.Format(" Select * from CHUYENBAYY WHERE DBO.fuConvertToUnsign1(SanBayDi) Like '%' + dbo.fuConvertToUnsign1 ('{0}') + '%'  and   DBO.fuConvertToUnsign1(SanBayDen) Like '%' + dbo.fuConvertToUnsign1 ('{1}') + '%' and DBO.fuConvertToUnsign1(MaChuyenBay) Like '%' + dbo.fuConvertToUnsign1 ('{2}') + '%'", sanbaydi, sanbayden, machuyenbay);
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            SearchChuyenBay(txbMaChuyenBay.Text, txbSanBayDi.Text, txbSanBayDen.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDSChuyenBay();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            fVeChuyenBay Child = new fVeChuyenBay();
            Child.Sender(txbMaChuyenBay.Text);
            Child.Show();
        }
    }
}
