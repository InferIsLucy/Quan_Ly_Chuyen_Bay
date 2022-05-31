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
                dtgvCustomerInfo.DataSource = DAO.CustomersDAO.Instance.GetListCustomInForByName(txbFullName.Text);
                //txbPhoneNum.DataBindings.Add("Text", dtgvCustomerInfo.DataSource, "DienThoai");
                cmbCMND.ValueMember = "CMND";
                cmbCMND.DataSource = DAO.CustomersDAO.Instance.GetListCustomInForByName(txbFullName.Text).DefaultView;
            }


        }

        void PaymentYet(int pay)
        {
            if(pay == 0)
                btnPayment.Enabled = true;
            else
                btnPayment.Enabled = false;
        }

        #endregion

        #region EVENTS
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           AutoFillDtgv();
        }

        private void cmbCMND_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedValue != null)
                PaymentYet(DAO.ReverseOrderDAO.Instance.GetStatusByCMND(cb.SelectedValue.ToString()));
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
