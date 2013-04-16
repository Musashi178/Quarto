using System;

namespace Quarto.Domain
{
    public class Stone : IEquatable<Stone>
    {
        private readonly Color _color;
        private readonly Shape _shape;
        private readonly Size _size;
        private readonly byte _stoneId;
        private readonly Surface _surface;

        public Stone(Size size, Surface surface, Color color, Shape shape)
        {
            this._size = size;
            this._surface = surface;
            this._color = color;
            this._shape = shape;

            this._stoneId = CalculateStoneId(this);
        }

        public Size Size
        {
            get { return this._size; }
        }

        public Surface Surface
        {
            get { return this._surface; }
        }

        public Color Color
        {
            get { return this._color; }
        }

        public Shape Shape
        {
            get { return this._shape; }
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

            return this._stoneId == other._stoneId;
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
            return this._stoneId;
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
