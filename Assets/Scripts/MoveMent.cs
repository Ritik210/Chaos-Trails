using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMent : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody rb;
    public Animator Anim;
    public Transform target;
    float horizontal;
    float vertical;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject Panel;
    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
   void Update()
     {
        if(currentHealth <= 0)
        {
            Panel.SetActive(true);
            Button.SetActive(false);
            

           
            
        }
     }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal") ;
        vertical = Input.GetAxis("Vertical") ;

        rb.velocity = new Vector3(horizontal * speed * Time.deltaTime, rb.velocity.y, vertical * speed * Time.deltaTime);

        if (JoystickMovement.Instance.joyVec.x != 0 || JoystickMovement.Instance.joyVec.y != 0)
        {
            rb.velocity = new Vector3(JoystickMovement.Instance.joyVec.y* speed*Time.deltaTime, rb.velocity.y, JoystickMovement.Instance.joyVec.x * -1 * speed * Time.deltaTime);
            rb.rotation = Quaternion.LookRotation(new Vector3(JoystickMovement.Instance.joyVec.y, 0, -JoystickMovement.Instance.joyVec.x));
           
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            TakeDamage(10);
        }
    }
    
}
