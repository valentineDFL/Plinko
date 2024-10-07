using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Settings.AudioSettings
{
    internal class AudioViewBorderCalculator : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _scroller;
        private float _offset = 0.4f;

        private AudioNormalizePositionCalculator _normalizedPositionCalculator = new AudioNormalizePositionCalculator();

        private Vector2 _maxLeft;
        private Vector2 _maxRight;

        public Image Scroller => _scroller;

        public Vector2 MaxLeft => _maxLeft;
        public Vector2 MaxRight => _maxRight;

        public float NormalizeSoundValue => _normalizedPositionCalculator.CalculatePositionPercent(_maxLeft.x, _maxRight.x, _scroller.rectTransform.localPosition.x);

        private void Awake()
        {
            Image image = _backgroundImage;

            float offset = _scroller.rectTransform.rect.width * _offset;

            print(offset + " - " + _scroller.rectTransform.rect.width + " - " + _offset);
            float nedeedSize = image.rectTransform.rect.width - (image.rectTransform.rect.width / 2);
            nedeedSize -= offset;

            _maxLeft = new Vector2(-nedeedSize, image.rectTransform.localPosition.y);
            _maxRight = new Vector2(nedeedSize, image.rectTransform.localPosition.y);
        }
    }
}
