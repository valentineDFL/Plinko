using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    internal class SaveStatus
    {
        public void SaveBool(int status, string key)
        {
            if (PlayerPrefs.GetInt(key) != status)
            {
                PlayerPrefs.SetInt(key, status);
            }
        }

        public void SaveStatusText(string key, string statusText)
        {
            if (PlayerPrefs.GetString(key) != statusText)
            {
                PlayerPrefs.SetString(key, statusText);
            }
        }

        public void LoadStatusText(string key, TextMeshProUGUI text)
        {
            if (PlayerPrefs.HasKey(key) && PlayerPrefs.GetString(key).Length != 0)
            {
                text.text = PlayerPrefs.GetString(key);
            }
        }
    }
}
