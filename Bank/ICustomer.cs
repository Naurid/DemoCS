namespace Bank;

public interface ICustomer
{
    public double Balance { get; }

    public void WithDraw(double amount);

    public void Deposit(double amount);

}