using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Shop.BacgroundsShop
{
    internal class BackgroundBuy : MonoBehaviour
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        private void Awake()
        {
            int count = transform.childCount;
            for(int i = 0; i < count; i++)
            {
                _gameObjects.Add(transform.GetChild(i).gameObject);
                _gameObjects[i].AddComponent<ItemStatus>();
            }
            print(count + " - " + _gameObjects.Count);
        }
    }
}
