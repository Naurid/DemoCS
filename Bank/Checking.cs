namespace Bank
{
    public class Checking
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
        
        public Checking(string number, double creditLine, Person owner, double balance = 0)
        {
            this.Number = number;
            this.CreditLine = creditLine;
            this.Owner = owner;
            this.Balance = balance;
        }

        public void WithDraw(double amount)
        {
            if ((this.Balance + CreditLine) - amount < 0) return;

            this.Balance -= amount;
        }

        public void Deposit(double amount)
        {
            this.Balance += amount;
        }

        public static double operator +(Checking left, Checking right)
        {
              return Math.Max(left.Balance, 0) + Math.Max(right.Balance, 0);
        }

        public static double operator +(double left, Checking right)
        {
             return Math.Max(left, 0) + Math.Max(right.Balance, 0);
        }
    }
    
}

