using System;
using TicTacToeYellowBelt;

namespace TicTacToeYellowBelt;

class Program
{
    static void Main(string[] args)
    {
        var ticTacToe  = new TicTacToe(new Player(), new Player(), new Sleeper(2000));
        ticTacToe.Play();
    }
}
