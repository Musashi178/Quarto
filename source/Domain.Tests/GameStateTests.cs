using NUnit.Framework;
using Quarto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
namespace Domain.Tests
{
    [TestFixture]
    public class GameStateTests
    {
        [Test]
        public void Ctor_WithNullPlayField_ThrowsArgumentNullException()
        {
            Action call = () => new GameState(null, new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round));
            call.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Ctor_WithNextStoneAlreadyPresentOnPlayingField_ThrowsArgumentException()
        {
            var sampleStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round);
            var playfield = new PlayingBoard();
            playfield = playfield.SetStone(0, 0, sampleStone);

            Action call = () => new GameState(playfield, sampleStone);
            call.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void Ctor_WithANonNullPlayfieldAndNextStoneNull_DoesNotThrowAnException()
        {
            Action call = () => new GameState(new PlayingBoard(), null);
            call.ShouldNotThrow();
        }

        [Test]
        public void Ctor_WithANonNullPlayfieldAndANotSetNextStone_DoesNotThrowAnException()
        {
            var setStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round);
            var notSetStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square);

            var playfield = new PlayingBoard();
            playfield = playfield.SetStone(0, 0, setStone);
            Action call = () => new GameState(playfield, notSetStone);
            call.ShouldNotThrow();
        }

        [Test]
        public void ChooseAsNextStone_WhenNextStoneIsAlreadyChoosen_ThrowsAnInvalidOperationException()
        {
           var setStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round);
            var nextStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square);
            var objectUnderTest = new GameState(new PlayingBoard(), setStone);

            objectUnderTest.Invoking(o => o.ChooseAsNextStone(nextStone)).ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void SetAsNextStone_WhenNoNextStoneIsChoosen_ThrowsAnInvalidOperationException()
        {
            var objectUnderTest = new GameState(new PlayingBoard(), null);
            objectUnderTest.Invoking(o => o.SetNextStoneTo(2, 2)).ShouldThrow<InvalidOperationException>();

        }

        [Test]
        public void ChooseAsNextStone_WithUnsetStone_ReturnsAGameStateWithTheStoneSetToTheGivenPosition()
        {
            var nextStone = new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square);

            var objectUnderTest = new GameState(new PlayingBoard(), nextStone);
            var result = objectUnderTest.SetNextStoneTo(1, 1);

            result.Should().NotBeNull();
            result.PlayingBoard.Should().NotBeNull();
            result.PlayingBoard.GetStone(1, 1).Should().Be(nextStone);
        }
    }
}
