using System;
using Banking;

namespace Clab11
{
    internal class CreateAccount
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sid's Account");
            BankAccount sidsAccount = Bank.GetAccaunt(Bank.CreateAccount());
            TestDeposit(sidsAccount);
            TestWithdraw(sidsAccount);
            Write(sidsAccount);
            //sidsAccount.Dispose();
            if (Bank.CloseAccount(sidsAccount.Number()))
            {
                Console.WriteLine("Account closed");
            }
            else
            {
                Console.WriteLine("Something went wrong closing the account");
            }

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        static void Write(BankAccount account)
        {
            Console.WriteLine("Account number is {0}", account.Number());
            Console.WriteLine("Account balance is {0}", account.Balance());
            Console.WriteLine("Account type is {0}", account.Type());
            foreach (BankTransaction transaction in account.Transactions())
            {
                Console.WriteLine("Date|Time:" + transaction.When + " Amount:" + transaction.Amount);
                Console.WriteLine();
            }
        }

        public static void TestDeposit(BankAccount bankAccount)
        {
            Console.Write("Enter amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            bankAccount.Deposit(amount);
        }

        public static void TestWithdraw(BankAccount bankAccount)
        {
            Console.Write("Enter amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            if (!(bankAccount.Withdraw(amount)))
            {
                Console.WriteLine("Insufficient founds.");
            }
        }
    }
}