using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.SceneManage
{
    internal class MetronomeSpawnerAdaptive : GameAdaptive
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private float _divider = 3;

        private Transform _metronomeSpawner;
        private Image _image;

        private Vector2 _nedeedPos;
        private Vector2 _nedeedSize;

        private void Awake()
        {
            _image = _menuPanel.GetComponent<Image>();
            _metronomeSpawner = GetComponent<Transform>();

            float firstYHalf = _image.rectTransform.rect.height / 2;
            float secondYHalf = Screen.height / CameraSize.Height;
            float y = _menuPanel.transform.position.y - (firstYHalf / secondYHalf);

            _nedeedPos = new Vector2(_menuPanel.transform.position.x, y);
            _nedeedSize = new Vector2(CameraSize.Width / _divider, CameraSize.Width / _divider);

            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            _metronomeSpawner.transform.position = _nedeedPos;
            _metronomeSpawner.transform.localScale = _nedeedSize;
        }
    }
}
