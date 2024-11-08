#region Division

void Division()
{
    Console.WriteLine("Entrez un premier nombre entier");
    int numberToDivide = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Entrez un deuxieme nombre entier");
    int divider = int.Parse(Console.ReadLine());
    
    Console.WriteLine(numberToDivide/divider);
    Console.WriteLine(numberToDivide%divider);
    Console.WriteLine((float)numberToDivide/divider);
}

Division();
#endregion

#region Verification Compte Bancaire

bool IsAccountValid(string bbaNumber)
{
    bbaNumber.Trim().Replace(" ", "").Replace("-", "");

    if (bbaNumber.Length != 12) return false;
    return true;
}

bool VerificationCompteBancaire(string BBANumber)
{
    if (!IsAccountValid(BBANumber)) return false;

    string first10Digits = BBANumber.Substring(0, 10);
    string last2Digits = BBANumber.Substring(10, 2);
    
    int modulo = int.Parse(first10Digits)%97;
    int last2 = int.Parse(last2Digits);

    if ((modulo == 0 && last2 == 97) || modulo == last2) return true;
    
    return false;
}

Console.WriteLine(VerificationCompteBancaire("000000000097")? "OK" : "KO");
#endregion

#region Creation de Compte

string CreateAccount(string accountNumber)
{
    if (!VerificationCompteBancaire(accountNumber)) return "Invalid account";
    
    string trimmed = accountNumber.Trim().Replace("-", "");
    
    string last2Digits = trimmed.Substring(10, 2);

    string dummy = $"{last2Digits}{last2Digits}111400";

    long result = 98 - (long.Parse(dummy) % 97);
    
    string bg = trimmed.Insert(4, " ").Insert(9, " ");
    
    string finalIban = $"BE{result} {bg}";
    
    return finalIban;
}

Console.WriteLine(CreateAccount("000000014245"));
#endregion