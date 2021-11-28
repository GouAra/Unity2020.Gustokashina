using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowQuaternion : MonoBehaviour
{
    public Transform arrow = null;
    public float angleX = 0f;
    public float angleY = 0f;
    public float angleZ = 0f;
    private Quaternion from;
    private Quaternion to;
    public TextMeshProUGUI quaternionText;

    void Start()
    {
        from = Quaternion.identity;
        to = Quaternion.Euler(angleX, angleY, angleZ);
        SetQuaternionText(from);
    }
    
    void Update()
    {
        Quaternion now = new Quaternion();
        now = Quaternion.LerpUnclamped(from, to, Time.time);
        SetQuaternionText(now);
        arrow.rotation = now;
    }

    void SetQuaternionText(Quaternion now)
    {
        float w = now.w;
        float x = now.x;
        float y = now.y;
        float z = now.z;
        quaternionText.text = "w = " + w.ToString() + ", x = " + x.ToString() + ", y = " + y.ToString() + ", z = " + z.ToString();
    }
}
