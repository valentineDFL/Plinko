using System;
using System.Collections.Generic;
using Assets.Scripts.Shop.Equip.EquipVerification;
using Assets.Scripts.Shop.Equip;
using Assets.Scripts.Shop.SoundShop;
using UnityEngine;

namespace Assets.Scripts.Shop.Spawner
{
    public class MusicPlayDemoInitializer
    {
        protected GameObject ProductFolder;
        private Sprite _stopPlayingIcon;

        public MusicPlayDemoInitializer(GameObject productFolder, Sprite stopPlayingIcon)
        {
            ProductFolder = productFolder;
            _stopPlayingIcon = stopPlayingIcon;
        }

        public void Initialize()
        {
            for (int i = 0; i < ProductFolder.transform.childCount; i++)
            {
                Transform musicsFolder = ProductFolder.transform.GetChild(i);
                for (int j = 0; j < musicsFolder.childCount; j++)
                {
                    Transform CurrentMusic = musicsFolder.GetChild(j);

                    if (CurrentMusic.TryGetComponent<PlayDemoSound>(out PlayDemoSound demoSource))
                        demoSource.Init(_stopPlayingIcon, EquipStatus(i), CreateUnEquipper());
                }
            }
        }

        protected IUseVerification EquipStatus(int indexToSkip)
        {
            List<PlayDemoSound> demoSounds = new List<PlayDemoSound>();

            for (int i = 0; i < ProductFolder.transform.childCount; i++)
            {
                if (i != indexToSkip)
                {
                    for (int j = 0; j < ProductFolder.transform.GetChild(i).childCount; j++)
                    {
                        if (ProductFolder.transform.GetChild(i).GetChild(j).TryGetComponent<PlayDemoSound>(out PlayDemoSound demoSound))
                            demoSounds.Add(demoSound);
                    }
                }
            }

            return new VerificationPlayedStatus(demoSounds.ToArray());
        }

        private UnEquipperUsedMusic CreateUnEquipper()
        {
            IReadOnlyList<AudioSource> gameObjects = ProductFolder.GetComponent<EquipMusic>().Subscribers;

            List<AudioSource> audioSources = new List<AudioSource>();

            for (int i = 0; i < gameObjects.Count; i++)
            {
                audioSources.Add(gameObjects[i].GetComponent<AudioSource>());
            }

            return new UnEquipperUsedMusic(audioSources.ToArray());
        }
    }
}
