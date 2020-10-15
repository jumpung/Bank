using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class GlobalSavingsAccount: SavingsAccount, IExchangeable, IAccount
    {
        public GlobalSavingsAccount(double balance, double interest) : base(balance, interest)
        {   
        }

        public double USValue(double rate)
        {
            return currentBalance * rate;
        }
    }
}
