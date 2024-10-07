using Assets.Scripts.SaveLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop.Equip
{
    internal abstract class EquipItem : MonoBehaviour
    {
        [SerializeField] protected DataRecorderMenu DataRecorder;
        [SerializeField] protected ProductAdder ItemForSaleFolder;
    }
}
