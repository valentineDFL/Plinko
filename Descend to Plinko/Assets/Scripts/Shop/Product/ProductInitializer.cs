using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.Shop.InitializePrice;
using UnityEngine;

namespace Assets.Scripts.Shop.Product
{
    public abstract class ProductInitializer
    {
        protected GameObject ProductFolder;
        protected GameObject NotEnoughtMoneyPanel;
        protected long Price;

        protected ProductTextInitializer InitializeText = new ProductTextInitializer();
        protected ProductPriceCalculator PriceCalculator = new ProductPriceCalculator();
        protected StatusContainer StatusContainer = new StatusContainer();

        public ProductInitializer(GameObject productFolder, GameObject notEnoughtPanel, long price)
        {
            ProductFolder = productFolder;
            NotEnoughtMoneyPanel = notEnoughtPanel;
            Price = price;
        }

        public ProductInitializer() { }

        public abstract void Initialize();
        protected abstract ProductForSale[] CreateItemsArray();
        protected abstract IUseVerification EquipStatus(int flagIndex, ProductForSale[] itemsForSale);
    }
}
