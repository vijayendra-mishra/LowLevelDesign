using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe
{
    public class Game
    {
        List<Player> players;
        Board board;

        public Game()
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            players = new List<Player>();
            PlayingPiece crossPiece = new(PieceType.X);
            Player player1 = new("Player 1", crossPiece);
            Console.WriteLine($"{player1.Name} is playing with \"X\"");

            PlayingPiece zeroPiece = new(PieceType.O);
            Player player2 = new("Player 2", zeroPiece);
            Console.WriteLine($"{player2.Name} is playing with \"0\"");

            players.Add(player1);
            players.Add(player2);

            board = new Board(3);
        }

        public string StartGame()
        {
            Console.WriteLine("Starting Game: ");
            board.PrintBoard();

            bool noWinner = true;
            int emptyCells = board.Size * board.Size;
            string winner = string.Empty;

            while (noWinner)
            {
                if (emptyCells == 0) return "TIE";

                Player p = players.ElementAt(0);
                players.RemoveAt(0);

                Console.WriteLine($"Enter row, column for {p.Name}: ");
                var position = Console.ReadLine();

                if (string.IsNullOrEmpty(position)) InvalidEntry(ref p);
                else
                {
                    int row = board.Size + 1; // default validation fails condition
                    int col = row;

                    string[] values = position.Split(',');

                    if (values.Length == 2)
                    {
                        _ = int.TryParse(values[0], out row);
                        _ = int.TryParse(values[1], out col);
                    }

                    if ((row < board.Size && col < board.Size) && board.AddPiece(row, col, p.Piece))
                    {
                        emptyCells--;
                        board.PrintBoard();
                        players.Add(p);

                        if (IsThereAWinner(row, col, p.Piece.PieceType))
                        {
                            noWinner = false;
                            winner = p.Name;
                        }
                    }
                    else
                    {
                        InvalidEntry(ref p);
                    }
                }
            }
            return winner;
        }

        private void InvalidEntry(ref Player p)
        {
            Console.WriteLine("Incorrect position, please enter again!");
            players.Insert(0, p);
        }

        private bool IsThereAWinner(int row, int col, PieceType pieceType)
        {
            bool rowMatch = true;
            bool colMatch = true;
            bool leftDiagMatch = true;
            bool rightDiagMatch = true;

            var pB = board.PlayingBoard;

            //rows
            for (int i = 0; i < board.Size; i++)
            {
                if (pB[row, i] == null || pB[row, i].PieceType != pieceType)
                    rowMatch = false;
            }

            //columns
            for (int i = 0; i < board.Size; i++)
            {
                if (pB[i, col] == null || pB[i, col].PieceType != pieceType)
                    colMatch = false;
            }

            //left diagonal
            for (int i = 0, j = 0; i < board.Size; i++, j++)
            {
                if (pB[i, j] == null || pB[i, j].PieceType != pieceType)
                    leftDiagMatch = false;
            }

            //right diagonal
            for (int i = 0, j = board.Size - 1; i < board.Size; i++, j--)
            {
                if (pB[i, j] == null || pB[i, j].PieceType != pieceType)
                    rightDiagMatch = false;
            }

            return rowMatch || colMatch || leftDiagMatch || rightDiagMatch;

        }
    }
}
