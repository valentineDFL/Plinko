using Assets.Scripts.Gold;
using Assets.Scripts.JsonSaver;
using Assets.Scripts.Shop.Equip;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    internal class DataRecorder : MonoBehaviour
    {
        [SerializeField] private Bank _bank;
        [SerializeField] private EquipBackground _equipBackground;

        [SerializeField] private long _gold;
        private Sprite _currentBackground;
        private AudioClip _currentMusic;

        private JsonDataLoader _jsonDataLoader;
        private JsonDataSaver _jsonDataSaver;
        private Data _data;

        private Dictionary<string, bool> _catalogueItemsStatus;

        public long Gold => _gold;
        public Sprite CurrentBackground => _currentBackground;
        public AudioClip CurrentMusic => _currentMusic;

        public IReadOnlyDictionary<string, bool> CatalogueItemsStatus => (Dictionary<string, bool>)_catalogueItemsStatus;

        private void Awake()
        {
            _jsonDataLoader = new JsonDataLoader(_gold, _currentBackground, _currentMusic, _catalogueItemsStatus);
            _data = _jsonDataLoader.Load();

            _gold = _data.Gold;
            _currentBackground = _data.CurrentBackground;
            _currentMusic = _data.CurrentMusic;
            _catalogueItemsStatus = _data.CatalogueItemsStatus;

            print("goldOnLoad: " + _data.Gold);
        }

        public void OnEnable()
        {
            _bank.GoldIncreased += _data.SetGold;
        }

        public void OnDisable()
        {
            _bank.GoldIncreased -= _data.SetGold;

            _jsonDataSaver = new JsonDataSaver();
            print("goldOnDisable: " + _data.Gold);
            _jsonDataSaver.DataSave(_data);
        }
    }
}
