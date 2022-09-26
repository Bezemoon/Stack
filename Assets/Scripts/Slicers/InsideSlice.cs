using Boxes;
using UnityEngine;

namespace Slicers
{
    public class InsideSlice: Slice
    {
        public InsideSlice(Vector3 position, Vector3 scale, Color color) : base(position, scale, color)
        {
        }
        
        public InsideSlice(Vector3 positionDifference, Box box) : base(positionDifference, box)
        {
            SetPosition(box.Transform.position, positionDifference);
            SetScale(box.Transform.localScale, positionDifference);
        }

        private void SetScale(Vector3 boxScale, Vector3 positionDiffernce)
        {
            Scale.x = boxScale.x - Mathf.Abs(positionDiffernce.x);
            Scale.y = boxScale.y;
            Scale.z = boxScale.z - Mathf.Abs(positionDiffernce.z);
        }

        private void SetPosition(Vector3 boxPosition, Vector3 positionDifference)
        {
            Position.x = CalculateOffset(boxPosition.x, positionDifference.x);
            Position.y = boxPosition.y;
            Position.z = CalculateOffset(boxPosition.z, positionDifference.z);
        }
        
        private float CalculateOffset(float currentOffset, float scaleOffset)
        {
            return currentOffset - scaleOffset / 2f;
        }
    }
}