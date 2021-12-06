using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMovement : MonoBehaviour
{
    public float angle; //угол в градусах между вектором скорости и OY
    public float velocity; //модуль скорости
    private Vector3 v; //вектор скорости

    void Start()
    {
        angle = (100 - angle) * Mathf.Deg2Rad;
        v = new Vector3(
            velocity * Mathf.Sin(angle),
            velocity * Mathf.Cos(angle),
            0
            );
        GetComponent<Rigidbody>().AddForce(v, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
