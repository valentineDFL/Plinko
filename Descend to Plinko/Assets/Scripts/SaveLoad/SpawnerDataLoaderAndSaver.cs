using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.JsonSaver;
using Assets.Scripts.Shop.Spawner;

namespace Assets.Scripts.SaveLoad
{
    public class SpawnerDataLoaderAndSaver
    {
        public void LoadSpawnersData(List<Spawner> spawners, Data data)
        {
            for (int i = 0; i < spawners.Count; i++)
            {
                if (spawners.Count > data.SpawnerData.Count)
                {
                    data.AddSpawnerData();
                }

                float creationTime = data.SpawnerData[i].CreationTime;
                long timeUpgradePrice = data.SpawnerData[i].SpawnerCreationTimeUpgradePrice;
                int creationLvl = data.SpawnerData[i].CreationTimeLvl;

                int capacity = data.SpawnerData[i].SpawnerCapacityCount;
                long capacityUpgradePrice = data.SpawnerData[i].SpawnerCapacityUpgragePrice;
                int capacityLvl = data.SpawnerData[i].SpawnerCapacityLvl;

                bool isBuying = data.SpawnerData[i].IsBuying;

                if(i == 0 || i == 1)
                {
                    isBuying = true;
                }

                spawners[i].InitSpawner(creationTime, timeUpgradePrice, creationLvl, capacity, capacityUpgradePrice, capacityLvl, isBuying);
            }
        }

        public void SaveSpawnersData(List<Spawner> spawners, Data data)
        {
            for (int i = 0; i < spawners.Count; i++)
            {
                float creationTime = spawners[i].CreationTime;
                long timeUpgradePrice = spawners[i].SpawnerCreationTimeUpgradePrice;
                int creationLvl = spawners[i].CreationTimeLvl;

                int capacity = spawners[i].SpawnerCapacityCount;
                long capacityUpgradePrice = spawners[i].SpawnerCapacityUpgragePrice;
                int capacityLvl = spawners[i].SpawnerCapacityLvl;

                bool isBuying = spawners[i].IsBuying;

                data.SpawnerData[i].SetSpawnerData(creationTime, timeUpgradePrice, creationLvl, capacity, capacityUpgradePrice, capacityLvl, isBuying);
            }
        }
    }
}
