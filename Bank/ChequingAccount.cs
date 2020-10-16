using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ChequingAccount: Account, IAccount
    {

        public ChequingAccount(double balance, double interest) : base(balance, interest)
        {
        }


        public override void MakeWithdraw(double amount)
        {

            if(CurrentBalance - amount < 0)
            {
                serviceCharge += 15;
                Console.WriteLine("Withdrawal denied, not enough money in your current balance");
                Console.WriteLine("15$ has been added to your monthly charge fee");
            }
            else
            {
                base.MakeWithdraw(amount);
                Console.WriteLine("You have withdrawn: " + amount);
            }

        }

        public override void MakeDeposit(double amount)
        {
            base.MakeDeposit(amount);
            Console.WriteLine("You have deposited: " + amount + "$");
            Console.WriteLine("Curent balance: " + CurrentBalance + "$");
        }

        public override string ToString()
        {
            serviceCharge += 5 +(0.10 * withdrawalCount);
            return base.ToString();
        }
    }
}
