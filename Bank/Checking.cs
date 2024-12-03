namespace Bank
{
    public class Checking : Account
    {
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

        protected override double CalculateInterest()
        {
            return Balance * (Balance > 0 ? 0.03 : 0.0975);
        }

        public override void WithDraw(double amount)
        {
            if (amount < 0 || Balance - amount < - CreditLine) return;
            base.WithDraw(amount);

        }
    }
    
}

