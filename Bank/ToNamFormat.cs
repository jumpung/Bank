using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class ToNamFormat
    {
        public static string ToNAMoneyFormat(this double n, Boolean tf)
        {
            if (tf == false)
            {
                return n.ToString();
            }
            else
                Math.Round(n, 2);
            return n.ToString();
        }
    }
    }

