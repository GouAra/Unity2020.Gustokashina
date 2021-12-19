using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    const float G = 6.67e-11f; //гравитационная постоянная
    public int number = 0;
    
    public GameObject Prefab;
    public GameObject Sphere;
    public GameObject Number;
    private GameObject[] planets;

    private Rigidbody sphere;
    private Rigidbody prefab;
    private Rigidbody planet1;
    private Rigidbody planet2;
    
    void Start()
    {
        
        if (Sphere == null) Sphere = GameObject.Find("Sphere");
        if (Prefab == null) Prefab = GameObject.Find("PreSphere");
        if (Number == null) Number = GameObject.Find("Number");

        number = Number.GetComponent<GetNumber>().N;

        prefab = Prefab.GetComponent<Rigidbody>();
        prefab.mass = 3.3e23f;
        Vector3 velocity = new Vector3(0, -prefab.transform.position.y, prefab.transform.position.z);
        prefab.AddForce(velocity, ForceMode.VelocityChange);

        sphere = Sphere.GetComponent<Rigidbody>();
        sphere.mass = 5.9e24f;
        velocity = new Vector3(0, sphere.transform.position.y, -sphere.transform.position.z);
        sphere.AddForce(velocity, ForceMode.VelocityChange);

        planets = new GameObject[number];
        for (int i = 0; i < number - 1; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f) * (i + 1) / (number - 1), Random.Range(-5f, 5f) * (i + 1) / (number - 1), Random.Range(-5f, 5f) * (i + 1) / (number - 1));
            planets[i] = Instantiate(Prefab, position, Quaternion.identity);
            planet1 = planets[i].GetComponent<Rigidbody>();
            planet1.mass = 3.3e23f;
            Vector3 v = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            planet1.AddForce(v, ForceMode.VelocityChange);
        }
    }
    

    void FixedUpdate()
    {
        Vector3 r = sphere.transform.position - prefab.transform.position;
        Vector3 F = -r.normalized * G * prefab.mass * sphere.mass / Mathf.Pow(r.magnitude, 2);
        sphere.AddForce(F, ForceMode.Impulse);
        prefab.AddForce(-F, ForceMode.Impulse);

        for (int i = 0; i < number - 1; i++)
        {
            planet1 = planets[i].GetComponent<Rigidbody>();
            Vector3 R = prefab.transform.position - planet1.transform.position;
            Vector3 Force = -R.normalized * G * prefab.mass * planet1.mass / Mathf.Pow(R.magnitude, 2);
            prefab.AddForce(Force, ForceMode.Impulse);
            planet1.AddForce(-Force, ForceMode.Impulse);
        }

        for (int i = 0; i < number - 1; i++)
        {
            planet1 = planets[i].GetComponent<Rigidbody>();
            Vector3 R = sphere.transform.position - planet1.transform.position;
            Vector3 Force = -R.normalized * G * sphere.mass * planet1.mass / Mathf.Pow(R.magnitude, 2);
            sphere.AddForce(Force, ForceMode.Impulse);
            planet1.AddForce(-Force, ForceMode.Impulse);

            for (int j = i; j < number - 1; j++)
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
