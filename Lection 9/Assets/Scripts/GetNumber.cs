using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetNumber : MonoBehaviour
{
    public TMP_InputField tMP_Input;
    public int N;

    void Start()
    {
        string inputText = tMP_Input.text;
        N = int.Parse(inputText);
    }

    void Update()
    {
        string inputText = tMP_Input.text;
        N = int.Parse(inputText);
    }
}
