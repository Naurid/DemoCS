namespace Bank
{
    public class Account
    {
        public string Number { get; private set; }
        public double Balance { get; private set; }
        public Person Owner { get; private set; }

        private readonly double _creditLine;

        public double CreditLine
        {
            get => _creditLine;
            private init
            {
                if (value >= 0) _creditLine = value;
                else _creditLine = 0;
            }
        }
        
        public Account(string number, double creditLine, Person owner, double balance = 0)
        {
            this.Number = number;
            this.CreditLine = creditLine;
            this.Owner = owner;
            this.Balance = balance;
        }

        public void WithDraw(double amount)
        {
            if (this.Balance - amount < 0) return;

            this.Balance -= amount;
        }

        public void Deposit(double amount)
        {
            this.Balance += amount;
        }
    }
    
}

