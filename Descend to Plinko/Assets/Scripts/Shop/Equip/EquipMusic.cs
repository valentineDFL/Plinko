using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Shop.Music;
using UnityEngine;

namespace Assets.Scripts.Shop.Equip
{
    internal class EquipMusic : EquipItem
    {
        private List<BuyMusic> _itemsForSale = new List<BuyMusic>();

        public AudioClip CurrentMusic { get; private set; }
        private int ChildCount => ItemForSaleFolder.transform.childCount;

        private void Start()
        {
            for (int i = 0; i < ChildCount; i++)
            {
                BuyMusic currentBackground = ItemForSaleFolder.transform.GetChild(i).GetComponent<BuyMusic>();
                _itemsForSale.Add(currentBackground);
            }

            for (int i = 0; i < _itemsForSale.Count; i++)
            {
                _itemsForSale[i].CurrentMusicChanged += Equip;
            }

            InitializeStartupBackground();

            print(CurrentMusic.name);
            if (CurrentMusic != null)
            {
                Equip(CurrentMusic);
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _itemsForSale.Count; i++)
            {
                _itemsForSale[i].CurrentMusicChanged -= Equip;
            }
        }

        private void Equip(AudioClip music)
        {
            CurrentMusic = music;

            for (int i = 0; i < SubscribersForEquip.Count; i++)
            {
                SubscribersForEquip[i].GetComponent<AudioSource>().clip = music;
            }
        }

        private void InitializeStartupBackground()
        {
            if (DataRecorder.CurrentBackground == null)
            {
                print("Вход произошёл в то что в дата null задний фон");
                CurrentMusic = SubscribersForEquip[0].GetComponent<AudioSource>().clip;
                Equip(CurrentMusic);
            }
            else
            {
                CurrentMusic = DataRecorder.CurrentMusic;
                print("Вход произошёл в то что в дата задний фон не null" + DataRecorder.CurrentBackground.name);
            }
        }
    }
}
