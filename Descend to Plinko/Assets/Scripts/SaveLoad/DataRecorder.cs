using System;
using System.Collections.Generic;
using Assets.Scripts.Gold;
using Assets.Scripts.JsonSaver;
using Assets.Scripts.Shop;
using Assets.Scripts.Shop.Equip;
using Assets.Scripts.Shop.Music;
using Assets.Scripts.Shop.Product;
using Assets.Scripts.Shop.Spawner;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    public class DataRecorder : MonoBehaviour
    {
        [SerializeField] private Bank _bank;
        [SerializeField] private List<Spawner> _spawners;
        [SerializeField] private List<EquipItem> _itemsForEquip;

        private SpawnerDataLoaderAndSaver _spawnerDataLoaderAndSaver = new SpawnerDataLoaderAndSaver();
        
        private Data _data;
        private DataSaverAndLoader _dataSaver = new DataSaverAndLoader();

        public Sprite CurrentBackground => _data.CurrentBackground;
        public AudioClip CurrentMusic => _data.CurrentMusic;
        public long Gold => _data.Gold;

        private void Awake()
        {
            _data = _dataSaver.Load();
            _spawnerDataLoaderAndSaver.LoadSpawnersData(_spawners, _data);


            print($"{_data.CurrentBackground}\n{_data.CurrentMusic}\n{_data.Gold}");
        }

        private void OnEnable()
        {
            for (int i = 0; i < _itemsForEquip.Count; i++)
            {
                if (_itemsForEquip[i] is EquipBackground)
                {
                    EquipBackground equip = (EquipBackground)_itemsForEquip[i];
                    equip.CurrentBackgroundChanged += _data.ChangeCurrentBackground;

                    continue;
                }

                if (_itemsForEquip[i] is EquipMusic)
                {
                    EquipMusic equip = (EquipMusic)_itemsForEquip[i];
                    equip.CurrentMusicChanged += _data.ChangeCurrentMusic;

                    continue;
                }
            }
        }

        private void Start()
        {
            _bank.GoldDecreased += _data.SetGold;
        }

        private void OnDisable()
        {
            _spawnerDataLoaderAndSaver.SaveSpawnersData(_spawners, _data);
            //_dataSaver.Save(_data);
            PlayerPrefs.DeleteAll();

            _bank.GoldDecreased -= _data.SetGold;

            for (int i = 0; i < _itemsForEquip.Count; i++)
            {
                if (_itemsForEquip[i] is EquipBackground)
                {
                    EquipBackground equip = (EquipBackground)_itemsForEquip[i];
                    equip.CurrentBackgroundChanged += _data.ChangeCurrentBackground;

                    continue;
                }

                if (_itemsForEquip[i] is EquipMusic)
                {
                    EquipMusic equip = (EquipMusic)_itemsForEquip[i];
                    equip.CurrentMusicChanged += _data.ChangeCurrentMusic;

                    continue;
                }
            }
        }
    }
}
