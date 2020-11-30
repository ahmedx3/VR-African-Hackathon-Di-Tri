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

    public float MAX_CORRECT_DISTANCE = 0.8f;

    //public GameObject player;
    //int damping = 12;

    public Text personName;
    public Text tableNumber;

    void Start()
    {
        personName.text = personToBeServed.name;
        tableNumber.text = personToBeServed.table.tableNumber.ToString();
    }

    bool hasScored = false;
    void Update()
    {
        ServeTheDish();

        if (isPlateEmpty)
        {
            if (!hasScored)
            {
                ScoreSystem.score += 45;
                hasScored = true;
            }
           this.transform.Find("Gfx").transform.Find("Slice").gameObject.SetActive(false);
           this.transform.Find("Gfx").transform.Find("Plate").transform.Find("Canvas").transform.Find("Panel").GetComponent<Image>().color = new Color(1, 0, 0, 0.3f);
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
