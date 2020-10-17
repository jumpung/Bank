using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class SavingsAccount : Account, IAccount
    {
        Status status = Status.inactive;

        public SavingsAccount(double balance, double interest) : base(balance, interest) 
        {       
        }

        public override void MakeWithdraw(double amount)
        {
            if(status == Status.active && CurrentBalance < 25)
            {
                status = Status.inactive;
                Console.WriteLine("The account is inactive and currently has less than 25$");
                Console.WriteLine("Current balance: " + ToNamFormat.ToNAMoneyFormat(true, CurrentBalance) + "$");
            }
            else
            {
                base.MakeWithdraw(amount);
                Console.WriteLine("You have withdrawn: " + ToNamFormat.ToNAMoneyFormat(true, amount) + "$");
                Console.WriteLine("Current balance: " + ToNamFormat.ToNAMoneyFormat(true, CurrentBalance) + "$");
            }
        }

        public override void MakeDeposit(double amount)
        {
 
            if(status == Status.inactive && (CurrentBalance + amount) >= 25)
            {
                base.MakeDeposit(amount);
                Console.WriteLine("You have deposited: " + ToNamFormat.ToNAMoneyFormat(true, amount) + "$");
                Console.WriteLine("Curent balance: " + ToNamFormat.ToNAMoneyFormat(true, CurrentBalance) + "$");
                status = Status.active;
            }
            else
            {
                base.MakeDeposit(amount);
                Console.WriteLine("You have deposited: " + ToNamFormat.ToNAMoneyFormat(true, amount) + "$");
                Console.WriteLine("Curent balance: " + ToNamFormat.ToNAMoneyFormat(true, CurrentBalance) + "$");
            }
        }

        public override string CloseAndReport()
        {
            if (withdrawalCount > 4)
            {
                serviceCharge++;
                return base.CloseAndReport();
            }
            else 
            {
                return base.CloseAndReport();
            }

        }

    }
}
