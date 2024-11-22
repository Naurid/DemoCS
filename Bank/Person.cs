namespace Bank
{
    public class Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public DateTime DateOfBirth { get; private set; } = dateOfBirth;
    }
}
