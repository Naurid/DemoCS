namespace Bank;

public interface IBanker : ICustomer
{
    public string Number { get; }
    
    public Person Owner { get; }

    public double ApplyInterest();
}