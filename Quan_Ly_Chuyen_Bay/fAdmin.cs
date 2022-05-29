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
            LoadFunction();
        }

        #region FUNCTION
        void LoadFunction()
        {
            LoadYearForTurnoverByYear();
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

        #endregion

        #region GETSET FUNCTION
        public int CmbYear
        {
            get { if (cmbYear.SelectedItem == null) return 0; return (int)cmbYear.SelectedItem; }
            set { cmbYear.SelectedItem = value; }
        }
        #endregion

    }
}
