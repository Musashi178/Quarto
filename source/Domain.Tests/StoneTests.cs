using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Quarto.Domain;

namespace Domain.Tests
{
    [TestFixture]
    public class StoneTests
    {
        [Test]
        public void CalculateStoneId_GivenAllPossibleStones_ReturnsUniqueIdForEach()
        {
            var allStonesWithId = this._allPossibleStones.Select(s => new
                {
                    Id = (byte)Stone.StoneId.GetStoneId(s),
                    Stone = s
                }).OrderBy(sid => sid.Id);

            Dictionary<byte, Stone> stonesDic = allStonesWithId.ToDictionary(sid => sid.Id, sid => sid.Stone);

            stonesDic.Should().HaveCount(this._allPossibleStones.Length);
        }

        private readonly Stone[] _allPossibleStones = new[]
            {
                new Stone(Size.High, Surface.Flat, Color.Black, Shape.Round),
                new Stone(Size.High, Surface.Flat, Color.Black, Shape.Square),
                new Stone(Size.High, Surface.Flat, Color.White, Shape.Round),
                new Stone(Size.High, Surface.Flat, Color.White, Shape.Square),
                new Stone(Size.High, Surface.Hole, Color.Black, Shape.Round),
                new Stone(Size.High, Surface.Hole, Color.Black, Shape.Square),
                new Stone(Size.High, Surface.Hole, Color.White, Shape.Round),
                new Stone(Size.High, Surface.Hole, Color.White, Shape.Square),
                new Stone(Size.Low, Surface.Flat, Color.Black, Shape.Round),
                new Stone(Size.Low, Surface.Flat, Color.Black, Shape.Square),
                new Stone(Size.Low, Surface.Flat, Color.White, Shape.Round),
                new Stone(Size.Low, Surface.Flat, Color.White, Shape.Square),
                new Stone(Size.Low, Surface.Hole, Color.Black, Shape.Round),
                new Stone(Size.Low, Surface.Hole, Color.Black, Shape.Square),
                new Stone(Size.Low, Surface.Hole, Color.White, Shape.Round),
                new Stone(Size.Low, Surface.Hole, Color.White, Shape.Square)
            };
    }
}
