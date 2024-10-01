using System;
using System.Collections.Generic;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop;
using Assets.Scripts.Shop.Spawner;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.JsonSaver
{
    [Serializable]
    public class Data
    {
        [SerializeField] private long _gold;
        [SerializeField] private Sprite _currentBackground;
        [SerializeField] private AudioClip _currentMusic;
        [SerializeField] private List<SpawnerData> _spawnerData = new List<SpawnerData>();

        public long Gold => _gold;
        public Sprite CurrentBackground => _currentBackground;
        public AudioClip CurrentMusic => _currentMusic;

        public IReadOnlyList<SpawnerData> SpawnerData => _spawnerData;

        public void SetGold(long gold)
        {
            if (gold > 0)
                _gold = gold;
            else
                throw new Exception("Gold non positive number: " + nameof(SetGold));
        }

        public void ChangeCurrentBackground(Sprite sprite)
        {
            if(_currentBackground != sprite)
                _currentBackground = sprite;
            Debug.Log("новый задний фон: " + _currentBackground.name);
        }

        public void ChangeCurrentMusic(AudioClip audioClip)
        {
            if (_currentMusic != audioClip)
                _currentMusic = audioClip;
            Debug.Log("новая музыка: " + _currentMusic.name);
        }

        public void AddSpawnerData()
        {
            _spawnerData.Add(new SpawnerData());
        }
    }
}
