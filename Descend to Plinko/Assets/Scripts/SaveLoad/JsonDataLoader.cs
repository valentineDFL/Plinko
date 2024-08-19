using Assets.Scripts.JsonSaver;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    internal class JsonDataLoader
    {
        private long _gold;
        private Sprite _currentBackground;
        private AudioClip _currentMusic;
        private Dictionary<string, bool> _catalogueItemsStatus;

        public JsonDataLoader(long gold, Sprite background, AudioClip music, Dictionary<string, bool> catalogueItemsStatus)
        {
            _gold = gold;
            _currentBackground = background;
            _currentMusic = music;
            _catalogueItemsStatus = catalogueItemsStatus;
        }

        public Data Load()
        {
            string gameData = PlayerPrefs.GetString(Keys.Data);
            Debug.Log("loadInfo: " + gameData);

            Data data = JsonUtility.FromJson<Data>(gameData);

            if (data != null)
            {
                Debug.Log("Всё хорошо");
                return data;
            }

            Debug.Log("Всё плохо");
            data = new Data(_gold, _currentBackground, _currentMusic, _catalogueItemsStatus);

            return data;
        }
    }
}
