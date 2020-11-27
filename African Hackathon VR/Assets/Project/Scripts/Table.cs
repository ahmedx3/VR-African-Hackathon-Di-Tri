using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Person[] persons;

    public int tableNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
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
