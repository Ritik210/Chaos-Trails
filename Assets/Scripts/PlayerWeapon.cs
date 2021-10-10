﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 20;  
    }

    /* public void OnTriggerEnter(Collider other)
     {
         Debug.Log("Name :" + other.transform.name);
         if(other.transform.CompareTag("Wall") || other.transform.CompareTag("Monster"))
         {
             Debug.Log("Name :" + other.transform.name);
             GetComponent<Rigidbody>().velocity = Vector3.zero;
             Destroy(gameObject, 0.2f);
         }
     }
     private void OnCollisionEnter(Collision collision)
     {
         Debug.Log("Name :" + collision.transform.name);
         if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Monster"))
         {
             Debug.Log("Name :" + collision.transform.name);
             GetComponent<Rigidbody>().velocity = Vector3.zero;
             Destroy(gameObject, 0.2f);
         }
     }*/

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster"|| collision.gameObject.tag == "Wall")
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
}
