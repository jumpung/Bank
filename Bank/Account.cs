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
        public double startingBalance { get; set; } //Balance section
        public double currentBalance { get; set; }


        protected int depositCount;       // Deposit section
        protected double totalDepositAmount;

        protected int withdrawalCount;    // Withdrawal section
        protected double totalWithdrawalAmount;

        protected double annualInterestRate;
        protected double monthlyInterestRate;
        protected double monthlyInterest;
        protected double serviceCharge;

        public enum Status
        {
            active = 1,
            inactive = 0
        }

        public Account()
        {

        }

        public Account(double startingBalance, double currentBalance, double annualInterestRate)
        {
            this.startingBalance = startingBalance;
            this.currentBalance = currentBalance;
            this.annualInterestRate = annualInterestRate;
        }

        public virtual void MakeDeposit(double amount)
        {
            currentBalance += amount;
            totalDepositAmount += amount;
            depositCount++;
        }

        public virtual void MakeWithdraw(double amount)
        {
            currentBalance -= amount;
            totalWithdrawalAmount -= amount;
            withdrawalCount++;
        }

        public void CalculateInterest()
        {
            monthlyInterestRate = (annualInterestRate / 12);
            monthlyInterest = currentBalance * monthlyInterestRate;
            currentBalance = currentBalance + monthlyInterest;
        }

        public virtual string CloseAndReport()
        {
            currentBalance -= serviceCharge;
            CalculateInterest();

            withdrawalCount = 0;
            depositCount = 0;
            serviceCharge = 0;

            StringBuilder accountInfo = new StringBuilder();

            accountInfo.Append("Previous balance: " + startingBalance + "$");
            accountInfo.AppendLine("New Balance: " + currentBalance + "$");

            double percentChange = (startingBalance / currentBalance) * 100;
            accountInfo.AppendLine("Percent change: " + percentChange + "%");

            accountInfo.AppendLine("Monthly interest rate: " + monthlyInterestRate + "%");
            accountInfo.AppendLine("Monthly interest: " + monthlyInterest + "$");
            accountInfo.AppendLine("Current balance: " + currentBalance + "$");


            return accountInfo.ToString();
        }




    }

}
