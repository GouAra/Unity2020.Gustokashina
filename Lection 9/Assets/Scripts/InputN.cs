using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputN : MonoBehaviour
{
    TMP_InputField tMP_Input;
    public int N;

    public void InputNumber()
    {
        tMP_Input = GetComponent<TMP_InputField>();
        string inputText = tMP_Input.text;
        N = int.Parse(inputText);
    }
}
