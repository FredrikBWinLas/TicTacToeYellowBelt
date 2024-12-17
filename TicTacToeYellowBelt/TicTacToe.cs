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

            CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
        }

        return '\0';
    }

    private bool CheckWin(char symbol)
    {
        if (_board[0] == _board[3] && _board[0] == _board[6] && _board[0] == symbol) return true;
        if (_board[1] == _board[4] && _board[1] == _board[7] && _board[1] == symbol) return true;
        if (_board[2] == _board[5] && _board[2] == _board[8] && _board[2] == symbol) return true;
        
        if (_board[0] == _board[1] && _board[0] == _board[2] && _board[0] == symbol) return true;
        if (_board[3] == _board[4] && _board[3] == _board[5] && _board[3] == symbol) return true;
        if (_board[6] == _board[7] && _board[6] == _board[8] && _board[6] == symbol) return true;
        return false;
    }
}