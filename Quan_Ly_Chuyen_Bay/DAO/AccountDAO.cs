using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance { get { if (instance == null) instance = new AccountDAO(); return instance; } private set => instance = value; }
        private AccountDAO() { }

        public bool Login(string userName, string password) 
        {
            string query = "EXEC USP_Login @UserName , @PassWord";
            DataTable result = DAO.DataProvider.Instance.ExecuteQuery(query, new object[] { userName, password });
            return result.Rows.Count > 0;
        }

        public DTO.AccountDTO GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ACCOUNT WHERE USERNAME = '" + userName + "'");

            foreach(DataRow item in data.Rows)
            {
                return new DTO.AccountDTO(item);
            }

            return null;
        }

        public bool UpdateAccount(string username, string displayname, string pass, string newpass)
        {
            string query = "EXEC USP_UpdateAccount @userName , @displayName , @password , @newPassword";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, displayname, pass, newpass });

            return result > 0;
            
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type FROM dbo.ACCOUNT");
        }

        public int GetTypeAccount(string username)
        {
            if(DataProvider.Instance.ExecuteScalar("SELECT Type FROM dbo.ACCOUNT WHERE UserName = '" + username + "'") == null)
                return 0;
            return (int)DataProvider.Instance.ExecuteScalar("SELECT Type FROM dbo.ACCOUNT WHERE UserName = '" + username + "'");
        }

        public bool InsertAccount(string username, string displayname, int type)
        {
            string query = string.Format("INSERT dbo.ACCOUNT (UserName, DisplayName, Type) VALUES (N'{0}', N'{1}', {2})", username, displayname, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string username, string displayname, int type)
        {
            string query = string.Format("UPDATE dbo.ACCOUNT SET DisplayName = N'{1}' , Type = {2} WHERE UserName = '{0}'", username, displayname, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = string.Format("DELETE dbo.ACCOUNT WHERE UserName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
