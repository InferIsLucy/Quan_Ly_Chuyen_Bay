﻿using System;
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
    public partial class fChartByYear : Form
    {
        public fChartByYear()
        {
            InitializeComponent();
            
        }

        #region CREATE LINK WITH fAdmin
        private fAdmin mainForm = null;

        public fChartByYear(Form callingForm)
        {
            mainForm = callingForm as fAdmin;
            InitializeComponent();
            LoadFunction();
        }
        #endregion

        #region FUNCTIONS
        void LoadFunction()
        {
            LoadData(this.mainForm.CmbYear);
        }

        void LoadData(int year)
        {
            string query = "EXEC USP_TEST @year";
            chartColumn.DataSource = DAO.DataProvider.Instance.ExecuteQuery(query, new object[] { year });
            chartColumn.Series.Add("VND");
            chartColumn.Series["VND"].XValueMember = "THANG";
            chartColumn.Series["VND"].YValueMembers = "DOANHTHU";
            chartColumn.Titles.Add("Biểu đồ cột thống kê doanh số");
        }
        #endregion

        private void fChartByYear_FormClosing(object sender, FormClosingEventArgs e)
        {
            chartColumn.Series.Clear();
        }
    }
}
