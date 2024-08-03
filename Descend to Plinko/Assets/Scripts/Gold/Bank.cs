using Assets.Scripts.LootZone;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gold
{
    internal class Bank : MonoBehaviour
    {
        [SerializeField] private List<CoinsZone> _zones = new List<CoinsZone>();
        private long _gold;

        private void OnEnable()
        {
            for (int i = 0; i < _zones.Count; i++)
            {
                _zones[i].GoldCountChanged += SetGoldCount;
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _zones.Count; i++)
            {
                _zones[i].GoldCountChanged += SetGoldCount;
            }
        }

        private void SetGoldCount(int gold)
        {

        }
    }
}
