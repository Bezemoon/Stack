using UnityEngine;

namespace Scripts
{
    public class Guide
    { 
        public Vector3 GetDirection(Vector3 startPosition)
        {
            Vector3 direction = Vector3.right;
        
            if(Mathf.Abs(startPosition.z) > Mathf.Abs(startPosition.x))
                direction = Vector3.forward;

            return direction;
        }

    }   
}
