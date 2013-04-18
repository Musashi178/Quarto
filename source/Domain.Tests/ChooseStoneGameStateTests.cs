using FluentAssertions;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class ChooseStoneGameStateTests
    {
        [Test]
        public void ChooseAsNextStone_WithAnUnsetStone_ReturnsAGameStateWithTheSamePlayboardAndANextStoneSelected()
        {
            var objectUnderTest = new ChooseStoneGameState(new PlayingBoard(), Player.One);
            var result = objectUnderTest.ChooseAsNextStone(this._sampleStone);

            result.Should().NotBeNull();
            result.PlayingBoard.ShouldBeEquivalentTo(objectUnderTest.PlayingBoard);
            result.NextStone.Should().Be(this._sampleStone);
        }

        [Test]
        public void ChooseAsNextStone_WithValiArguments_SwitchesCurrentPlayer([Values(Player.One, Player.Two)] Player player)
        {
            var objectUnderTest = new ChooseStoneGameState(new PlayingBoard(), player);
            var result = objectUnderTest.ChooseAsNextStone(this._sampleStone);

            result.CurrentPlayer.Should().NotBe(objectUnderTest.CurrentPlayer);
        }

        private readonly Stone _sampleStone = new Stone(Size.Low, Surface.Hole, Color.White, Shape.Square);
    }
}