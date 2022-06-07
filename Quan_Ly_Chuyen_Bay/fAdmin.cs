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
using Quan_Ly_Chuyen_Bay.DAO;
using Quan_Ly_Chuyen_Bay.DTO;

namespace Quan_Ly_Chuyen_Bay
{
    public partial class fAdmin : Form
    {
        BindingSource listAccount = new BindingSource();
        BindingSource listHangVe = new BindingSource();
        BindingSource listSanBay = new BindingSource();

        public AccountDTO loginAcc;
        public fAdmin()
        {
            InitializeComponent();
            LoadFunction();
        }

        #region FUNCTION
        void LoadFunction()
        {
            LoadYearForTurnoverByYear();
            ShowSLHVMax();
        }

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName"));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName"));
        }

        void AddHangVeBinding()
        {
            txbTenHangVe.DataBindings.Add(new Binding("Text", dtgvListHangVe.DataSource, "TenHangVe"));
            txbSoLuongGhe.DataBindings.Add(new Binding("Text", dtgvListHangVe.DataSource, "SoLuongGhe"));
            txbPhanTramDonGia.DataBindings.Add(new Binding("Text", dtgvListHangVe.DataSource, "PhanTramDonGia"));
        }

        void AddSanBayBinding()
        {
            txbMaSB.DataBindings.Add(new Binding("Text", dtgvSanBay.DataSource, "MaSanBay"));
            txbTenSB.DataBindings.Add(new Binding("Text", dtgvSanBay.DataSource, "TenSanBay"));
        }

        void LoadAccount()
        {
            listAccount.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.DataSource = listAccount;
        }

        void LoadHangVe()
        {
            listHangVe.DataSource = SoLuongGheDAO.Instance.GetListHangVe();
            dtgvListHangVe.DataSource = listHangVe;
        }

        void LoadSanBay()
        {
            listSanBay.DataSource = SanBayDAO.Instance.GetListSanBay();
            dtgvSanBay.DataSource = listSanBay;
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

        void AddAccount(string userName, string displayName, int type)
        {
            DataTable data = AccountDAO.Instance.GetAllUserName();
            foreach (DataRow row in data.Rows)
            {
                if (txbUserName.Text.Equals(row["UserName"].ToString()))
                {
                    MessageBox.Show("Tên này đã tồn tại!");
                    return;
                }
            }

            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Thêm tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Cập nhật tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAcc.UserName.Equals(txbUserName.Text))
            {
                MessageBox.Show("Không thể xóa tài khoản hiện hành!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo");
            else
                MessageBox.Show("Xóa tài khoản thất bại!", "Thông báo");

            LoadAccount();
        }

        void CheckInt(string data, ref int result)
        {
            if(data != "")
            {
                if (!Int32.TryParse(data, out result))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!");
                }
            }
        }

        void updateMinFlightTime(string data)
        {
            int result = 0;

            if (data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateMinFlightTime(result))
                {
                    MessageBox.Show("Cập nhật thời gian bay tối thiểu thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công thời gian bay tối thiểu!");
            }
            else
                return;

        }

        void updateMaxBreakAirport(string data)
        {
            int result = 0;
            if (data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateMaxBreakAirport(result))
                {
                    MessageBox.Show("Cập nhật số sân bay trung gian tối đa thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công số sân bay trung gian tối đa!");
            }
            else
                return;

        }

        void updateBreakTimeMin(string data)
        {
            int result = 0;
            if(data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateBreakTimeMin(result))
                {
                    MessageBox.Show("Cập nhật thời gian dừng tối thiếu thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công thời gian dừng tối thiểu!");
            }
            else return;

        }

        void updateBreakTimeMax(string data)
        {
            int result = 0;
            if (data != "")
            {
                CheckInt(data, ref result);
                if (ThamSoDAO.Instance.UpdateBreakTimeMax(result))
                {
                    MessageBox.Show("Cập nhật thời gian dừng tối đa thành công!");
                }
                else
                    MessageBox.Show("Không cập nhật thành công thời gian dừng tối đa!");
            }
            else return;
        }

        void AddHangVe(string tenHangVe, float phanTramDonGia, int soLuongGhe)
        {
            int slhvMax = SoLuongGheDAO.Instance.GetSLHVMax();
            int slhv = SoLuongGheDAO.Instance.GetSLHV();

            if(slhv >= slhvMax)
            {
                MessageBox.Show("Số lượng hạn vé vượt quá mức quy định. Không thể thêm hạng vé!");
                return;
            }
            else
            {
                DataTable data = SoLuongGheDAO.Instance.GetAllTenHangVe();
                foreach (DataRow dr in data.Rows)
                {
                    if (txbTenHangVe.Text.Equals(dr["TenHangVe"].ToString()))
                    {
                        MessageBox.Show("Tên hạng vé này đã tồn tại!");
                        return;
                    }
                }

                if (SoLuongGheDAO.Instance.InsertHangVe(tenHangVe, phanTramDonGia, soLuongGhe))
                    MessageBox.Show("Thêm hạng vé thành công!");
                else
                    MessageBox.Show("Thêm hạng vé thất bại!");

                LoadHangVe();
            }
        }

        void EditHangVe(string tenHangVe, float phanTramDonGia, int soLuongGhe)
        {
            if (SoLuongGheDAO.Instance.UpdateHangVe(tenHangVe, phanTramDonGia, soLuongGhe))
                MessageBox.Show("Cập nhật hạng vé thành công!");
            else
                MessageBox.Show("Cập nhật hạng vé thất bại!");

            LoadHangVe();
        }

        void DeleteHangVe(string tenHangVe)
        {
            if (SoLuongGheDAO.Instance.DeleteHangVe(tenHangVe))
                MessageBox.Show("Xóa tài khoản thành công!");
            else
                MessageBox.Show("Xóa tài khoản thất bại!");

            LoadHangVe();
        }

        void ShowSLHVMax()
        {
            int SLHVTD = SoLuongGheDAO.Instance.GetSLHVMax();
            lbSLHVTD.Text = "(Số lượng hạng vé tối đa hiện tại là: " + SLHVTD + ")";
        }

        void UpdateSLHV(string slhv)
        {
            int result = 0;
            if (slhv == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô dữ liệu trước khi cập nhật!");
                return;
            }
                
            CheckInt(slhv, ref result);

            if (ThamSoDAO.Instance.UpdateSLHV(result))
                MessageBox.Show("Cập nhật số lượng hạng vé tối đa thành công!");
            else
                MessageBox.Show("Cập nhật số lượng hạng vé tối đa thất bại!");
        }

        void UpdateTGHV(string tghv)
        {
            int result = 0;
            if (tghv == "")
                return;

            CheckInt(tghv, ref result);

            if (ThamSoDAO.Instance.UpdateHuyVeChamNhat(result))
                MessageBox.Show("Cập nhật thời gian hủy vé chậm nhất trước giờ bay thành công!");
            else
                MessageBox.Show("Cập nhật thời gian hủy vé chậm nhất trước giờ bay thất bại!");
        }

        void UpdateTGTT(string tgtt)
        {
            int result = 0;
            if (tgtt == "")
                return;

            CheckInt(tgtt, ref result);

            if (ThamSoDAO.Instance.UpdateThanhToanChamNhat(result))
                MessageBox.Show("Cập nhật thời gian thanh toán chậm nhất sau khi đặt vé thành công!");
            else
                MessageBox.Show("Cập nhật thời gian thanh toán chậm nhất sau khi đặt vé thất bại!");
        }

        void AddSanBay(string maSanBay, string tenSanBay)
        {
            DataTable data = SanBayDAO.Instance.GetAllMaSB();
            foreach (DataRow dr in data.Rows)
            {
                if (txbTenHangVe.Text.Equals(dr["MaSanBay"].ToString()))
                {
                    MessageBox.Show("Mã sân bay này đã tồn tại!");
                    return;
                }
            }

            if (SanBayDAO.Instance.InsertSanBay(maSanBay,  tenSanBay))
                MessageBox.Show("Thêm sân bay thành công!");
            else
                MessageBox.Show("Thêm sân bay thất bại!");

            LoadSanBay();
        }

        void EditSanBay(string maSanBay, string tenSanBay)
        {
            if (SanBayDAO.Instance.UpdateSanBay(maSanBay, tenSanBay))
                MessageBox.Show("Cập nhật sân bay thành công!");
            else
                MessageBox.Show("Cập nhật sân bay thất bại!");

            LoadSanBay();
        }

        void DeleteSanBay(string maSanBay)
        {
            if (SanBayDAO.Instance.DeleteSanBay(maSanBay))
                MessageBox.Show("Xóa sân bay thành công!");
            else
                MessageBox.Show("Xóa sân bay thất bại!");

            LoadSanBay();
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadAccount();
            try
            {
                AddAccountBinding();
            }catch(Exception)
            {
                return;
            }
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {
            int type = AccountDAO.Instance.GetTypeAccount(txbUserName.Text);
            cbTypeAccount.SelectedIndex = type;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = cbTypeAccount.SelectedIndex;

            AddAccount(userName, displayName, type);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = cbTypeAccount.SelectedIndex;

            EditAccount(userName, displayName, type);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            AccountDTO acc = AccountDAO.Instance.GetAccountByUserName(txbUserName.Text);
            fAccountProfile f = new fAccountProfile(acc);
            f.ShowDialog();
            this.Show();
        }

        private void btnUpdateAirport_Click(object sender, EventArgs e)
        {
            updateBreakTimeMax(txbBreakTimeTo.Text);
            updateBreakTimeMin(txbBreakTimeFrom.Text);
            updateMaxBreakAirport(txbMaxBreakAirport.Text);
            updateMinFlightTime(txbMinFlightTime.Text);
        }

        private void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            string slhvtd = txbFlightTicketName.Text;
            UpdateSLHV(slhvtd);
        }

        private void btnUpdateBookTicket_Click(object sender, EventArgs e)
        {
            string tghv = txbMinTimeCancelTicket.Text;
            string tgtt = txbMinTimePayment.Text;

            UpdateTGHV(tghv);
            UpdateTGTT(tgtt);
        }

        private void btnXemHangVe_Click(object sender, EventArgs e)
        {
            LoadHangVe();
            try
            {
                AddHangVeBinding();
            }catch(Exception)
            {
                return;
            }
        }

        private void btnThemHangVe_Click(object sender, EventArgs e)
        {
            string tenHangVe = txbTenHangVe.Text;
            float phanTramDonGia;
            if (!float.TryParse(txbPhanTramDonGia.Text, out phanTramDonGia))
            {
                MessageBox.Show("Vui lòng chỉ nhập số ở ô 'Phần trăm đơn giá'!");
                return;
            }
            int soLuongGhe;
            if (!Int32.TryParse(txbSoLuongGhe.Text, out soLuongGhe))
            {
                MessageBox.Show("Vui lòng chỉ nhập số ở ô 'Số lượng ghế'!");
                return;
            }

            AddHangVe(tenHangVe, phanTramDonGia, soLuongGhe);
        }

        private void btnXoaHangVe_Click(object sender, EventArgs e)
        {
            string tenHangVe = txbTenHangVe.Text;

            DeleteHangVe(tenHangVe);
        }

        private void btnSuaHangVe_Click(object sender, EventArgs e)
        {
            string tenHangVe = txbTenHangVe.Text;
            float phanTramDonGia;
            if (!float.TryParse(txbPhanTramDonGia.Text, out phanTramDonGia))
            {
                MessageBox.Show("Vui lòng chỉ nhập số ở ô 'Phần trăm đơn giá'!");
                return;
            }
            int soLuongGhe;
            if (!Int32.TryParse(txbSoLuongGhe.Text, out soLuongGhe))
            {
                MessageBox.Show("Vui lòng chỉ nhập số ở ô 'Số lượng ghế'!");
                return;
            }

            EditHangVe(tenHangVe, phanTramDonGia, soLuongGhe);
        }

        private void btnXemSB_Click(object sender, EventArgs e)
        {
            LoadSanBay();
            try
            {
                AddSanBayBinding();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnThemSB_Click(object sender, EventArgs e)
        {
            string maSanBay = txbMaSB.Text;
            if(maSanBay.Length > 5)
            {
                MessageBox.Show("Mã sân bay không hợp lệ");
                return;
            }
            string tenSanBay = txbTenSB.Text;
            if(tenSanBay.Length > 100)
            {
                MessageBox.Show("Tên sân bay quá dài, vui lòng nhập lại!");
                return;
            }

            AddSanBay(maSanBay.ToUpper(), tenSanBay);

        }

        private void btnSuaSB_Click(object sender, EventArgs e)
        {
            string maSanBay = txbMaSB.Text;
            
            string tenSanBay = txbTenSB.Text;
            if (tenSanBay.Length > 100)
            {
                MessageBox.Show("Tên sân bay quá dài, vui lòng nhập lại!");
                return;
            }

            EditSanBay(maSanBay, tenSanBay);
        }

        private void btnXoaSB_Click(object sender, EventArgs e)
        {
            string maSanBay = txbMaSB.Text;
            DeleteSanBay(maSanBay);
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
