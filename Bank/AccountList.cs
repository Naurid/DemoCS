namespace Bank;

public class AccountList
{
    private List<Account> _accounts;
    
    public Account this[string accountNumber]
    {
        get
        {
            foreach (var account in _accounts)
            {
                if (account.Number == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }
        set
        {
        }
    }
}