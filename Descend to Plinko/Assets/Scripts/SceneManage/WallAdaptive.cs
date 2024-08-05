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

        private void Awake()
        {

            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            float pos = (CameraSize.Width / 2) + _leftWall.transform.localScale.x / 2;

            _leftWall.transform.localScale = new Vector2(1, CameraSize.Height);
            _leftWall.transform.position = new Vector2(-pos, 0);

            _leftWall.transform.localScale = _leftWall.transform.localScale;
            _rightWall.transform.position = new Vector2(pos, 0);
        }
    }
}
