using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SceneManage
{
    internal class StaticSirclesAdaptive : GameAdaptive
    {
        [SerializeField] private List<GameObject> _staticBalls = new List<GameObject>();
        [SerializeField] private MetronomeSpawnerAdaptive _metronomeSpawnerAdaptive;
        private Vector2 _startPos;

        private float _width;
        private float _height;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _height = 2f * _camera.orthographicSize;
            _width = _height * _camera.aspect;

            SetAdaptive();
        }

        private void Start()
        {
            //Vector2 scale = new Vector2(_metronomeSpawnerAdaptive.transform.localScale.x / 4, _metronomeSpawnerAdaptive.transform.localScale.y);
            //print(scale);
            //Vector2 left = new Vector2(_metronomeSpawnerAdaptive.transform.position.x - scale.x, _metronomeSpawnerAdaptive.transform.position.y - scale.y);
            //print(_metronomeSpawnerAdaptive.transform.position + " - " + _metronomeSpawnerAdaptive.transform.localScale + " - " + scale);

            //_startPos = left;
            //this.transform.position = left;
        }

        protected override void SetAdaptive()
        {
            for(int i = 0; i < _staticBalls.Count; i++)
            {
                //_staticBalls[i].transform.position = _startPos;
            }
        }
    }
}
