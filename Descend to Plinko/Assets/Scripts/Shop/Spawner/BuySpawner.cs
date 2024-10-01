using System;
using System.Collections.Generic;
using Assets.Scripts.Gold;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Shop.Product;
using Assets.Scripts.SaveLoad;

namespace Assets.Scripts.Shop.Spawner
{
    internal class BuySpawner : ProductForSale
    {
        public override event Func<long, bool> PurchaseCharged;
        public event Action<bool> SpawnerBuyed;

        private Spawner _spawner;
        
        private void Awake()
        {
            _spawner = GetComponent<SpawnerModel>().Spawner;
            PriceTag = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(BuyItem);
        }

        private void Start()
        {
            
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();

            SaveStatus.SaveStatus(IsBuying, this.Key);

            SaveStatus.SaveStatusText(this.TextKey, PriceTag.text);
        }

        protected override void BuyItem()
        {
            if (IsBuying == true)
            {
                MarkAsUsed();
            }
            else
            {
                if (PurchaseCharged.Invoke(Price))
                {
                    Buy();
                }
                else
                {
                    NotEnoughtMoneyPanel.SetActive(true);
                }
            }
        }

        protected override void MarkAsUsed()
        {
            PriceTag.text = Keys.IsSeen;
            VerificationEquipStatus.UnUse();
        }

        public override void MarkAsOwned()
        {
            if(PriceTag.text != Keys.Owned)
               PriceTag.text = Keys.Owned;
        }

        private void Buy()
        {
            PriceTag.text = Keys.Owned;
            IsBuying = true;

            _spawner.SetBuyStatus();
        }
    }
}
