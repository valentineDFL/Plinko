using Assets.Scripts;
using Assets.Scripts.LootZone;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCount : MonoBehaviour
{
    [SerializeField] private List<CoinsZone> _zones = new List<CoinsZone>();
    private long _count;
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        bool parse = long.TryParse(PlayerPrefs.GetString(Keys.GoldKey), out long result);
        if (parse)
        {
            _count = result;
        }
        _textMeshPro.text = Ceil();
    }

    private void OnEnable()
    {
        for(int i = 0; i < _zones.Count; i++)
        {
            _zones[i].GoldCountChanged += SetGoldCount;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _zones.Count; i++)
        {
            _zones[i].GoldCountChanged -= SetGoldCount;
        }

        PlayerPrefs.SetString(Keys.GoldKey, _count.ToString());
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey(Keys.GoldKey);
    }

    private void SetGoldCount(int count)
    {
        if(_count + count > 0)
        {
            _count += count;
        }
        else if(_count + count <= 0)
        {
            _count = 0;
        }

        _textMeshPro.text = Ceil();
    }

    private string Ceil()
    {
        int thousend = 1000;
        int million = 1000000;
        int billion = 1000000000;
        string res = "";

        int[] nums = new int[] {thousend, million, billion };
        char[] chars = new[] {'K', 'M', 'B'};

        if(_count < nums[0])
        {
            res = _count.ToString();
            return res;
        }

        for(int i = 0; i < nums.Length; i++)
        {
            if (_count >= nums[i])
            {
                res = $"{Math.Round((double)_count / nums[i], 3)}{chars[i]}";
                continue;
            }
        }
        return res;
    }
}
