using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private CameraMovement _cameraMovement;

    private ColorChanger _colorChanger;

    private void Awake()
    {
        _colorChanger = new ColorChanger();
    }

    private void OnEnable()
    {
        _cameraMovement.BackgroundColorChanged += OnBackgroundColorChange;
    }

    private void OnDisable()
    {
        _cameraMovement.BackgroundColorChanged -= OnBackgroundColorChange;
    }

    private void OnBackgroundColorChange(Color color)
    {
        Debug.Log(color);
        Debug.Log(_colorChanger.GetColorMatch(color));
        _image.color = _colorChanger.GetColorMatch(color);
    }
}
