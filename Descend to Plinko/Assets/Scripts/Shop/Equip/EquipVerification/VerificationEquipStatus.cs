using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop.Equip.EquipVerification
{
    internal class VerificationEquipStatus : IUseVerification
    {
        private ProductForSale[] _itemsForUnEquip;

        public VerificationEquipStatus(ProductForSale[] itemsForSale)
        {
            _itemsForUnEquip = itemsForSale;
        }

        public virtual void UnUse()
        {
            for (int i = 0; i < _itemsForUnEquip.Length; i++)
            {
                if (_itemsForUnEquip[i].IsBuying)
                {
                    _itemsForUnEquip[i].MarkAsOwned();
                }
            }
        }
    }
}
