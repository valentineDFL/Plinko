using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Shop;
using System;
using Assets.Scripts.SaveLoad;

namespace Assets.Scripts.Gold
{
    internal class Bank : MonoBehaviour
    {
        public event Action<long> GoldIncreased;

        [SerializeField] private DataRecorder _loadGold;
        [SerializeField] private List<AddItemToShop> _itemForSaleFolder = new List<AddItemToShop>();
        private List<ItemForSale> _itemsForSaleSubscribers = new List<ItemForSale>();
        
        private long _gold;
        public long Gold => _gold;

        private void Awake()
        {
            _gold = 140000; //_loadGold.Gold;
        }

        private void Start()
        {

            InitItems();

            for (int i = 0; i < _itemsForSaleSubscribers.Count; i++)
            {
                _itemsForSaleSubscribers[i].ItemBuyed += BuyItem;
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _itemsForSaleSubscribers.Count; i++)
            {
                _itemsForSaleSubscribers[i].ItemBuyed -= BuyItem;
            }
        }

        private void InitItems()
        {
            for(int i = 0; i < _itemForSaleFolder.Count; i++)
            {
                for(int j = 0; j < _itemForSaleFolder[i].transform.childCount; j++)
                {
                    GameObject currentGameObjectInFolder = _itemForSaleFolder[i].transform.GetChild(j).gameObject;
                    currentGameObjectInFolder.TryGetComponent<ItemForSale>(out ItemForSale currentItemForSale);
                    _itemsForSaleSubscribers.Add(currentItemForSale);
                }
            }
        }

        private void BuyItem(long increaseGold)
        {
            _gold -= increaseGold;
            GoldIncreased?.Invoke(_gold);
        }
    }
}
