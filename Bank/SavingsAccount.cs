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
            
            if(CurrentBalance < 25)
            {
                status = Status.inactive;
            }
            else
            {
                status = Status.active;
            }
        
        }
        
        public override void MakeWithdraw(double amount)
        {
            if(status == Status.inactive)
            {
                Console.WriteLine("The account is inactive and currently has less than 25$");
                Console.WriteLine("Current balance: " + CurrentBalance);
            }
            else
            {
                base.MakeWithdraw(amount);
                Console.WriteLine("You have withdrawn: " + amount + "$");
            }
        }
        public override void MakeDeposit(double amount)
        {
 
            if(status == Status.inactive && (CurrentBalance + amount) > 25)
            {
                status = Status.active;
                base.MakeDeposit(amount);
                
            }
            else
            {
                base.MakeDeposit(amount);
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
