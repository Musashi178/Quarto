using System;
using FluentAssertions;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class GameStateTests
    {
        [Test]
        public void ChooseAsNextStone_WhenNextStoneIsAlreadyChoosen_ThrowsAnInvalidOperationException()
        {
            var nextStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square);
            var objectUnderTest = new GameState(new PlayingBoard(), this._sampleStone, Player.One);

            objectUnderTest.Invoking(o => o.ChooseAsNextStone(nextStone)).ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ChooseAsNextStone_WithAnUnsetStone_ReturnsAGameStateWithTheSamePlayboardAndANextStoneSelected()
        {
            var objectUnderTest = new GameState(new PlayingBoard(), null, Player.One);
            var result = objectUnderTest.ChooseAsNextStone(this._sampleStone);

            result.Should().NotBeNull();
            result.PlayingBoard.ShouldBeEquivalentTo(objectUnderTest.PlayingBoard);
            result.NextStone.Should().Be(this._sampleStone);
        }

        [Test]
        public void Ctor_WithANonNullPlayfieldAndANotSetNextStone_DoesNotThrowAnException()
        {
            var notSetStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square);

            var playfield = new PlayingBoard();
            playfield = playfield.SetStone(0, 0, this._sampleStone);
            Action call = () => new GameState(playfield, notSetStone, Player.One);
            call.ShouldNotThrow();
        }

        [Test]
        public void Ctor_WithANonNullPlayfieldAndNextStoneNull_DoesNotThrowAnException()
        {
            Action call = () => new GameState(new PlayingBoard(), null, Player.One);
            call.ShouldNotThrow();
        }

        [Test]
        public void Ctor_WithNextStoneAlreadyPresentOnPlayingField_ThrowsArgumentException()
        {
            var playfield = new PlayingBoard();
            playfield = playfield.SetStone(0, 0, this._sampleStone);

            Action call = () => new GameState(playfield, this._sampleStone, Player.One);
            call.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void Ctor_WithNullPlayField_ThrowsArgumentNullException()
        {
            Action call = () => new GameState(null, this._sampleStone, Player.One);
            call.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SetAsNextStone_WhenNoNextStoneIsChoosen_ThrowsAnInvalidOperationException()
        {
            var objectUnderTest = new GameState(new PlayingBoard(), null, Player.One);
            objectUnderTest.Invoking(o => o.SetNextStoneTo(2, 2)).ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void SetNextStoneTo_WithUnsetStone_ReturnsAGameStateWithTheStoneSetToTheGivenPositionAndNoNextStoneSelected()
        {
            this._sampleStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square);

            var objectUnderTest = new GameState(new PlayingBoard(), this._sampleStone, Player.One);
            var result = objectUnderTest.SetNextStoneTo(1, 1);

            result.Should().NotBeNull();
            result.PlayingBoard.Should().NotBeNull();
            result.PlayingBoard.GetStone(1, 1).Should().Be(this._sampleStone);
            result.NextStone.Should().BeNull();
        }

        [Test]
        public void SetNextStone_WithValidArguments_DoesNotSwitchCurrentPlayer([Values(Player.One, Player.Two)] Player player)
        {
            var objectUnderTest = new GameState(new PlayingBoard(), this._sampleStone, player);
            var result = objectUnderTest.SetNextStoneTo(1, 1);

            result.CurrentPlayer.Should().Be(objectUnderTest.CurrentPlayer);
        }

        [Test]
        public void ChooseAsNextStone_WithValiArguments_SwitchesCurrentPlayer([Values(Player.One, Player.Two)] Player player)
        {
            var objectUnderTest = new GameState(new PlayingBoard(), null , player);
            var result = objectUnderTest.ChooseAsNextStone(this._sampleStone);

            result.CurrentPlayer.Should().NotBe(objectUnderTest.CurrentPlayer);
        }


        private Stone _sampleStone = new Stone(Size.Low, Surface.Hole, Color.White, Shape.Square);
    }
}
