using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Assets.Scripts.Shop.InitializePrice;

namespace Assets.Scripts.Shop
{
    internal class AddBackgroundsToShop : AddItemToShop
    {
        public event Action<string, bool> BackGroundItemAdded;
        private InitializeText _initializeText;

        private void Awake()
        {
            _initializeText = new InitializeText();

            InitItems();
        }

        protected override void InitItems()
        {
            IReadOnlyDictionary<string, bool> status = CurrentData.CatalogueItemsStatus;

            BuyBackground currentChild;
            for (int i = 0; i < transform.childCount; i++)
            {
                currentChild = transform.GetChild(i).AddComponent<BuyBackground>();
                string currentChildName = currentChild.name;
                long currentPrice = Price * (long)i;

                if(i == 0)
                {
                    currentChild.Init(true, Bank, NotEnoughtMoneyPanel, 0);
                    continue;
                }

                if (status != null)
                {
                    ContainsItemNameCheck(status, currentChildName, currentChild, currentPrice);
                }
                else // сделать систему что если у нас словарь нулл, то мы его инициализируем
                {
                    SetDefault(currentChild, NotEnoughtMoneyPanel, currentPrice);
                }
                SetItemsPrice(currentPrice, currentChild.gameObject);
            }
        }

        private void SetDefault(BuyBackground currentChild, GameObject notEnoughtMoneyPanel, long price)
        {
            currentChild.Init(false, Bank, notEnoughtMoneyPanel, price);
        }

        private void ContainsItemNameCheck(IReadOnlyDictionary<string, bool> status, string currentChildName, BuyBackground currentChild, long price)
        {
            if (status.ContainsKey(currentChildName))
            {
                currentChild.Init(status[currentChildName], Bank, NotEnoughtMoneyPanel, price);
            }
            else
            {
                SetDefault(currentChild, NotEnoughtMoneyPanel, price);
            }
        }

        protected override void SetItemsPrice(long currentPrice, GameObject currentChild)
        {
            _initializeText.InitPrice(currentPrice, currentChild.gameObject);
        }
    }
}
