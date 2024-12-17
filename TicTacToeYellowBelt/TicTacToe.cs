namespace TicTacToeYellowBelt;

public class TicTacToe
{
    private char[] _board = "         ".ToCharArray(); 
    public string Board => new string(_board);
    public IPlayer CurrentPlayer { get; set; }
    public TicTacToe(IPlayer player1, IPlayer player2)
    {
        player1.Symbol = 'X';
        player2.Symbol = 'O';
        CurrentPlayer = player1;
    }
}