using System;
using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Equip.EquipVerification;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Shop.InitializePrice;
using Assets.Scripts.Shop.Music;
using Unity.VisualScripting;

namespace Assets.Scripts.Shop.Product
{
    internal abstract class ProductAdder : MonoBehaviour
    {
        [SerializeField] protected ShopBank Bank;
        [SerializeField] protected GameObject NotEnoughtMoneyPanel;
        [SerializeField] protected long Price;

        protected ProductInitializer ProductInitializer;
        protected abstract void AddItems();

    }
}
