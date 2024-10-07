using System;
using UnityEngine;

namespace Assets.Scripts.Shop.Spawner
{
    internal class SpawnerModel : MonoBehaviour
    {
        public event Func<long, bool> PurchaseCharged;

        [SerializeField] private Spawner _spawner;

        public Spawner Spawner => _spawner;
        public bool IsBuying => Spawner.IsBuying;

        public bool TryBuyUpgrade(long price)
        {
            if (PurchaseCharged.Invoke(-price))
            {
                return true;
            }
            
            return false;
        }
    }
}
