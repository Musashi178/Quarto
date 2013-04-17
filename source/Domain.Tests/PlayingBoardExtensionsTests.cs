using FluentAssertions;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class PlayingBoardExtensionsTests
    {
        [Test]
        public void GetAllLines_ReturnsTenLines()
        {
            var pb = new PlayingBoard();

            var result = pb.GetAllLines();

            result.Should().NotBeNull();
            result.Should().HaveCount(10);
        }

        [Test]
        public void GetAllFields_WithOneStonesSet_ReturnsTheSetStone()
        {
            var objectUnderTest = new PlayingBoard().SetStone(0, 0, this._sampleStoneOne);

            var result = objectUnderTest.GetAllFields();

            result.Should().Contain(this._sampleStoneOne);
        }

        private readonly Stone _sampleStoneOne = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round);
     
    }
}
