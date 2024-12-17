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

    [Fact]
    public void TicTacToe_WhenCreate_ShouldTheSecondPlayerBeO()
    {
        var player1 = new Player();
        var player2 = new Player();
        
        var ticTacToe  = new TicTacToe(player1, player2);

        player2.Symbol.Should().Be('O');
    }

    [Fact]
    public void TicTacToe_WhenCreate_ShouldTheFirstPlayerStart()
    {
        var player1 = new Player();
        var player2 = new Player();
        
        var ticTacToe  = new TicTacToe(player1, player2);

        ticTacToe.CurrentPlayer.Should().Be(player1);
    }

    [Fact]
    public void TicTacToe_XWonWithAVerticalLineInFirstColumn()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 3, 6);
        player2.MakeMove().Returns(1, 2, 4);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player1.Symbol);
    }

    [Fact]
    public void TicTacToe_OWonWithAVerticalLineInSecondColumn()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 2, 3);
        player2.MakeMove().Returns(1, 4, 7);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player2.Symbol);
    }
    
    [Fact]
    public void TicTacToe_XWonWithAVerticalLineInThirdColumn()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(2, 5, 8);
        player2.MakeMove().Returns(1, 4, 7);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player1.Symbol);
    }

    [Fact]
    public void TicTacToe_XWonWithAHorizontalLineInFirstRow()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 1, 2);
        player2.MakeMove().Returns(3, 4, 5);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player1.Symbol);
    }

    [Fact]
    public void TicTacToe_OWonWithAHorizontalLineInSecondRow()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 1, 6);
        player2.MakeMove().Returns(3, 4, 5);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player2.Symbol);
    }
}