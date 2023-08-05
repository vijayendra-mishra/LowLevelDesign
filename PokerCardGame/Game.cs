using DeckBuilder;

namespace CardDeck
{
    public class Game
    {
        public Game()
        {
            Console.WriteLine($"Starting New Game...{Environment.NewLine}");
        }

        public int Noc { get; set; }
        public List<Player> Players = new();
        private int winningPoints = 0;

        public static void Main(string[] args)
        {

            while (true)
            {
                Game newGame = new();
                Deck d = new();

                d.PopulateDeck();
                d.DisplayDeck();

                d.ShuffleDeck();
                d.DisplayDeck();

                Console.WriteLine($"Remaining Cards in Deck : {d.cards.Count}{Environment.NewLine}");

                Console.WriteLine($"Enter no of Players and no of Cards :");
                newGame.DealCards(d, Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                newGame.DisplayPlayerCards();

                Console.WriteLine($"Remaining Cards in Deck : {d.cards.Count}{Environment.NewLine}");

                Console.WriteLine("Press G to Deal cards again, Enter to get Winner :");
                var userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) && userInput.ToLower() == "g")
                {
                    newGame.DealCardsAgain(d);
                    newGame.DisplayPlayerCards();

                    Console.WriteLine($"Remaining Cards in Deck : {d.cards.Count}{Environment.NewLine}");
                }

                Console.WriteLine($"And the WINNER is : Player {newGame.GetWinner()}{Environment.NewLine}");

                Console.WriteLine("Press Ctrl-C to exit, Enter to start a New Game.");
                Console.ReadLine();
            }
        }

        private int GetWinner()
        {
            var winnerId = 0;

            foreach (var p in Players)
            {
                var playerPoints = p.CardsDealt.Sum(x => x.Points);
                if (playerPoints > winningPoints)
                {
                    winningPoints = playerPoints;
                    winnerId = p.Id;
                }
            }

            return winnerId;
        }

        public void DealCards(Deck d, int nop, int noc)
        {
            Console.WriteLine($"Dealing Cards to { noc} Players!{Environment.NewLine}");

            Noc = noc;

            for (int i = 1; i <= nop; ++i)
            {
                Players.Add(new Player(i));
                Players[i - 1].CardsDealt = d.PopCards( noc);
            }

        }


        public void DisplayPlayerCards()
        {
            foreach (var p in Players) { Console.WriteLine(p.ToString()); }
        }

        public void DealCardsAgain(Deck d)
        {
            Console.WriteLine($"Dealing Cards Again!{Environment.NewLine}");

            foreach (var p in Players)
            {
                p.CardsDealt.AddRange( d.PopCards(Noc));
            }

        }
    }
}
