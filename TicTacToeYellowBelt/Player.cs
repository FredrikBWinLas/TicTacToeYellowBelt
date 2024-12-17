namespace TicTacToeYellowBelt;

public class Player : IPlayer
{
    public char Symbol { get; set; }
}

public interface IPlayer
{
    char Symbol { get; set; }
}