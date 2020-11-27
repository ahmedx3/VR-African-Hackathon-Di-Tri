using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationPosition : MonoBehaviour
{
    public bool isOccupied;
    public float MAX_CORRECT_DISTANCE = 0.5f;

    void Start()
    {
        isOccupied = false;
    }

    void Update()
    {
        CheckIsOccupied();
    }

    private void CheckIsOccupied()
    {
        foreach (var dish in GameObject.FindGameObjectsWithTag("Dish"))
        {
            if (Vector3.Distance(transform.position, dish.transform.position) < MAX_CORRECT_DISTANCE)
            {
                isOccupied = true;
                return;
            }
        }

        isOccupied = false;
    }
}
