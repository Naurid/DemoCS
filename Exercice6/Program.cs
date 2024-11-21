namespace Exercice6;

class Program
{
    static void Main(string[] args)
    {
        Case[,] puissance4;
        Puissance4(6, 7);

        void Puissance4(int width, int height)
        {
            puissance4 = new Case[height, width];

            bool isPlayerTurn = false;
            bool doWin = false;

            do
            {
                isPlayerTurn = !isPlayerTurn;
                
                for (int i = 0; i < width; i++)
                {
                    Console.Write($"[{i}]");
                }
                
                DrawBoard(height, width, false, isPlayerTurn);
                
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

                doWin = CheckWinCon(height, width);
            } while (!doWin);
            
            DrawBoard(height, width, true, isPlayerTurn);
        }

        bool CheckWinCon(int height, int width)
        {
            for (int i = height - 1; i > 0; i--)
            {
                for (int j = 0; j < width; j++)
                {
                    if (puissance4[i, j].Content != " ")
                    {
                        if (j > 3 && i > 3 && CheckLeftDiagonal(i, j)) return true;
                        if (j < width - 3 && i > 3 && CheckRightDiagonal(i, j))return true;
                        if (i > 3 && CheckColumn(i, j))return true;
                        if (j < width - 3 && CheckRow(i, j))return true;
                    }
                }
            }
            return false;
        }

        bool CheckLeftDiagonal(int column, int row)
        {
            string currentPawn = puissance4[column, row].Content;
            for (int i = 1; i < 4; i++) if (puissance4[column - i, row - i].Content != currentPawn) return false;
            return true;
        }

        bool CheckRightDiagonal(int column, int row)
        {
            string currentPawn = puissance4[column, row].Content;
            for (int i = 1; i < 4; i++) if (puissance4[column - i, row + i].Content != currentPawn) return false;
            return true;
        }

        bool CheckColumn(int column, int row)
        {
            string currentPawn = puissance4[column, row].Content;
            for (int i = 1; i < 4; i++) if (puissance4[column - i, row].Content != currentPawn) return false;
            return true;
        }

        bool CheckRow( int column, int row)
        {
            string currentPawn = puissance4[column, row].Content;
            for (int i = 1; i < 4; i++) if (puissance4[column, row + i].Content != currentPawn) return false;
            return true;
        }
        
        void DrawBoard(int height, int width, bool winMessage, bool isPlayerTurn)
        {
            Console.Clear();
            Console.WriteLine(winMessage ? $"Joueur {(isPlayerTurn ? "1" : "2")} a gagné": $"Player {(isPlayerTurn ? "1" : "2")}'s turn:");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    puissance4[i, j].Content = string.IsNullOrEmpty(puissance4[i, j].Content)
                        ? " "
                        : puissance4[i, j].Content;
                    Console.Write($"[{puissance4[i, j].Content}]");
                }

                Console.WriteLine();
            }
        }
    }

   
}