using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop.SoundShop
{
    [RequireComponent(typeof(Button))]
    internal class PlayDemoSound : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] int _delayWaitInSec;
        [SerializeField] private Sprite _buttonSpriteStop;

        private const int _secondsMultiplyerCoff = 1000;
        private AudioSource _audioSource;
        private Button _button;
        private Sprite _buttonSpriteStart;

        public bool IsPlaying => _audioSource.isPlaying;

        private void Awake()
        {
            _audioSource = GetComponentInParent<AudioSource>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnStartButtonClick);

            _buttonSpriteStart = _button.image.sprite;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        public async void OnStartButtonClick()
        {
            _audioSource?.Play();
            _button.image.sprite = _buttonSpriteStop;
            
            await Task.Delay(_delayWaitInSec * _secondsMultiplyerCoff);

            CancelPlaying();            
        }

        public void CancelPlaying()
        {
            if (_audioSource.isPlaying)
            {
                _audioSource?.Stop();
                _button.image.sprite = _buttonSpriteStart;
            }
        }
    }
}
