using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Shop.Product;

namespace Assets.Scripts.Shop.Equip
{
    internal class UnEquipperUsedMusic
    {
        private IReadOnlyList<AudioSource> _subscribersForEquip;

        public UnEquipperUsedMusic(IReadOnlyList<AudioSource> subscribersForEquip)
        {
            _subscribersForEquip = subscribersForEquip;
        }

        public void SwitchEquippedMusic()
        {
            for (int i = 0; i < _subscribersForEquip.Count; i++)
            {
                SwitchPlayMode(i);
            }
        }

        private void SwitchPlayMode(int index)
        {
            if (_subscribersForEquip[index].isPlaying)
                _subscribersForEquip[index].Pause();
            else
                _subscribersForEquip[index].Play();
        }
    }
}
