#region Fibonacci

//0, 1, 1, 2, 3, 5, 8, 13 et 21.
void Fibonacci()
{
    int iterationNumber = GetIntInput("Entrez le nombre d'itérations que vous voulez pour la suite de Fibonacci");;

    var firstValue = 1;
    var secondValue = 0;
    Console.WriteLine($"{secondValue}");
    Console.WriteLine($"{firstValue}");

    for (var i = 0; i < iterationNumber; i++)
    {
        var value = firstValue + secondValue;
        Console.WriteLine($"{value}");

        secondValue = firstValue;
        firstValue = value;
    }
}

#endregion
//Fibonacci();
#region Jeu du nombre mystere

void MysteryNumberGame()
{
    var doContinue = true;

    do
    {
        var isGameDone = false;

        while (!isGameDone)
        {
            Console.WriteLine("Veuillez choisir un niveau de difficulté entre 1 (facile), 2 (moyen) ou 3 (difficile):");
            Console.WriteLine("Entrez 4 pour Quitter");

            if (!int.TryParse(Console.ReadLine(), out var level))
            {
                WriteInColor("veuillez entrer un nombre", ConsoleColor.Red);
            }
            else
            {
                switch (level)
                {
                    case 1:
                        WriteInColor("Bienvenue dans le mode facile", ConsoleColor.Green);
                        StartGame(50);
                        break;
                    case 2:
                        WriteInColor("Bienvenue dans le mode normal", ConsoleColor.Yellow);
                        StartGame(100);
                        break;
                    case 3:
                        WriteInColor("Bienvenue dans le mode difficile", ConsoleColor.Red);
                        StartGame(200);
                        break;
                    case 4:
                        doContinue = false;
                        break;
                    default:
                        WriteInColor("le nombre entré n'est aucun des bons nombres", ConsoleColor.Red);
                        continue;
                }

                isGameDone = true;
            }

            if (!doContinue) WriteInColor("Au revoir", ConsoleColor.Yellow);
        }
    } while (doContinue);

    void StartGame(int upperLimit)
    {
        var random = new Random();
        var numberToFind = random.Next(0, upperLimit + 1);

        var isGameWon = false;

        while (!isGameWon)
        {
            Console.WriteLine($"Devine le nombre entre 0 et {upperLimit}");
            int guessedNumber;
            bool isInCorrectRange = int.TryParse(Console.ReadLine(), out guessedNumber) &&
                                    guessedNumber >= 0 &&
                                    guessedNumber <= upperLimit;

            if (isInCorrectRange && guessedNumber != numberToFind)
            {
                WriteInColor("C'est pas le bon :(", ConsoleColor.Red);
                GuidePlayer(guessedNumber, numberToFind);
            }
            else if (isInCorrectRange && guessedNumber == numberToFind)
            {
                WriteInColor("Woohoo!!! Tu as gagné Rien!", ConsoleColor.Green);
                isGameWon = true;
            }
        }

        var answer = "Y";
        do
        {
            Console.WriteLine("Continue ? y/n");
            answer = Console.ReadLine()?.ToUpper();
        } while (answer != "Y" && answer != "N");

        doContinue = answer.ToUpper() == "Y";
    }

    void GuidePlayer(int guessedNumber, int numberToFind)
    {
        if (guessedNumber < numberToFind)
            WriteInColor("Plus grand!", ConsoleColor.Red);
        else if (guessedNumber > numberToFind) WriteInColor("Plus petit!", ConsoleColor.Red);
    }


    void WriteInColor(string input, ConsoleColor color, bool jumpLine = true)
    {
        Console.ForegroundColor = color;
        if (jumpLine) Console.WriteLine(input);
        else Console.Write(input);
        Console.ResetColor();
    }
}

#endregion
//MysteryNumberGame();
#region Conversion de Température

void ConvertTemperature(){
    
    string[] choices =
    [
        "Celsius en Fahrenheit",
        "Celsius en Kelvin",
        "Fahrenheit en Celsius",
        "Fahrenheit en Kelvin",
        "Kelvin en Fahrenheit",
        "Kelvin en Celsius"
    ];
    
    var doContinueTemp = true;

    do
    {
        int userChoice;

        do
        {
            Console.Clear();
            Console.WriteLine("Sélectionnez ce que vous voulez faire: ");
            for (var index = 0; index < choices.Length; index++)
            {
                var choice = choices[index];
                Console.WriteLine($"{index + 1}. {choice}");
            }
        } while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > choices.Length - 1);

        var value = GetIntInput($"Veuillez entrer la valeur que vous voulez convertir de {choices[userChoice]}");

        switch (userChoice)
        {
            case 1:
                Console.WriteLine(value * 9f / 5 + 32);
                break;
            case 2:
                Console.WriteLine(value + 273.15f);
                break;
            case 3:
                Console.WriteLine((value - 32) * (5f / 9));
                break;
            case 4:
                Console.WriteLine((value - 32) * 5f / 9 + 273.15f);
                break;
            case 5:
                Console.WriteLine((value - 273.15) * 9f / 5 + 32);
                break;
            case 6:
                Console.WriteLine(value - 273.15);
                break;
            default:
                continue;
        }

        var answer = "Y";
        do
        {
            Console.WriteLine("Continue ? y/n");
            answer = Console.ReadLine()?.ToUpper();
        } while (answer != "Y" && answer != "N");

        doContinueTemp = answer.ToUpper() == "Y";
    } while (doContinueTemp);
}

int GetIntInput(string outPutString, bool clear = false)
{
    int value;
    do
    {
        if (clear) Console.Clear();
        Console.WriteLine(outPutString);
    } while (!int.TryParse(Console.ReadLine(), out value));

    return value;
}

#endregion
//ConvertTemperature();