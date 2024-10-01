using System;
using Assets.Scripts.Shop.Equip.EquipVerification;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Shop.Equip;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

namespace Assets.Scripts.Shop.SoundShop
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    internal class PlayDemoSound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Sprite _buttonSpriteStop;

        private AudioSource _audioSource;
        private Button _button;
        private Sprite _buttonSpriteStart;

        private IUseVerification _usedMusicVerificator;
        private UnEquipperUsedMusic _equippedMusicPauser;

        public bool IsPlaying => _audioSource.isPlaying;

        private bool _pointerClick;
        private float _playTime;

        public void Init(Sprite stopIconButton, IUseVerification usedMusicVerificator, UnEquipperUsedMusic unEquipper)
        {
            _buttonSpriteStop = stopIconButton;
            _usedMusicVerificator = usedMusicVerificator;
            _equippedMusicPauser = unEquipper;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);

            _buttonSpriteStart = _button.image.sprite;
        }

        private void OnDisable()
        {
            if (_button.image.sprite == _buttonSpriteStop)
            {
                _button.image.sprite = _buttonSpriteStart;
                _equippedMusicPauser.SwitchEquippedMusic();
            }
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void Update()
        {
            if (_audioSource.isPlaying)
            {
                _playTime += Time.deltaTime;

                if (_pointerClick)
                {
                    _pointerClick = false;
                    _playTime = 0;
                }

                if (_playTime >= _audioSource.clip.length)
                {
                    _playTime = 0;
                    
                    SwitchPlaying();
                }
            }
        }

        public void OnPointerDown(PointerEventData poi)
        {
            _pointerClick = true;
        }

        public void OnPointerUp(PointerEventData poi)
        {
            _pointerClick = false;
        }

        private void OnButtonClick()
        {
            _usedMusicVerificator.UnUse();

            SwitchPlaying();
        }

        public void SwitchPlaying()
        {
            if (_audioSource.isPlaying)
            {
                _playTime = 0;
                _audioSource.Stop();
                _button.image.sprite = _buttonSpriteStart;
            }
            else
            {
                _audioSource.Play();
                _button.image.sprite = _buttonSpriteStop;
            }
            _equippedMusicPauser.SwitchEquippedMusic();
        }
    }
}
