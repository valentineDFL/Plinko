using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SceneManage
{
    internal class WallAdaptive : GameAdaptive
    {
        [SerializeField] private GameObject _leftWall;
        [SerializeField] private GameObject _rightWall;
        private float _width;
        private float _height;

        private void Awake()
        {
            Camera camera = Camera.main;
            _height = 2f * camera.orthographicSize;
            _width = _height * camera.aspect;

            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            float pos = (_width / 2) + _leftWall.transform.localScale.x / 2;

            _leftWall.transform.localScale = new Vector2(1, _height);
            _leftWall.transform.position = new Vector2(-pos, 0);

            _leftWall.transform.localScale = _leftWall.transform.localScale;
            _rightWall.transform.position = new Vector2(pos, 0);
        }
    }
}
