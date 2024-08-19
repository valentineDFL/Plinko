using Assets.Scripts.Gold;
using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.Shop
{
    internal abstract class AddItemToShop : MonoBehaviour
    {
        [SerializeField] protected Bank Bank;
        [SerializeField] protected DataRecorder CurrentData;
        [SerializeField] protected GameObject NotEnoughtMoneyPanel;
        [SerializeField] protected long Price;
        protected abstract void InitItems();
        protected abstract void SetItemsPrice(long currentPrice, GameObject currentChild);
        protected long SetItemPrice(int i)
        {
            return Price * i;
        }
    }
}
