using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Gold;
using Assets.Scripts.JsonSaver;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    public abstract class DataRecorder : MonoBehaviour
    {
        [SerializeField] protected Bank Bank;

        protected Data Data;
        protected DataSaverAndLoader DataSaver = new DataSaverAndLoader();

        public Sprite CurrentBackground => Data.CurrentBackground;
        public AudioClip CurrentMusic => Data.CurrentMusic;
        public long Gold => Data.Gold;
    }
}
