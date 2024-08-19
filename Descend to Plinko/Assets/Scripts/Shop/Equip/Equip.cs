using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shop.Equip
{
    internal abstract class Equip : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> SubscribersForEquip = new List<GameObject>();
        [SerializeField] protected AddItemToShop ItemForSaleFolder;
    }
}
