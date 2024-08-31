using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Gold;
using Assets.Scripts.JsonSaver;
using Assets.Scripts.Shop;

namespace Assets.Scripts.SaveLoad
{
    internal class DataRecorder : MonoBehaviour
    {
        [SerializeField] private Bank _bank;
        [SerializeField] private List<AddItemToShop> _itemsCatalogue;

        private int CatalogueCount => _itemsCatalogue.Count;
        
        [SerializeField] private long _gold;
        [SerializeField] private Image _image;
        [SerializeField] private AudioSource _audioSource;

        private Sprite _currentBackground;
        private AudioClip _currentMusic;

        private JsonDataLoader _jsonDataLoader;
        private JsonDataSaver _jsonDataSaver;
        private Data _data;

        public long Gold => _gold;
        public Sprite CurrentBackground => _currentBackground;
        public AudioClip CurrentMusic => _currentMusic;


        private void Awake()
        {
            _jsonDataLoader = new JsonDataLoader();
            _data = _jsonDataLoader.Load(0, null, null);

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
        }

        private void Start()
        {
            ChangeCurrentBackgroundSubscribe();
            _bank.GoldIncreased += _data.SetGold;
        }

        private void OnDisable()
        {
            _bank.GoldIncreased -= _data.SetGold;
            _jsonDataSaver = new JsonDataSaver();
            _jsonDataSaver.DataSave(_data);

            //PlayerPrefs.DeleteAll();
            ChangeCurrentBackgroundDescribe();
        }

        private void ChangeCurrentBackgroundSubscribe()
        {
            if (CatalogueCount != 0)
            {
                for (int i = 0; i < CatalogueCount; i++)
                {
                    for (int j = 0; j < _itemsCatalogue[i].transform.childCount; j++)
                    {
                        _itemsCatalogue[i].gameObject.transform.GetChild(j).GetComponent<BuyBackground>().CurrentBackgroundChanged += _data.ChangeCurrentBackground;
                    }
                }
            }
            else
                throw new ArgumentNullException("В DataRecorder AddFolder 0");
        }

        private void ChangeCurrentBackgroundDescribe()
        {
            if(_itemsCatalogue != null && CatalogueCount != 0)
            {
                for (int i = 0; i < CatalogueCount; i++)
                {
                    if(_itemsCatalogue[i] != null)
                    {
                        for (int j = 0; j < _itemsCatalogue[i].transform.childCount; j++)
                        {
                            _itemsCatalogue[i].gameObject.transform.GetChild(j).GetComponent<BuyBackground>().CurrentBackgroundChanged -= _data.ChangeCurrentBackground;
                        }
                    }
                }
            }
            else
                throw new ArgumentNullException("В DataRecorder AddFolder Null");

        }
    }
}
