using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GimbalMovement : MonoBehaviour
{
    private Rigidbody gimbal;
    public Vector3 axis;
    public TextMeshProUGUI gimbalText;
    private Quaternion q;

    void Start()
    {
        gimbal = GetComponent<Rigidbody>();
        q = Quaternion.identity;
        SetGimbalText(q);
    }

    // Update is called once per frame
    void Update()
    {
        gimbal.AddTorque(axis, ForceMode.Impulse);
        q = transform.rotation;
        SetGimbalText(q);
    }

    void SetGimbalText(Quaternion now)
    {
        float w = now.w;
        float x = now.x;
        float y = now.y;
        float z = now.z;
        gimbalText.text = "White cube: (" + w.ToString() + ", " + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ")";
    }
}
