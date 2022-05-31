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
    public partial class fTraCuuChuyenBay : Form
    {
        BindingSource listChuyenBay = new BindingSource();
        public fTraCuuChuyenBay()
        {
            InitializeComponent();
            LoadFunction();
            txbMaChuyenBay.DataBindings.Add(new Binding("Text", listChuyenBay, "MaChuyenBay", true, DataSourceUpdateMode.Never));
        }

        void LoadFunction()
        {
            dtgvTraCuuChuyenBay.DataSource = listChuyenBay;
            LoadSanBay();
            LoadTextBox();
        }
        void LoadSanBay()
        {
            string query = string.Format("select * from CHUYENBAY");
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
         void LoadTextBox()
        {
            AutoCompleteStringCollection DataCollection2 = new AutoCompleteStringCollection();
            getData(DataCollection2, "MaSanBay");
            txbSanBayDi.AutoCompleteCustomSource = DataCollection2;

            AutoCompleteStringCollection DataCollection3 = new AutoCompleteStringCollection();
            getData(DataCollection3, "MaSanBay");
            txbSanBayDen.AutoCompleteCustomSource = DataCollection3;
        }

        void getData(AutoCompleteStringCollection DataCollection, string name)
        {
            string query = string.Format(" Select * from SANBAY ");
            DataTable data = (DataTable)DAO.DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DataCollection.Add(item[name].ToString());
            }
        }
        void TraCuuChuyenBay(string sanbaydi,string sanbayden)
        {
            string query = string.Format(" Select * from CHUYENBAY WHERE DBO.fuConvertToUnsign1(MaSanBayDi) Like '%' + dbo.fuConvertToUnsign1 ('{0}') + '%'  and   DBO.fuConvertToUnsign1(MaSanBayDen) Like '%' + dbo.fuConvertToUnsign1 ('{1}') + '%'", sanbaydi, sanbayden);
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TraCuuChuyenBay(txbSanBayDi.Text, txbSanBayDen.Text);
        }

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            LoadSanBay();
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            fBanVeChuyenBay BanVe = new fBanVeChuyenBay();
            BanVe.Sender(txbMaChuyenBay.Text);
            BanVe.Show();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            fChiTietChuyenBay Child = new fChiTietChuyenBay();
            Child.Sender(txbMaChuyenBay.Text,"","","","",0);
            Child.Show();
        }
    }
}
