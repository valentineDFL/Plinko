using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Gold;
using Assets.Scripts.Shop.Equip;
using Assets.Scripts.Shop.Spawner;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    internal class DataRecorderGame : DataRecorder
    {
        private GameBank _gameBank;

        private void Awake()
        {
            Data = DataSaver.Load();

            print($"{Data.CurrentBackground}\n{Data.CurrentMusic}\n{Data.Gold}");
        }

        private void Start()
        {
            _gameBank = (GameBank)Bank;
            _gameBank.GoldChanged += Data.SetGold;
        }

        private void OnDisable()
        {
            _gameBank.GoldChanged -= Data.SetGold;

            // DataSaver.Save(Data);
        }
    }
}
