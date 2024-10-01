﻿using System.Collections.Generic;
using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Equip.EquipVerification;
using UnityEngine;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop.Music
{
    public class MusicInitializer : ProductInitializer
    {
        public MusicInitializer(GameObject productFolder, GameObject notEnoughtPanel, long price) : base(productFolder, notEnoughtPanel, price)
        {
            ProductFolder = productFolder;
            NotEnoughtMoneyPanel = notEnoughtPanel;
            Price = price;
        }

        public override void Initialize()
        {
            for (int i = 0; i < ProductFolder.transform.childCount; i++)
            {
                BuyMusic currentChild = ProductFolder.transform.GetChild(i).GetComponent<BuyMusic>();

                string currentChildName = currentChild.name;
                long currentPrice = PriceCalculator.SetItemPrice(i, Price);

                BuyMusic[] backgrounds = (BuyMusic[])CreateItemsArray();

                IUseVerification equipStatus = EquipStatus(i, backgrounds);

                SetStatus(i, currentChild, currentPrice, equipStatus);
            }
        }

        protected override ProductForSale[] CreateItemsArray()
        {
            BuyMusic[] backgrounds = new BuyMusic[ProductFolder.transform.childCount];
            for (int j = 0; j < ProductFolder.transform.childCount; j++)
            {
                BuyMusic currentBackground = ProductFolder.transform.GetChild(j).GetComponent<BuyMusic>();
                backgrounds[j] = currentBackground;
            }

            return backgrounds;
        }

        protected override IUseVerification EquipStatus(int flagIndex, ProductForSale[] itemsForSale)
        {
            List<ProductForSale> items = new List<ProductForSale>();

            for (int i = 0; i < ProductFolder.transform.childCount; i++)
            {
                if (i != flagIndex)
                    items.Add(itemsForSale[i]);
            }

            return new VerificationEquipStatus(items.ToArray());
        }

        private void SetStatus(int index, BuyMusic currentChild, long price, IUseVerification verificationEquipStatus)
        {
            bool status = StatusContainer.LoadStatus(currentChild.name);

            if (!status)
            {
                if (index == 0)
                {
                    currentChild.Init(true, NotEnoughtMoneyPanel, price, verificationEquipStatus, StatusContainer);
                    InitializeText.InitPrice(Keys.Used, currentChild.gameObject);
                    return;
                }

                currentChild.Init(false, NotEnoughtMoneyPanel, price, verificationEquipStatus, StatusContainer);
                InitializeText.InitPrice(price.ToString(), currentChild.gameObject);

                return;
            }

            currentChild.Init(true, NotEnoughtMoneyPanel, price, verificationEquipStatus, StatusContainer);
            InitializeText.InitPrice(StatusContainer.LoadStatusText(currentChild.TextKey), currentChild.gameObject);
        }
    }
}
