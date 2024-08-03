using Assets.Scripts.LootZone;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldIconRise : MonoBehaviour
{
    [SerializeField] private List<CoinsZone> _zones = new List<CoinsZone>();
    private Animator _animator;
    private string _triggerName = "GoldIncrease";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        for(int i = 0; i < _zones.Count; i++)
        {
            _zones[i].GoldIconAnimationPlayed += StartAnimationPlay;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _zones.Count; i++)
        {
            _zones[i].GoldIconAnimationPlayed -= StartAnimationPlay;
        }
    }

    private void StartAnimationPlay()
    {
        _animator.SetTrigger(_triggerName);
    }
}
