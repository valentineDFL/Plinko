using System;
using System.Drawing;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.LootZone
{
    internal class CoffitientsText : MonoBehaviour
    {
        protected enum Colors
        {
            red = 0,
            green = 1,
            blue = 2,
            purple = 3,
            yellow = 4,
            orange = 5
        }

        [SerializeField] private TextMeshProUGUI _textMeshProTextUi;
        private CoinsZone _coinZone;

        private void Start()
        {
            _coinZone = GetComponent<CoinsZone>();
            SetCoffitientsValue();
        }

        private void SetCoffitientsValue()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int j = 0; j < _coinZone.Coffs.Count; j++)
            {
                float str = (float)Math.Round(_coinZone.Coffs[j], 2);
                string color = $"{(Colors)j}";
                
                stringBuilder.Append($"<color={color}> {str}</color>");
                if(j % 2 == 1)
                {
                    stringBuilder.AppendLine();
                }
            }
            _textMeshProTextUi.text = stringBuilder.ToString();
        }
    }
}