using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintedObject : MonoBehaviour
{
    const int MAX_NUMBER_OF_HANDS = 6;
    int startIndex = 0;
    public List<Transform> handPos = new List<Transform>(MAX_NUMBER_OF_HANDS);

    public Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        Vector4[] HandContact = new Vector4[6];
        Vector4[] HandContactFwd = new Vector4[6];
        Vector4[] HandContactRight = new Vector4[6];

        for (int i = 0; i < handPos.Count; i++)
        {
            HandContact[i] = handPos[i].position;
            HandContactFwd[i] = handPos[i].forward;
            HandContactRight[i] = handPos[i].right;
        }

        objectMaterial.SetVectorArray("_HandContact", HandContact);
        objectMaterial.SetVectorArray("_HandContactFwd", HandContactFwd);
        objectMaterial.SetVectorArray("_HandContactRight", HandContactRight);
    }
}
