using System;
using FluentAssertions;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class SetStoneGameStateTests
    {
        private readonly Stone _sampleStone = new Stone(Size.Low, Surface.Hole, Color.White, Shape.Square);

        [Test]
        public void Ctor_WithNullStopme_ThrowsAnArgumentNullException()
        {
            Action call = () => new SetStoneGameState(new PlayingBoard(), null, Player.One);
            call.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SetNextStoneTo_WithUnsetStone_ReturnsAGameStateWithTheStoneSetToTheGivenPositionAndNoNextStoneSelected()
        {
            var objectUnderTest = new SetStoneGameState(new PlayingBoard(), this._sampleStone, Player.One);
            var result = objectUnderTest.SetNextStoneTo(1, 1);

            result.Should().NotBeNull();
            result.PlayingBoard.Should().NotBeNull();
            result.PlayingBoard.GetStone(1, 1).Should().Be(this._sampleStone);
            result.NextStone.Should().BeNull();
        }

        [Test]
        public void SetNextStone_WithValidArguments_DoesNotSwitchCurrentPlayer([Values(Player.One, Player.Two)] Player player)
        {
            var objectUnderTest = new SetStoneGameState(new PlayingBoard(), this._sampleStone, player);
            var result = objectUnderTest.SetNextStoneTo(1, 1);

            result.CurrentPlayer.Should().Be(objectUnderTest.CurrentPlayer);
        }
    }
}