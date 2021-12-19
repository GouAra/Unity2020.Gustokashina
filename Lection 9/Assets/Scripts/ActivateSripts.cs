using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateSripts : MonoBehaviour
{
    public GameObject Sphere;

    public void Activate()
    {
        if (Sphere == null) Sphere = GameObject.FindGameObjectWithTag("Sphere");
        Sphere.AddComponent<Movement>();
        Sphere.GetComponent<Movement>().enabled = true;
    }
}
