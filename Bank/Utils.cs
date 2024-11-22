namespace Bank
{
    public static class Utils
    {
        public static void WriteInColor(string text, ConsoleColor color, bool jumpLine = true)
        {
            Console.ForegroundColor = color;
            if(jumpLine) Console.WriteLine(text);
            else Console.Write(text);
            Console.ResetColor();
        }

        public static int GetIntInput(string queryText)
        {
            int value;
            do
            {
                Console.WriteLine(queryText);
            } while (!int.TryParse(Console.ReadLine(), out value));

            return value;
        }
    
        public static string GetTextInput(string queryText)
        {
            string value;
            do
            {
                Console.WriteLine(queryText);
                value = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(value));

            return value;
        }
    }
}