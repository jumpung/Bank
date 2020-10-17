using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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
            ShowMainMenu();

            bool exit = false;

            try
            {
                do
                {


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
            SavingsAccount saving = new SavingsAccount(10.00, 0.03);

            ShowSavingsAccountMenu();

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

                            string a;
                            double depositAmount;

                            a = Console.ReadLine();

                            while (!double.TryParse(a, out depositAmount))
                            {
                                Console.WriteLine("Please enter a number");
                                a = Console.ReadLine();
                            }
                            

                            depositAmount = double.Parse(a);
                            saving.MakeDeposit(depositAmount);


                            ShowSavingsAccountMenu();
                            break;

                        case "B":
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("How much do you want to withdraw?");

                            string b;
                            double withdrawAmount;

                            b = Console.ReadLine();

                            while (!double.TryParse(b, out withdrawAmount))
                            {
                                Console.WriteLine("Please enter a number");
                                b = Console.ReadLine();
                            }

                            withdrawAmount = double.Parse(b);
                            saving.MakeWithdraw(withdrawAmount);

                            ShowSavingsAccountMenu();
                            break;

                        case "C":
                            Console.WriteLine("--------------------------------------------");
                            Console.Write(saving.CloseAndReport());
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            ShowSavingsAccountMenu();
                            break;

                        case "Q":
                            MainMenu();
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Please select a valid option: ");
                            ShowSavingsAccountMenu();
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
            ChequingAccount chequing = new ChequingAccount(10.00, 0.03);

            ShowChequingsAccountMenu();

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

                            string a;
                            double depositAmount;

                            a = Console.ReadLine();

                            while (!double.TryParse(a, out depositAmount))
                            {
                                Console.WriteLine("Please enter a number");
                                a = Console.ReadLine();
                            }

                            chequing.MakeDeposit(depositAmount);
                            
                            ShowChequingsAccountMenu();
                            break;

                        case "B":

                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("How much do you want to withdraw?");

                            string b = Console.ReadLine();
                            double withdrawAmount;


                            while (!double.TryParse(b, out withdrawAmount))
                            {
                                Console.WriteLine("Please enter a number");
                                b = Console.ReadLine();
                            }

                            withdrawAmount = double.Parse(b);
                            chequing.MakeWithdraw(withdrawAmount);

                            ShowChequingsAccountMenu();
                            break;

                        case "C":
                            Console.WriteLine("--------------------------------------------");
                            Console.Write(chequing.CloseAndReport());
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            ShowChequingsAccountMenu();
                            break;

                        case "Q":
                            MainMenu();
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Please select a valid option: ");
                            ShowChequingsAccountMenu();
                            break;
                    }
                    

                } while (exit == false);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }

            
        }
        public static void GlobalMenu()
        {
            GlobalSavingsAccount global = new GlobalSavingsAccount(5.00, 0.03);

            ShowGlobalSavingsAccountMenu();

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

                            string a;
                            double depositAmount;

                            a = Console.ReadLine();

                            while (!double.TryParse(a, out depositAmount))
                            {
                                Console.WriteLine("Please enter a number");
                                a = Console.ReadLine();
                            }

                            double depositamount = double.Parse(a);
                            global.MakeDeposit(depositamount);
                            ShowGlobalSavingsAccountMenu();
                            break;

                        case "B":
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("How much do you want to withdraw?");

                            string b = Console.ReadLine();
                            double withdrawAmount;


                            while (!double.TryParse(b, out withdrawAmount))
                            {
                                Console.WriteLine("Please enter a number");
                                b = Console.ReadLine();
                            }

                            double withdrawalamount = double.Parse(b);
                            global.MakeWithdraw(withdrawalamount);

                            ShowGlobalSavingsAccountMenu();
                            break;

                        case "C":
                            Console.WriteLine("--------------------------------------------");
                            Console.Write(global.CloseAndReport());
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();

                            ShowGlobalSavingsAccountMenu();
                            break;

                        case "D":
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Balance in USD " + ToNamFormat.ToNAMoneyFormat(true, global.USValue(0.76)) + "$");
                            ShowGlobalSavingsAccountMenu();
                            break;

                        case "R":
                            MainMenu();
                            break;

                        default:
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Please select a valid option: ");
                            ShowGlobalSavingsAccountMenu();
                            break;
                    }
                   
                } while (exit == false);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }


        public static void ShowMainMenu()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine("A: Savings");
            Console.WriteLine("B: Checkings");
            Console.WriteLine("C: Global Savings");
            Console.WriteLine("Q: Exit");
        }
        public static void ShowSavingsAccountMenu()
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Savings Menu");

            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("Q: Return to bank menu");
        }

        public static void ShowChequingsAccountMenu()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Chequings Account Menu\n");

            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("Q: Return to bank menu");
        }

        public static void ShowGlobalSavingsAccountMenu()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Global Savings Account Menu\n");

            Console.WriteLine("A: Deposit");
            Console.WriteLine("B: Withdrawal");
            Console.WriteLine("C: Close & Report");
            Console.WriteLine("D: Report balance in USD");
            Console.WriteLine("R: Return to bank menu");
        }
    }
}
