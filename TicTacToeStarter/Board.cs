namespace TicTacToeStarter
{
    public class Board
    {
        private PlayerEnum[,] board = new PlayerEnum[3, 3];
        private PlayerEnum currentPlayer;

        public PlayerEnum CurrentPlayer
        {
            get { return currentPlayer; }
        }

        public Board()
        {
            Reset();
        }

        public void Reset()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    board[x, y] = PlayerEnum.NONE;
                }
            }
            currentPlayer = PlayerEnum.X;
        }

        public bool Select(int row, int col)
        {
            if (board[row, col] == PlayerEnum.NONE)
            {
                board[row, col] = currentPlayer;
                currentPlayer = currentPlayer == PlayerEnum.X ? PlayerEnum.O : PlayerEnum.X;
                return true;
            }
            return false;
        }

        public PlayerEnum CheckWin()
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != PlayerEnum.NONE)
                    return board[i, 0];
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != PlayerEnum.NONE)
                    return board[0, i];
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != PlayerEnum.NONE)
                return board[0, 0];
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != PlayerEnum.NONE)
                return board[0, 2];

            return PlayerEnum.NONE;
        }

        public bool IsBoardFull()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[x, y] == PlayerEnum.NONE)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetCurrentPlayer(PlayerEnum player)
        {
            currentPlayer = player;
        }
    }
}