using Assets.Scripts.Gold;
using Assets.Scripts.JsonSaver;
using Assets.Scripts.Shop;
using Assets.Scripts.Shop.Equip;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.SaveLoad
{
    internal class DataRecorder : MonoBehaviour
    {
        [SerializeField] private Bank _bank;
        [SerializeField] private AddBackgroundsToShop _backgroundsFolder;
        private List<BuyBackground> _buyBackgrounds;


        [SerializeField] private long _gold;
        [SerializeField] private Image _image;
        [SerializeField] private AudioSource _audioSource;
        private Sprite _currentBackground;
        private AudioClip _currentMusic;

        private JsonDataLoader _jsonDataLoader;
        private JsonDataSaver _jsonDataSaver;
        private Data _data;

        private Dictionary<string, bool> _catalogueItemsStatus = new Dictionary<string, bool>();

        public long Gold => _gold;
        public Sprite CurrentBackground => _currentBackground;
        public AudioClip CurrentMusic => _currentMusic;

        public IReadOnlyDictionary<string, bool> CatalogueItemsStatus => (Dictionary<string, bool>)_catalogueItemsStatus;

        private void Awake()
        {
            _currentMusic = _audioSource.clip;

            _jsonDataLoader = new JsonDataLoader(_gold, _currentBackground, _currentMusic, _catalogueItemsStatus);
            _data = _jsonDataLoader.Load();

            if(_data != null)
            {
                _currentBackground = _data.CurrentBackground;
            }
            else
            {
                _currentBackground = _image.sprite;
            }


            _gold = _data.Gold;
            _currentBackground = _data.CurrentBackground;
            _currentMusic = _data.CurrentMusic;
            _catalogueItemsStatus = _data.CatalogueItemsStatus;

            print("goldOnLoad: " + _data.CurrentBackground);
        }

        private void Start()
        {
            Subscribe();
            _bank.GoldIncreased += _data.SetGold;
        }

        private void OnDisable()
        {
            _bank.GoldIncreased -= _data.SetGold;

            _jsonDataSaver = new JsonDataSaver();
            print("goldOnDisable: " + _data.Gold);
            _jsonDataSaver.DataSave(_data);

            Describe();
        }

        private void Subscribe()
        {
            for(int i = 0; i < _backgroundsFolder.gameObject.transform.childCount; i++)
            {
                _backgroundsFolder.gameObject.transform.GetChild(i).GetComponent<BuyBackground>().CurrentBackgroundChanged += _data.ChangeCurrentBackground;
            }
        }

        private void Describe()
        {
            print("Попытка отписки");
            for (int i = 0; i < _backgroundsFolder.gameObject.transform.childCount; i++)
            {
                _backgroundsFolder.gameObject.transform.GetChild(i).GetComponent<BuyBackground>().CurrentBackgroundChanged -= _data.ChangeCurrentBackground;
            }
        }
    }
}
