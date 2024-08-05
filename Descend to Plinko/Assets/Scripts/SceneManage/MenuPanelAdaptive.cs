using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.SceneManage
{
    internal class MenuPanelAdaptive : GameAdaptive
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _background;

        private void Awake()
        {
            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            float screenHeight = Screen.height;
            float space = screenHeight - _background.GetComponent<Image>().rectTransform.rect.height;
            float nedeedYScale = space / (screenHeight / CameraSize.Height);

            _menuPanel.transform.localScale = new Vector2(CameraSize.Width, nedeedYScale);

            float halfYSize = _menuPanel.transform.localScale.y / 2;
            _menuPanel.transform.position = new Vector2(0, (CameraSize.Height / 2) - halfYSize); 
        }
    }
}
