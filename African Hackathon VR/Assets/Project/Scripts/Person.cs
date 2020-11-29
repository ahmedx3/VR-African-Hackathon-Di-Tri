using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour
{
    public string personName;
    public Transform dishPosition;
    public Table table;

    private bool hasPlate = false;
    private bool hasOrdered = false;

    public float MAX_CORRECT_DISTANCE = 0.8f;

    public GameObject player;
    int damping = 12;

    void Start()
    {
        this.transform.Find("Canvas").gameObject.transform.Find("Text").GetComponent<Text>().text = personName;
    }

    void Update()
    {
        CheckHasPlate();
        var lookPos = this.transform.Find("Canvas").gameObject.transform.position - player.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        this.transform.Find("Canvas").gameObject.transform.rotation = Quaternion.Slerp(this.transform.Find("Canvas").gameObject.transform.rotation, rotation, Time.deltaTime * damping);
    }

    private void CheckHasPlate()
    {
        foreach (var dish in GameObject.FindGameObjectsWithTag("Dish"))
        {
            if (Vector3.Distance(dishPosition.position,dish.transform.position) < MAX_CORRECT_DISTANCE)
            {
                hasPlate = true;
                return;
            }
        }

        hasPlate = false;
    }

    public bool HasPlate()
    {
        return hasPlate;
    }

    public void SetHasPlate(bool value)
    {
        hasPlate = value;
    }

    public bool HasOrdered()
    {
        return hasOrdered;
    }

    public void SetHasOrdered(bool value)
    {
        hasOrdered = value;
    }
}
