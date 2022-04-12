using System;
using System.Data;
using System.Linq;

namespace DehasoftEntegrasyon.Class
{
    public static class NullKontrol
    {
        public static double NullKontrolDouble(DataRow satir, string kolon)
        {
            if (satir[kolon] is DBNull)
            {
                return 0;
            }
            else
            {
                return (double)satir[kolon];
            }
        }
        public static long NullKontrolBigint(DataRow satir, string kolon)
        {
            if (satir[kolon] is DBNull)
            {
                return 0;
            }
            else
            {
                return (long)satir[kolon];
            }
        }
        public static string NullKontrolString(DataRow satir, string kolon)
        {
            if (satir[kolon] is DBNull)
            {
                return "";
            }
            else
            {
                return satir[kolon].ToString();
            }
        }
        public static int NullKontrolInt(DataRow satir, string kolon)
        {
            if (satir[kolon] is DBNull)
            {
                return 0;
            }
            else
            {
                return (int)satir[kolon];
            }
        }
    }

}
