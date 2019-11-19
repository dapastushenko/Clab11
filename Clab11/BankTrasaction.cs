using System;

namespace Banking
{
    public class BankTransaction
    {
        private readonly decimal amount;
        private readonly DateTime when;

        public decimal Amount => amount;
        public DateTime When => when;

        public BankTransaction(decimal tranAmount)
        {
            amount = tranAmount;
            when = DateTime.Now;
        }
    }
}