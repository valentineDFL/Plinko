using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.SceneManage
{
    internal class MenuPanelAdaptive : GameAdaptive
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _background;

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

        protected override void SetAdaptive()
        {
            float screenHeight = Screen.height;
            float space = screenHeight - _background.GetComponent<Image>().rectTransform.rect.height;
            float nedeedYScale = space / (screenHeight / _height);

            _menuPanel.transform.localScale = new Vector2(_width, nedeedYScale);

            float halfYSize = _menuPanel.transform.localScale.y / 2;
            _menuPanel.transform.position = new Vector2(0, (_height / 2) - halfYSize); 
        }
    }
}
