using Assets.Scripts.Gold;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop
{
    [RequireComponent(typeof(Button))]
    internal abstract class ItemForSale : MonoBehaviour
    {
        public abstract event Action<long> ItemBuyed;
        protected GameObject NotEnoughtMoneyPanel;
        protected Bank Bank;
        protected long Price;

        protected abstract void BuyItem();
        protected abstract void EquipBuyedItem();
        public abstract void Init(bool buyingState, Bank bank, GameObject notEnoughtMoneyPanel, long price);


        public bool IsBuying { get; protected set; }

        protected Button _button;
    }
}
