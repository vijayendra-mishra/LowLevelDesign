namespace TicTacToe.Model
{
    public class PlayingPiece
    {
        public PieceType PieceType { get; set; }

        public PlayingPiece(PieceType pieceType)
        {
            PieceType = pieceType;
        }

    }
}
