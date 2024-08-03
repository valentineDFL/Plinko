using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.SceneManage
{
    internal class MetronomeSpawnerAdaptive : GameAdaptive
    {
        private Transform _metronomeSpawner;
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private int _divider = 3;

        private void Awake()
        {
            _metronomeSpawner = GetComponent<Transform>();
            SetAdaptive();
        }

        protected override void SetAdaptive()
        {
            _metronomeSpawner.transform.position = new Vector2(_menuPanel.transform.position.x, _menuPanel.transform.position.y - _menuPanel.transform.localScale.y / 2);
            _metronomeSpawner.transform.localScale = new Vector2(_menuPanel.transform.localScale.x / _divider, _menuPanel.transform.localScale.x / _divider);
        }
    }
}
