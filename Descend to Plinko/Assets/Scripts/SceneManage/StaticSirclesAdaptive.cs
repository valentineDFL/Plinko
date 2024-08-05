using System;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SceneManage
{
    internal class StaticSirclesAdaptive : GameAdaptive
    {
        [SerializeField] private List<GameObject> _staticBalls = new List<GameObject>();

        [SerializeField] private MetronomeSpawnerAdaptive _metronomeSpawnerAdaptive;
        [SerializeField] private GameAdaptive _panel;
        
        private Vector2 _startPos;

        private float _width;
        private float _height;

        private float _yStep;
        private float _xStep;

        private void Awake()
        {
            _height = CameraSize.Height;
            _width = CameraSize.Width;
            _height -= _panel.transform.localScale.y;
        }

        private void Start()
        {
            Bounds scale = _metronomeSpawnerAdaptive.GetComponent<SpriteRenderer>().bounds;
            Vector2 left = new Vector2(_metronomeSpawnerAdaptive.transform.position.x, _metronomeSpawnerAdaptive.transform.position.y - scale.size.y * 2);
            int possitionMultiplyCoff = 2;

            float height = _height / 2;
            float width = _width - _staticBalls[0].transform.localScale.x;

            int maxPinsPerLine = 9;
            int linesCount = 8;

            _xStep = (width / (maxPinsPerLine - 1)) / 2;
            _yStep = height / (linesCount - 1);

            _startPos = new Vector2(left.x - _xStep, left.y);
            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            int line = 2;
            int divider = GetTriangleNum(line) - 1;

            Vector2 vec = _startPos;
            for(int i = 0; i < _staticBalls.Count; i++)
            {
                if(i == divider)
                {
                    line++;
                    divider = GetTriangleNum(line) - 1;

                    _startPos = new Vector2(_startPos.x - _xStep, _startPos.y - _yStep);
                    vec = _startPos;
                }
                _staticBalls[i].transform.position = vec;
                vec += new Vector2(_xStep * 2, 0);
            }
        }

        protected int GetTriangleNum(int preTriangleNum)
        {
            int nextTriangleNum = preTriangleNum * (preTriangleNum + 1) / 2;
            return nextTriangleNum;
        }
    }
}
