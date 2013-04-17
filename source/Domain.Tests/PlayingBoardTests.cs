using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class PlayingBoardTests
    {
        [SetUp]
        public void SetUp()
        {
            this._objectUnderTest = new PlayingBoard();
        }

        [Test]
        public void DefaultCtor_CreatesAnEmptyPlayingBoard()
        {
            this._objectUnderTest.GetAllFields().Should().OnlyContain(s => s == null);
        }

      

        [Test]
        public void GetColumns_WithStonesSet_ReturnsExpectedColumns()
        {
            this._objectUnderTest = this._objectUnderTest.SetStone(0, 1, this._sampleStoneOne);
            this._objectUnderTest = this._objectUnderTest.SetStone(2, 3, this._sampleStoneTwo);

            var result = this._objectUnderTest.GetColumns().ToArray();
            result.Should().HaveCount(4);

            result[0].Should().BeEquivalentTo(new Stone[] {null, null, null, null}, "column 0 must match");
            result[1].Should().BeEquivalentTo(new Stone[] {this._sampleStoneOne, null, null, null}, "column 1 must match");
            result[2].Should().BeEquivalentTo(new Stone[] {null, null, null, null}, "column 2 must match");
            result[3].Should().BeEquivalentTo(new Stone[] {null, null, this._sampleStoneTwo, null}, "column 3 must match");
        }

        [Test]
        public void GetDiagonals_WithStonesSet_ReturnsExpectedDiagonals()
        {
            this._objectUnderTest = this._objectUnderTest.SetStone(1, 1, this._sampleStoneOne);
            this._objectUnderTest = this._objectUnderTest.SetStone(2, 3, this._sampleStoneTwo);

            var result = this._objectUnderTest.GetDiagonals().ToArray();
            result[0].Should().BeEquivalentTo(new Stone[] {null, this._sampleStoneOne, null, null}, "diagonal 0 must match");
            result[1].Should().BeEquivalentTo(new Stone[] {null, null, null, null}, "diagonal 1 must match");
        }

        [Test]
        public void GetRows_WithStonesSet_ReturnsExpectedRows()
        {
            this._objectUnderTest = this._objectUnderTest.SetStone(0, 1, this._sampleStoneOne);
            this._objectUnderTest = this._objectUnderTest.SetStone(2, 3, this._sampleStoneTwo);

            var result = this._objectUnderTest.GetRows().ToArray();
            result.Should().HaveCount(4);

            result[0].Should().BeEquivalentTo(new Stone[] {null, this._sampleStoneOne, null, null}, "row 0 must match");
            result[1].Should().BeEquivalentTo(new Stone[] {null, null, null, null}, "row 1 must match");
            result[2].Should().BeEquivalentTo(new Stone[] {null, null, null, this._sampleStoneTwo}, "row 2 must match");
            result[3].Should().BeEquivalentTo(new Stone[] {null, null, null, null}, "row 3 must match");
        }

        [Test]
        public void SetStone_OnGivenCoordinates_ReturnsANewPlayingBoardWithTheExpectedStoneSet()
        {
            var oldState = this._objectUnderTest;
            var newState = oldState.SetStone(0, 0, this._sampleStoneOne);

            newState.Should().NotBeNull();
            newState.Should().NotBeSameAs(oldState);
            newState.GetStone(0, 0).Should().Be(this._sampleStoneOne);

            oldState.GetAllFields().Should().OnlyContain(s => s == null);
        }

        private PlayingBoard _objectUnderTest;
        private readonly Stone _sampleStoneOne = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round);
        private readonly Stone _sampleStoneTwo = new Stone(Size.Low, Surface.Hole, Color.White, Shape.Square);
    }
}
