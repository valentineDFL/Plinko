using System;
using Assets.Scripts.Shop.Equip;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop.Music
{
    internal class BuyMusic : ItemForSale
    {
        public override event Action<long> PurchaseCharged;
        public event Action<AudioClip> CurrentMusicChanged;

        private AudioClip _music;
        private TextMeshProUGUI _priceTag;

        private void Awake()
        {
            _priceTag = GetComponentInChildren<TextMeshProUGUI>();
            _music = GetComponent<AudioSource>().clip;
        }

        private void Start()
        {
            SavedStatus = PlayerPrefs.GetInt(this.name);
            SaveStatus.LoadStatusText(this.name + typeof(ItemForSale), _priceTag);
        }

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(BuyItem);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();

            SaveStatus.SaveBool(SavedStatus, this.name);

            SaveStatus.SaveStatusText(this.name + typeof(ItemForSale), _priceTag.text);
        }

        protected override void BuyItem()
        {
            if (IsBuying == true)
            {
                EquipBuyedItem();
            }
            else
            {
                if (Price <= Bank.Gold)
                {
                    Buy();
                }
                else
                {
                    NotEnoughtMoneyPanel.SetActive(true);
                }
            }
        }

        protected override void EquipBuyedItem()
        {
            AudioClip currentMusic = GetComponentInParent<EquipMusic>().CurrentMusic;
            if (currentMusic != _music)
            {
                _priceTag.text = Keys.Used;
                CurrentMusicChanged?.Invoke(_music);
                VerificationEquipStatus.UnUse();
            }
        }

        public override void UnEquipBuyedItem()
        {
            _priceTag.text = Keys.Owned;
        }

        private void Buy()
        {
            SavedStatus = 1;
            _priceTag.text = Keys.Owned;
            IsBuying = true;
            PurchaseCharged?.Invoke(Price);
        }
    }
}
