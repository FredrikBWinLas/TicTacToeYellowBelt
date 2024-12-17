using FluentAssertions;
using NSubstitute;
using TicTacToeYellowBelt;

namespace Test;

public class PlayerTests
{
    [Fact]
    public void Player_WhenChangeSymbol_ShouldChangeTheSymbol()
    {
        IPlayer player = new Player();
        player.Symbol = 'X';
        player.Symbol.Should().Be('X');
    }

    [Fact]
    public void Player_WhenMakeMove_ShouldGiveNumberFrom0To8()
    {
        var random = Substitute.For<Random>();
        random.Next(0, 9).Returns(5);
        IPlayer player = new Player();

        var result = player.MakeMove();
        result.Should().BeGreaterOrEqualTo(0);
        result.Should().BeLessThanOrEqualTo(8);
    }
}