using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.JsonSaver
{
    [Serializable]
    internal class Data
    {
        [SerializeField] private long _gold;
        [SerializeField] private Sprite _currentBackground;
        [SerializeField] private AudioClip _currentMusic;
        [SerializeField] private Dictionary<string, bool> _catalogueItemsStatus;
        [SerializeField] private Dictionary<string, string> _catalogueItemsPriceCaption;

        public long Gold => _gold;
        public Sprite CurrentBackground => _currentBackground;
        public AudioClip CurrentMusic => _currentMusic;
        public Dictionary<string, bool> CatalogueItemsStatus => _catalogueItemsStatus;

        public Data(long gold, Sprite sprite, AudioClip music, Dictionary<string, bool> catalogueItemsStatus)
        {
            _gold = gold;
            _currentBackground = sprite;
            _currentMusic = music;
            _catalogueItemsStatus = catalogueItemsStatus;
        }

        public void SetGold(long gold)
        {
            _gold = gold;
        }

        public void ChangeCurrentBackground(Sprite sprite)
        {
            _currentBackground = sprite;
        }

        public void ChangeCurrentMusic(AudioClip audioClip)
        {
            _currentMusic = audioClip;
        }

        public void ChangeItemBuyStatus(string key, bool status)
        {
            if (_catalogueItemsStatus.ContainsKey(key))
            {
                _catalogueItemsStatus[key] = status;
            }
        }

        public void AddNewStatus(string keyName, bool status)
        {
            if (!_catalogueItemsStatus.ContainsKey(keyName))
            {
                _catalogueItemsStatus.Add(keyName, status);
            }
        }
    }
}
