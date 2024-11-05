#region Console

// string name = "John";
//
// Console.WriteLine($"Bonjour {name},il est {DateTime.Now.ToShortDateString()}");
//
// string response = Console.ReadLine()?? "no name input";
//
// Console.WriteLine(response);

#endregion

#region Exercices
//parse  method
while(true){
    Console.WriteLine("Write the first number:");
    string? firstNumber = Console.ReadLine();
    float number1;
    
    try
    {
        number1 = float.Parse(firstNumber);
    }
    catch (Exception e)
    {
        WriteInColor($"{firstNumber} n'est pas un nombre", ConsoleColor.Red);
        Console.ReadLine();
        Console.Clear();
        continue;
    }

    Console.WriteLine("Write the second number:");
    string? secondNumber = Console.ReadLine();
    float number2 ;
    
    try
    {
        number2 = float.Parse(secondNumber);
    }
    catch (Exception e)
    {
        WriteInColor($"{secondNumber} n'est pas un nombre", ConsoleColor.Red);
        Console.ReadLine();
        Console.Clear();
        continue;
    }


    //WriteInColor($"{number1} + {number2} = {number1 + number2}", ConsoleColor.Green);
    break;
}

//tryparse method
while(true){
    Console.WriteLine("Write the first number:");
    string? firstNumber = Console.ReadLine();
    float number1;
    bool isNumber1 = float.TryParse(firstNumber, out number1);

    if (!isNumber1)
    {
        WriteInColor($"{firstNumber} n'est pas un nombre", ConsoleColor.Red);
        Console.ReadLine();
        Console.Clear();
        continue;
    }


    Console.WriteLine("Write the second number:");
    string? secondNumber = Console.ReadLine();
    float number2;
    bool isNumber2 = float.TryParse(secondNumber, out number2);

    if (!isNumber2)
    {
        WriteInColor($"{secondNumber} n'est pas un nombre", ConsoleColor.Red);
        Console.ReadLine();
        Console.Clear();
        continue;
    }

    if (isNumber1 && isNumber2) WriteInColor($"{number1} + {number2} = {number1 + number2}", ConsoleColor.Green);
    break;
}

void WriteInColor(string input, ConsoleColor color, bool jumpLine = true)
{
    Console.ForegroundColor = color;
    if (jumpLine) Console.WriteLine(input);
    else Console.Write(input);
    Console.ResetColor();
}

#endregion