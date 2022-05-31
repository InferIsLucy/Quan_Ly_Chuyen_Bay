using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Chuyen_Bay.DTO;
using Quan_Ly_Chuyen_Bay.DAO;

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fAccountProfile : Form
    {
        private AccountDTO Acc;

        public AccountDTO Acc1 { get => Acc; set { Acc = value; } }
        public fAccountProfile(AccountDTO acc)
        {
            InitializeComponent();

            this.Acc = acc;

            LoadFunc();
        }

        #region FUNCTION
        void LoadFunc()
        {
            ChangeAccount(Acc);
        }

        void ChangeAccount(AccountDTO account)
        {
            txbUsername.Text = Acc.UserName;
            txbDisplayName.Text = Acc.DisplayName;
        }

        void UpdateAccount()
        {
            string username = txbUsername.Text;
            string displayName = txbDisplayName.Text;
            string password = txbPassword.Text;
            string newpass = txbNewPassword.Text;
            string repass = txbReWritePassword.Text;

            if (!newpass.Equals(repass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới", "Thông báo lỗi");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    if(eUpdateAccount != null)
                    {
                        eUpdateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!", "Thông báo");
                }
            }
        }
        #endregion

        #region EVENTS
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private event EventHandler<AccountEvent> eUpdateAccount;
        public event EventHandler<AccountEvent> EUpdateAccount
        {
            add { eUpdateAccount += value; }
            remove { EUpdateAccount -= value; }
        }
        #endregion
    }

    public class AccountEvent : EventArgs
    {
        private AccountDTO Acc;

        public AccountDTO Acc1 { get => Acc; set => Acc = value; }

        public AccountEvent(AccountDTO acc) { this.Acc = acc; }
    }
}
