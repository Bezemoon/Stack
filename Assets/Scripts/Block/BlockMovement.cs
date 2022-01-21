using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] private  float _speed;

    private Vector3 _target;
    private Vector3 _startPosition;

    public float CurrentSpeed { get; private set; }

    private void Start()
    {
        _startPosition = transform.position;
        _target = SetDirection(transform.position);
        CurrentSpeed = _speed;
    }


    private Vector3 SetDirection(Vector3 position)
    {
        if (Mathf.Abs(position.x) > Mathf.Abs(position.z))
            position.x *= -1;
        else
            position.z *= -1;

        return position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, CurrentSpeed * Time.deltaTime);

        if (transform.position == _target)
            ChangeStartPostion();
    }

    private void ChangeStartPostion()
    {
        _target = _startPosition;
        _startPosition = transform.position;
    }

    public void StopMovement()
    {
        CurrentSpeed = 0;
    }
}
