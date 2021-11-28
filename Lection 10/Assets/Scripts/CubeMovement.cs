using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public GameObject cube = null;
    private float angle = 0.1f;
    public Vector3 axis;
    private Quaternion q;

    void Start()
    {
        angle *= Mathf.Deg2Rad;
        axis = axis.normalized;
        q = new Quaternion(Mathf.Sin(angle / 2) * axis.x, Mathf.Sin(angle / 2) * axis.y, Mathf.Sin(angle / 2) * axis.z, Mathf.Cos(angle / 2));
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.rotation = cube.transform.rotation * q;
    }
}
