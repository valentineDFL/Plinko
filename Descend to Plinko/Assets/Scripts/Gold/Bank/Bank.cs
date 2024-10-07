using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.Gold
{
    public abstract class Bank : MonoBehaviour
    {
        public abstract event Action<long> GoldChanged;

        [SerializeField] protected DataRecorder LoadGold;

        protected long Gold;
        public long GoldCount => Gold;
    }
}
