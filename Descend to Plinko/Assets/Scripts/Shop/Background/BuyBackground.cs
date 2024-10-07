using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Gold;
using Assets.Scripts.Shop.Equip;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop
{
    internal class BuyBackground : ProductForSale
    {
        public override event Func<long, bool> PurchaseCharged;
        public event Action<Sprite> CurrentBackgroundChanged;

        private Sprite _background;
        
        private void Awake()
        {
            PriceTag = GetComponentInChildren<TextMeshProUGUI>();
            _background = GetComponent<Image>().sprite;
        }

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(BuyItem);
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
                if (PurchaseCharged.Invoke(-Price))
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
            Sprite currentBackground = GetComponentInParent<EquipBackground>().CurrentSprite;
            if (currentBackground != _background)
            {
                PriceTag.text = Keys.Used;
                CurrentBackgroundChanged?.Invoke(_background);
                VerificationEquipStatus.UnUse();
            }
        }

        public override void MarkAsOwned()
        {
            PriceTag.text = Keys.Owned;
        }

        private void Buy()
        {
            IsBuying = true;
            PriceTag.text = Keys.Owned;
        }
    }
}
