using System;
using System.Collections;
using System.IO;

namespace Banking
{
sealed public class BankAccount : IDisposable
    {
        private Queue tranQueue = new Queue(); //queue of transactions
        private static long nextAccNo = 123;
        private long accNo;
        private decimal accBal;
        private AccountType accType;
        private bool disposed; //по умолчанию false зачем в лаб. написано о присвоении?

//        public void Populate(decimal balance)
//        {
//            accNo = NextNumber();
//            accBal = balance;
//            accType = AccountType.Checking;
//        }
        internal BankAccount()
        {
            accNo = NextNumber();
            accType = AccountType.Checking;
            accBal = 0;
        }

        internal BankAccount(AccountType aType)
        {
            accNo = NextNumber();
            accType = aType;
            accBal = 0;
        }

        internal BankAccount(decimal aBal)
        {
            accNo = NextNumber();
            accType = AccountType.Checking;
            accBal = aBal;
        }

        internal BankAccount(AccountType aType, decimal aBal)
        {
            accNo = NextNumber();
            accType = aType;
            accBal = aBal;
        }

        ~BankAccount()
        {
            Dispose();
        }

        public long Number()
        {
            return accNo;
        }

        public decimal Balance()
        {
            return accBal;
        }

        //public AccountType Type()
        //{
        //    return accType;
        //}

        public string Type()
        {
            return accType.ToString();
        }

        private static long NextNumber()
        {
            return nextAccNo++;
        }

        public decimal Deposit(decimal amount)
        {
            accBal += amount;
            BankTransaction bankTransaction = new BankTransaction(amount);
            tranQueue.Enqueue(bankTransaction);
            return accBal;
        }

        public bool Withdraw(decimal amount)
        {
            if (accBal < amount)
            {
                return false;
            }
            else
            {
                accBal -= amount;
                BankTransaction bankTransaction = new BankTransaction(-amount);
                tranQueue.Enqueue(bankTransaction);
                return true;
            }
        }

        public void TransferFrom(BankAccount accFrom, decimal amount)
        {
            if (accFrom.Withdraw(amount))
                this.Deposit(amount);
        }

        public Queue Transactions()
        {
            return tranQueue;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                StreamWriter streamWriter = File.AppendText("Transactions.dat");
                streamWriter.WriteLine("Account number is:" + accNo);
                streamWriter.WriteLine("Account balance is:" + accBal);
                streamWriter.WriteLine("Account type is:" + accType);
                streamWriter.WriteLine("Transactions:");
                foreach (BankTransaction bankTransaction in tranQueue)
                {
                    streamWriter.WriteLine("Date|Time:" + bankTransaction.When + " Amount:" + bankTransaction.Amount);
                }

                streamWriter.Close();
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}