using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Chuyen_Bay.DAO;
using Quan_Ly_Chuyen_Bay.DTO;

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fAdmin : Form
    {
        BindingSource listAccount = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
            LoadFunction();
        }

        #region FUNCTION
        void LoadFunction()
        {
            LoadYearForTurnoverByYear();
            
        }

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName"));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName"));
        }

        void LoadAccount()
        {
            listAccount.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.DataSource = listAccount;
        }
        void LoadYearForTurnoverByYear()
        {
            //Giả sử 2015 là năm thành lập công ty
            for (int i = 2015; i <= DateTime.Now.Year; i++)
            {
                cmbYear.Items.Add(i);
            }

            cmbYear.SelectedItem = DateTime.Now.Year;
        }

        void ShowTurnover(int year)
        {
            dtgvBill.DataSource = DAO.BillDAO.Instance.GetTurnoverByYear(year);
        }

        void GetAmountMoneyByYear(int year)
        {
            lbAmount2.Text = DAO.BillDAO.Instance.GetAmountMoneyByYearBillDAO(year).ToString();
        }

        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Thêm tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Cập nhật tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (AccountDAO.Instance.DeleteAccount(userName))
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Xóa tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }
        #endregion

        #region EVENTS
        private void btnViewBillByFlightID_Click(object sender, EventArgs e)
        {
            fTurnoverByFlightID f = new fTurnoverByFlightID();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowTurnover((int)cmbYear.SelectedItem);
                GetAmountMoneyByYear((int)cmbYear.SelectedItem);
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.CmbYear = (int)cmbYear.SelectedItem;
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            fChartByYear f = new fChartByYear(this);
            f.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadAccount();
            try
            {
                AddAccountBinding();
            }catch(Exception ex)
            {
                return;
            }
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {
            int type = AccountDAO.Instance.GetTypeAccount(txbUserName.Text);
            cbTypeAccount.SelectedIndex = type;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = cbTypeAccount.SelectedIndex;

            AddAccount(userName, displayName, type);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = cbTypeAccount.SelectedIndex;

            EditAccount(userName, displayName, type);
        }
        #endregion

        #region GETSET FUNCTION
        public int CmbYear
        {
            get { if (cmbYear.SelectedItem == null) return 0; return (int)cmbYear.SelectedItem; }
            set { cmbYear.SelectedItem = value; }
        }



        #endregion

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            AccountDTO acc = AccountDAO.Instance.GetAccountByUserName(txbUserName.Text);
            fAccountProfile f = new fAccountProfile(acc);
            f.ShowDialog();
            this.Show();
        }
    }
}
