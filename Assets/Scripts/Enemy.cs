using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerTarget list;
    public int maxHealth = 100;
    [SerializeField] int currentHealth;
    public EnemyHealthBar healthBar;
    public Rigidbody rb;
    


    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            TakeDamage(20);
            Debug.Log("Taking Damage");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        list = FindObjectOfType<PlayerTarget>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            //list.TargetIndex = -1;
            // rb.gameObject.SetActive(false);
            list.MonsterList.Remove(gameObject);
            
            Destroy(gameObject);
           



        }
        
    }
}
