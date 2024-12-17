namespace TicTacToeYellowBelt;

public class Sleeper : ISleeper
{
    private readonly int _milliseconds;

    public Sleeper(int milliseconds)
    {
        _milliseconds = milliseconds;
    }
    public void Sleep()
    {
        Thread.Sleep(_milliseconds);
    }
}

public interface ISleeper
{
    void Sleep();
}