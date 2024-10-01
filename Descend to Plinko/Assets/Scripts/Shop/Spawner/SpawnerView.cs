using System;
using System.Collections.Generic;
using Assets.Scripts.Gold;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Shop.Spawner
{
    internal class SpawnerView : MonoBehaviour
    {
        [SerializeField] private SpawnerPresenter _spawnerPresenter;

        [SerializeField] private GameObject _notEnoughtGoldPanel;

        [SerializeField] private TextMeshProUGUI _spawnerName;
        [SerializeField] private TextMeshProUGUI _capacityCount;
        [SerializeField] private TextMeshProUGUI _creationTime;

        [SerializeField] private Button _upgradeCapacityButton;
        [SerializeField] private Button _decreaseCreationTimeButton;

        private TextMeshProUGUI _capacityUpgradePriceText;
        private TextMeshProUGUI _creationTimeUpgradePriceText;

        private CeilGold _ceilGold = new CeilGold();


        private void Awake()
        {
            _upgradeCapacityButton.onClick.AddListener(_spawnerPresenter.BuyCapacityUpdate);
            _decreaseCreationTimeButton.onClick.AddListener(_spawnerPresenter.BuyTimeDecreaseUpdate);

            _capacityUpgradePriceText = _upgradeCapacityButton.GetComponentInChildren<TextMeshProUGUI>();
            _creationTimeUpgradePriceText = _decreaseCreationTimeButton.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            _upgradeCapacityButton.onClick.RemoveAllListeners();
            _decreaseCreationTimeButton.onClick.RemoveAllListeners();
        }

        public void SetSpawnerName(string name)
        {
            _spawnerName.text = name;
        }

        public void SetCapacityCount(int capacityCount)
        {
            _capacityCount.text = "Capacity: " + capacityCount.ToString();
        }

        public void SetCreationTime(float createdTime)
        {
            _creationTime.text = "Creation time: " + createdTime.ToString();
        }

        public void SetCapacityPrice(long price)
        {
            _capacityUpgradePriceText.text = _ceilGold.Ceil(price);
        }

        public void SetCreationTimePrice(long price)
        {
            _creationTimeUpgradePriceText.text = _ceilGold.Ceil(price);
        }

        public void NotEnoughtGoldPanelCall()
        {
            _notEnoughtGoldPanel.SetActive(true);
        }

        public void ShowInfo(SpawnerModel model)
        {
            _spawnerPresenter.ShowSpawnerInfo(model); 
        }
    }
}
