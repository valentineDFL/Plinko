using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.JsonSaver
{
    internal class JsonDataSaver
    {
        public void DataSave(Data dataForSave)
        {
            string dataJson = JsonUtility.ToJson(dataForSave, true);
            PlayerPrefs.SetString(Keys.Data, dataJson);
            Debug.Log("saveJson: " + dataJson);
        }
    }
}