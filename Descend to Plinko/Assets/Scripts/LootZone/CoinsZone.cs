using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.LootZone
{
    internal class CoinsZone : MonoBehaviour
    {
        public event Action<int> GoldCountChanged;
        public event Action GoldIconAnimationPlayed;

        private List<float> _coffs = new List<float>();

        [Range(-1f, 4)] private float _greenCoff;
        [Range(-1f, 4)] private float _redCoff;
        [Range(-1f, 4)] private float _blueCoff;
        [Range(-1f, 4)] private float _purpleCoff;
        [Range(-1f, 4)] private float _yellowCoff;
        [Range(-1f, 4)] private float _orangeCoff;

        [SerializeField] private GameObject _spawnPos;
        
        public IReadOnlyList<float> Coffs
        {
            get { return _coffs; }
        }

        private void Awake()
        {
            _coffs = new List<float>()
            {
                _redCoff,
                _greenCoff,
                _blueCoff,
                _purpleCoff,
                _yellowCoff,
                _orangeCoff
            };

            float coffitient = 0;

            for (int i = 0; i < _coffs.Count; i++)
            {
                float number = UnityEngine.Random.Range(1, 11);

                if (number > 7)
                {
                    coffitient = UnityEngine.Random.Range(-0.1f, 1.0f);
                }
                else if (number < 7)
                {
                    coffitient = UnityEngine.Random.Range(0.1f, 4.0f);
                }
                _coffs[i] = 100;//(float)Math.Round(coffitient, 1);
            }
            // стоимость улучшений каждый раз прибавляется на 6.5 - 7 процента
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<Ball>())
            {
                Ball ball = collision.GetComponent<Ball>();
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                collision.gameObject.transform.position = _spawnPos.transform.position;

                BallByType(ball);

                //Destroy(collision.gameObject);
            }
        }

        private void BallByType<T>(T ball) where T : Ball
        {
            GoldIconAnimationPlayed?.Invoke();
            GoldCountChanged?.Invoke((int)(ball.Point * _coffs[ball.Index]));
        }


    }
}
