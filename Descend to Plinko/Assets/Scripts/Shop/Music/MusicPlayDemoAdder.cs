using System;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.Shop.SoundShop;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using Assets.Scripts.Shop.Equip;
using Assets.Scripts.Shop.Spawner;

namespace Assets.Scripts.Shop.Music
{
    internal class MusicPlayDemoAdder : MonoBehaviour
    {
        [SerializeField] private Sprite _stopPlayingIcon;

        private void Start()
        {
            AddDemoPlayer();

            MusicPlayDemoInitializer musicPlayDemoInitializer = new MusicPlayDemoInitializer(this.gameObject, _stopPlayingIcon);
            musicPlayDemoInitializer.Initialize();
        }

        private void AddDemoPlayer()
        { 
            for(int i = 0; i < transform.childCount; i++)
            {
                for(int j = 0; j < transform.GetChild(i).transform.childCount; j++)
                {
                    if(transform.GetChild(i).GetChild(j).TryGetComponent<Button>(out Button demoSource))
                        demoSource.AddComponent<PlayDemoSound>();
                }
            }
        }
    }
}
