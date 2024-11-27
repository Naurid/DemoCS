namespace Bank;

public class Bank(string name)
{
    public string Name { get; private set; } = name;
    
    public List<Account> Accounts { get; } = new (); 
    
    public Account this[string number]
    {
        get
        {
            foreach (var compte in Accounts)
            {
                if (compte.Number == number) return compte;
            }
            return null;
        }
    }
    public string RegisterAccount(Person owner, bool isCheckingsAccount = true, double starterBalance = 0, double creditLine = 0)
    {

        string newID = GetRandomAccountNumber();
        Console.WriteLine(newID);
        Account newAccount = isCheckingsAccount
            ? new Checking(newID.ToString(), creditLine, owner, starterBalance)
            : new Savings(newID.ToString(), owner, starterBalance);
        Accounts.Add(newAccount);
        
        return newAccount.Number;
        
    }

    public void DeRegisterAccount(string  accountNumber)
    {
        var account = this[accountNumber];
        if (account != null)
        {
            Accounts.Remove(account);
            Console.WriteLine($"Le compte {accountNumber} a été supprimé de la banque.");
        }
        else
        {
            Console.WriteLine($"Aucun compte trouvé avec le numéro {accountNumber}.");
        }
    }

    public void DisplayBalance(string accountNumber)
    {
        Account checkingToDisplay = this[accountNumber];
        if (checkingToDisplay == null) return;
        Utils.WriteInColor($"{checkingToDisplay.Number}: {checkingToDisplay.Balance}", ConsoleColor.Yellow);
    }

    public double GetAccounts(Person owner)
    {
        double sumOfAll = 0;

        foreach (Account account in Accounts)
        {
            if (account.Owner == owner) sumOfAll += account;;
        }
        
        return sumOfAll;
    }

    private string GetRandomAccountNumber()
    {
        string number = "";
        
        for (int i = 1; i < 18; i++)
        {
            if (i is 3 or 8 or 13) number += " ";
            else number += Random.Shared.Next(10);
        }
        return "BE" + number;
    }
}