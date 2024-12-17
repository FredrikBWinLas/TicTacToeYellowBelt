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
        Console.WriteLine($"Game Board Creation…\n{BoardToOutputString()}Board Created.\nThe game will start with player {CurrentPlayer.Symbol}\n");
    }
    public char Play()
    {
        for(int i=0; i<9; i++)
        {
            Console.WriteLine($"Player {CurrentPlayer.Symbol}:");
            int movePosition;
            do
            {
                movePosition = CurrentPlayer.MakeMove();
            }
            while (!IsValidMove(movePosition));

            _board[movePosition] = CurrentPlayer.Symbol;
            
            Console.WriteLine(BoardToOutputString());
            
            if (CheckWin(CurrentPlayer.Symbol))
            {
                Console.WriteLine($"\nPLAYER {CurrentPlayer.Symbol} WON!");
                return CurrentPlayer.Symbol;
            }

            CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
        }
        
        Console.WriteLine("THE GAME ENDS WITH A DRAW!");
        return '\0';
    }

    private string BoardToOutputString()
    {
        var result = string.Empty;
        
        for (int i = 0; i < _board.Length; i++)
        {
            result += _board[i];
            if (i % 3 < 2)
                result += "|";
            else if (i == 8)
                result += "\n";
            else 
                result += "\n-+-+-\n";
        }

        return result;
    }

    private bool IsValidMove(int position) => _board[position] == ' ';
    private bool CheckWin(char symbol)
    {
        if (_board[0] == _board[3] && _board[0] == _board[6] && _board[0] == symbol) return true;
        if (_board[1] == _board[4] && _board[1] == _board[7] && _board[1] == symbol) return true;
        if (_board[2] == _board[5] && _board[2] == _board[8] && _board[2] == symbol) return true;
        
        if (_board[0] == _board[1] && _board[0] == _board[2] && _board[0] == symbol) return true;
        if (_board[3] == _board[4] && _board[3] == _board[5] && _board[3] == symbol) return true;
        if (_board[6] == _board[7] && _board[6] == _board[8] && _board[6] == symbol) return true;

        if (_board[0] == _board[4] && _board[4] == _board[8] && _board[0] == symbol) return true;
        if (_board[2] == _board[4] && _board[4] == _board[6] && _board[2] == symbol) return true;

        return false;
    }
}