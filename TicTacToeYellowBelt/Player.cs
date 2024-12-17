namespace TicTacToeYellowBelt;

public class Player : IPlayer
{
    private Random _random = new Random();

    public Player(Random? random = null)
    {
        _random = random ?? new Random();
    }
    public char Symbol { get; set; }
    public int MakeMove() => _random.Next(0, 9);
}

public interface IPlayer
{
    char Symbol { get; set; }
    int MakeMove();
}