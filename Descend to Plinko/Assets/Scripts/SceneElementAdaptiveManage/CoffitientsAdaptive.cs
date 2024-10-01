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


        public IReadOnlyList<GameObject> Zones
        {
            get { return _zones; }
        }

        private void Awake()
        {
            print(Screen.safeArea.yMin / (Screen.height / CameraSize.Height));

            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            float width2 = (0 * CameraSize.Width) / 100;
            float w = 0;
            int count = 0;

            float yPos = Screen.safeArea.yMin / (Screen.height / CameraSize.Height);

            for (int i = _zones.Count - 1; i >= 0; i--)
            {
                _zones[count].transform.localScale = new Vector2(CameraSize.Width / _zones.Count, _zones[count].transform.localScale.y);
                _zones[count].transform.position = new Vector2(width2 - (CameraSize.Width / 2) + (_zones[count].transform.localScale.x / 2) + w, (-CameraSize.Height / 2 + (_zones[count].transform.localScale.y / 2)) + yPos);
                w += CameraSize.Width / _zones.Count;
                count++;
            }
        }
    }
}
