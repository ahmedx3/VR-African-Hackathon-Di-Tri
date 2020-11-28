using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dish : MonoBehaviour
{
    public Person personToBeServed;
    bool isPlateEmpty = false;

    public float MAX_EAT_TIME = 5;

    public float MAX_CORRECT_DISTANCE = 0.5f;

    void Start()
    {
        this.transform.Find("Canvas").gameObject.transform.Find("PN").GetComponent<Text>().text = personToBeServed.name;
        this.transform.Find("Canvas").gameObject.transform.Find("TN").GetComponent<Text>().text = personToBeServed.table.tableNumber.ToString();
    }

    void Update()
    {
        ServeTheDish();

        if (isPlateEmpty)
        {
           this.transform.Find("Gfx").transform.Find("Cube").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
           personToBeServed.SetHasOrdered(false);
        }
    }

    private void ServeTheDish()
    {
        float distanceToPerson = Vector3.Distance(transform.position, personToBeServed.dishPosition.position);

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
