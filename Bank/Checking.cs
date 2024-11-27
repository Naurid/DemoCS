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

        protected override double CalculateInterest()
        {
            return Balance * (Balance > 0 ? 0.03 : 0.095);
        }

        protected override void WithDraw(double amount)
        {
            if (amount < 0 || Balance - amount < - CreditLine) return;
            base.WithDraw(amount);

        }
    }
    
}

