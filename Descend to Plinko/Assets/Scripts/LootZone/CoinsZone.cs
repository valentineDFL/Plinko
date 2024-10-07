using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.LootZone
{
    internal class CoinsZone : MonoBehaviour
    {
        public event Func<long, bool> GoldChanged;
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
                    coffitient = UnityEngine.Random.Range(-4.1f, 1.0f);
                }
                else if (number < 7)
                {
                    coffitient = UnityEngine.Random.Range(0.1f, 5.0f);
                }
                _coffs[i] = (float)Math.Round(coffitient, 1);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<Ball>())
            {
                Ball ball = collision.GetComponent<Ball>();
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                collision.gameObject.transform.position = _spawnPos.transform.position;

                BallByType(ball);
                
            }
        }

        private void BallByType<T>(T ball) where T : Ball
        {

            long goldToAdd = (long)(ball.Point * _coffs[ball.Index]);
            if (GoldChanged.Invoke(goldToAdd))
            {
                GoldIconAnimationPlayed?.Invoke();
            }
            

        }


    }
}
