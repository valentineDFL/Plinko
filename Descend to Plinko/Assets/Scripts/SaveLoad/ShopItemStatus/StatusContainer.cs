using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Shop.Spawner;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    public class StatusContainer
    {
        public void SaveStatus(bool status, string key)
        {
            if (PlayerPrefs.GetString(key) != status.ToString())
            PlayerPrefs.SetString(key, status.ToString());
        }

        public bool LoadStatus(string key)
        {
            if (bool.TryParse(PlayerPrefs.GetString(key), out bool result))
            {
                return result;
            }    
            return false;
        }

        public void SaveStatusText(string key, string statusText)
        {
            if (PlayerPrefs.GetString(key) != statusText)
                PlayerPrefs.SetString(key, statusText);
        }

        public string LoadStatusText(string key)
        {
            return PlayerPrefs.GetString(key);
        }
    }
}
