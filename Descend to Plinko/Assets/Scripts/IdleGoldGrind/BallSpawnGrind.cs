using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.IdleGoldGrind
{
    internal abstract class BallSpawnGrind : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> Ui = new List<GameObject>();
        [SerializeField][Range(20, 180)] protected float BallCreationTime;

        public abstract event Action<long> BallInTimeAdded;

        protected abstract void BallSpawn();
    }
}
