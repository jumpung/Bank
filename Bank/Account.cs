using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{


    abstract class Account : IAccount   
    {

        private double Balance = 0;
        private double Interest;
        private double ServiceCharge;
        private double AnnualInterestRate = 0.10;
        private double MonthlyInterestRate;
        private double MonthlyInterest;
        private int NumberOfDeposits;
        private int NumberOfWithdrawls;
        double OriginalBalance;
        double ServiceCharges;
        public enum CurrentAccountStatus { Active, Inactive };
        private double MonthlyCharge = 10.00;
        //private double Deposit;
        //private double Withdrawls;
        

        public Account(double Balance, double AnnualInterestRate)
        {
            this.Balance = Balance;
            this.AnnualInterestRate = AnnualInterestRate;
        }
        public void CalculateInterest()
        {
            MonthlyInterestRate = AnnualInterestRate/12;
            MonthlyInterest = Balance * MonthlyInterestRate;
            Balance = Balance + MonthlyInterest;
        }

        public string CloseAndReport()
        {
            double OriginalBalance = Balance;
            Console.WriteLine(OriginalBalance);//original Balance

            double NewBalance;
            NewBalance = OriginalBalance - MonthlyCharge;
            CalculateInterest();
            Console.WriteLine("This is the new balance",(NewBalance));//new Balance
            
            Console.WriteLine("This is the percentage change",(NewBalance/OriginalBalance)*100);
            NumberOfWithdrawls = 0;
            NumberOfDeposits = 0;
            MonthlyCharge = 0;
        }

        public void MakeDeposit(double amount)
        {
            Balance = amount + Balance;
            NumberOfDeposits++;
        }

        public void MakeWithdrawl(double amount)
        {
            Balance = amount - Balance;
            NumberOfWithdrawls++;
        }
    }
}
