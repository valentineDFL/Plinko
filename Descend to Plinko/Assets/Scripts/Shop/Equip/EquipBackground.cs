using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop.Equip
{
    internal class EquipBackground : EquipItem
    {
        public event Action<Sprite> CurrentBackgroundChanged;

        [SerializeField] private List<Image> _subscribersForEquip = new List<Image>();
        private List<BuyBackground> _backgroundItemsForSale = new List<BuyBackground>();

        public Sprite CurrentSprite { get; private set; }
        private int ChildCount => ItemForSaleFolder.transform.childCount;

        private void Start()
        {
            for (int i = 0; i < ChildCount; i++)
            {
                BuyBackground currentBackground = ItemForSaleFolder.transform.GetChild(i).GetComponent<BuyBackground>();
                _backgroundItemsForSale.Add(currentBackground);
            }

            for(int i = 0; i < _backgroundItemsForSale.Count; i++)
            {
                _backgroundItemsForSale[i].CurrentBackgroundChanged += Equip;
            }

            InitializeStartupBackground();
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _backgroundItemsForSale.Count; i++)
            {
                _backgroundItemsForSale[i].CurrentBackgroundChanged -= Equip;
            }
        }

        private void Equip(Sprite sprite)
        {
            CurrentSprite = sprite;
            CurrentBackgroundChanged?.Invoke(CurrentSprite);

            for (int i = 0; i < _subscribersForEquip.Count; i++)
            {
                _subscribersForEquip[i].sprite = sprite;
            }
        }

        private void InitializeStartupBackground()
        {
            if (DataRecorder.CurrentBackground == null)
            {
                print("Вход произошёл в то что в дата null задний фон");
                Equip(_subscribersForEquip[0].sprite);
            }
            else
            {
                print("Вход произошёл в то что в дата задний фон не null " + DataRecorder.CurrentBackground.name);
                Equip(DataRecorder.CurrentBackground);
            }
        }
    }
}
