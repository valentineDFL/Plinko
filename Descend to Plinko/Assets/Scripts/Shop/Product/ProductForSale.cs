using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Equip.EquipVerification;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop.Product
{
    [RequireComponent(typeof(Button))]
    public abstract class ProductForSale : MonoBehaviour
    {
        public abstract event Func<long, bool> PurchaseCharged;

        protected GameObject NotEnoughtMoneyPanel;
        protected long Price;
        protected TextMeshProUGUI PriceTag;
        protected IUseVerification VerificationEquipStatus;

        protected StatusContainer SaveStatus;
        protected Button _button;

        public bool IsBuying { get; protected set; }
        public string Key => this.name;
        public string TextKey => this.name + typeof(ProductForSale);

        protected abstract void BuyItem();
        protected abstract void MarkAsUsed();
        public abstract void MarkAsOwned();
        public void Init(bool buyingState, GameObject notEnoughtMoneyPanel, long price, IUseVerification verificationEquipStatus, StatusContainer statusContainer)
        {
            IsBuying = buyingState;
            NotEnoughtMoneyPanel = notEnoughtMoneyPanel;
            Price = price;
            VerificationEquipStatus = verificationEquipStatus;
            SaveStatus = statusContainer;
        }
    }
}
