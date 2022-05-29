using System;

namespace Quan_Ly_Chuyen_Bay
{
    internal class DataProvider
    {
        public static object Instance { get; internal set; }

        internal object ExcuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        internal int ExcuteNonQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}