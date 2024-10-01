using System;
using UnityEngine;

namespace Assets.Scripts.Shop.Spawner
{
    internal class SpawnerModel : MonoBehaviour
    {
        public event Func<long, bool> PurchaseCharged;

        [SerializeField] private Spawner _spawner;

        private BuySpawner _buySpawner;

        public Spawner Spawner => _spawner;
        public bool IsBuying => _buySpawner.IsBuying;

        private void Awake()
        {
            _buySpawner = GetComponent<BuySpawner>();
        }

        public bool TryBuyUpgrade(long price)
        {
            if (PurchaseCharged.Invoke(price))
            {
                return true;
            }
            
            return false;
        }
    }
}
