using System;
using System.Collections.Generic;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.JsonSaver
{
    [Serializable]
    internal class Data
    {
        [SerializeField] private long _gold;
        [SerializeField] private Sprite _currentBackground;
        [SerializeField] private AudioClip _currentMusic;

        public long Gold => _gold;
        public Sprite CurrentBackground => _currentBackground;
        public AudioClip CurrentMusic => _currentMusic;

        public Data(long gold, Sprite sprite, AudioClip music)
        {
            _gold = gold;
            _currentBackground = sprite;
            _currentMusic = music;
        }

        public void SetGold(long gold)
        {
            Debug.Log("старый баланс денег: " + _gold);
            _gold = gold;
            Debug.Log("новый баланс денег: " + _gold);
        }

        public void ChangeCurrentBackground(Sprite sprite)
        {
            _currentBackground = sprite;
            Debug.Log("новый задний фон: " + _currentBackground.name);
        }

        public void ChangeCurrentMusic(AudioClip audioClip)
        {
            Debug.Log("старая музыка: " + _currentMusic.name);
            _currentMusic = audioClip;
            Debug.Log("новая музыка: " + _currentMusic.name);
        }
    }
}
