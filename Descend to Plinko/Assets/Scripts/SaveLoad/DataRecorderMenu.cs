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
    public class DataRecorderMenu : DataRecorder
    {
        [SerializeField] private List<Spawner> _spawners;
        [SerializeField] private List<EquipItem> _itemsForEquip;
        [SerializeField] private SpawnerDataLoaderAndSaver _spawnerDataLoaderAndSaver = new SpawnerDataLoaderAndSaver();
        private ShopBank _shopBank;


        private void Awake()
        {
            Data = DataSaver.Load();
            _spawnerDataLoaderAndSaver.LoadSpawnersData(_spawners, Data);

            _shopBank = (ShopBank)Bank;

            print($"{Data.CurrentBackground}\n{Data.CurrentMusic}\n{Data.Gold}");
        }

        private void Start()
        {
            _shopBank.GoldChanged += Data.SetGold;
        }

        private void OnEnable()
        {
            for (int i = 0; i < _itemsForEquip.Count; i++)
            {
                if (_itemsForEquip[i] is EquipBackground)
                {
                    EquipBackground equip = (EquipBackground)_itemsForEquip[i];
                    equip.CurrentBackgroundChanged += Data.ChangeCurrentBackground;

                    continue;
                }

                if (_itemsForEquip[i] is EquipMusic)
                {
                    EquipMusic equip = (EquipMusic)_itemsForEquip[i];
                    equip.CurrentMusicChanged += Data.ChangeCurrentMusic;

                    continue;
                }
            }
        }

        private void OnDisable()
        {
            _spawnerDataLoaderAndSaver.SaveSpawnersData(_spawners, Data);
            // DataSaver.Save(Data);

            PlayerPrefs.DeleteAll();

            _shopBank.GoldChanged -= Data.SetGold;

            print($"{Data.CurrentBackground}\n{Data.CurrentMusic}\n{Data.Gold}");

            for (int i = 0; i < _itemsForEquip.Count; i++)
            {
                if (_itemsForEquip[i] is EquipBackground)
                {
                    EquipBackground equip = (EquipBackground)_itemsForEquip[i];
                    equip.CurrentBackgroundChanged += Data.ChangeCurrentBackground;

                    continue;
                }

                if (_itemsForEquip[i] is EquipMusic)
                {
                    EquipMusic equip = (EquipMusic)_itemsForEquip[i];
                    equip.CurrentMusicChanged += Data.ChangeCurrentMusic;

                    continue;
                }
            }
        }
    }
}
