using UnityEngine;

namespace Extensions
{
    public static class TransformExtension
    {
        public static void Resize(this Transform transform, Vector3 scale)
        {
            transform.localScale = scale;
        }
    }
}