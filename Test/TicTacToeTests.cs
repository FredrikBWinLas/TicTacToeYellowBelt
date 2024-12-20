﻿using FluentAssertions;
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

    [Fact]
    public void TicTacToe_XWonWithAHorizontalLineInThirdRow()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(6, 7, 8);
        player2.MakeMove().Returns(3, 4, 5);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player1.Symbol);
    }
    
    [Fact]
    public void TicTacToe_XWonWithADiagonalLineFromLeftToRight()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 4, 8);
        player2.MakeMove().Returns(1, 2, 3);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player1.Symbol);
    }
    [Fact]
    public void TicTacToe_OWonWithADiagonalLineFromRightToLeft()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 1, 3);
        player2.MakeMove().Returns(2, 4, 6);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player2.Symbol);
    }
    
    [Fact]
    public void TicTacToe_TheBoardIsFull_ShouldReturn0()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 2, 5, 6, 7);
        player2.MakeMove().Returns(1, 3, 4, 8);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be('\0');
    }
    
    [Fact]
    public void TicTacToe_CannotPlayInOccupatedSpots()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 0, 0, 1, 2);
        player2.MakeMove().Returns(3, 4, 5);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        var result = ticTacToe.Play();

        result.Should().Be(player1.Symbol);
    }

    [Fact]
    public void TicTacToe_WhenCreate_ShouldShowCreationMessage()
    {
        var output = new StringWriter();
        Console.SetOut(output);   
        
        var ticTacToe  = new TicTacToe(new Player(), new Player());

        var consoleOutput = output.ToString().Trim();
        var expexted = "Game Board Creation…\n | | \n-+-+-\n | | \n-+-+-\n | | \nBoard Created.\nThe game will start with player X";
        consoleOutput.Should().Be(expexted);
    }
    
    [Fact]
    public void TicTacToe_WhenPlay_ShouldPrintTheCurrentPlayer()
    {
        var output = new StringWriter();
        Console.SetOut(output);   
        
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 3, 6);
        player2.MakeMove().Returns(1, 2, 4);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        ticTacToe.Play();

        var consoleOutput = output.ToString().Trim();
        consoleOutput.Should().Contain("Player O:");
    }
    
    [Fact]
    public void TicTacToe_WhenPlayerWins_ShouldPrintTheWinner()
    {
        var output = new StringWriter();
        Console.SetOut(output);   
        
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 3, 6);
        player2.MakeMove().Returns(1, 2, 4);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        ticTacToe.Play();

        var consoleOutput = output.ToString().Trim();
        consoleOutput.Should().Contain("PLAYER X WON!");
    }
    
    [Fact]
    public void TicTacToe_WhenThereIsNoWinner_ShouldPrintTheDraw()
    {
        var output = new StringWriter();
        Console.SetOut(output);   
        
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();

        player1.MakeMove().Returns(0, 2, 5, 6, 7);
        player2.MakeMove().Returns(1, 3, 4, 8);
        
        var ticTacToe  = new TicTacToe(player1, player2);
        ticTacToe.Play();

        var consoleOutput = output.ToString().Trim();
        consoleOutput.Should().Contain("THE GAME ENDS WITH A DRAW!");
    }
    [Fact]
    public void TicTacToe_WhenPlay_ShouldHaveTimeoutBetweenMoves()
    {
        var player1 = Substitute.For<IPlayer>();
        var player2 = Substitute.For<IPlayer>();
        
        var sleeper = Substitute.For<ISleeper>();

        player1.MakeMove().Returns(0, 3, 6);
        player2.MakeMove().Returns(1, 2, 4);
        
        var ticTacToe  = new TicTacToe(player1, player2, sleeper);
        ticTacToe.Play();

        sleeper.Received(5).Sleep();
    }
}