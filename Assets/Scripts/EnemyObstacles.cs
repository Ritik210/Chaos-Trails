using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacles : MonoBehaviour
{
    MoveMent damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = FindObjectOfType<MoveMent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damage.TakeDamage(10);
            Debug.Log("Hit");
        }
    }
    
}
