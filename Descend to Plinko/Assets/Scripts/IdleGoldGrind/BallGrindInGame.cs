using System;
using UnityEngine;

namespace Assets.Scripts.IdleGoldGrind
{
    internal class BallGrindInGame : BallSpawnGrind
    {
        public override event Action<long> BallInTimeAdded;
        private float _timeInGame;

        protected override void BallSpawn()
        {
            _timeInGame += Time.deltaTime;
            if(_timeInGame >= BallCreationTime)
            {
                BallInTimeAdded?.Invoke(1);
                _timeInGame = 0;
            }
        }

        private void Update()
        {
            BallSpawn();
        }
    }
}
