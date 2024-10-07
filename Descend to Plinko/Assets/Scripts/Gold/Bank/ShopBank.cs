using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Shop;
using System;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Spawner;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Gold
{
    public class ShopBank : Bank
    {
        public override event Action<long> GoldChanged;

        [SerializeField] private List<ProductAdder> _itemForSaleFolder = new List<ProductAdder>();
        private List<ProductForSale> _itemsForSaleSubscribers = new List<ProductForSale>();


        private void Awake()
        {
            Gold = 10000; //_loadGold.Gold;
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

        protected bool BuyItem(long goldCount)
        {
            if(TryBuyItem(goldCount))
            {
                Gold += goldCount;
                GoldChanged?.Invoke(Gold);
                return true;
            }
            
            return false;
        }

        private bool TryBuyItem(long gold) => Gold + gold >= 0;
    }
}
