using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]  private Camera _camera;
    [SerializeField] private GameManager _manager;

    private float elapsedTime;
    private void Update()
    {
        if (_camera.WorldToViewportPoint(new Vector3(0, _manager.CurrentBlock.transform.position.y, 0)).y >= 0.5f)
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
    }
}
