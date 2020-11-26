using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public Person personToBeServed;
    bool isPlateEmpty = false;

    private float MAX_EAT_TIME = 10;

    public float MAX_CORRECT_DISTANCE = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        ServeTheDish();

        if (isPlateEmpty)
        {
           this.transform.Find("Gfx").transform.Find("Cube").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }

    private void ServeTheDish()
    {
        float distanceToPerson = Vector3.Distance(transform.position, personToBeServed.dishPosition.position);

        Debug.Log("distanceToPerson : "  +  distanceToPerson);

        if (distanceToPerson < MAX_CORRECT_DISTANCE)
        {
            EatTheDish();
        }
    }

    private void EatTheDish()
    {
        if (MAX_EAT_TIME > 0)
        {
            MAX_EAT_TIME -= Time.deltaTime;
        }
        else
        {
            isPlateEmpty = true;
        }
    }
}
