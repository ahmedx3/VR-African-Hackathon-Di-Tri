﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    public Person[] persons;

    public int tableNumber;

    public GameObject player;
    int damping = 12;

    void Start()
    {
        this.transform.Find("Canvas").gameObject.transform.Find("Text").GetComponent<Text>().text = tableNumber.ToString();
    }

    void Update()
    {
        var lookPos = this.transform.Find("Canvas").gameObject.transform.position - player.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        this.transform.Find("Canvas").gameObject.transform.rotation = Quaternion.Slerp(this.transform.Find("Canvas").gameObject.transform.rotation, rotation, Time.deltaTime * damping);
    }

    public List<Person> GetEmptyHandedPersons()
    {
        List<Person> emptyPersons = new List<Person>();

        foreach (var person in persons)
        {
            if (!person.HasPlate() && !person.HasOrdered())
            {
                emptyPersons.Add(person);
            }
        }

        return emptyPersons;
    }
}
