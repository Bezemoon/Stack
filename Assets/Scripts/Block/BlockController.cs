using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockMovement))]
public class BlockController : MonoBehaviour
{
    private BlockMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<BlockMovement>();
    }

    private void Update()
    {
        if (_movement.CurrentSpeed == 0)
            return;

        if (Input.GetMouseButtonDown(0))
            _movement.StopMovement();
    }
}
