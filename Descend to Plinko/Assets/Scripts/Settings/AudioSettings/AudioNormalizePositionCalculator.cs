using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Settings.AudioSettings
{
    internal struct AudioNormalizePositionCalculator
    {
        public float CalculatePositionPercent(float min, float max, float current)
        {
            return (current - min) / (max - min);
        }
    }
}
