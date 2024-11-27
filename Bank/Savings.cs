namespace Bank;

public class Savings : Account
{
    public DateTime LastTimeWithDrawn {get; private set;}
    
    public Savings(string number, Person owner, double balance = 0) : base(number, owner, balance)
    {
        LastTimeWithDrawn = DateTime.Now;
    }

    protected override void WithDraw(double amount)
    {
        if (Balance - amount < 0) return;
        base.WithDraw(amount);
        LastTimeWithDrawn = DateTime.Now;
    }
}