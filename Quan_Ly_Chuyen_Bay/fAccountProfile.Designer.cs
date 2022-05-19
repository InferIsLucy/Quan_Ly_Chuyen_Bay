namespace Quan_Ly_Chuyen_Bay
{
    partial class fAccountProfile
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbReWritePassword = new System.Windows.Forms.Label();
            this.txbReWritePassword = new System.Windows.Forms.TextBox();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.txbNewPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.lbDisplayName = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.txbDisplayName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Location = new System.Drawing.Point(15, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 98);
            this.panel1.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(690, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(186, 64);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(474, 16);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(186, 64);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbReWritePassword);
            this.panel2.Controls.Add(this.txbReWritePassword);
            this.panel2.Controls.Add(this.lbNewPassword);
            this.panel2.Controls.Add(this.txbNewPassword);
            this.panel2.Controls.Add(this.lbPassword);
            this.panel2.Controls.Add(this.txbPassword);
            this.panel2.Controls.Add(this.txbUsername);
            this.panel2.Controls.Add(this.lbDisplayName);
            this.panel2.Controls.Add(this.lbUsername);
            this.panel2.Controls.Add(this.txbDisplayName);
            this.panel2.Location = new System.Drawing.Point(15, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(908, 476);
            this.panel2.TabIndex = 5;
            // 
            // lbReWritePassword
            // 
            this.lbReWritePassword.AutoSize = true;
            this.lbReWritePassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReWritePassword.Location = new System.Drawing.Point(20, 380);
            this.lbReWritePassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbReWritePassword.Name = "lbReWritePassword";
            this.lbReWritePassword.Size = new System.Drawing.Size(152, 37);
            this.lbReWritePassword.TabIndex = 9;
            this.lbReWritePassword.Text = "Nhập lại:";
            // 
            // txbReWritePassword
            // 
            this.txbReWritePassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbReWritePassword.Location = new System.Drawing.Point(273, 380);
            this.txbReWritePassword.Margin = new System.Windows.Forms.Padding(6);
            this.txbReWritePassword.Name = "txbReWritePassword";
            this.txbReWritePassword.PasswordChar = '*';
            this.txbReWritePassword.Size = new System.Drawing.Size(603, 44);
            this.txbReWritePassword.TabIndex = 8;
            this.txbReWritePassword.UseSystemPasswordChar = true;
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewPassword.Location = new System.Drawing.Point(20, 291);
            this.lbNewPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(236, 37);
            this.lbNewPassword.TabIndex = 7;
            this.lbNewPassword.Text = "Mật khẩu mới:";
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewPassword.Location = new System.Drawing.Point(273, 291);
            this.txbNewPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.PasswordChar = '*';
            this.txbNewPassword.Size = new System.Drawing.Size(603, 44);
            this.txbNewPassword.TabIndex = 6;
            this.txbNewPassword.UseSystemPasswordChar = true;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(20, 199);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(166, 37);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Mật khẩu:";
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(273, 199);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(603, 44);
            this.txbPassword.TabIndex = 4;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // txbUsername
            // 
            this.txbUsername.Enabled = false;
            this.txbUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(273, 15);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(6);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.ReadOnly = true;
            this.txbUsername.Size = new System.Drawing.Size(603, 44);
            this.txbUsername.TabIndex = 0;
            // 
            // lbDisplayName
            // 
            this.lbDisplayName.AutoSize = true;
            this.lbDisplayName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplayName.Location = new System.Drawing.Point(20, 106);
            this.lbDisplayName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbDisplayName.Name = "lbDisplayName";
            this.lbDisplayName.Size = new System.Drawing.Size(208, 37);
            this.lbDisplayName.TabIndex = 3;
            this.lbDisplayName.Text = "Tên hiển thị:";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(20, 17);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(177, 37);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Tài khoản:";
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDisplayName.Location = new System.Drawing.Point(273, 106);
            this.txbDisplayName.Margin = new System.Windows.Forms.Padding(6);
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.PasswordChar = '*';
            this.txbDisplayName.Size = new System.Drawing.Size(603, 44);
            this.txbDisplayName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Location = new System.Drawing.Point(15, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 98);
            this.panel1.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(690, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(186, 64);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(474, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(186, 64);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // fAccountProfile
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(938, 608);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "fAccountProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fAccountProfile";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label lbDisplayName;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox txbDisplayName;
        private System.Windows.Forms.Label lbReWritePassword;
        private System.Windows.Forms.TextBox txbReWritePassword;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.TextBox txbNewPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txbPassword;
    }
}