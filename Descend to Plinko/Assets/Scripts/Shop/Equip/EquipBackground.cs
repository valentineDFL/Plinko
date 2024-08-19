using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop.Equip
{
    internal class EquipBackground : Equip
    {
        private List<BuyBackground> _itemsForSale = new List<BuyBackground>();
        
        public Sprite CurrentSprite { get; private set; }
        private int ChildCount => ItemForSaleFolder.transform.childCount;

        private void Start()
        {
            for (int i = 0; i < ChildCount; i++)
            {
                BuyBackground currentBackground = ItemForSaleFolder.transform.GetChild(i).GetComponent<BuyBackground>();
                _itemsForSale.Add(currentBackground);
            }

            for(int i = 0; i < _itemsForSale.Count; i++)
            {
               _itemsForSale[i].CurrentBackgroundChanged += Equip;
            }

            InitializeStartupBackground();
            Equip(CurrentSprite);
        }

        private void OnDisable()
        {
            for (int i = 0; i < _itemsForSale.Count; i++)
            {
                _itemsForSale[i].CurrentBackgroundChanged -= Equip;
            }
        }

        private void Equip(Sprite sprite)
        {
            CurrentSprite = sprite;

            for (int i = 0; i < SubscribersForEquip.Count; i++)
            {
                SubscribersForEquip[i].GetComponent<Image>().sprite = sprite;
            }
        }

        private void InitializeStartupBackground()
        {
            if (DataRecorder.CurrentBackground == null)
            {
                print("Вход произошёл в то что в дата null задний фон");
                CurrentSprite = SubscribersForEquip[0].GetComponent<Image>().sprite;
                Equip(CurrentSprite);
            }
            else
            {
                CurrentSprite = DataRecorder.CurrentBackground;
                print("Вход произошёл в то что в дата задний фон не null" + DataRecorder.CurrentBackground.name);
            }
        }
    }
}
