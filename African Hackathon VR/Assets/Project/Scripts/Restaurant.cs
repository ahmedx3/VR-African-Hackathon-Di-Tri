using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    public Table[] tables;

    void Start()
    {
        
    }

    void Update()
    {
        List<Person> persons = GetEmptyHandedPersons();
    }

    public List<Person> GetEmptyHandedPersons()
    {
        List<Person> emptyPersons = new List<Person>();

        foreach (var table in tables)
        {
            foreach (var person in table.GetEmptyHandedPersons())
            {
                emptyPersons.Add(person);
            }
        }

        return emptyPersons;
    }
}
