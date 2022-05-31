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
    public partial class fVeDaDat : Form
    {
        BindingSource listChuyenBay = new BindingSource();
        string cmnd = "221516379";
        public fVeDaDat()
        {
            InitializeComponent();
            LoadData();
            AddPlaneBinding();
        }

        void LoadData()
        {
            string query = string.Format("SELECT * FROM PHIEUDATCHO WHERE CMND = '{0}'", cmnd);
            dtgvDanhSachVeDaDat.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
            string query1 = string.Format("SELECT * FROM PHIEUDATCHO WHERE MaPhieuDat = '{0}'", txbMaPhieuDatCho.Text);
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query1);
            foreach (DataRow item in data.Rows)
            {
                if (int.Parse(item["TinhTrang"].ToString()) == 1)
                    btnThanhToan.Enabled = false;
            }
            //int i = 0;
        }

        void AddPlaneBinding()
        {
            txbMaPhieuDatCho.DataBindings.Add(new Binding("Text", dtgvDanhSachVeDaDat.DataSource, "MaPhieuDat", true, DataSourceUpdateMode.Never));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
