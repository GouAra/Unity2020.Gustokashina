using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPosition : MonoBehaviour
{
    public GameObject anchor;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - anchor.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = anchor.transform.position + offset;
    }
}
