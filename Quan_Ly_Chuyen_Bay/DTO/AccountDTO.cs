﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quan_Ly_Chuyen_Bay.DTO
{
    public class AccountDTO
    {
        private string password;
        private int type;
        private string displayName;
        private string userName;
        #region GetSet
        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
        #endregion

        public AccountDTO(string userName, string displayName, int type, string password = null) 
        {
            this.userName = userName;
            this.displayName = displayName;
            this.type = type;
            this.password = password;
        }

        public AccountDTO(DataRow row)
        {
            this.userName = row["userName"].ToString();
            this.displayName = row["displayName"].ToString();
            this.type = (int)row["type"];
            this.password = row["password"].ToString();
        }

    }
}
