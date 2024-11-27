namespace Bank
{
    public class Checking : Account
    {
        private readonly double _creditLine;

        public Checking(string number, double creditLine, Person owner, double balance = 0) : base(number, owner, balance)
        {
            CreditLine = creditLine;
        }

        public double CreditLine
        {
            get => _creditLine;
            private init
            {
                if (value >= 0) _creditLine = value;
                else _creditLine = 0;
            }
        }

        protected override void WithDraw(double amount)
        {
            if ((Balance + CreditLine) - amount < 0) return;
            base.WithDraw(amount);

        }
    }
    
}

