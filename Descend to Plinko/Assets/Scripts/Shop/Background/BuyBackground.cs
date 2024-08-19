using Assets.Scripts.Gold;
using Assets.Scripts.Shop.Equip;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop
{
    internal class BuyBackground : ItemForSale
    {
        public override event Action<long> ItemBuyed;
        public event Action<Sprite> CurrentBackgroundChanged;

        private Sprite _background;
        private TextMeshProUGUI _priceTag;

        private void Awake()
        {
            _priceTag = GetComponentInChildren<TextMeshProUGUI>();
            _background = GetComponent<Image>().sprite;
        }

        public override void Init(bool buyingState, Bank bank, GameObject notEnoughtMoneyPanel, long price)
        {
            IsBuying = buyingState;
            Bank = bank;
            NotEnoughtMoneyPanel = notEnoughtMoneyPanel;
            Price = price;
        }

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(BuyItem);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        protected override void BuyItem()
        {
            print("item: " + this.gameObject.name + " - " + IsBuying);
            if (IsBuying == true)
            {
                EquipBuyedItem();
            }
            else
            {
                if (Price <= Bank.Gold)
                {
                    _priceTag.text = Keys.Owned;
                    IsBuying = true;
                    // отправить в логи статус покупки, добавить в текст статус куплено
                    print("Я купил предмет");
                    ItemBuyed?.Invoke(Price);
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
            }
        }
    }
}
