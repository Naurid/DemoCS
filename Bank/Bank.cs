namespace Bank;

public class Bank(string name, AccountList accountList)
{
    public string Name { get; private set; } = name;
    
    public AccountList Accounts { get; private set; } 
    

    public void RegisterAccount(Person owner, double starterBalance = 0, double creditLine = 0)
    {
        Guid newID = new Guid();
        Account account = new Account(newID.ToString(), creditLine, owner, starterBalance);
        
    }

    public void DeRegisterAccount(Account account)
    {
        
    }

    public void DisplayBalance(Person owner)
    {
        // Account accountToDisplay = Accounts[Accounts._accounts.First(x => x.Value.Owner == owner).Value.Number];
        //Utils.WriteInColor($"{accountToDisplay.Number}: {accountToDisplay.Balance}", ConsoleColor.Yellow);
    }
}