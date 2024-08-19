using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float radius;
    float angle = 0;

    private void Update()
    {
        angle += 7f * Time.deltaTime;
        this.transform.position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle)* radius);
        
    }
}
