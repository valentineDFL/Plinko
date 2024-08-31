using System;
using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Equip.EquipVerification;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Shop.InitializePrice;

namespace Assets.Scripts.Shop
{
    internal abstract class AddItemToShop : MonoBehaviour
    {
        [SerializeField] protected Bank Bank;
        [SerializeField] protected DataRecorder CurrentData;
        [SerializeField] protected GameObject NotEnoughtMoneyPanel;
        [SerializeField] protected long Price;

        protected InitializeText InitializeText = new InitializeText();

        protected abstract void AddItems();
        protected abstract void InitItems();
        protected abstract void SetItemsText(long currentPrice, GameObject currentChild);
        protected abstract IUseVerification EquipStatus(int flagIndex, ItemForSale[] itemsForSale);
        protected long SetItemPrice(int i)
        {
            return Price * i;
        }
    }
}
