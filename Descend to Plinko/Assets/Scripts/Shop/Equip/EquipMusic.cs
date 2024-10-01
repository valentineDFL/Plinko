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
        public event Action<AudioClip> CurrentMusicChanged;

        [SerializeField] private List<AudioSource> _subscribersForEquip = new List<AudioSource>();
        private List<BuyMusic> _musicItemsForSale = new List<BuyMusic>();

        public AudioClip CurrentMusic;
        private int ChildCount => ItemForSaleFolder.transform.childCount;

        public IReadOnlyList<AudioSource> Subscribers => _subscribersForEquip;

        private void Start()
        {
            for (int i = 0; i < ChildCount; i++)
            {
                BuyMusic currentMusic = ItemForSaleFolder.transform.GetChild(i).GetComponent<BuyMusic>();
                _musicItemsForSale.Add(currentMusic);
            }

            for (int i = 0; i < _musicItemsForSale.Count; i++)
            {
                _musicItemsForSale[i].CurrentMusicChanged += Equip;
            }

            InitializeStartupMusic();
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _musicItemsForSale.Count; i++)
            {
                _musicItemsForSale[i].CurrentMusicChanged -= Equip;
            }
        }

        private async void Equip(AudioClip music)
        {
            CurrentMusic = music;
            CurrentMusicChanged?.Invoke(CurrentMusic);

            for (int i = 0; i < _subscribersForEquip.Count; i++)
            {
                AudioSource audioSource = _subscribersForEquip[i];
                audioSource.clip = music;
                await Task.Delay(1300);
                audioSource.Play();
            }
        }

        private void InitializeStartupMusic()
        {
            if (DataRecorder.CurrentMusic == null)
            {
                print("Вход произошёл в то что в дата null музыка");
                Equip(_subscribersForEquip[0].clip);
            }
            else
            {
                print("Вход произошёл в то что в дата музыка не null" + DataRecorder.CurrentMusic.name);
                Equip(DataRecorder.CurrentMusic);
            }
        }
    }
}
