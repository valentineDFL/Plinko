using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Shop.SoundShop;

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
            for(int i = 0; i < _sounds.Length; i++)
            {
                if (_sounds[i].IsPlaying)
                {

                }
            }
        }
    }
}
