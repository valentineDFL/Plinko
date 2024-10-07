using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.LootZone;
using UnityEngine;

namespace Assets.Scripts.Gold
{
    public class GameBank : Bank
    {
        public override event Action<long> GoldChanged;

        [SerializeField] private List<CoinsZone> _zones = new List<CoinsZone>();

        private void Awake()
        {
            Gold = 10000; //LoadGold.Gold;

            for(int i = 0; i < _zones.Count; i++)
            {
                _zones[i].GoldChanged += AddGold; 
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _zones.Count; i++)
            {
                _zones[i].GoldChanged -= AddGold;
            }
        }

        protected bool AddGold(long goldToAdd)
        {
            if (TryAddGold(goldToAdd))
            {
                Gold += goldToAdd;
                GoldChanged?.Invoke(Gold);
                return true;
            }

            return false;
        }

        private bool TryAddGold(long goldToAdd) => goldToAdd + Gold >= 0;
    }
}
