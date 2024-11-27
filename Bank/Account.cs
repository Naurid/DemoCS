namespace Bank;

public abstract class Account
{
    public string Number { get; protected set; }
    public double Balance { get; private set; }
    public Person Owner { get; protected set; }

    public Account(string number, Person owner, double balance = 0)
    {
        Number = number;
        Owner = owner;
        Balance = balance;
    }
    
    protected abstract double CalculateInterest();

    public double ApplyInterest() => Balance + CalculateInterest();

    protected virtual void WithDraw(double amount)
    {
        Balance -= amount;
    }

    protected virtual void Deposit(double amount)
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