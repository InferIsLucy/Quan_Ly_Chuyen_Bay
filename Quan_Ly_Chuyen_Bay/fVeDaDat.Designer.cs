
namespace Quan_Ly_Chuyen_Bay
{
    partial class fVeDaDat
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtgvDanhSachVeDaDat = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txbMaPhieuDatCho = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachVeDaDat)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(428, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vé Đã Đặt";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dtgvDanhSachVeDaDat);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(982, 370);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dtgvDanhSachVeDaDat
            // 
            this.dtgvDanhSachVeDaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDanhSachVeDaDat.Location = new System.Drawing.Point(3, 3);
            this.dtgvDanhSachVeDaDat.Name = "dtgvDanhSachVeDaDat";
            this.dtgvDanhSachVeDaDat.RowHeadersWidth = 51;
            this.dtgvDanhSachVeDaDat.RowTemplate.Height = 24;
            this.dtgvDanhSachVeDaDat.Size = new System.Drawing.Size(972, 367);
            this.dtgvDanhSachVeDaDat.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbMaPhieuDatCho);
            this.panel1.Controls.Add(this.btnThanhToan);
            this.panel1.Location = new System.Drawing.Point(12, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 106);
            this.panel1.TabIndex = 2;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThanhToan.Location = new System.Drawing.Point(811, 58);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(168, 48);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbMaPhieuDatCho
            // 
            this.txbMaPhieuDatCho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbMaPhieuDatCho.Location = new System.Drawing.Point(3, 3);
            this.txbMaPhieuDatCho.Name = "txbMaPhieuDatCho";
            this.txbMaPhieuDatCho.Size = new System.Drawing.Size(193, 30);
            this.txbMaPhieuDatCho.TabIndex = 1;
            // 
            // fVeDaDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(999, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "fVeDaDat";
            this.Text = "Vé đã bán";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachVeDaDat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgvDanhSachVeDaDat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txbMaPhieuDatCho;
    }
}