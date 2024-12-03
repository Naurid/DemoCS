namespace Bank;

public abstract class Account : ICustomer, IBanker
{
    public string Number { get; set; }
    public Person Owner { get; set; }
    public double Balance { get; private set; }
    
    protected abstract double CalculateInterest();


    public double ApplyInterest() => Balance += CalculateInterest();

    public virtual void WithDraw(double amount)
    {
        Balance -= amount;
    }

    public virtual void Deposit(double amount)
    {
        if (amount < 0) return;
        Balance += amount;
    }

    public static double operator +(Account left, Account right)
    {
        return Math.Max(left.Balance, 0) + Math.Max(right.Balance, 0);
    }

    public static double operator +(double left, Account right)
    {
        return Math.Max(left, 0) + Math.Max(right.Balance, 0);
    }
}