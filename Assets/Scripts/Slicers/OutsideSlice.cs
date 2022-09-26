using Boxes;
using UnityEngine;

namespace Slicers
{
    public class OutsideSlice: Slice
    {
        private readonly float _accuracy = 0.1f;

        public OutsideSlice(Vector3 position, Vector3 scale, Color color) : base(position, scale, color)
        {
        }
        
        public OutsideSlice(Vector3 positionDifference, Box box) : base(positionDifference, box)
        {
            SetPosition(positionDifference, box);
            SetScale(box.Transform.localScale, positionDifference);
        }

        private void SetPosition(Vector3 positionDifference, Box box)
        {
            Position.x = CalculateSnipAxisPosition(box.Transform.localScale.x, box.Transform.position.x, positionDifference.x);
            Position.y = box.Transform.position.y;
            Position.z = CalculateSnipAxisPosition(box.Transform.localScale.z, box.Transform.position.z, positionDifference.z);
        }
        
        private float CalculateSnipAxisPosition(float boxAxisScale, float boxAxisPosition, float positionDifferenceAxis)
        {
            if (positionDifferenceAxis == 0)
                return boxAxisPosition;
            
            return GetValueBySnipAxisScale(positionDifferenceAxis) * boxAxisScale / 2f + boxAxisPosition - positionDifferenceAxis / 2f;
        }

        private float GetValueBySnipAxisScale(float positionDifferenceAxis)
        {
            return positionDifferenceAxis <  -_accuracy ? -1 : 1;
        }

        private void SetScale(Vector3 boxScale, Vector3 positionDifference)
        {
            Scale.x = GetNonZeroValue(Mathf.Abs(positionDifference.x), boxScale.x);
            Scale.y = boxScale.y;
            Scale.z = GetNonZeroValue(Mathf.Abs(positionDifference.z), boxScale.z);
        }
        
        private float GetNonZeroValue(float value1, float value2)
        {
            if (value1 == 0)
                return value2;

            return value1;
        }
    }
}