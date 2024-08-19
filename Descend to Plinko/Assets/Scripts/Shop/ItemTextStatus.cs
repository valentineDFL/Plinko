using TMPro;
using UnityEngine;

namespace Assets.Scripts.Shop
{
    internal class ItemTextStatus : MonoBehaviour
    {
        private string _statusText;
        private ItemForSale _itemForSale;

        public ItemTextStatus(string statusText, ItemForSale itemForSale)
        {
            _statusText = statusText;
            _itemForSale = itemForSale;
        }

        public void SetItemStatus(TextMeshProUGUI text)
        {
            
        }
    }
}
