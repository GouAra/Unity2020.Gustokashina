using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    public GameObject pendulum;

    private float g = 9.8f;
    private float w; //собственная частота колебаний
    private float a; //амплитуда
    private float startingPhase;
    private Vector3 Position;

    public float length = 1; //длина нити
    public float startingAngle = 1; //начальный угол отклонения (градусы)
    public float startingVelocity = 1; //начальная угловая скорость

    void Start()
    {
        Position = pendulum.transform.position;
        startingAngle = startingAngle * Mathf.PI / 180;
        w = Mathf.Sqrt(g / length);
        a = Mathf.Sqrt(Mathf.Pow(startingAngle, 2) + Mathf.Pow(startingVelocity / w, 2));
        startingPhase = Mathf.Atan(startingAngle * w / startingVelocity);
        transform.position = new Vector3(length * Mathf.Sin(startingAngle), -length * Mathf.Cos(startingAngle), 0) + Position;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = a * Mathf.Sin(w * Time.time + startingPhase);
        transform.position = new Vector3(length * Mathf.Sin(angle), -length * Mathf.Cos(angle), 0) + Position;
    }
}
