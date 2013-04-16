using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class PlayingBoardTests
    {
        private PlayingBoard _objectUnderTest;
        private Stone sampleStoneOne = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round);
        private Stone sampleStoneTwo = new Stone(Size.Low, Surface.Hole, Color.White, Shape.Square);
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
        public void GetAllFields_WithOneStonesSet_ReturnsTheSetStone()
        {
            this._objectUnderTest = this._objectUnderTest.SetStone(0, 0, sampleStoneOne);
            
            var result = this._objectUnderTest.GetAllFields();

            result.Should().Contain(sampleStoneOne);
        }

        [Test]
        public void SetStone_OnGivenCoordinates_ReturnsANewPlayingBoardWithTheExpectedStoneSet()
        {
            var oldState = this._objectUnderTest;
            var newState = oldState.SetStone(0, 0, sampleStoneOne);

            newState.Should().NotBeNull();
            newState.Should().NotBeSameAs(oldState);
            newState.GetStone(0, 0).Should().Be(sampleStoneOne);

            oldState.GetAllFields().Should().OnlyContain(s => s == null);
        }
    }
}
