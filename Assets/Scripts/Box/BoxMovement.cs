using Interfaces;
using Scripts;
using UnityEngine;

namespace Boxes
{
    public class BoxMovement: MonoBehaviour, IMovable
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistance;

        private Guide _guide;
        private float _currentSpeed;
        private Vector3 _currentDirection;
        private Vector3 _startPosition;
        
        private void Start()
        {
            SetStartPosition(transform.position);
            
            _guide = new Guide();
            _currentDirection = _guide.GetDirection(_startPosition);
            _currentSpeed = _speed;
            
            BoxInput.Instance.MovementStopped += OnStop;
        }
        
        private void SetStartPosition(Vector3 position)
        {
            _startPosition = position;
        }
        
        private void OnStop()
        {
            enabled = false;
            BoxInput.Instance.MovementStopped -= OnStop;
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.position += _currentDirection * _currentSpeed * Time.deltaTime;
            
            if (GetAbsoluteDistance() >= _maxDistance)
            {
                SetStartPosition(transform.position);
                ChangeDirection();
            }
        }

        private float GetAbsoluteDistance()
        {
            return Mathf.Abs(Vector3.Distance(_startPosition, transform.position));
        }

        private void ChangeDirection()
        {
            _currentDirection *= -1;
        }
    }
}