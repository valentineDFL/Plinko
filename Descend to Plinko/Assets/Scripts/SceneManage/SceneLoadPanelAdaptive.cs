using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SceneManage
{
    internal class SceneLoadPanelAdaptive : GameAdaptive
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            print(Screen.width + " - " + Screen.height + " - " + Camera.main.scaledPixelWidth + " - " + Camera.main.scaledPixelHeight);


            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            _rectTransform.position = Vector3.zero;
            _rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        }
    }
}
