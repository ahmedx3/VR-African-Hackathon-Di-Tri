using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        FingerPrintedObject fpo = other.gameObject.GetComponent<FingerPrintedObject>();
        Debug.Log(fpo);
        if (fpo)
        {
            fpo.SetNewContact(transform.position);// (other.ClosestPointOnBounds(transform.position));
        }
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
