using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    Room room;
    PlayerTarget list;

    // Start is called before the first frame update
    void Start()
    {
        room = FindObjectOfType<Room>();
        list = FindObjectOfType<PlayerTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        if(room.playerInRoom == true && list.MonsterList.Count<=0)
        {
            animator.SetBool("OPEN", true);
        }
    }
}
