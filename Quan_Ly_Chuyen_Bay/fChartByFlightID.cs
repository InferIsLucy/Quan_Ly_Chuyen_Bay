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
    public partial class fChartByFlightID : Form
    {
        public fChartByFlightID()
        {
            InitializeComponent();
        }

        #region TẠO LINK VỚI fTurnoverByFlightID MUỐN TRUYỀN HÀM GÌ THÌ TRUYỀN VÀO TRONG NÀY
        private fTurnoverByFlightID mainForm = null;
        public fChartByFlightID(Form callingForm)
        {
            mainForm = callingForm as fTurnoverByFlightID;
            InitializeComponent();
            LoadFunction();
        }
        #endregion

        #region FUNCTION
        void LoadFunction()
        {
            LoadChart();
        }

        void LoadChart()
        {
            chartColumn.DataSource = this.mainForm.DtgvViewBill;
            chartColumn.Series.Add("Vnd");
            chartColumn.Series["Vnd"].XValueMember = "Mã chuyến bay";
            chartColumn.Series["Vnd"].YValueMembers = "Doanh thu";
            chartColumn.Titles.Add("Biều đồ doanh thu theo chuyến bay");
        }
        #endregion

        #region EVENTS
        private void fChartByFlightID_FormClosing(object sender, FormClosingEventArgs e)
        {
            chartColumn.Series.Clear();
        }
        #endregion
    }
}
