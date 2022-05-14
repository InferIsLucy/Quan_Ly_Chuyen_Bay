
namespace Quan_Ly_Chuyen_Bay
{
    partial class fBanVeChuyenBay
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMaChuyenBay = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSanBayDi = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txbSanBayDen = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txbNgayDi = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnXemThongTinCB = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 213);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTim);
            this.flowLayoutPanel1.Controls.Add(this.btnXemThongTinCB);
            this.flowLayoutPanel1.Controls.Add(this.btnDangKy);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(347, 148);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(400, 44);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(12, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 202);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(768, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txbMaChuyenBay);
            this.panel5.Location = new System.Drawing.Point(5, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(315, 59);
            this.panel5.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã Chuyến Bay: ";
            // 
            // txbMaChuyenBay
            // 
            this.txbMaChuyenBay.Location = new System.Drawing.Point(116, 19);
            this.txbMaChuyenBay.Name = "txbMaChuyenBay";
            this.txbMaChuyenBay.Size = new System.Drawing.Size(190, 22);
            this.txbMaChuyenBay.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txbSanBayDi);
            this.panel3.Location = new System.Drawing.Point(5, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(315, 59);
            this.panel3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sân bay đi:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txbSanBayDi
            // 
            this.txbSanBayDi.Location = new System.Drawing.Point(116, 19);
            this.txbSanBayDi.Name = "txbSanBayDi";
            this.txbSanBayDi.Size = new System.Drawing.Size(190, 22);
            this.txbSanBayDi.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txbSanBayDen);
            this.panel4.Location = new System.Drawing.Point(432, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(315, 59);
            this.panel4.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sân bay đến:";
            // 
            // txbSanBayDen
            // 
            this.txbSanBayDen.Location = new System.Drawing.Point(116, 19);
            this.txbSanBayDen.Name = "txbSanBayDen";
            this.txbSanBayDen.Size = new System.Drawing.Size(190, 22);
            this.txbSanBayDen.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txbNgayDi);
            this.panel6.Location = new System.Drawing.Point(5, 133);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(315, 59);
            this.panel6.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày đi: ";
            // 
            // txbNgayDi
            // 
            this.txbNgayDi.Location = new System.Drawing.Point(116, 19);
            this.txbNgayDi.Name = "txbNgayDi";
            this.txbNgayDi.Size = new System.Drawing.Size(190, 22);
            this.txbNgayDi.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(3, 3);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(126, 41);
            this.btnTim.TabIndex = 0;
            this.btnTim.Text = "Tìm Chuyến Bay";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // btnXemThongTinCB
            // 
            this.btnXemThongTinCB.Location = new System.Drawing.Point(135, 3);
            this.btnXemThongTinCB.Name = "btnXemThongTinCB";
            this.btnXemThongTinCB.Size = new System.Drawing.Size(126, 41);
            this.btnXemThongTinCB.TabIndex = 1;
            this.btnXemThongTinCB.Text = "Xem Thông Tin";
            this.btnXemThongTinCB.UseVisualStyleBackColor = true;
            this.btnXemThongTinCB.Click += new System.EventHandler(this.btnXemThongTinCB_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(267, 3);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(126, 41);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng ký mua vé";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.button2_Click);
            // 
            // fBanVeChuyenBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fBanVeChuyenBay";
            this.Text = "fBanVeChuyenBay";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSanBayDi;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMaChuyenBay;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbNgayDi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbSanBayDen;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnXemThongTinCB;
        private System.Windows.Forms.Button btnDangKy;
    }
}