using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the bank, please pick one of the following options");

            MainMenu();

        }

        public static void MainMenu()
        {


            bool exit = false;
            try
            {
                do
                {
                    Console.WriteLine("A: Savings");
                    Console.WriteLine("B: Checkings");
                    Console.WriteLine("C: GlobalSavings");
                    Console.WriteLine("Q: Exit");

                    switch (Console.ReadLine().ToUpper())
                    {
                        case "A":
                            Console.WriteLine("--------------------------------------------");
                            SavingsMenu();
                            break;
                        case "B":
                            Console.WriteLine("--------------------------------------------");
                            CheckingMenu();
                            break;
                        case "C":
                            Console.WriteLine("--------------------------------------------");
                            GlobalMenu();
                            break;
                        case "Q":
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Thank you for using our bank, the program will now close");
                            Console.ReadLine();
                            exit = true;
                            break;
                    }
                }
                while (exit == false);


            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
        }

        public static void SavingsMenu()
        {
            SavingsAccount saving = new SavingsAccount(5.00, 0.03);
            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("Q: Return to bank menu");

            bool exit = false;

            do
            {
                switch (Console.ReadLine().ToUpper())
                {
                    case "A":
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("How much do you want to deposit?");
                        string a = Console.ReadLine();
                        saving.currentBalance = double.Parse(a);
                        saving.MakeDeposit(saving.currentBalance);
                        break;

                    case "B":
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("How much do you want to withdraw?");
                        string b = Console.ReadLine();
                        double withdrawalamount = double.Parse(b);
                        saving.MakeWithdraw(withdrawalamount);
                        break;

                    case "C":
                        Console.WriteLine("--------------------------------------------");
                        Console.Write(saving.CloseAndReport());
                        Console.ReadLine();
                        break;

                    case "Q":
                        Console.WriteLine("--------------------------------------------");
                        MainMenu();
                        break;

                    default:
                        Console.WriteLine("--------------------------------------------");                  
                        SavingsMenu();
                        break;
                }
            } while (exit == false);




        }
        public static void CheckingMenu()
        {
            ChequingAccount chequing = new ChequingAccount(5.00, 0.03);
            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("Q: Return to bank menu");

            switch (Console.ReadLine().ToUpper())
            {
                case "A":

                    string a = Console.ReadLine();
                    double depositamount = double.Parse(a);
                    chequing.MakeDeposit(depositamount);
                    break;

                case "B":

                    string b = Console.ReadLine();
                    double withdrawalamount = double.Parse(b);
                    chequing.MakeWithdraw(withdrawalamount);
                    break;

                case "C":
                    chequing.CloseAndReport().ToString();
                    Console.ReadLine();
                    break;

                case "Q":
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Please enter the following options A, B, C, Q");
                    break;
            }
        }
        public static void GlobalMenu()
        {
            GlobalSavingsAccount global = new GlobalSavingsAccount(5.00, 0.03);
            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("D: Report balance in USD");
            Console.WriteLine("R: Return to bank menu");

            switch (Console.ReadLine().ToUpper())
            {
                case "A":

                    string a = Console.ReadLine();
                    double depositamount = double.Parse(a);
                    global.MakeDeposit(depositamount);
                    break;

                case "B":

                    string b = Console.ReadLine();
                    double withdrawalamount = double.Parse(b);
                    global.MakeWithdraw(withdrawalamount);
                    break;

                case "C":
                    global.CloseAndReport();
                    break;

                case "D":
                    global.USValue(0.76);
                    break;

                case "R":
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Please enter the following options A, B, C, Q");
                    break;
            }
        }
    }
}
