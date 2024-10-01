using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.Shop.Music;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Shop.Product;
using Assets.Scripts.SaveLoad;

namespace Assets.Scripts.Shop.Spawner
{
    internal class ShopSpawnerAdder : ProductAdder
    {
        private void Awake()
        {
            AddItems();

            ProductInitializer = new SpawnerInitializer(this.gameObject, NotEnoughtMoneyPanel, Price);
            ProductInitializer.Initialize();
        }

        protected override void AddItems()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).AddComponent<BuySpawner>();
            }
        }
    }
}
