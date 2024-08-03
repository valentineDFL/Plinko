using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SceneManage
{
    internal class CoffitientsTextAdaptive : GameAdaptive
    {
        [Header("Text")]
        [SerializeField] private List<TextMeshProUGUI> _textMeshProUGUIs = new List<TextMeshProUGUI>();
        [SerializeField] private CoffitientsAdaptive _coffs;

        private List<GameObject> _zones;

        private void Awake()
        {
            _zones = (List<GameObject>)_coffs.Zones;

            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            for(int i = 0; i < _zones.Count; i++)
            {
                _textMeshProUGUIs[i].transform.position = _zones[i].transform.position;
                SetTextSize(_textMeshProUGUIs[i]);
            }
        }

        private void SetTextSize(TextMeshProUGUI text)
        {
            Camera cam = Camera.main;
            float screenHeightInUnits = cam.orthographicSize * 2;
            float screenHeightInPixels = Screen.height;
            float pixelsPerUnit = screenHeightInPixels / screenHeightInUnits;

            for(int i = 0; i < _zones.Count; i++)
            {
                text.rectTransform.sizeDelta = new Vector2(pixelsPerUnit * _zones[i].transform.localScale.x, pixelsPerUnit * _zones[i].transform.localScale.y);
            }
        }
    }
}
