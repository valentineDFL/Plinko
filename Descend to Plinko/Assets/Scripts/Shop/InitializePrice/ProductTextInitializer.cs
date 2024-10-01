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
    public class ProductTextInitializer
    {
        private CeilGold _ceilGold = new CeilGold();

        public void InitPrice(string status, GameObject textFather)
        {
           TextMeshProUGUI text = textFather.GetComponentInChildren<TextMeshProUGUI>();

           if(int.TryParse(status, out int result))
                text.text = _ceilGold.Ceil(result);
           else
                text.text = status;
        }
    }
}
