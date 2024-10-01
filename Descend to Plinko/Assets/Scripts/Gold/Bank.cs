using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Shop;
using System;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Spawner;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Gold
{
    public class Bank : MonoBehaviour
    {
        public event Action<long> GoldDecreased;

        [SerializeField] private DataRecorder _loadGold;
        [SerializeField] private List<ProductAdder> _itemForSaleFolder = new List<ProductAdder>();
        private List<ProductForSale> _itemsForSaleSubscribers = new List<ProductForSale>();
        
        private long _gold;
        public long Gold => _gold;

        private void Awake()
        {
            _gold = _loadGold.Gold;
        }

        private void Start()
        {
            InitItems();
            for (int i = 0; i < _itemsForSaleSubscribers.Count; i++)
            {
                _itemsForSaleSubscribers[i].PurchaseCharged += BuyItem;
            }

            for(int j = 0; j < _itemsForSaleSubscribers.Count; j++)
            {
                if (_itemsForSaleSubscribers[j].TryGetComponent<SpawnerModel>(out SpawnerModel model))
                {
                    model.PurchaseCharged += BuyItem;
                }
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _itemsForSaleSubscribers.Count; i++)
            {
                _itemsForSaleSubscribers[i].PurchaseCharged -= BuyItem;
            }

            for (int j = 0; j < _itemsForSaleSubscribers.Count; j++)
            {
                if (_itemsForSaleSubscribers[j] != null && _itemsForSaleSubscribers[j].TryGetComponent<SpawnerModel>(out SpawnerModel model))
                {
                    model.PurchaseCharged -= BuyItem;
                }
            }
        }

        private void InitItems()
        {
            for(int i = 0; i < _itemForSaleFolder.Count; i++)
            {
                for(int j = 0; j < _itemForSaleFolder[i].transform.childCount; j++)
                {
                    GameObject currentGameObjectInFolder = _itemForSaleFolder[i].transform.GetChild(j).gameObject;
                    currentGameObjectInFolder.TryGetComponent<ProductForSale>(out ProductForSale currentItemForSale);
                    _itemsForSaleSubscribers.Add(currentItemForSale);
                }
            }
        }

        private bool BuyItem(long goldCount)
        {
            if(TryBuyItem(goldCount))
            {
                _gold -= goldCount;
                GoldDecreased?.Invoke(_gold);
                return true;
            }
            
            return false;
        }

        private bool TryBuyItem(long gold) => _gold - gold >= 0;
    }
}
