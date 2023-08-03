namespace TicTacToe.Model
{
    public class Board
    {
        public int Size { get; set; }
        public PlayingPiece[,] PlayingBoard { get; set; }

        public Board(int size)
        {
            Size = size;
            PlayingBoard = new PlayingPiece[size, size];
        }

        public bool AddPiece(int row, int column, PlayingPiece pieceToAdd)
        {
            if (PlayingBoard[row, column] != null) return false;
            PlayingBoard[row, column] = pieceToAdd;
            return true;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    var piece = PlayingBoard[i, j];
                    Console.Write((piece == null ? "   " : " " + piece.PieceType + " ") + " |");
                }
                Console.WriteLine();
            }
        }
    }
}
