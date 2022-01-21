using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Point[] _points;
    private Vector3 _currentPoint;
    private int _currentIndex;

    private void Awake()
    {
        _points = GetComponentsInChildren<Point>();
    }

    private void SetSpawnPoint(Vector3 blockPosition)
    {
        _currentPoint = new Vector3(_points[_currentIndex].transform.position.x + blockPosition.x , _points[_currentIndex].transform.position.y, _points[_currentIndex].transform.position.z + blockPosition.z);
    }

    public Block CreateSpawn(Block original)
    {
        SetSpawnPoint(original.transform.position);
        IncreaseIndex();
        MoveUp();
        return SpawnOnThePoint(original, _currentPoint);
    }

    public Block SpawnOnThePoint(Block original, Vector3 point)
    {
        return Instantiate(original, point, Quaternion.identity);
    }

    private void IncreaseIndex()
    {
        _currentIndex++;

        if (_currentIndex > _points.Length - 1)
            _currentIndex = 0;

    }

    private void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }


}
