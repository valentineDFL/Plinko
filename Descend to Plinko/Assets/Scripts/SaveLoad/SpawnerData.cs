using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    [Serializable]
    public class SpawnerData
    {
        [SerializeField] private float _creationTime = 180;
        [SerializeField] private int _spawnerCapacityCount = 10;

        [SerializeField] private long _spawnerCapacityUpgradePrice = 40;
        [SerializeField] private long _creationTimeUpgradePrice = 90;

        [SerializeField] private int _creationTimeLvl = 1;
        [SerializeField] private int _spawnerCapacityLvl = 1;

        [SerializeField] private bool _isBuying;

        public float CreationTime => _creationTime;
        public int SpawnerCapacityCount => _spawnerCapacityCount;

        public long SpawnerCapacityUpgragePrice => _spawnerCapacityUpgradePrice;
        public long SpawnerCreationTimeUpgradePrice => _creationTimeUpgradePrice;

        public int CreationTimeLvl => _creationTimeLvl;
        public int SpawnerCapacityLvl => _spawnerCapacityLvl;

        public bool IsBuying => _isBuying;

        public void SetSpawnerData(float creationTime, long timeUpgradePrice, int creationLvl, int capacityCount, long capacityUpgradePrice, int capacityLvl, bool isBuying)
        {
            _creationTime = creationTime;
            _creationTimeUpgradePrice = timeUpgradePrice;
            _creationTimeLvl = creationLvl;

            _spawnerCapacityCount = capacityCount;
            _spawnerCapacityUpgradePrice = capacityUpgradePrice;
            _spawnerCapacityLvl = capacityLvl;

            _isBuying = isBuying;
        }
    }
}
