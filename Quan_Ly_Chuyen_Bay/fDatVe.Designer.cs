
namespace Quan_Ly_Chuyen_Bay
{
    partial class fDatVe
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtagvLichChuyenBay = new System.Windows.Forms.DataGridView();
            this.btnThemCB = new System.Windows.Forms.Button();
            this.btnXoaCB = new System.Windows.Forms.Button();
            this.btnSuaCB = new System.Windows.Forms.Button();
            this.MaChuyenBay = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MaCB = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtagvLichChuyenBay)).BeginInit();
            this.MaChuyenBay.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtagvLichChuyenBay);
            this.panel1.Location = new System.Drawing.Point(13, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 361);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSuaCB);
            this.panel2.Controls.Add(this.btnXoaCB);
            this.panel2.Controls.Add(this.btnThemCB);
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 59);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(470, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(318, 59);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.MaChuyenBay);
            this.panel4.Location = new System.Drawing.Point(470, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(317, 360);
            this.panel4.TabIndex = 3;
            // 
            // dtagvLichChuyenBay
            // 
            this.dtagvLichChuyenBay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtagvLichChuyenBay.Location = new System.Drawing.Point(0, 3);
            this.dtagvLichChuyenBay.Name = "dtagvLichChuyenBay";
            this.dtagvLichChuyenBay.RowHeadersWidth = 51;
            this.dtagvLichChuyenBay.RowTemplate.Height = 24;
            this.dtagvLichChuyenBay.Size = new System.Drawing.Size(446, 358);
            this.dtagvLichChuyenBay.TabIndex = 0;
            // 
            // btnThemCB
            // 
            this.btnThemCB.Location = new System.Drawing.Point(3, 3);
            this.btnThemCB.Name = "btnThemCB";
            this.btnThemCB.Size = new System.Drawing.Size(81, 56);
            this.btnThemCB.TabIndex = 1;
            this.btnThemCB.Text = "Thêm";
            this.btnThemCB.UseVisualStyleBackColor = true;
            // 
            // btnXoaCB
            // 
            this.btnXoaCB.Location = new System.Drawing.Point(90, 3);
            this.btnXoaCB.Name = "btnXoaCB";
            this.btnXoaCB.Size = new System.Drawing.Size(81, 56);
            this.btnXoaCB.TabIndex = 2;
            this.btnXoaCB.Text = "Xóa";
            this.btnXoaCB.UseVisualStyleBackColor = true;
            // 
            // btnSuaCB
            // 
            this.btnSuaCB.Location = new System.Drawing.Point(177, 3);
            this.btnSuaCB.Name = "btnSuaCB";
            this.btnSuaCB.Size = new System.Drawing.Size(81, 56);
            this.btnSuaCB.TabIndex = 3;
            this.btnSuaCB.Text = "Sửa";
            this.btnSuaCB.UseVisualStyleBackColor = true;
            this.btnSuaCB.Click += new System.EventHandler(this.button1_Click);
            // 
            // MaChuyenBay
            // 
            this.MaChuyenBay.Controls.Add(this.textBox1);
            this.MaChuyenBay.Controls.Add(this.MaCB);
            this.MaChuyenBay.Location = new System.Drawing.Point(3, 3);
            this.MaChuyenBay.Name = "MaChuyenBay";
            this.MaChuyenBay.Size = new System.Drawing.Size(311, 51);
            this.MaChuyenBay.TabIndex = 1;
            this.MaChuyenBay.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // MaCB
            // 
            this.MaCB.AutoSize = true;
            this.MaCB.Location = new System.Drawing.Point(4, 15);
            this.MaCB.Name = "MaCB";
            this.MaCB.Size = new System.Drawing.Size(99, 17);
            this.MaCB.TabIndex = 0;
            this.MaCB.Text = "MaChuyenBay";
            this.MaCB.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 22);
            this.textBox1.TabIndex = 1;
            // 
            // fDatVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fDatVe";
            this.Text = "fDatVe";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtagvLichChuyenBay)).EndInit();
            this.MaChuyenBay.ResumeLayout(false);
            this.MaChuyenBay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtagvLichChuyenBay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSuaCB;
        private System.Windows.Forms.Button btnXoaCB;
        private System.Windows.Forms.Button btnThemCB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel MaChuyenBay;
        private System.Windows.Forms.Label MaCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}