using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipCreator : MonoBehaviour
{
    [SerializeField] private Block _snipPrefab;
    [SerializeField] private Spawner _spawner;

    private Block _currentSnip;


    private void Start()
    {
        _currentSnip = _snipPrefab;
    }


    public void Create(Vector3 snipScale, Block block)
    {
        _currentSnip.Resize(ZeroValueCheck(block.transform.localScale.x, Mathf.Abs(snipScale.x)), ZeroValueCheck(block.transform.localScale.z, Mathf.Abs(snipScale.z)));
        _currentSnip = _spawner.SpawnOnThePoint(_currentSnip, new Vector3(SnipCalculateAxisPosition(snipScale.x, block.transform.localScale.x, block.transform.position.x),
           block.transform.position.y, SnipCalculateAxisPosition(snipScale.z, block.transform.localScale.z, block.transform.position.z)));
        _currentSnip.Material.color = block.Material.color;
    }

    private float ZeroValueCheck(float BlockAxisPosition1, float BlockAxisPosition2)
    {
        if (BlockAxisPosition2 == 0)
            return BlockAxisPosition1;

        return BlockAxisPosition2;
    }

    private float SnipCalculateAxisPosition(float snipAxisScale, float currentBlockAxisScale, float currentBlockAxisPosition)
    {
        if (snipAxisScale == 0)
            return currentBlockAxisPosition;

        return CheckOrientationIndex(snipAxisScale) * (currentBlockAxisScale / 2) + currentBlockAxisPosition + (snipAxisScale / 2);
    }

    private int CheckOrientationIndex(float value)
    {
        return (value < -0.05f) ? -1 : 1;
    }
}
