﻿using System.Text;

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
                               $"was born on the {newPerson.DateOfBirth.Day}th of {newPerson.DateOfBirth:MMMM} in {newPerson.DateOfBirth.Year}.",
                ConsoleColor.Green);

           string accountNumber1 = bank.RegisterAccount(newPerson);
           bank.DisplayBalance(accountNumber1);
           Console.WriteLine(bank[accountNumber1].GetType());
           
           
           string accountNumber2 = bank.RegisterAccount(newPerson, false, 178);
           bank.DisplayBalance(accountNumber2);
           Console.WriteLine(bank[accountNumber2].GetType());

           Console.WriteLine(bank.GetAccounts(newPerson));

           Console.WriteLine(bank[accountNumber2].ApplyInterest());
        }
    }
}
