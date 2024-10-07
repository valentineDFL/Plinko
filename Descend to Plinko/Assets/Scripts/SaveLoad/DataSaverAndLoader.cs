using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.JsonSaver;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    public class DataSaverAndLoader
    {
        public void Save(Data dataForSave)
        {
            string json = JsonUtility.ToJson(dataForSave);

            PlayerPrefs.SetString(Keys.GameData, json);
        }

        public Data Load()
        {
            string data = PlayerPrefs.GetString(Keys.GameData);

            if (data.Length > 1)
                return JsonUtility.FromJson<Data>(PlayerPrefs.GetString(Keys.GameData));
            else
            {
                return new Data();
            }
        }
    }
}
