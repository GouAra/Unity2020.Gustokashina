using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    //траектория движения - эллипс

    static float eps = 6.67e-11f; //гравитационная постоянная

    public float mass = 10; //масса Point
    public float e; //относительный эксцентриситет

    private float velocity; //начальная скорость, угол между R и velocity = 0
    private float a; //eps * масса Point * масса Centre
    private float R; //расстояние между Centre и Point
    private float K0; //кинетический момент
    private float p; //фокальный параметр конического сечения
    private float f = 0;

    void Start()
    {
        a = eps * mass * 1.989e30f;
        R = transform.position.magnitude;
      
        velocity = Random.Range(0.1f, Mathf.Sqrt(2 * a / (mass * R)) - 0.1f); // velocity < Mathf.Sqrt(2 * a / (mass * R)) при e < 1
        K0 = R * mass * velocity;
        p = Mathf.Pow(K0, 2) / (mass * a);
    }

    void Update()
    {
        f += K0 / (mass * Mathf.Pow(R, 2) ) * Mathf.Deg2Rad;
        R = p / ( 1 + e * Mathf.Cos(f) );
        transform.position = new Vector3(R * Mathf.Cos(f), R * Mathf.Sin(f), 0);
    }
}
