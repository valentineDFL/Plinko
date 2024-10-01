using UnityEngine;

namespace Assets.Scripts.Shop.Spawner
{
    public struct CostCalculator
    {
        private float _minPercentMultiplayer;
        private float _maxPercentMultiplayer;

        public CostCalculator(float minPersentMultipluer, float maxPersentMultipluer)
        {
            _minPercentMultiplayer = minPersentMultipluer;
            _maxPercentMultiplayer = maxPersentMultipluer;
        }

        public long CalculateCostByPrice(long currentPrice)
        {
            float percent = Random.Range(_minPercentMultiplayer, _maxPercentMultiplayer);

            float preRes = (float)currentPrice / 100 * percent;
            float newCurrentPrice = currentPrice + preRes;

            return (long)newCurrentPrice;
        }
    }
}
