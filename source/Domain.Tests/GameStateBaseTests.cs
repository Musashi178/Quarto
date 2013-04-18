using System;
using System.Reflection;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class GameStateBaseTests
    {
        [Test]
        public void Ctor_WithANonNullPlayfieldAndANotSetNextStone_DoesNotThrowAnException()
        {
            var notSetStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square);

            var playfield = new PlayingBoard();
            playfield = playfield.SetStone(0, 0, this._sampleStone);
            Action call = () => Substitute.For<GameStateBase>(playfield, notSetStone, Player.One);
            call.ShouldNotThrow();
        }

        [Test]
        public void Ctor_WithANonNullPlayfieldAndNextStoneNull_DoesNotThrowAnException()
        {
            Action call = () => Substitute.For<GameStateBase>(new PlayingBoard(), null, Player.One);
            call.ShouldNotThrow();
        }

        [Test]
        public void Ctor_WithNextStoneAlreadyPresentOnPlayingField_ThrowsArgumentException()
        {
            var playfield = new PlayingBoard();
            playfield = playfield.SetStone(0, 0, this._sampleStone);

            Action call = () => Substitute.For<GameStateBase>(playfield, this._sampleStone, Player.One);
            call.ShouldThrow<TargetInvocationException>().WithInnerException<ArgumentException>();
        }

        [Test]
        public void Ctor_WithNullPlayField_ThrowsArgumentNullException()
        {
            Action call = () => Substitute.For<GameStateBase>(null, this._sampleStone, Player.One);
            call.ShouldThrow<TargetInvocationException>().WithInnerException<ArgumentNullException>();
        }

        [Test]
        public void IsWinLine_WithFourStonesWithNothingInCommon_ReturnsFalse()
        {
            var winLine = new[]
                {
                    new Stone(Size.Low, Surface.Flat, Color.Black, Shape.Round),
                    new Stone(Size.High, Surface.Hole, Color.Black, Shape.Round),
                    new Stone(Size.High, Surface.Flat, Color.White, Shape.Round),
                    new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square),
                };
            var result = GameStateBase.IsWinLine(winLine);

            result.Should().BeFalse();
        }

        [Test]
        public void IsWinLine_WithFourStonesWithTheSameSizeButNothingElseInCommon_ReturnsTrue()
        {
            var winLine = new[]
                {
                    new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round),
                    new Stone(Size.High, Surface.Hole, Color.Black, Shape.Round),
                    new Stone(Size.High, Surface.Flat, Color.White, Shape.Round),
                    new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square),
                };
            var result = GameStateBase.IsWinLine(winLine);

            result.Should().BeTrue();
        }

        private readonly Stone _sampleStone = new Stone(Size.Low, Surface.Hole, Color.White, Shape.Square);
    }
}
