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

            if(currentBalance - amount < 0)
            {
                serviceCharge += 15;
                Console.WriteLine("Withdrawal denied, not enough money in your current balance");
                Console.WriteLine("15$ has been added to your monthly charge fee");
                Console.ReadLine();
            }
            base.MakeWithdraw(amount);
            Console.WriteLine("You have withdrawn: " + amount);
            Console.ReadLine();
        }

        public override void MakeDeposit(double amount)
        {
            base.MakeDeposit(amount);
        }

        public override string ToString()
        {
            serviceCharge += 5 +(0.10 * withdrawalCount);
            return base.ToString();
        }
    }
}
