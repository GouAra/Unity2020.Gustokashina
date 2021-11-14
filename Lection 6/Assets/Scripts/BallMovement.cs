using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float theta; //угол в градусах между вектором скорости и OX
    public float phi; //угол в градусах между вектором скорости и OY
    public float velocity; //модуль скорости
    public GameObject Wall;
    public Vector3 v; //вектор скорости
    private Vector3 Position;
    private Vector3 v1;
    private Vector3 v2;

    void Collide1()
    {
        if (Wall.transform.position.z <= transform.position.z) v = new Vector3(v.x, v.y, -v.z);
    }

    void Collide2()
    {
        if (0 >= transform.position.y) v = new Vector3(v.x, -v.y, v.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        Position = transform.position;
        v = new Vector3(
            velocity * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Cos(phi * Mathf.Deg2Rad),
            velocity * Mathf.Cos(theta * Mathf.Deg2Rad),
            velocity * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Sin(phi * Mathf.Deg2Rad));
        

        transform.position = new Vector3(v.x * Time.time,
             v.y * Time.time - 9.8f * Mathf.Pow(Time.time, 2) / 2,
             v.z * Time.time) + Position;
    }

    // Update is called once per frame
    void Update()
    {
        Collide1();
        Collide2();

        transform.position = new Vector3(v.x * Time.time,
            v.y * Time.time - 9.8f * Mathf.Pow(Time.time, 2) / 2,
            v.z * Time.time) + Position;
    }
}
