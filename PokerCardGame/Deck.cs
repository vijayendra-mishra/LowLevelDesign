namespace DeckBuilder
{
    public class Deck
    {
        public Stack<Card> cards = new();

        public Deck()
        {
            cards.Push(new Card());
            cards.Push(new Card());
        }


        public void PopulateDeck()
        {
            Console.WriteLine($"Populating Deck...{Environment.NewLine}");
            foreach (string suitName in Enum.GetNames(typeof(Suit)))
            {
                for (int i = 1; i <= 13; ++i)
                {
                    cards.Push(new Card(i, suitName));
                }
            }
        }

        public List<Card> PopCards(int v)
        {
            var cardsDealt = new List<Card>();

            for (int i = 0; i < v; ++i)
            {
                cardsDealt.Add(cards.Pop());
            }

            return cardsDealt;
        }

        public void DisplayDeck()
        {
            foreach (var c in cards)
            {
                Console.WriteLine(c.ToString());

            }
            Console.WriteLine(" ");
        }

        public void ShuffleDeck()
        {
            Console.WriteLine($"Shuffling Deck...{Environment.NewLine}");

            var rnd = new Random();
            var shuffledDeck = new Stack<Card>(cards.OrderBy(item => rnd.Next()).ToList());
            cards = shuffledDeck;
        }

    }
    public enum Suit
    {
        Heart,
        Spade,
        Diamond,
        Club
    }

}


