namespace TicTacToeYellowBelt;

public class TicTacToe
{
    private char[] _board = "         ".ToCharArray(); 
    public string Board => new string(_board);
    public TicTacToe(IPlayer player1, IPlayer player2)
    {
        player1.Symbol = 'X';
    }
}