using System;
using UnityEngine;

namespace Assets.Scripts.Shop.Equip.EquipVerification
{
    internal class VerificationEquipStatus : IUseVerification
    {
        private bool _isEquipped;
        private ItemForSale[] _itemsForUnEquip;

        public VerificationEquipStatus(ItemForSale[] itemsForSale)
        {
            _itemsForUnEquip = itemsForSale;
        }

        public virtual void UnUse()
        {
            for (int i = 0; i < _itemsForUnEquip.Length; i++)
            {
                if (_itemsForUnEquip[i].IsBuying)
                {
                    _itemsForUnEquip[i].UnEquipBuyedItem();
                    Debug.Log(_itemsForUnEquip[i].name);
                }
            }
        }
    }
}
