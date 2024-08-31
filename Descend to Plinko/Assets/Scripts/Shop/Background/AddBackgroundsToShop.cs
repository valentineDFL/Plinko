﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Assets.Scripts.Shop.InitializePrice;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.SaveLoad;
using System.Linq;

namespace Assets.Scripts.Shop
{
    internal class AddBackgroundsToShop : AddItemToShop
    {
        private void Awake()
        {
            AddItems();
        }

        private void Start()
        {
            InitItems();
        }

        protected override void AddItems() // 1 +
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).AddComponent<BuyBackground>();
            }
        }

        protected override void InitItems() // 2 +
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                BuyBackground currentChild = transform.GetChild(i).GetComponent<BuyBackground>();
                string currentChildName = currentChild.name;
                int status = PlayerPrefs.GetInt(currentChildName);
                long currentPrice = SetItemPrice(i);

                BuyBackground[] backgrounds = InitBackgrounds();

                IUseVerification equipStatus = EquipStatus(i, backgrounds);

                if (i == 0)
                {
                    currentChild.Init(true, Bank, NotEnoughtMoneyPanel, 0, equipStatus);
                    continue;
                }
                SetStatus(status, currentChild, NotEnoughtMoneyPanel, currentPrice, equipStatus);
                SetItemsText(currentPrice, currentChild.gameObject);
            }
        }

        private BuyBackground[] InitBackgrounds() // 3 +
        {
            BuyBackground[] backgrounds = new BuyBackground[transform.childCount];
            for (int j = 0; j < transform.childCount; j++)
            {
                BuyBackground currentBackground = transform.GetChild(j).GetComponent<BuyBackground>();
                backgrounds[j] = currentBackground;
            }

            return backgrounds;
        }

        protected override IUseVerification EquipStatus(int flagIndex, ItemForSale[] itemsForSale) // 4 + 
        {
            List<ItemForSale> items = new List<ItemForSale>();

            for(int i = 0; i < transform.childCount; i++)
            {
                if (i != flagIndex)
                {
                    items.Add(itemsForSale[i]);
                }
            }

            return new VerificationEquipStatus(items.ToArray());
        }

        private void SetStatus(int status, BuyBackground currentChild, GameObject notEnoughtMoneyPanel, long price, IUseVerification verificationEquipStatus) // 5 +
        {
            if(status == 0)
            {
                currentChild.Init(false, Bank, notEnoughtMoneyPanel, price, verificationEquipStatus);
                return;
            }
            currentChild.Init(true, Bank, notEnoughtMoneyPanel, price, verificationEquipStatus);
        }

        protected override void SetItemsText(long currentPrice, GameObject currentChild) // 6 +
        {
            InitializeText.InitPrice(currentPrice, currentChild.gameObject);
        }
    }
}
