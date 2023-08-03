namespace TicTacToe.Model
{
    public class Player
    {
        public string Name { get; set; }
        public PlayingPiece Piece { get; set; }

        public Player(string name, PlayingPiece piece)
        {
            Name = name;
            Piece = piece;
        }

    }
}
