using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{

    public GameObject handPrefab;
    public float timeBetweenInstances = 3;

    float timer = 0;
    bool canInstantiate = true;

    private void Update()
    {
        if (!canInstantiate)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                canInstantiate = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*FingerPrintedObject fpo = other.gameObject.GetComponent<FingerPrintedObject>();
        if (fpo)
        {
            //Debug.Log(fpo);
            //fpo.SetNewContact(transform.position);// (other.ClosestPointOnBounds(transform.position));
        }*/

        if (!canInstantiate)
            return;

        if (other.name == "BodyCollider")
            return;

        canInstantiate = false;
        timer = timeBetweenInstances;

        GameObject go = Instantiate(handPrefab,
            other.ClosestPointOnBounds(transform.position),
            //Quaternion.FromToRotation(other.ClosestPointOnBounds(transform.position), other.ClosestPointOnBounds(transform.position) - transform.position));
            Quaternion.FromToRotation(other.ClosestPoint(transform.position), transform.position - other.ClosestPoint(transform.position)));

        go.transform.parent = other.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.name);
        //FingerPrintedObject fpo = collision.transform.gameObject.GetComponent<FingerPrintedObject>();
        //if (fpo)
        //{
        //    fpo.SetNewContact(collision.contacts[0].point);
        //}
    }

}
