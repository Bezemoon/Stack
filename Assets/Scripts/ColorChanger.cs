using UnityEngine;

namespace Scripts
{
    public class ColorChanger
    {
        private Color _primaryColor;
        private Color _targetColor;
        private float _tParameter;

        public ColorChanger()
        {
            _primaryColor = GenerateColor();
            _targetColor = GenerateColor();
            _tParameter = 0;
        }

        private Color GenerateColor()
        {
            return new Color(GetValue(), GetValue(), GetValue());
        }

        private float GetValue()
        {
            return Random.Range(0, 256) / 255f;
        }

        public Color GetColor()
        {
            _tParameter += 0.05f;
            if (_tParameter >= 1)
            {
                ChangeTargetColor();
                _tParameter = 0;
            }
            
            return Color.Lerp(_primaryColor, _targetColor, _tParameter); 
        }

        private void ChangeTargetColor()
        {
            _primaryColor = _targetColor;
            _targetColor = GenerateColor();
        }

        public Color GetColorMatch(Color color)
        {
            float hue;
            float saturation;
            float value;
            Color.RGBToHSV(color, out hue,out saturation, out value);
            Debug.Log(hue);
             hue = IncreaseHue(hue);

            return Color.HSVToRGB(hue, saturation, value, true);
        }

        private float IncreaseHue(float hue)
        {
            hue += .25f;

            if (hue >= 1)
                hue -= 1;

            return hue;
        }
    }
}