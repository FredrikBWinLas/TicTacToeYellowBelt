namespace TicTacToeYellowBelt;

public class TicTacToe
{
    private char[] _board = "         ".ToCharArray(); 
    public string Board => new string(_board);
    public IPlayer CurrentPlayer { get; set; }
    private IPlayer _player1;
    private IPlayer _player2;
    public TicTacToe(IPlayer player1, IPlayer player2)
    {
        _player1 = player1;
        _player2 = player2;
        _player1.Symbol = 'X';
        _player2.Symbol = 'O';
        CurrentPlayer = player1;
    }
    public char Play()
    {
        while(true)
        {
            var movePosition = CurrentPlayer.MakeMove();
            _board[movePosition] = CurrentPlayer.Symbol;

            if (CheckWin(CurrentPlayer.Symbol))
            {
                return CurrentPlayer.Symbol;
            }
        }

        return '\0';
    }

    private bool CheckWin(char symbol)
    {
        if (_board[0] == _board[3] && _board[0] == _board[6] && _board[0] == symbol) return true;
        return false;
    }
}