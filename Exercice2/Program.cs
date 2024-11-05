#region Conditions

bool isGameDone = false;

while(!isGameDone)
{
    int upperLimit;
    Console.WriteLine("Veuillez choisir un niveau de difficulté entre 1 (facile), 2 (moyen) ou 3 (difficile):");

    if (!int.TryParse(Console.ReadLine(), out int level))
    {
        WriteInColor("veuillez entrer un nombre", ConsoleColor.Red);
    }
    else 
    {
        switch (level)
        {
            case 1:
                upperLimit = 50;
                WriteInColor("Bienvenue dans le mode facile", ConsoleColor.Green);
                break;
            case 2:
                upperLimit = 100;
                WriteInColor("Bienvenue dans le mode normal", ConsoleColor.Yellow);
                break;
            case 3:
                upperLimit = 200;
                WriteInColor("Bienvenue dans le mode difficile", ConsoleColor.Red);
                break;
            default:
                WriteInColor("le nombre entré n'est aucun des bons nombres", ConsoleColor.Red);
                continue;
        }

        StartGame(upperLimit);
        isGameDone = true;
    }
}

void StartGame(int upperLimit)
{
    Random random = new Random();
    int numberToFind = random.Next(0, upperLimit + 1);
    
    bool isGameWon = false;

    while (!isGameWon)
    {
        Console.WriteLine($"Devine le nombre entre 0 et {upperLimit}");
        int guessedNumber;
        bool isANumber = int.TryParse(Console.ReadLine(), out guessedNumber);

        if (!isANumber) continue;
        
        if (guessedNumber != numberToFind)
        {
            WriteInColor("C'est pas le bon :(", ConsoleColor.Red);
            GuidePlayer(guessedNumber, numberToFind);
        }
        else
        {
            WriteInColor("Woohoo!!! Tu as gagné Rien!", ConsoleColor.Green);
            isGameWon = true;
        }
    }
}

void GuidePlayer(int guessedNumber, int numberToFind)
{
    if (guessedNumber < numberToFind)
    {
        WriteInColor("Plus grand!", ConsoleColor.Red);
    }
    else if (guessedNumber > numberToFind)
    {
        WriteInColor("Plus petit!", ConsoleColor.Red);
    }
}


void WriteInColor(string input, ConsoleColor color, bool jumpLine = true)
{
    Console.ForegroundColor = color;
    if (jumpLine) Console.WriteLine(input);
    else Console.Write(input);
    Console.ResetColor();
}
#endregion