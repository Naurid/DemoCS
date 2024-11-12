
namespace Exercice5;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Exo1

        void GenerateIntegers(int nbrOfIteration)
        {
            int[] numbers = new int[nbrOfIteration];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (int)Math.Pow(2, i+1);
            }

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        
        
        #endregion
        //GenerateIntegers(10);
        
        #region Exo2

        void GiveAverage()
        {
            int nbrOfPlayers;
            do
            {
                Console.WriteLine($"Give a number of players:");
            } while (int.TryParse(Console.ReadLine(), out nbrOfPlayers) || nbrOfPlayers < 0 || nbrOfPlayers > 10);
            
            int[] players = new int[nbrOfPlayers];

            for (var i = 0; i < players.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Give the score of player n°{i+1}: ");
                } while (int.TryParse(Console.ReadLine(), out players[i]) || players[i] < 0);
            }

            int sum = 0;
            foreach (int player in players)
            {
                sum += player;
            }
            
            Console.WriteLine(sum/players.Length);
        }

        

        #endregion
        //GiveAverage();
        
        #region Exo3
        
        void InvertTable()
        {
            int[] normalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            foreach (int number in normalArray)
            {
                Console.Write(number); 
            }
            Console.WriteLine();
            for (int i = 0; i < normalArray.Length/2; i++)
            {
               (normalArray[i], normalArray[normalArray.Length - 1 - i]) = (normalArray[normalArray.Length - 1 - i], normalArray[i]);
            }   
            foreach (int number in normalArray)
            {
                Console.Write(number); 
            }
        }
        
        #endregion
        //InvertTable();
        
        #region Exo4

        void MovePawn()
        {
            bool keepPlaying = true;
            string pawnChar = "\u265f\ufe0f";
            string[] pawnSquares = new string[10]{"\u265f\ufe0f", "", "", "", "", "", "", "", "", ""};
            
            do
            {
                
                foreach (var pawnSquare in pawnSquares) Console.Write(pawnSquare);
                string? playerMove = "";
                do
                {
                    Console.WriteLine("Where do you want to move the pawn? (L)eft or (R)ight? or(Q)uit?");
                    playerMove = Console.ReadLine().ToUpper();
                } while (playerMove != "L" && playerMove != "R" && playerMove != "Q");
                
                int currentIndex = Array.IndexOf(pawnSquares, pawnChar);
                pawnSquares[currentIndex] = "";
                
                switch (playerMove)
                {
                    case "L":
                        pawnSquares[currentIndex == 0 ? pawnSquares.Length - 1 : currentIndex - 1] = pawnChar;
                        break;
                    case "R":
                        pawnSquares[currentIndex == pawnSquares.Length-1 ? 0 : currentIndex + 1] = pawnChar;
                        break;
                    case "Q":
                        keepPlaying=false;
                        break;
                }
                Console.WriteLine();
                foreach (var pawnSquare in pawnSquares) Console.Write($"[{pawnSquare}]");
        
            } while (keepPlaying);
        }
        #endregion
        //MovePawn();

        #region Exo5

        void RockPaperScissor()
        {
            Dictionary<string, string> RPS = new Dictionary<string, string>();
            RPS.Add("Rock", "Scissors");
            RPS.Add("Scissors", "Paper");
            RPS.Add("Paper", "Scissors");
            
            string[] choices = RPS.Keys.ToArray();
            
            bool keepPlaying = true;

            do
            {
                string? playerChoice = "";
                do
                {
                    Console.WriteLine("(R)ock, (P)aper or (S)cissors?");
                    playerChoice = Console.ReadLine().ToUpper();
                } while (playerChoice != "R" && playerChoice != "P" && playerChoice != "S");

                switch (playerChoice)
                {
                    case "R":
                        playerChoice = "Rock";
                        break;
                    case "P":
                        playerChoice = "Paper";
                        break;
                    case "S":
                        playerChoice = "Scissors";
                        break;
                }

                Random random = new Random();
                string robotChoice = choices[random.Next(choices.Length)];
                Console.WriteLine(robotChoice);

                if (RPS[playerChoice] == robotChoice)
                {
                    Console.WriteLine("You win!");
                }
                else if (playerChoice == robotChoice)
                {
                    Console.WriteLine("It's a draw!");
                }
                else if (RPS[robotChoice] == playerChoice)
                {
                    Console.WriteLine("You Lose!");
                }
                
                do
                {
                    Console.WriteLine("Continue? (Y)es or (N)o?");
                    playerChoice = Console.ReadLine().ToUpper();
                } while (playerChoice != "Y" && playerChoice != "N");
               
                keepPlaying = playerChoice == "Y";
                
            } while (keepPlaying);
        }

        #endregion
        
        //RockPaperScissor();

        #region Exo6

        int[] encryptedMessage;
        void EncryptMessage(string message, int encryptionKey)
        {
            message = message.Trim();
            char[] characters = message.ToCharArray();
            encryptedMessage = new int[characters.Length];
            
            for (int i = 0; i < characters.Length; i++)
            {
                encryptedMessage[i] = (characters[i] + encryptionKey);
            }
        }

        string DecryptMessage(int encryptionKey)
        {
            if(encryptedMessage.Length == 0) return "No message to decrypt";

            char[] decryptedMessage = new char[encryptedMessage.Length];

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                decryptedMessage[i] = (char)(encryptedMessage[i] - encryptionKey);
            }
            
            return new string(decryptedMessage);
        }

        
        #endregion
        // EncryptMessage("iello", 2);
        // Console.WriteLine(DecryptMessage(2));

        #region Exo7

        void Tournament()
        {
            string[] players = new string[8];
            List<string> winners = new List<string>();
            List<string> losers = new List<string>();
            
            for (int i = 0; i < players.Length; i++)
            {
                string? playerName = "";
                do
                {
                    Console.WriteLine($"Give the name of player n°{i + 1}");
                    playerName = Console.ReadLine().ToUpper();
                } while (playerName == "" || players.Contains(playerName));

                players[i] = playerName;
            }

            winners = players.ToList();
            foreach (var winner in winners) Console.WriteLine(winner);

            do
            {
                for (int i = 0; i < winners.Count/2 ; i++)
                {
                    int winner;
                    do
                    {
                        Console.WriteLine($"Who wins? (1) {winners[i]} or (2) {winners[winners.Count - 1 - i]}");
                    } while (!int.TryParse(Console.ReadLine(), out winner) || (winner != 1 && winner != 2));

                    Console.WriteLine(winner);

                    switch (winner)
                    {
                        case 1:
                            losers.Add(winners[winners.Count - 1 - i]);
                            break;
                        case 2:
                            losers.Add(winners[i]);
                            break;
                    }
                }

                for (int i = 0; i < losers.Count; i++)
                {
                    winners.Remove(losers[i]);
                }

                Console.WriteLine("End of round");
            } while (winners.Count > 1);
            Console.WriteLine("End of the Game, the winner is:");
            Console.WriteLine(winners[0]);
        }

        #endregion
        
        //Tournament();
    }
    
    
}