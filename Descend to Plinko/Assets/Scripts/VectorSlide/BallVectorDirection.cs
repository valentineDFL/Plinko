using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

namespace Assets.Scripts.VectorSlide
{
    internal class BallVectorDirection : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 _touchPoint;
        private Vector2 _lastPount;
        private Vector2 _velocity;

        public void OnPointerDown(PointerEventData eventData)
        {
            _touchPoint = GetWorldPosition(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _lastPount = GetWorldPosition(eventData.position);
            UpdateVelocity();
        }

        private async void UpdateVelocity()
        {
            _velocity = (_lastPount - _touchPoint);
            print("velocityPrev: " + _velocity);

            if(_velocity.y > 0)
            {
                _velocity = new Vector2(_velocity.x, -_velocity.y);
            }

            await AsyncLifeTimer(VelocityBoostZone());
        }

        private GameObject VelocityBoostZone()
        {
            GameObject velocityZone = new GameObject();
            velocityZone.transform.position = _touchPoint;

            velocityZone.AddComponent<BoxCollider2D>();
            velocityZone.AddComponent<SpriteRenderer>();
            velocityZone.AddComponent<VectorDirectionObject>();

            BoxCollider2D box = velocityZone.GetComponent<BoxCollider2D>();
            box.isTrigger = true;
            box.size = new Vector2(4, 1);

            velocityZone.GetComponent<VectorDirectionObject>().Init(_velocity);

            return velocityZone;
        }

        private Vector2 GetWorldPosition(Vector2 pos)
        {
            return Camera.main.ScreenToWorldPoint(pos);
        }

        private async Task AsyncLifeTimer(GameObject gameObject)
        {
            await Task.Delay(2000);
            if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }
    }
}
