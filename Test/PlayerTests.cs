using FluentAssertions;
using TicTacToeYellowBelt;

namespace Test;

public class PlayerTests
{
    [Fact]
    public void Player_WhenChangeSymbol_ShouldChangeTheSymbol()
    {
        var player = new Player();
        player.Symbol = 'X';
        player.Symbol.Should().Be('X');
    }
}
