using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorMovement : MonoBehaviour
{
    public GameObject oscillator;
    private float a; //амплитуда
    private float w; //частота колебани€
    private float p; //начальна€ фаза
    private Vector3 Position;

    public float startingPosition = 0;
    public float forceConstant = 1;
    public float mass = 1;
    public float startingVelocity = 1;

    void Start()
    {
        Position = oscillator.transform.position;
        w = Mathf.Sqrt(forceConstant / mass);
        p = Mathf.Atan(startingPosition / (startingVelocity * w));
        a = startingVelocity / (w * Mathf.Cos(p));

        transform.position = new Vector3(0, a * Mathf.Sin(w * Time.time + p), 0) + Position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, a * Mathf.Sin(w * Time.time + p), 0) + Position;
    }
}
