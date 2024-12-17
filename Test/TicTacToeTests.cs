using FluentAssertions;
using NSubstitute;
using TicTacToeYellowBelt;

namespace Test;

public class TicTacToeTests
{
    [Fact]
    public void TicTacToe_WhenCreate_ShouldBoardBeEmpty()
    {
        var player1 = new Player();
        var player2 = new Player();
        
        var ticTacToe  = new TicTacToe(player1, player2);

        ticTacToe.Board.Should().Be("         ");
    }
    
    [Fact]
    public void TicTacToe_WhenCreate_ShouldTheFirstPlayerBeX()
    {
        var player1 = new Player();
        var player2 = new Player();
        
        var ticTacToe  = new TicTacToe(player1, player2);

        player1.Symbol.Should().Be('X');
    }

}