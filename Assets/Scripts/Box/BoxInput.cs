using System;
using UnityEngine;

namespace Boxes
{
    public class BoxInput : MonoBehaviour
    {
        private static BoxInput _instance;

        public static BoxInput Instance => _instance;
    
        public event Action BoxSpawned;
        public event Action MovementStopped;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                BoxSpawned?.Invoke();
                MovementStopped?.Invoke();
            }
        }
    }   
}
