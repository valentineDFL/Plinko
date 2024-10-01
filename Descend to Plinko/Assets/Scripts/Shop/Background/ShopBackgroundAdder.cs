using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Assets.Scripts.Shop.InitializePrice;
using Assets.Scripts.Shop.Equip.EquipVerification;
using System;
using Assets.Scripts.Shop.Background;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop
{
    internal class ShopBackgroundAdder : ProductAdder
    {
        private void Awake()
        {
            AddItems();

            ProductInitializer = new BackgroundsInitializer(this.gameObject, NotEnoughtMoneyPanel, Price);
            ProductInitializer.Initialize();
        }

        protected override void AddItems()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).AddComponent<BuyBackground>();
            }
        }

        
    }
}
