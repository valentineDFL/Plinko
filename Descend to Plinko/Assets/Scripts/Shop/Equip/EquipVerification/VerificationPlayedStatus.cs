using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Shop.SoundShop;
using UnityEngine;

namespace Assets.Scripts.Shop.Equip.EquipVerification
{
    internal class VerificationPlayedStatus : IUseVerification
    {
        private PlayDemoSound[] _sounds;

        public VerificationPlayedStatus(PlayDemoSound[] sounds)
        {
            _sounds = sounds;
        }

        public void UnUse()
        {
            for (int j = 0; j < _sounds.Length; j++)
            {
                if (_sounds[j].IsPlaying)
                {
                    _sounds[j].SwitchPlaying();
                }
            }
        }
    }
}
