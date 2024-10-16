﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System;

namespace Assets.Scripts.Settings.AudioSettings
{
    internal class HorizontalScroller : MonoBehaviour, IPointerMoveHandler
    {
        public event Action OnScrollerMoved;

        [SerializeField] private Image _foregroundImage;
        private AudioViewBorderCalculator _audioLvlCalculator;

        private Image _scroller;

        private void Awake()
        {
            _audioLvlCalculator = GetComponentInParent<AudioViewBorderCalculator>();
            _scroller = _audioLvlCalculator.Scroller;
        }

        public void OnPointerMove(PointerEventData poi)
        {
            Vector2 newPos = new Vector2(Mathf.Clamp(poi.position.x, _audioLvlCalculator.MaxLeft.x, _audioLvlCalculator.MaxRight.x), _audioLvlCalculator.MaxRight.y);

            print(_scroller.rectTransform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(poi.position)));


            //if(poi.position.x - Screen.width != newPos.x)
            //{

            //OnScrollerMoved.Invoke();
            //    _foregroundImage.fillAmount = _audioLvlCalculator.NormalizeSoundValue;
            //    _scroller.rectTransform.localPosition = _scroller.rectTransform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            //}
        }
    }
}
