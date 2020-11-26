using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public string personName;
    public Transform dishPosition;
    public Table table;

    private bool hasPlate = false;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public bool HasPlate()
    {
        return hasPlate;
    }

    public void SetHasPlate(bool value)
    {
        hasPlate = value;
    }
}
