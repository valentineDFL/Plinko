using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _angle = 0;

    [SerializeField] private float _multipluyerCoff;
    private Vector2 _position;

    private void Awake()
    {
        _position = transform.position;
    }

    private void Update()
    {
        _angle += _multipluyerCoff * Time.unscaledDeltaTime;
        this.transform.position = new Vector3(_position.x + Mathf.Cos(_angle) * _radius, _position.y + Mathf.Sin(_angle) * _radius);
        
    }
}
