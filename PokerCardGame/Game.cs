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

                Console.WriteLine($"Enter no of Players, no of Cards :");
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

        public void DealCards(Deck _d, int _nop, int _noc)
        {
            Console.WriteLine($"Dealing Cards to {_noc} Players!{Environment.NewLine}");

            Noc = _noc;

            for (int i = 1; i <= _nop; ++i)
            {
                Players.Add(new Player(i));
                Players[i - 1].CardsDealt = _d.PopCards(_noc);
            }

        }


        public void DisplayPlayerCards()
        {
            foreach (var p in Players) { Console.WriteLine(p.ToString()); }
        }

        public void DealCardsAgain(Deck _d)
        {
            Console.WriteLine($"Dealing Cards Again!{Environment.NewLine}");

            foreach (var p in Players)
            {
                p.CardsDealt.AddRange(_d.PopCards(Noc));
            }

        }
    }
}
