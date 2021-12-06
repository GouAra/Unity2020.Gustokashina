using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWall : MonoBehaviour
{
    public int Height = 5;
    public int Width = 5;

    public GameObject prefab;
    private GameObject[] bricks;

    void Start()
    {
        bricks = new GameObject[Height * Width];
        int k = 0;
        for (int i = 0; i < Height; i++)
        {
            for(int j = 0; j < Width; j++)
            {
                Vector3 position = new Vector3(0, i + 0.500001f, j + 0.000001f);
                bricks[k] = Instantiate(prefab, position, Quaternion.identity);
                k++;
            }
        }

        for (int i = 0; i < Height; i++)
        {
            for (int j = 1; j < Width; j++)
            {
                bricks[i + j * Width].GetComponent<HingeJoint>().connectedBody = bricks[i + (j - 1) * Width].GetComponent<Rigidbody>();
            }
        }

        for (int j = Width - 1; j > 0; j--) bricks[j].GetComponent<HingeJoint>().connectedBody = bricks[j - 1].GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
