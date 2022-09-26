using Boxes;
using UnityEngine;

namespace Slicers
{
    public class Slicer
    {
        private readonly float _accuracy = 0.1f;
        private InsideSlice _insideSlice;
        private OutsideSlice _outsideSlice;

        public InsideSlice InsideSlice => _insideSlice;
        public OutsideSlice OutsideSlice => _outsideSlice;

        public void Slice(Box currentBox, Box previousBox)
        {
            var positionDifference = currentBox.Transform.position - previousBox.Transform.position;
            if (CheckAccuracy(positionDifference.x) || CheckAccuracy(positionDifference.z))
            {
                Vector3 position = new Vector3(previousBox.Transform.position.x, currentBox.Transform.position.y, previousBox.Transform.position.z);
                _insideSlice = new InsideSlice(position, currentBox.Transform.localScale, currentBox.Material.color);
                
                return;
            }
            
            if (CheckBounds(positionDifference.x, currentBox.Transform.localScale.x) || CheckBounds(positionDifference.z, currentBox.Transform.localScale.z))
            {
                _outsideSlice = new OutsideSlice(currentBox.Transform.position, currentBox.Transform.localScale, currentBox.Material.color);
                return;
            }

            _insideSlice = new InsideSlice(positionDifference, currentBox);
            _outsideSlice = new OutsideSlice(positionDifference, currentBox);
        }

        private bool CheckBounds(float positionDifferenceAxis, float boxAxisScale)
        {
            return Mathf.Abs(positionDifferenceAxis) >= boxAxisScale;
        }

        private bool CheckAccuracy(float offsetAxis)
        {
            return offsetAxis <= _accuracy && offsetAxis > 0;
        }
    }
}