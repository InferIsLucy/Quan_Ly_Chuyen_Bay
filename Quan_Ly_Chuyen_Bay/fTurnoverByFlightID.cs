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
    public partial class fTurnoverByFlightID : Form
    {
        public fTurnoverByFlightID()
        {
            InitializeComponent();
            LoadFunction();
        }

        #region FUNCTION
        void LoadFunction()
        {
            SetDefaultMonth();
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvViewBill.DataSource = DAO.BillDAO.Instance.GetTurnoverByDate(checkIn, checkOut);
        }

        void GetAmountMoneyByMonth(DateTime checkIn, DateTime checkOut)
        {
            txbAmount.Text = DAO.BillDAO.Instance.GetAmountMoneyByMonthBillDAO(checkIn, checkOut).ToString();
        }

        void SetDefaultMonth()
        {
            DateTime Today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(Today.Year, Today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        #endregion

        #region EVENTS
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            GetAmountMoneyByMonth(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion
    }
}
