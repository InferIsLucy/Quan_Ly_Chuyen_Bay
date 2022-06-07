using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Chuyen_Bay.DAO;
using Quan_Ly_Chuyen_Bay.DTO;

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fThongTinKhachHang : Form
    {
        AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
        public fThongTinKhachHang()
        {
            InitializeComponent();
            LoadFunction();
        }

        #region FUNCTION
        void LoadFunction()
        {
            AddBinding();
            BuildAutoCompleteTextboxFunc();
            
        }

        void AddBinding()
        {
            txbFullName.DataBindings.Add("Text", DAO.CustomersDAO.Instance.GetListNameCustomers(), "TenKH");
        }

        void BuildAutoCompleteTextboxFunc()
        {
            if(DAO.CustomersDAO.Instance.GetListNameCustomers().Rows.Count > 0)
            {
                for(int i = 0; i < DAO.CustomersDAO.Instance.GetListNameCustomers().Rows.Count; i++)
                {
                    auto.Add(DAO.CustomersDAO.Instance.GetListNameCustomers().Rows[i]["TenKH"].ToString());
                }
            }

            txbFullName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txbFullName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbFullName.AutoCompleteCustomSource = auto;
        }

        void AutoFillDtgv()
        {
            if(DAO.CustomersDAO.Instance.GetListNameCustomers().Rows.Count > 0)
            {
                dtgvCustomerInfo.DataSource = DAO.CustomersDAO.Instance.GetCustomerInfoByName(txbFullName.Text);
                //txbPhoneNum.DataBindings.Add("Text", dtgvCustomerInfo.DataSource, "DienThoai");
                cmbCMND.ValueMember = "CMND";
                cmbCMND.DataSource = DAO.CustomersDAO.Instance.GetCustomerInfoByName(txbFullName.Text).DefaultView;
            }


        }

        #endregion

        #region EVENTS
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txbFullName.Text == "")
            {
                dtgvCustomerInfo.DataSource = CustomersDAO.Instance.GetListNameCustomers();
            }
            else
                AutoFillDtgv();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            fThanhToanPhieuDatCho f = new fThanhToanPhieuDatCho();
            f.ShowDialog();
        }

        #endregion

    }
}
