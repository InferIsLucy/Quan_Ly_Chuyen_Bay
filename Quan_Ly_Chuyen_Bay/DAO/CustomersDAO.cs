using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Chuyen_Bay.DAO
{
    public class CustomersDAO
    {
        private static CustomersDAO instance;

        public static CustomersDAO Instance { get { if (instance == null) instance = new CustomersDAO(); return instance; } private set => instance = value; }
    }
}
