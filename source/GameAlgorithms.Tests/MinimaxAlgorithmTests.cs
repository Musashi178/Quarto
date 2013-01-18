using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Quarto.Algorithms;

namespace Quarto.GameAlgorithms.Tests
{
    [TestFixture]
    public class MinimaxAlgorithmTests
    {
        [Test]
        public void GetMaximumValue_WithNonTerminalState_ReturnsMaximumValueOfSuccessorState()
        {
            var objectUnderTest = new MinimaxAlgorithm<float>(
                o => o >= 1.0,
                o => o,
                o => new IMove<float>[]
                    {
                        new FloatMove(6.0f),
                        new FloatMove(3.0f),
                        new FloatMove(7.0f),
                        new FloatMove(1.2f)
                    });

            float result = objectUnderTest.GetMaximumValue(.0f);

            result.Should().BeApproximately(7.0f, float.Epsilon);
        }

        [Test]
        public void GetMaximumValue_WithTerminalState_ReturnsUtilityValue()
        {
            var objectUnderTest = new MinimaxAlgorithm<float>(
                o => true,
                o => o,
                o => Enumerable.Empty<IMove<float>>());

            float result = objectUnderTest.GetMaximumValue(4.0f);

            result.Should().BeApproximately(4.0f, float.Epsilon);
        }

        [Test]
        public void GetMinimumValue_WithNonTerminalState_ReturnsMinimumValueOfSuccessorState()
        {
            var objectUnderTest = new MinimaxAlgorithm<float>(
                o => o >= 1.0,
                o => o,
                o => new IMove<float>[]
                    {
                        new FloatMove(6.0f),
                        new FloatMove(3.0f),
                        new FloatMove(7.0f),
                        new FloatMove(1.2f)
                    });

            float result = objectUnderTest.GetMinimumValue(.0f);

            result.Should().BeApproximately(1.2f, float.Epsilon);
        }

        [Test]
        public void GetMinimumValue_WithTerminalState_ReturnsUtilityValue()
        {
            var objectUnderTest = new MinimaxAlgorithm<float>(
                o => true,
                o => o,
                o => Enumerable.Empty<IMove<float>>());

            float result = objectUnderTest.GetMinimumValue(4.0f);

            result.Should().BeApproximately(4.0f, float.Epsilon);
        }

        private class FloatMove : IMove<float>
        {
            private readonly float f;

            public FloatMove(float f)
            {
                this.f = f;
            }

            public float ApplyTo(float state)
            {
                return this.f;
            }
        }
    }
}
