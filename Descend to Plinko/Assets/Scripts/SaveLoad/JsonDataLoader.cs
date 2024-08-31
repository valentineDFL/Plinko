using Assets.Scripts.JsonSaver;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    internal class JsonDataLoader
    {
        public Data Load(long gold, Sprite currentBackground, AudioClip currentMusic)
        {
            string gameData = PlayerPrefs.GetString(Keys.Data);
            Debug.Log("loadInfo: " + gameData);

            Data data = JsonUtility.FromJson<Data>(gameData);

            if (data != null)
            {
                return data;
            }
            data = new Data(gold, currentBackground, currentMusic);
            return data;
        }
    }
}
