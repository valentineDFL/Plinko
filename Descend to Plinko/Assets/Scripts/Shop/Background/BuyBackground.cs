using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Gold;
using Assets.Scripts.Shop.Equip;
using Assets.Scripts.Shop.Equip.EquipVerification;

namespace Assets.Scripts.Shop
{
    internal class BuyBackground : ItemForSale
    {
        public override event Action<long> PurchaseCharged;
        public event Action<Sprite> CurrentBackgroundChanged;

        private Sprite _background;
        private TextMeshProUGUI _priceTag;
        
        private void Awake()
        {
            _priceTag = GetComponentInChildren<TextMeshProUGUI>();
            _background = GetComponent<Image>().sprite;
        }

        private void Start()
        {
            SavedStatus = PlayerPrefs.GetInt(this.name);
            SaveStatus.LoadStatusText(this.name + typeof(ItemForSale), _priceTag);
        }

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(BuyItem);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();

            SaveStatus.SaveBool(SavedStatus, this.name);

            SaveStatus.SaveStatusText(this.name + typeof(ItemForSale), _priceTag.text);
        }

        protected override void BuyItem()
        {
            if (IsBuying == true)
            {
                EquipBuyedItem();
            }
            else
            {
                if (Price <= Bank.Gold)
                {
                    Buy();
                }
                else
                {
                    NotEnoughtMoneyPanel.SetActive(true);
                }
            }
        }

        protected override void EquipBuyedItem()
        {
            Sprite currentBackground = GetComponentInParent<EquipBackground>().CurrentSprite;
            if (currentBackground != _background)
            {
                _priceTag.text = Keys.Used;
                CurrentBackgroundChanged?.Invoke(_background);
                VerificationEquipStatus.UnUse();
            }
        }

        public override void UnEquipBuyedItem()
        {
            _priceTag.text = Keys.Owned;
        }

        private void Buy()
        {
            SavedStatus = 1;
            _priceTag.text = Keys.Owned;
            IsBuying = true;
            PurchaseCharged?.Invoke(Price);
        }
    }
}
