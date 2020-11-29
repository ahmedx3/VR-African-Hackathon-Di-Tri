using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlateGeneration : MonoBehaviour
{
    public Restaurant restaurant;

    public List<GenerationPosition> dishSpawnPos = new List<GenerationPosition>();

    public float MAX_PLATE_GENERATION_TIME = 15;

    float plateGenerationTime;
    int MAX_DISHES;

    public GameObject dishGO;

    void Start()
    {
        MAX_DISHES = dishSpawnPos.Count;
        plateGenerationTime = MAX_PLATE_GENERATION_TIME;
    }

    void Update()
    {
        GenerateDish();
    }

    private void GenerateDish()
    {
        if (plateGenerationTime > 0)
        {
            plateGenerationTime -= Time.deltaTime;
        }
        else
        {

            List<Person> people = restaurant.GetEmptyHandedPersons();

            if (people.Count > 0)
            {
                foreach (var dishPos in dishSpawnPos)
                {
                    if (!dishPos.isOccupied)
                    {
                        int randomIndex = UnityEngine.Random.Range(0, people.Count);
                        dishGO.GetComponent<Dish>().personToBeServed = people[randomIndex];
                        people[randomIndex].SetHasOrdered(true);
                        Instantiate(dishGO, dishPos.transform);
                        break;
                    }
                }
            }

            plateGenerationTime = MAX_PLATE_GENERATION_TIME;
        }
    }
}
