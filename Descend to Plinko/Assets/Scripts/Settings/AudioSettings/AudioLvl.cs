using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Settings.AudioSettings
{
    internal class AudioLvlController : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> _audio = new List<AudioSource>();
        [SerializeField] private HorizontalScroller _horizontalScroller;
        private AudioViewBorderCalculator _volumeValueContainer;

        private void OnEnable()
        {
            _volumeValueContainer = GetComponent<AudioViewBorderCalculator>();
            _horizontalScroller.OnScrollerMoved += SetAudioLvl;
        }

        private void OnDisable()
        {
            _horizontalScroller.OnScrollerMoved -= SetAudioLvl;

            PlayerPrefs.SetFloat(Keys.AmountSoundLvl, _volumeValueContainer.NormalizeSoundValue);
        }

        public void SetAudioLvl()
        {
            for (int i = 0; i < _audio.Count; i++)
            {
                //print(_audio[i].name);
                _audio[i].volume = _volumeValueContainer.NormalizeSoundValue;
            }
        }
    }
}
