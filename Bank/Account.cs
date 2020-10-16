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
        public double StartingBalance { get; set; } //Balance section
        public double CurrentBalance { get; set; }


        protected int depositCount;       // Deposit section
        protected double totalDepositAmount;

        protected int withdrawalCount;    // Withdrawal section
        protected double totalWithdrawalAmount;

        protected double annualInterestRate;
        protected double monthlyInterestRate;
        protected double monthlyInterest;
        protected double serviceCharge = 5.00;

        public enum Status
        {
            active = 1,
            inactive = 0
        }

        public Account()
        {
        }

        public Account(double balance, double annualInterestRate)
        {
            this.StartingBalance = balnce;
            this.CurrentBalance = balance;
            this.annualInterestRate = annualInterestRate;
        }

        public virtual void MakeDeposit(double amount)
        {
            totalDepositAmount += amount;
            CurrentBalance += totalDepositAmount;
            depositCount++;
        }

        public virtual void MakeWithdraw(double amount)
        {
            totalWithdrawalAmount -= amount;
            CurrentBalance += totalWithdrawalAmount;
            withdrawalCount++;
        }

        public void CalculateInterest()
        {
            monthlyInterestRate = (annualInterestRate / 12);
            monthlyInterest = CurrentBalance * monthlyInterestRate;
            CurrentBalance += monthlyInterest;
        }

        public virtual string CloseAndReport()
        {
            CurrentBalance -= serviceCharge;
            CalculateInterest();

            StringBuilder accountInfo = new StringBuilder();

            accountInfo.AppendLine("Previous Balance: " + StartingBalance + "$");
            accountInfo.AppendLine("New Balance: " + CurrentBalance + "$");

            double percentChange = (StartingBalance / CurrentBalance) * 100;
            accountInfo.AppendLine("Percent change: " + percentChange + "%");

            accountInfo.AppendLine("Monthly interest rate: " + monthlyInterestRate + "%");
            accountInfo.AppendLine("Monthly interest: " + monthlyInterest + "$");
            accountInfo.AppendLine("Current balance: " + CurrentBalance + "$");

            withdrawalCount = 0;
            depositCount = 0;
            serviceCharge = 0;

            return accountInfo.ToString();
        }

    }

}
