using System;
using System.Linq;
using System.Text;
using Assets.Scripts.SaveLoad;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Shop.Spawner
{
    internal class SpawnerPresenter : MonoBehaviour
    {
        [SerializeField] SpawnerView _spawnerView;

        private SpawnerModel _spawnerModel;

        private void Awake()
        {
            StatusContainer statusContainer = new StatusContainer();
            for (int i = 0; i < this.transform.childCount; i++)
            {
                string key = transform.GetChild(i).GetComponent<BuySpawner>().TextKey;
                if (statusContainer.LoadStatusText(key) == Keys.IsSeen || transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text == Keys.IsSeen)
                {
                    _spawnerModel = transform.GetChild(i).GetComponent<SpawnerModel>();
                    break;
                }
            }
        }

        private void Start()
        {
            ShowSpawnerInfo(_spawnerModel);
        }

        public void ShowSpawnerInfo(SpawnerModel model)
        {
            if (model.IsBuying)
            {
                _spawnerModel = model;

                _spawnerView.SetSpawnerName(model.Spawner.name);

                _spawnerView.SetCapacityCount(model.Spawner.SpawnerCapacityCount);
                _spawnerView.SetCapacityPrice(model.Spawner.SpawnerCapacityUpgragePrice);
            
                _spawnerView.SetCreationTime(model.Spawner.CreationTime);
                _spawnerView.SetCreationTimePrice(model.Spawner.SpawnerCreationTimeUpgradePrice);
            }
        }

        public void BuyCapacityUpdate()
        {
            if (_spawnerModel.TryBuyUpgrade(_spawnerModel.Spawner.SpawnerCapacityUpgragePrice))
            {
                _spawnerModel.Spawner.UpdateCapacityLvl();

                ShowSpawnerInfo(_spawnerModel);
            }
            else
                _spawnerView.NotEnoughtGoldPanelCall();
        }

        public void BuyTimeDecreaseUpdate()
        {
            if (_spawnerModel.TryBuyUpgrade(_spawnerModel.Spawner.SpawnerCreationTimeUpgradePrice))
            {
                _spawnerModel.Spawner.UpdateCreationLvl();

                ShowSpawnerInfo(_spawnerModel);
            }
            else
                _spawnerView.NotEnoughtGoldPanelCall();
        }
    }
}
