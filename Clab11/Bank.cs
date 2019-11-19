using System.Collections;
namespace Banking
{
    public static class Bank{
    
        private static Hashtable accaunts = new Hashtable();
        public static long CreateAccount()
        {
            BankAccount bankAccount = new BankAccount();
            accaunts[bankAccount.Number()] = bankAccount;
            return bankAccount.Number();
        }

        public static bool CloseAccount(long accNumber)
        {
            BankAccount closeBankAccount = (BankAccount) accaunts[accNumber];
            if (closeBankAccount !=null)
            {
                accaunts.Remove(accNumber);
                closeBankAccount.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static BankAccount GetAccaunt(long accNumber)
        {
            return (BankAccount) accaunts[accNumber];
        }
    }
}