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
        protected double serviceCharge;

        public enum Status
        {
            active = 1,
            inactive = 0
        }


        public Account(double balance, double annualInterestRate)
        {
            this.StartingBalance = balance;
            this.CurrentBalance = balance;
            this.annualInterestRate = annualInterestRate;
        }

        public virtual void MakeDeposit(double amount)
        {
            totalDepositAmount += amount;
            CurrentBalance += amount;
            depositCount++;
        }

        public virtual void MakeWithdraw(double amount)
        {
            totalWithdrawalAmount -= amount;
            CurrentBalance -= amount;
            withdrawalCount++;
        }

        public void CalculateInterest()
        {
            monthlyInterestRate = (annualInterestRate / 12);
            monthlyInterest = CurrentBalance * monthlyInterestRate;
            CurrentBalance += monthlyInterest;
        }
        public double GetPercentageChange() {
            double percentChangeTotal = (StartingBalance / CurrentBalance);
            return percentChangeTotal;
        }

        public virtual string CloseAndReport()
        {
            CurrentBalance -= serviceCharge;
            CalculateInterest();

            StringBuilder accountInfo = new StringBuilder();
            

            accountInfo.AppendLine("Previous Balance: " + ToNamFormat.ToNAMoneyFormat(true, StartingBalance) + "$");
            accountInfo.AppendLine("New Balance: " + ToNamFormat.ToNAMoneyFormat(true, CurrentBalance) + "$");

            
            accountInfo.AppendLine("Percent change: " + ToNamFormat.ToNAMoneyFormat(true, GetPercentageChange()) + "%");

            accountInfo.AppendLine("Monthly interest rate: " + ToNamFormat.ToNAMoneyFormat(true, monthlyInterestRate) + "%");
            accountInfo.AppendLine("Monthly interest: " + ToNamFormat.ToNAMoneyFormat(true, monthlyInterest) + "$");
            accountInfo.AppendLine("Service charge: " + ToNamFormat.ToNAMoneyFormat(true, serviceCharge)); 
            accountInfo.AppendLine("Current balance: " + ToNamFormat.ToNAMoneyFormat(true, CurrentBalance) + "$");

            withdrawalCount = 0;
            depositCount = 0;
            serviceCharge = 0;

            return accountInfo.ToString();
        }
        

    }

}
