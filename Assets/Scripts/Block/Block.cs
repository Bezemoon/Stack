using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private ParticleController _particleController;

    private Material _material;

    public Material Material => _material;
    public ParticleController ParticleController => _particleController;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void Resize(float scaleX, float scaleZ)
    {
        transform.localScale = new Vector3(scaleX, transform.localScale.y, scaleZ); ;
    }


    public void Relocate(float scaleX, float scaleZ)
    {
        transform.position = new Vector3(CalculateValue(transform.position.x, scaleX), transform.position.y, CalculateValue(transform.position.z, scaleZ));
    }

    private float CalculateValue(float axisPosition, float axisScale)
    {
        return axisPosition - (axisScale / 2);
    }
}
