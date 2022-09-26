using System;
using System.Collections;
using Boxes;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _transform;
    [SerializeField] private BoxSpawner _boxSpawner;

    private readonly float _borderHeight = 0.5f;

    public event Action<Color> BackgroundColorChanged;

    private void Start()
    {
        BackgroundColorChanged?.Invoke(_boxSpawner.CurrentBox.Material.color);
    }
    
    private void OnEnable()
    {
        _boxSpawner.CameraMoved += OnCameraMove;
    }

    private void OnDisable()
    {
        _boxSpawner.CameraMoved -= OnCameraMove;
    }

    private void OnCameraMove(Box box)
    {
        if(GetViewportPoint(box.Transform.position) >= _borderHeight)
        {
            StartCoroutine(CameraMoving(box));
            BackgroundColorChanged?.Invoke(box.Material.color);
        }
    }

    IEnumerator CameraMoving(Box box)
    {
        var viewportPoint = GetViewportPoint(box.Transform.position);
        while (viewportPoint >= _borderHeight)
        {
            Move();
            viewportPoint = GetViewportPoint(box.Transform.position);
            yield return null;
        }
    }

    private float GetViewportPoint(Vector3 boxPosition)
    {
        return _camera.WorldToViewportPoint(new Vector3(0, boxPosition.y, 0)).y;
    }

    public void Move()
    {
        Vector3 position = transform.position;
        position.y += Time.deltaTime;
        _transform.position = position;
    }
}
