using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Gold;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.LootZone
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    internal abstract class GoldView : MonoBehaviour
    {
        [SerializeField] private ShopBank _bank;
        protected TextMeshProUGUI TextMeshPro;
        protected CeilGold CeilGold;

        protected void SetGoldCount(long count)
        {
            TextMeshPro.text = CeilGold.Ceil(count);
        }
    }
}
