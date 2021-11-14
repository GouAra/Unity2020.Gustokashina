using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float G = 6.67e-11f; //гравитационная постоянная
    public GameObject Body1; //первое тело
    public Rigidbody body1; //первое тело
    public GameObject Body2; //второе тело
    public Rigidbody body2; //второе тело

    public Vector3 velocity1; //начальная скорость первого тела
    public Vector3 velocity2; //начальная скорость второго тела


    // Start is called before the first frame update
    void Start()
    {
        Body1 = GameObject.Find("Point 1");
        Body2 = GameObject.Find("Point 2");
        body1 = Body1.GetComponent<Rigidbody>();
        body2 = Body2.GetComponent<Rigidbody>();

        velocity1 = new Vector3(0, Body1.transform.position.y, -Body1.transform.position.z);
        velocity2 = new Vector3(0, -Body2.transform.position.y, -Body2.transform.position.z);

        body1.AddForce(velocity1, ForceMode.VelocityChange);
        body2.AddForce(velocity2, ForceMode.VelocityChange);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 R = Body1.transform.position - Body2.transform.position; // вектор расстояния от центра до точки
        float r = R.magnitude; // расстояние от центра до точки
        float F = G * body1.mass * body2.mass / Mathf.Pow(r, 2); // закон всемирного тяготения в векторной форме
        Vector3 Force = -R.normalized * F;
        body1.AddForce(Force * Time.fixedDeltaTime, ForceMode.Impulse);
        body2.AddForce(-Force * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
