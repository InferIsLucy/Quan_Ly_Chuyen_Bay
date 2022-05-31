using Quan_Ly_Chuyen_Bay.DTO;
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
    public partial class fTableManager : Form
    {
        private DTO.AccountDTO Acc;

        public AccountDTO Acc1 { get => Acc; set { Acc = value; } }

        public fTableManager(DTO.AccountDTO acc)
        {
            InitializeComponent();

            this.Acc = acc;

            LoadFunc();
        }

        #region FUNCTION
        void LoadFunc()
        {
            ChangeAccount(Acc.Type);
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinCáNhânToolStripMenuItem.Text += " (" + Acc.DisplayName + ")";
            
        }
        #endregion

        #region EVENTS
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(Acc);
            f.EUpdateAccount += F_EUpdateAccount;
            f.ShowDialog();
        }

        private void F_EUpdateAccount(object sender, AccountEvent e)
        {
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc1.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin form = new fAdmin();
            form.ShowDialog();
            form.Close();
            this.Show();
        }

        private void btnSearchFlight_Click(object sender, EventArgs e)
        {

        }

        
        #endregion
    }
}
