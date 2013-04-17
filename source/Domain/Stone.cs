using System;
using System.Diagnostics;

namespace Quarto.Domain
{
    public class Stone : IEquatable<Stone>
    {
        private readonly Color _color;
        private readonly Shape _shape;
        private readonly Size _size;
        private readonly StoneId _stoneId;
        private readonly Surface _surface;

        public Stone(Size size, Surface surface, Color color, Shape shape)
        {
            this._size = size;
            this._surface = surface;
            this._color = color;
            this._shape = shape;

            this._stoneId = StoneId.GetStoneId(this);
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

        public StoneId Id
        {
            get { return this._stoneId; }
        }

        public bool Equals(Stone other)
        {
            if (null == other)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Stone);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public static bool operator ==(Stone left, Stone right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Stone left, Stone right)
        {
            return !Equals(left, right);
        }

        public struct StoneId : IEquatable<StoneId>
        {
            private readonly byte _id;

            private StoneId(byte id)
            {
                this._id = id;
            }

            public static implicit operator byte(StoneId id)
            {
                return id._id;
            }

            internal static StoneId GetStoneId(Stone stone)
            {
                Debug.Assert(stone != null, "stone != null");

                var stoneId = 0;
                stoneId += (byte) stone.Size << 0;
                stoneId += (byte) stone.Surface << 1;
                stoneId += (byte) stone.Color << 2;
                stoneId += (byte) stone.Shape << 3;
                return new StoneId((byte) stoneId);
            }

            public bool Equals(StoneId other)
            {
                return this._id == other._id;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                return obj is StoneId && Equals((StoneId) obj);
            }

            public override int GetHashCode()
            {
                return this._id;
            }

            public static bool operator ==(StoneId left, StoneId right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(StoneId left, StoneId right)
            {
                return !left.Equals(right);
            }
        }
    }
}
