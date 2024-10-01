using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.Shop.Spawner
{
    [CreateAssetMenu(fileName ="Spawner", menuName ="Assets/Spawner", order = 51)]
    public class Spawner : ScriptableObject
    {
        private const int CapacityUpdateOffset = 1;
        private const float TimeDecreaseOffset = 0.5f;

        [SerializeField] private Sprite _spawnerSpawnArrow;
        [SerializeField] private Ball _spawnerBall;

        [SerializeField] private float _creationTime = 180;
        [SerializeField] private int _spawnerCapacityCount = 10;

        [SerializeField] private long _spawnerCapacityUpgradePrice = 40;
        [SerializeField] private long _creationTimeUpgradePrice = 90;

        [SerializeField] private int _creationTimeLvl = 1;
        [SerializeField] private int _spawnerCapacityLvl = 1;

        [SerializeField] private bool _isBuying;

        public Ball Ball => _spawnerBall;

        public float CreationTime => _creationTime;
        public int SpawnerCapacityCount => _spawnerCapacityCount;

        public long SpawnerCapacityUpgragePrice => _spawnerCapacityUpgradePrice;
        public long SpawnerCreationTimeUpgradePrice => _creationTimeUpgradePrice;

        public int CreationTimeLvl => _creationTimeLvl;
        public int SpawnerCapacityLvl => _spawnerCapacityLvl;

        public bool IsBuying => _isBuying;

        public void UpdateCapacityLvl()
        {
            _spawnerCapacityLvl += 1;
            _spawnerCapacityCount += CapacityUpdateOffset;

            CostCalculator costCalculator = new CostCalculator(6, 16);
            _spawnerCapacityUpgradePrice = costCalculator.CalculateCostByPrice(_spawnerCapacityUpgradePrice);
        }

        public void UpdateCreationLvl()
        {
            _creationTimeLvl += 1;

            if(_creationTime - TimeDecreaseOffset >= 0)
            _creationTime -= TimeDecreaseOffset;

            CostCalculator costCalculator = new CostCalculator(6, 16);
            _creationTimeUpgradePrice = costCalculator.CalculateCostByPrice(_creationTimeUpgradePrice);
        }

        public void InitSpawner(float creationTime, long timeUpgradePrice, int creationLvl, int capacityCount, long capacityUpgradePrice, int capacityLvl, bool isBuying)
        {
            _creationTime = creationTime;
            _creationTimeUpgradePrice = timeUpgradePrice;
            _creationTimeLvl = creationLvl;

            _spawnerCapacityCount = capacityCount;
            _spawnerCapacityUpgradePrice = capacityUpgradePrice;
            _spawnerCapacityLvl = capacityLvl;

            _isBuying = isBuying;
        }

        public void SetBuyStatus()
        {
            _isBuying = true;
        }
    }
}
