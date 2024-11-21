using System.Security.Cryptography.X509Certificates;

namespace ExerciceEnum;

class Program
{
    static void Main(string[] args)
    {
       Pack deck = new Pack();
       deck.Shuffle();
       deck.Display();
    }

    public enum EColor
    {
        Coeur = 1,
        Carreau = 2,
        Pique = 3,
        Trefle = 4
    }

    public enum ECardTypes
    {
        Ace = 14,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9,
        Ten=10,
        J=11,
        Queen=12,
        King=13
    }

    public struct Card(EColor cardColor, ECardTypes cardType)
    {
        public EColor color = cardColor;
        public ECardTypes cardType = cardType;
    };
   

    private struct Pack()
    {
        private Card[] deck = new Card[52];
       
        public void Shuffle()
        {
            int i = 0;

            foreach (var color in Enum.GetNames<EColor>())
            {
                foreach (var type in Enum.GetNames<ECardTypes>())
                {
                    deck[i] = new Card(Enum.Parse<EColor>(color), Enum.Parse<ECardTypes>(type));
                    i++;
                }
            }
        }

        public void Display()
        {
            foreach (Card card in deck)
            {
                Console.WriteLine($"{card.color} - {card.cardType}");
            }
        }
        
        
    }
}