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
        Status status;

        public SavingsAccount(double balance, double interest) : base(balance, interest) 
        { 
            
            if(balance < 25)
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
                Console.ReadLine();
            }
            else
            {
                base.MakeWithdraw(amount);
                Console.WriteLine("You have withdrawn: " + amount + "$");
                Console.ReadLine();
            }
        }
        public override void MakeDeposit(double amount)
        {
 
            if(status == Status.inactive && currentBalance + amount > 25)
            {
                status = Status.active;
                base.MakeDeposit(amount);
                Console.WriteLine("You have deposited: " + amount + "$");
                Console.ReadLine();
            }
            else
            {
                base.MakeDeposit(amount);
                Console.WriteLine("You have deposited: " + amount + "$");
                Console.ReadLine();
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
