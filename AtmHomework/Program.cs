namespace AtmHomework
{
    internal class Program
    {
        static void Main()
        {
            Bank bank = new Bank();
            ATM atm1 = new ATM(bank);
            ATM atm2 = new ATM(bank);

            new Thread(() => atm1.WithdrawMoney(7000)).Start();
            new Thread(() => atm2.WithdrawMoney(2000)).Start();
        }
    }
    class Bank
    {
        private int accountBalance = 20000;
        public void WithdrawMoney(int amount)
        {
            if (amount > accountBalance)
            {
                Console.WriteLine("No money on your account");
            }
            else
            {
                Thread.Sleep(1000);
                accountBalance -= amount;
                Console.WriteLine($"Taken - {amount}. Balance - {accountBalance}");
            }
        }
    }
    class ATM
    {
        private Bank bank;

        public ATM(Bank bank)
        {
            this.bank = bank;
        }
        public void WithdrawMoney(int amount)
        {
            bank.WithdrawMoney(amount);
        }
    }
}
