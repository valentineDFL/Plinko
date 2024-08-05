using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.VectorSlide
{
    internal class VectorDirectionObject : MonoBehaviour
    {
        private Vector2 _velocity;

        public void Init(Vector2 initValues)
        {
            _velocity = initValues;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += _velocity;
            print(collision.gameObject.GetComponent<Rigidbody2D>().velocity += _velocity);
        }
    }
}
