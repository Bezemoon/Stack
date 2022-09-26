using Boxes;
using UnityEngine;

namespace Slicers
{
    public abstract class Slice
    {
        protected Vector3 Position;
        protected Vector3 Scale;
        protected Color Color;

        public Vector3 SlicePosition => Position;
        public Vector3 SliceScale => Scale;
        public Color SliceColor => Color;

        public Slice(Vector3 position, Vector3 scale, Color color)
        {
            Position = position;
            Scale = scale;
            Color = color;
        }

        public Slice(Vector3 positionDifference, Box _box)
        {
            Color = _box.Material.color;
        }
    }
}