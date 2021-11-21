using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    const float G = 6.67e-11f; //гравитационная постоянная
    public int Number = 3;

    public GameObject prefab;
    private GameObject[] planets;

    private Rigidbody sphere;
    private Rigidbody planet1;
    private Rigidbody planet2;
    
    void Start()
    {
        sphere = GetComponent<Rigidbody>();
        sphere.mass = 5.9e24f;
        Vector3 velocity = new Vector3(0, sphere.transform.position.y, -sphere.transform.position.z);
        sphere.AddForce(velocity, ForceMode.VelocityChange);

        planets = new GameObject[Number];
        for (int i = 0; i < Number; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f) * i, Random.Range(-5f, 5f) * i, Random.Range(-5f, 5f) * i);
            planets[i] = Instantiate(prefab, position, Quaternion.identity);
            planet1 = planets[i].GetComponent<Rigidbody>();
            planet1.mass = 3.3e23f;
            Vector3 v = new Vector3(0, -planet1.transform.position.y, -planet1.transform.position.z);
            planet1.AddForce(v, ForceMode.VelocityChange);
        }
    }
    

    void FixedUpdate()
    {
        for (int i = 0; i < Number; i++)
        {
            planet1 = planets[i].GetComponent<Rigidbody>();
            Vector3 R = sphere.transform.position - planet1.transform.position;
            Vector3 Force = -R.normalized * G * sphere.mass * planet1.mass / Mathf.Pow(R.magnitude, 2);
            sphere.AddForce(Force, ForceMode.Impulse);
            planet1.AddForce(-Force, ForceMode.Impulse);

            for (int j = i; j < Number; j++)
            {
                if (i == j) continue;
                planet2 = planets[j].GetComponent<Rigidbody>();
                Vector3 R1 = planet1.transform.position - planet2.transform.position;
                Vector3 Force1 = -R1.normalized * G * planet1.mass * planet2.mass / Mathf.Pow(R1.magnitude, 2);
                planet1.AddForce(Force1, ForceMode.Impulse);
                planet2.AddForce(-Force1, ForceMode.Impulse);
            }
        }
    }
}
