using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float theta; //угол в градусах между вектором скорости и OX
    public float phi; //угол в градусах между вектором скорости и OY
    public float velocity; //модуль скорости
    private Vector3 v; //вектор скорости


    void Start()
    {
        v = new Vector3(
            velocity * Mathf.Sin(theta * Mathf.Deg2Rad) *  Mathf.Cos(phi * Mathf.Deg2Rad), 
            velocity * Mathf.Cos(theta * Mathf.Deg2Rad),
            velocity * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Sin(phi * Mathf.Deg2Rad));
        GetComponent<Rigidbody>().AddForce(v, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {

    }
}
