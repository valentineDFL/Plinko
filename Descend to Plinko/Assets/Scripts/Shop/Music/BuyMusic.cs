using System;
using Assets.Scripts.Shop.Equip;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop.Music
{
    internal class BuyMusic : ProductForSale
    {
        public override event Func<long, bool> PurchaseCharged;
        public event Action<AudioClip> CurrentMusicChanged;

        private AudioClip _music;

        private void Awake()
        {
            PriceTag = GetComponentInChildren<TextMeshProUGUI>();
            _music = GetComponent<AudioSource>().clip;
        }

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(BuyItem);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();

            SaveStatus.SaveStatus(IsBuying, this.Key);

            SaveStatus.SaveStatusText(this.TextKey, PriceTag.text);
        }

        protected override void BuyItem()
        {
            if (IsBuying == true)
            {
                MarkAsUsed();
            }
            else
            {
                if (PurchaseCharged.Invoke(-Price))
                {
                    Buy();
                }
                else
                {
                    NotEnoughtMoneyPanel.SetActive(true);
                }
            }
        }

        protected override void MarkAsUsed()
        {
            AudioClip audioClip = GetComponentInParent<EquipMusic>().CurrentMusic;
            if(audioClip != _music)
            {

                PriceTag.text = Keys.Used;
                CurrentMusicChanged?.Invoke(_music);
                VerificationEquipStatus.UnUse();
            }
        }

        public override void MarkAsOwned()
        {
            PriceTag.text = Keys.Owned;
        }

        private void Buy()
        {
            PriceTag.text = Keys.Owned;
            IsBuying = true;
        }
    }
}
