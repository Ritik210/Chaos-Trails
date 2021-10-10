using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    List<GameObject> MonsterListInRoom = new List<GameObject>();
    public bool playerInRoom = false;
    public bool isClearRoom = false;
    MoveMent animator;
    PlayerTarget target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerTarget>();
        animator = FindObjectOfType<MoveMent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRoom)
        {
            if(MonsterListInRoom.Count <=0)
            {
                isClearRoom = true;
                Debug.Log("clear");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRoom = true;
            target.MonsterList = new List<GameObject>(MonsterListInRoom);
            Debug.Log("Enter room! Mob Count :" + target.MonsterList.Count);
            
        }
        if(other.CompareTag("Monster"))
        {
            MonsterListInRoom.Add(other.gameObject);
            Debug.Log("Mob name :" + other.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRoom = false;
           


            Debug.Log("Player Exit");
        }
        if (other.CompareTag("Monster"))
        {
            MonsterListInRoom.Remove(other.gameObject);
            
        }
    }
}
