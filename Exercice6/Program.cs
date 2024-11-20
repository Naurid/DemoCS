namespace Exercice6;

class Program
{
    static void Main(string[] args)
    {
        int height = 6;
        int width = 7;
        Case[,] puissance4 = new Case[height, width];
        
        bool isPlayerTurn = false;
        bool doWin = false;

        do
        {
            Console.Clear();
            isPlayerTurn = !isPlayerTurn;
            Console.WriteLine($"Player {(isPlayerTurn ? "1" : "2")}'s turn:");
            
            for (int i = 0; i < width; i++)
            {
                Console.Write($"[{i}]");
            }

            Console.WriteLine();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    puissance4[i, j].Content =  string.IsNullOrEmpty(puissance4[i, j].Content) ? " " : puissance4[i, j].Content;
                    Console.Write($"[{puissance4[i, j].Content}]");
                }

                Console.WriteLine();
            }

            int columnNumber;
            do
            {
                Console.Write("Enter the column number: ");
            } while (!int.TryParse(Console.ReadLine(), out columnNumber) || columnNumber < 0 ||
                     columnNumber > width - 1);

            for (int i = height - 1; i > 0; i--)
            {
                Case currentCase = puissance4[i, columnNumber];
                if (currentCase.Content == " ")
                {
                    puissance4[i, columnNumber].Content = isPlayerTurn ? "X" : "O";
                    break;
                }
            }

            for (int i = height - 1; i > 0; i--)
            {
                for (int j = 0; j < width; j++)
                {
                    if (puissance4[i, j].Content != " ")
                    {
                        if (j > 3 && i > 3 && CheckLeftDiagonal(puissance4, i, j))
                        {
                            doWin = true;
                        }
                        else if ( j < width - 3 && i > 3  && CheckRightDiagonal(puissance4, i, j))
                        {
                            doWin = true;
                        }
                        else if (i > 3 && CheckColumn(puissance4, i, j))
                        {
                            doWin = true;
                        }
                        else if (j < width - 3 && CheckRow(puissance4, i, j))
                        {
                            doWin = true;
                        }
                    }
                    
                }
            }
        } while (!doWin);
        
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"Joueur {(isPlayerTurn ? "1" : "2")} a gagné");
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write($"[{puissance4[i, j].Content}]");
            }

            Console.WriteLine();
        }
    }

    private static bool CheckLeftDiagonal(Case[,] puissance4, int column, int row)
    {
        string currentPawn = puissance4[column, row].Content;
        for (int i = 1; i < 4; i++) if (puissance4[column - i, row - i].Content != currentPawn) return false;
        return true;
    }

    private static bool CheckRightDiagonal(Case[,] puissance4, int column, int row)
    {
        string currentPawn = puissance4[column, row].Content;
        for (int i = 1; i < 4; i++) if (puissance4[column - i, row + i].Content != currentPawn) return false;
        return true;
    }

    private static bool CheckColumn(Case[,] puissance4, int column, int row)
    {
        string currentPawn = puissance4[column, row].Content;
        for (int i = 1; i < 4; i++) if (puissance4[column - i, row].Content != currentPawn) return false;
        return true;
    }
    
    private static bool CheckRow(Case[,] puissance4, int column, int row)
    {
        string currentPawn = puissance4[column, row].Content;
        for (int i = 1; i < 4; i++) if (puissance4[column, row + i].Content != currentPawn) return false;
        return true;
    }
}