namespace Quan_Ly_Chuyen_Bay
{
    partial class fTurnoverByFlightID
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbFlightID = new System.Windows.Forms.TextBox();
            this.lbFlightID = new System.Windows.Forms.Label();
            this.lbFlightName = new System.Windows.Forms.Label();
            this.cmbFlightName = new System.Windows.Forms.ComboBox();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.lbToDate = new System.Windows.Forms.Label();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.lbFromDate = new System.Windows.Forms.Label();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtgvViewBill = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbAmount = new System.Windows.Forms.TextBox();
            this.lbAmount = new System.Windows.Forms.Label();
            this.btnChart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvViewBill)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbFlightID);
            this.panel1.Controls.Add(this.lbFlightID);
            this.panel1.Controls.Add(this.lbFlightName);
            this.panel1.Controls.Add(this.cmbFlightName);
            this.panel1.Controls.Add(this.btnViewBill);
            this.panel1.Controls.Add(this.lbToDate);
            this.panel1.Controls.Add(this.dtpkToDate);
            this.panel1.Controls.Add(this.lbFromDate);
            this.panel1.Controls.Add(this.dtpkFromDate);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1808, 136);
            this.panel1.TabIndex = 0;
            // 
            // txbFlightID
            // 
            this.txbFlightID.Enabled = false;
            this.txbFlightID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFlightID.Location = new System.Drawing.Point(1043, 73);
            this.txbFlightID.Name = "txbFlightID";
            this.txbFlightID.Size = new System.Drawing.Size(303, 44);
            this.txbFlightID.TabIndex = 15;
            // 
            // lbFlightID
            // 
            this.lbFlightID.AutoSize = true;
            this.lbFlightID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlightID.Location = new System.Drawing.Point(786, 76);
            this.lbFlightID.Name = "lbFlightID";
            this.lbFlightID.Size = new System.Drawing.Size(241, 37);
            this.lbFlightID.TabIndex = 14;
            this.lbFlightID.Text = "Mã chuyến bay:";
            // 
            // lbFlightName
            // 
            this.lbFlightName.AutoSize = true;
            this.lbFlightName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlightName.Location = new System.Drawing.Point(8, 76);
            this.lbFlightName.Name = "lbFlightName";
            this.lbFlightName.Size = new System.Drawing.Size(252, 37);
            this.lbFlightName.TabIndex = 13;
            this.lbFlightName.Text = "Tên chuyến bay:";
            // 
            // cmbFlightName
            // 
            this.cmbFlightName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFlightName.FormattingEnabled = true;
            this.cmbFlightName.Location = new System.Drawing.Point(280, 73);
            this.cmbFlightName.Name = "cmbFlightName";
            this.cmbFlightName.Size = new System.Drawing.Size(478, 45);
            this.cmbFlightName.TabIndex = 12;
            // 
            // btnViewBill
            // 
            this.btnViewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBill.Location = new System.Drawing.Point(1467, 26);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(341, 77);
            this.btnViewBill.TabIndex = 11;
            this.btnViewBill.Text = "Thống kê";
            this.btnViewBill.UseVisualStyleBackColor = true;
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToDate.Location = new System.Drawing.Point(686, 20);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(162, 37);
            this.lbToDate.TabIndex = 10;
            this.lbToDate.Text = "Đến ngày:";
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkToDate.Location = new System.Drawing.Point(868, 26);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(478, 31);
            this.dtpkToDate.TabIndex = 9;
            // 
            // lbFromDate
            // 
            this.lbFromDate.AutoSize = true;
            this.lbFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFromDate.Location = new System.Drawing.Point(8, 20);
            this.lbFromDate.Name = "lbFromDate";
            this.lbFromDate.Size = new System.Drawing.Size(142, 37);
            this.lbFromDate.TabIndex = 8;
            this.lbFromDate.Text = "Từ ngày:";
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFromDate.Location = new System.Drawing.Point(156, 26);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(478, 31);
            this.dtpkFromDate.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dtgvViewBill);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 146);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1808, 772);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dtgvViewBill
            // 
            this.dtgvViewBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvViewBill.Location = new System.Drawing.Point(3, 3);
            this.dtgvViewBill.Name = "dtgvViewBill";
            this.dtgvViewBill.RowHeadersWidth = 82;
            this.dtgvViewBill.RowTemplate.Height = 33;
            this.dtgvViewBill.Size = new System.Drawing.Size(1805, 769);
            this.dtgvViewBill.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.txbAmount);
            this.panel2.Controls.Add(this.lbAmount);
            this.panel2.Controls.Add(this.btnChart);
            this.panel2.Location = new System.Drawing.Point(4, 924);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1808, 74);
            this.panel2.TabIndex = 2;
            // 
            // txbAmount
            // 
            this.txbAmount.Enabled = false;
            this.txbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAmount.Location = new System.Drawing.Point(945, 16);
            this.txbAmount.Name = "txbAmount";
            this.txbAmount.Size = new System.Drawing.Size(513, 44);
            this.txbAmount.TabIndex = 16;
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmount.Location = new System.Drawing.Point(686, 19);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(253, 37);
            this.lbAmount.TabIndex = 15;
            this.lbAmount.Text = "Tổng doanh thu:";
            // 
            // btnChart
            // 
            this.btnChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChart.Location = new System.Drawing.Point(1464, 3);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(341, 68);
            this.btnChart.TabIndex = 12;
            this.btnChart.Text = "Biểu đồ";
            this.btnChart.UseVisualStyleBackColor = true;
            // 
            // fTurnoverByFlightID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1818, 1002);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "fTurnoverByFlightID";
            this.Text = "Báo cáo doanh thu theo Chuyến Bay";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvViewBill)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
        private System.Windows.Forms.Label lbFromDate;
        private System.Windows.Forms.DateTimePicker dtpkFromDate;
        private System.Windows.Forms.TextBox txbFlightID;
        private System.Windows.Forms.Label lbFlightID;
        private System.Windows.Forms.Label lbFlightName;
        private System.Windows.Forms.ComboBox cmbFlightName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgvViewBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbAmount;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Button btnChart;
    }
}