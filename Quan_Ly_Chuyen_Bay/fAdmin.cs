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
        public AccountDTO loginAcc;
        public fAdmin()
        {
            InitializeComponent();
            LoadFunction();
        }

        #region FUNCTION
        void LoadFunction()
        {
            LoadYearForTurnoverByYear();
            LoadListAirport();
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
            DataTable data = AccountDAO.Instance.GetAllUserName();
            foreach (DataRow row in data.Rows)
            {
                if (txbUserName.Text.Equals(row["UserName"].ToString()))
                {
                    MessageBox.Show("Tên này đã tồn tại!");
                    return;
                }
            }

            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Thêm tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            DataTable data = AccountDAO.Instance.GetAllUserName();
            foreach (DataRow row in data.Rows)
            {
                if (txbUserName.Text.Equals(row["UserName"].ToString()))
                {
                    MessageBox.Show("Tên này đã tồn tại!");
                    return;
                }
            }

            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Cập nhật tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAcc.UserName.Equals(txbUserName.Text))
            {
                MessageBox.Show("Không thể xóa tài khoản hiện hành!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Xóa tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void CheckInt(string data, ref int result)
        {
            if(data != "")
            {
                if (!Int32.TryParse(data, out result))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!");
                }
            }
        }

        void updateMinFlightTime(string data)
        {
            int result = 0;

            if (data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateMinFlightTime(result))
                {
                    MessageBox.Show("Cập nhật thời gian bay tối thiểu thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công thời gian bay tối thiểu!");
            }
            else
                return;

        }

        void updateMaxBreakAirport(string data)
        {
            int result = 0;
            if (data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateMaxBreakAirport(result))
                {
                    MessageBox.Show("Cập nhật số sân bay trung gian tối đa thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công số sân bay trung gian tối đa!");
            }
            else
                return;

        }

        void updateBreakTimeMin(string data)
        {
            int result = 0;
            if(data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateBreakTimeMin(result))
                {
                    MessageBox.Show("Cập nhật thời gian dừng tối thiếu thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công thời gian dừng tối thiểu!");
            }
            else return;

        }

        void updateBreakTimeMax(string data)
        {
            int result = 0;
            if (data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateBreakTimeMax(result))
                {
                    MessageBox.Show("Cập nhật thời gian dừng tối đa thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công thời gian dừng tối đa!");
            }
            else return;
        }
        void UpDateMin(string mincancel, string minpayment)
        {
            string query = string.Format("Update THAMSO Set TGChamNhatHuyDatVe = '{0}', TGChamNhatDatVe = '{1}'",mincancel,minpayment);
            DAO.DataProvider.Instance.ExecuteQuery(query);

        }
        void AddSanBay(string masanbay, string tensanbay)
        {
            string query = string.Format("INSERT INTO SANBAY VALUES('{0}','{1}') ", masanbay, tensanbay);
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadListAirport()
        {
            cmbListAirport.DataSource = ThamSoDAO.Instance.GetListAirport();
            cmbListAirport.ValueMember = "TenSanBay";
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

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            AccountDTO acc = AccountDAO.Instance.GetAccountByUserName(txbUserName.Text);
            fAccountProfile f = new fAccountProfile(acc);
            f.ShowDialog();
            this.Show();
        }

        private void btnUpdateAirport_Click(object sender, EventArgs e)
        {
            updateBreakTimeMax(txbBreakTimeTo.Text);
            updateBreakTimeMin(txbBreakTimeFrom.Text);
            updateMaxBreakAirport(txbMaxBreakAirport.Text);
            updateMinFlightTime(txbMinFlightTime.Text);
        }
        #endregion

        #region GETSET FUNCTION
        public int CmbYear
        {
            get { if (cmbYear.SelectedItem == null) return 0; return (int)cmbYear.SelectedItem; }
            set { cmbYear.SelectedItem = value; }
        }





        #endregion

        private void btnUpdateBookTicket_Click(object sender, EventArgs e)
        {
            UpDateMin(txbMinTimeCancelTicket.Text, txbMinTimePayment.Text);
            MessageBox.Show("Thay đổi quy định đặt vé thành công");
        }

        private void btnAddAirPort_Click(object sender, EventArgs e)
        {
            AddSanBay(txbMaSanBay.Text, txbTenSanBay.Text);
            MessageBox.Show("Thêm sân bay thành công");
        }
    }
}
