using System.Text;

namespace Bank
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Bank bank = new Bank("Rotschild", new AccountList());
            
            Person newPerson = new Person("Gabor", "Vilics", new DateTime(1997, 05, 17));
            Utils.WriteInColor($"{newPerson.FirstName} {newPerson.LastName} " +
                               $"was born on the {newPerson.DateOfBirth.Day}'s of {newPerson.DateOfBirth:MMMM} in {newPerson.DateOfBirth.Year}.",
                ConsoleColor.Green);

           bank.RegisterAccount(newPerson);
           bank.DisplayBalance(newPerson);
        }
    }
}
