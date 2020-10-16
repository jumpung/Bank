using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the bank, please pick one of the following options\n");

            MainMenu();

        }

        public static void MainMenu()
        {

            bool exit;

            exit = false;
            try
            {
                do
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("A: Savings");
                    Console.WriteLine("B: Checkings");
                    Console.WriteLine("C: Global Savings");
                    Console.WriteLine("Q: Exit");

                    switch (Console.ReadLine().ToUpper())
                    {
                        case "A":
                            SavingsMenu();
                            break;
                        case "B":
                            CheckingMenu();
                            break;
                        case "C":
                            GlobalMenu();
                            break;
                        case "Q":
                            Console.WriteLine("Thank you for using our bank, the program will now close");
                            Console.ReadLine();
                            System.Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("Please select a valid option: \n");
                            MainMenu();
                            break;

                    }
                    Console.ReadLine();
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

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Savings Menu");

            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("Q: Return to bank menu");

            bool exit = false;

            try
            {
                do
                {
                    string input = Console.ReadLine();

                   
                    switch (input.ToUpper())
                    {
                        case "A":
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("How much do you want to deposit?");
                            string a = Console.ReadLine();

                            double depositamount = double.Parse(a);
                            saving.MakeDeposit(depositamount);

                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            SavingsMenu();
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
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            SavingsMenu();
                            break;

                        case "Q":
                            MainMenu();
                            exit = true;
                            break;

                        default:

                            break;
                    }
                } while (exit == false);

            }catch(Exception)
            {
                Console.WriteLine("error");
            }


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

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Global Savings Account Menu\n");

            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("D: Report balance in USD");
            Console.WriteLine("R: Return to bank menu");


            bool exit = false;

            try
            {
                
                do
                {
                    string input = Console.ReadLine();

                    switch (input.ToUpper())
                    {
                        case "A":
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("How much do you want to deposit?");
                            string a = Console.ReadLine();
                            double depositamount = double.Parse(a);
                            global.MakeDeposit(depositamount);
                            GlobalMenu();
                            break;

                        case "B":
                            Console.WriteLine("--------------------------------------------");
                            string b = Console.ReadLine();
                            double withdrawalamount = double.Parse(b);
                            global.MakeWithdraw(withdrawalamount);
                            break;

                        case "C":
                            Console.WriteLine("--------------------------------------------");
                            Console.Write(global.CloseAndReport());
                            Console.ReadLine();
                            break;

                        case "D":
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Balance in USD " + global.USValue(0.76) + "$");
                            GlobalMenu();
                            break;

                        case "R":
                            MainMenu();
                            break;

                        default:
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Please select a valid option: ");
                            GlobalMenu();
                            break;
                    }
                } while (exit == false);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }


        }
    }
}
