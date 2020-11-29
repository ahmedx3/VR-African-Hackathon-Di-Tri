using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintedObject : MonoBehaviour
{
    const int MAX_NUMBER_OF_HANDS = 6;
    int currPosIndex = 0;
    List<Transform> handPos = new List<Transform>();

    Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<MeshRenderer>().material;

        handPos.Clear();
        for (int i = 0; i < MAX_NUMBER_OF_HANDS; i++)
        {
            GameObject go = new GameObject("transform refrence " + i + ".");
            go.transform.parent = transform;
            handPos.Add(go.transform);
        }
    }

    private void Update()
    {
        Vector4[] HandContact = new Vector4[6];
        Vector4[] HandContactFwd = new Vector4[6];
        Vector4[] HandContactRight = new Vector4[6];

        for (int i = 0; i < MAX_NUMBER_OF_HANDS; i++)
        {
            HandContact[i] = handPos[i].position;
            HandContactFwd[i] = handPos[i].forward;
            HandContactRight[i] = handPos[i].right;
        }

        objectMaterial.SetVectorArray("_HandContact", HandContact);
        objectMaterial.SetVectorArray("_HandContactFwd", HandContactFwd);
        objectMaterial.SetVectorArray("_HandContactRight", HandContactRight);
    }

    public void SetNewContact(Vector3 contactPos)
    {
        handPos[currPosIndex].position = contactPos;
        currPosIndex++;
        currPosIndex %= MAX_NUMBER_OF_HANDS;
    }
}
