using System.Text;

namespace Bank
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Bank bank = new Bank("Rotschild");
            
            Person newPerson = new Person("Gabor", "Vilics", new DateTime(1997, 05, 17));
            Utils.WriteInColor($"{newPerson.FirstName} {newPerson.LastName} " +
                               $"was born on the {newPerson.DateOfBirth.Day}'s of {newPerson.DateOfBirth:MMMM} in {newPerson.DateOfBirth.Year}.",
                ConsoleColor.Green);

           string accountNumber1 = bank.RegisterAccount(newPerson);
           bank.DisplayBalance(accountNumber1);
           
           
           string accountNumber2 = bank.RegisterAccount(newPerson, 178);
           bank.DisplayBalance(accountNumber2);

           Console.WriteLine(bank.GetAccounts(newPerson));
        }
    }
}
