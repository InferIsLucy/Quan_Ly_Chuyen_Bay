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

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadAccount();
        }

        void LoadAccount()
        {
            string query = "SELECT * FROM dbo.ACCOUNT";
            dtgvAccount.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fTurnoverByFlightID f = new fTurnoverByFlightID();
            f.Show();
        }
    }
}
