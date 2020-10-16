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
            if (balance < 25)
            {
                status = Status.inactive;
            }
            else
                status = Status.active;
        }
        
        public override void MakeWithdraw(double amount)
        {
            if(status == Status.active)
            {
                base.MakeWithdraw(amount);
                Console.WriteLine("You have withdrawn: " + amount + "$");
                Console.WriteLine("Current balance: " + CurrentBalance + "$");

            }
            else
            {
                Console.WriteLine("The account is inactive and currently has less than 25$");
                Console.WriteLine("Current balance: " + CurrentBalance + "$");
            }
        }
        public override void MakeDeposit(double amount)
        {
 
            if(status == Status.inactive && (CurrentBalance + amount) >= 25)
            {
                base.MakeDeposit(amount);
                Console.WriteLine("You have deposited: " + amount + "$");
                Console.WriteLine("Curent balance: " + CurrentBalance + "$");
                status = Status.active;
            }
            else
            {
                base.MakeDeposit(amount);
                Console.WriteLine("You have deposited: " + amount + "$");
                Console.WriteLine("Curent balance: " + CurrentBalance + "$");
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
