using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Assets.Scripts.Shop.InitializePrice;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop.Music
{
    internal class ShopMusicAdder : ProductAdder
    {
        private void Awake()
        {
            AddItems();

            ProductInitializer = new MusicInitializer(this.gameObject, NotEnoughtMoneyPanel, Price);
            ProductInitializer.Initialize();
        }

        protected override void AddItems()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).AddComponent<BuyMusic>();
            }
        }
    }
}
