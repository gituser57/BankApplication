using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank<Account> bank = new Bank<Account>("SomeBank");
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen; 
                Console.WriteLine("1. Create account \t 2.  Withdraw (Debit)  \t 3. Deposit (Credit)");
                Console.WriteLine("4. Close account \t 5. Skip a day \t 6. Exit");
                Console.WriteLine("Choose menu item:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            OpenAccount(bank);
                            break;
                        case 2:
                            Withdraw(bank);
                            break;
                        case 3:
                            Put(bank);
                            break;
                        case 4:
                            CloseAccount(bank);
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                    bank.CalculatePercentage();
                }
                catch (ArgumentException ex1)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex1.Message );
                    Console.ForegroundColor = color;
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void OpenAccount(Bank<Account> bank)
        {
            Console.WriteLine("Input start amount:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Choose account type: 1. Ordinary 2. Deposit");
            AccountType accountType;

            int type = Convert.ToInt32(Console.ReadLine());

            if (type == 2)
                accountType = AccountType.Deposit;
            else
                accountType = AccountType.Ordinary;

            bank.Open(accountType,
                sum,
                AddSumHandler, 
                WithdrawSumHandler, 
                (o, e) => Console.WriteLine(e.Message), 
                CloseAccountHandler, 
                OpenAccountHandler); 
        }

        private static void Withdraw(Bank<Account> bank)
        {
            Console.WriteLine("Please input amount to withdraw from the account:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please input account id:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.Withdraw(sum, id);
        }

        private static void Put(Bank<Account> bank)
        {
            Console.WriteLine("Please input anount to put on the account:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please input account id:");
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Put(sum, id);
        }

        private static void CloseAccount(Bank<Account> bank)
        {
            Console.WriteLine("Please input account id for account closing:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.Close(id);
        }

        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Sum > 0)
                Console.WriteLine("Spending money");
        }
        
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
