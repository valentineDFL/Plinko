using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SceneManage
{
    internal class CoffitientsAdaptive : GameAdaptive
    {
        [SerializeField] private List<GameObject> _zones = new List<GameObject>();
        private float _width;
        private float _height;

        public IReadOnlyList<GameObject> Zones
        {
            get { return _zones; }
        }

        private void Awake()
        {
            Camera camera = Camera.main;
            _height = 2f * camera.orthographicSize;
            _width = _height * camera.aspect;

            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            float width2 = (0 * _width) / 100;
            float w = 0;
            int count = 0;

            for (int i = _zones.Count - 1; i >= 0; i--)
            {
                _zones[count].transform.localScale = new Vector2(_width / _zones.Count, _zones[count].transform.localScale.y);
                _zones[count].transform.position = new Vector2(width2 - (_width / 2) + (_zones[count].transform.localScale.x / 2) + w, -_height / 2 + (_zones[count].transform.localScale.y / 2));
                w += _width / _zones.Count;
                count++;
            }
        }
    }
}
