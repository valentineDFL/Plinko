using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Equip.EquipVerification;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop
{
    [RequireComponent(typeof(Button))]
    internal abstract class ItemForSale : MonoBehaviour
    {
        public abstract event Action<long> PurchaseCharged;

        protected GameObject NotEnoughtMoneyPanel;
        protected Bank Bank;
        protected long Price;
        protected IUseVerification VerificationEquipStatus;

        protected int SavedStatus { get; set; }
        protected SaveStatus SaveStatus = new SaveStatus();

        protected abstract void BuyItem();
        protected abstract void EquipBuyedItem();
        public abstract void UnEquipBuyedItem();
        public void Init(bool buyingState, Bank bank, GameObject notEnoughtMoneyPanel, long price, IUseVerification verificationEquipStatus)
        {
            IsBuying = buyingState;
            Bank = bank;
            NotEnoughtMoneyPanel = notEnoughtMoneyPanel;
            Price = price;
            VerificationEquipStatus = verificationEquipStatus;
        }

        protected Button _button;

        public bool IsBuying { get; protected set; }
    }
}
