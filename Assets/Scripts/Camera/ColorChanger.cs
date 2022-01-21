using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Material _material;

    private Color _primaryColor;
    private Color _targetColor;
    private float _tParametr;

    private Color GenerateColor()
    {
        return new Color(Random.Range(0, 256) / 255.0f, Random.Range(0, 256) / 255.0f, Random.Range(0, 256) / 255.0f);
    }

    private void Awake()
    {
        _primaryColor = GenerateColor();
        _material.color = _primaryColor;
        _targetColor = GenerateColor();
    }

    public Color CreateNewColor()
    {
        _tParametr += 0.05f;

        if(_tParametr >= 1)
        {
            _primaryColor = _targetColor;
            _targetColor = GenerateColor();
            _tParametr = 0;
        }

        return Color.Lerp(_primaryColor, _targetColor, _tParametr); 
    }
}
