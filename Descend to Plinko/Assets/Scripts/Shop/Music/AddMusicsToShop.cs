using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Assets.Scripts.Shop.InitializePrice;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.SaveLoad;
using System.Linq;
using Assets.Scripts.Shop.SoundShop;

namespace Assets.Scripts.Shop.Music
{
    internal class AddMusicsToShop : AddItemToShop
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
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).AddComponent<BuyMusic>();
            }
        }

        protected override void InitItems() // 2 +
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                BuyMusic currentChild = transform.GetChild(i).GetComponent<BuyMusic>();
                string currentChildName = currentChild.name;
                int status = PlayerPrefs.GetInt(currentChildName);
                long currentPrice = SetItemPrice(i);

                BuyMusic[] backgrounds = InitMusics();

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

        private BuyMusic[] InitMusics() // 3 +
        {
            BuyMusic[] backgrounds = new BuyMusic[transform.childCount];
            for (int j = 0; j < transform.childCount; j++)
            {
                BuyMusic currentBackground = transform.GetChild(j).GetComponent<BuyMusic>();
                backgrounds[j] = currentBackground;
            }

            return backgrounds;
        }

        protected override IUseVerification EquipStatus(int flagIndex, ItemForSale[] itemsForSale) // 4 + 
        {
            List<ItemForSale> items = new List<ItemForSale>();

            for (int i = 0; i < transform.childCount; i++)
            {
                if (i != flagIndex)
                {
                    items.Add(itemsForSale[i]);
                }
            }

            return new VerificationEquipStatus(items.ToArray());
        }

        private IUseVerification MusicPlayStatusEquip(int flagIndex, PlayDemoSound[] itemsForSale)
        {
            List<PlayDemoSound> items = new List<PlayDemoSound>();

            for (int i = 0; i < transform.childCount; i++)
            {
                if (i != flagIndex)
                {
                    items.Add(itemsForSale[i]);
                }
            }

            return new VerificationPlayedStatus(items.ToArray());
        }

        private void SetStatus(int status, BuyMusic currentChild, GameObject notEnoughtMoneyPanel, long price, IUseVerification verificationEquipStatus) // 5 +
        {
            if (status == 0)
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
