namespace Bank;

public class Savings : Account
{
    public DateTime LastTimeWithDrawn {get; private set;}

    protected override double CalculateInterest()
    {
        return Balance * 0.045;
    }

    public override void WithDraw(double amount)
    {
        if (amount < 0 || Balance - amount < 0) return;
        base.WithDraw(amount);
        LastTimeWithDrawn = DateTime.Now;
    }
}