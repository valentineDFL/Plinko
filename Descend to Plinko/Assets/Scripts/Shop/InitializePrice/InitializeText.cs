using Assets.Scripts.Gold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Shop.InitializePrice
{
    internal class InitializeText
    {
        public void InitPrice(long price, GameObject textFather)
        {
           TextMeshProUGUI text = textFather.GetComponentInChildren<TextMeshProUGUI>();
           CeilGold ceilGold = new CeilGold();

           text.text = ceilGold.Ceil(price);
        }
    }
}
