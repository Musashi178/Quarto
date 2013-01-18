using System;

namespace Quarto.Domain
{
    public class Stone : IEquatable<Stone>
    {
        private readonly Color color;
        private readonly Shape shape;
        private readonly Size size;
        private readonly byte stoneId;
        private readonly Surface surface;

        public Stone(Size size, Surface surface, Color color, Shape shape)
        {
            this.size = size;
            this.surface = surface;
            this.color = color;
            this.shape = shape;

            this.stoneId = CalculateStoneId(this);
        }

        public Size Size
        {
            get { return this.size; }
        }

        public Surface Surface
        {
            get { return this.surface; }
        }

        public Color Color
        {
            get { return this.color; }
        }

        public Shape Shape
        {
            get { return this.shape; }
        }

        public bool Equals(Stone other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.stoneId == other.stoneId;
        }

        public static byte CalculateStoneId(Stone stone)
        {
            int stoneId = 0;
            stoneId += (byte) stone.Size << 0;
            stoneId += (byte) stone.Surface << 1;
            stoneId += (byte) stone.Color << 2;
            stoneId += (byte) stone.Shape << 3;
            return (byte) stoneId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Stone) obj);
        }

        public override int GetHashCode()
        {
            return this.stoneId;
        }

        public static bool operator ==(Stone left, Stone right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Stone left, Stone right)
        {
            return !Equals(left, right);
        }
    }
}
