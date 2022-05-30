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
        }
        void LoadSanBay()
        {
            string query = string.Format("select * from CHUYENBAYY");
            listChuyenBay.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }

        void TraCuuChuyenBay(string sanbaydi,string sanbayden)
        {
            string query = string.Format(" Select * from CHUYENBAYY WHERE DBO.fuConvertToUnsign1(SanBayDi) Like '%' + dbo.fuConvertToUnsign1 ('{0}') + '%'  and   DBO.fuConvertToUnsign1(SanBayDen) Like '%' + dbo.fuConvertToUnsign1 ('{1}') + '%'", sanbaydi, sanbayden);
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
            Child.Sender(txbMaChuyenBay.Text);
            Child.Show();
        }
    }
}
