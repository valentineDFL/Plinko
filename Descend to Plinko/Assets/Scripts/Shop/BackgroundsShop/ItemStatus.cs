using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Shop.BacgroundsShop
{
    internal class ItemStatus : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public void OnPointerUp(PointerEventData poi)
        {
            print("Нажал");
        }

        public void OnPointerDown(PointerEventData poi)
        {
            print("Отжал");
        }
    }
}
