using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class ToNamFormat
    {
        public static string ToNAMoneyFormat(bool tf, double n)
        {
            if (tf == true)
            {
                Math.Round(n, 2);

                string formatted = n.ToString("C2");

                return formatted.ToString();
            }
            else
            return n.ToString();
        }
    }
    }

