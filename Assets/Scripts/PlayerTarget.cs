using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    MoveMent animator;
    Room room;
    public bool getATarget = false;
    float currentDist = 0;
    float closetDist = 100f;
    float TargetDist = 100f;
    int closeDistIndex = 0;
    public int TargetIndex = -1;
    int prevTargetIndex = 0;
    public LayerMask layerMask;

    public float atkSpd = 1f;

    public List<GameObject> MonsterList = new List<GameObject>();


    public GameObject PlayerBolt;
    public Transform AttackPoint;

    private void Start()
    {
        animator = GetComponent<MoveMent>();
        room = FindObjectOfType<Room>();
    }
    void OnDrawGizmos()
    {
        if (getATarget)
        {
            for (int i = 0; i < MonsterList.Count; i++)
            {
                if (MonsterList[i] == null) { return; }
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, MonsterList[i].transform.GetChild(0).position - transform.position,
                                            out hit, 20f, layerMask);

                if (isHit && hit.transform.CompareTag("Monster"))
                {
                    Gizmos.color = Color.green;
                }
                else
                {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawRay(transform.position, MonsterList[i].transform.GetChild(0).position - transform.position);
            }
        }
    }
    void Update()
    {
        SetTarget();
        AtkTarget();
        //Attack();
    }

    void Attack()
    {
       
        {
            animator.Anim.SetFloat("AttackSpd", atkSpd);
            Instantiate(PlayerBolt, AttackPoint.position, transform.rotation);
        }
    }
    void SetTarget()
    {
        if (MonsterList.Count != 0)
        {
            prevTargetIndex = TargetIndex;
            currentDist = 0f;
            closeDistIndex = 0;
            TargetIndex = -1;

            for (int i = 0; i < MonsterList.Count; i++)
            {
                if (MonsterList[i] == null) { return; }   
                currentDist = Vector3.Distance(transform.position, MonsterList[i].transform.GetChild(0).position);

                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, MonsterList[i].transform.GetChild(0).position - transform.position,
                                            out hit, 20f, layerMask);

                if (isHit && hit.transform.CompareTag("Monster"))
                {
                    if (TargetDist >= currentDist)
                    {
                        TargetIndex = i;

                        TargetDist = currentDist;

                        if (!JoystickMovement.Instance.isPlayerMoving && prevTargetIndex != TargetIndex)  
                        {
                            TargetIndex = prevTargetIndex;
                        }
                    }
                }

                if (closetDist >= currentDist)
                {
                    closeDistIndex = i;
                    closetDist = currentDist;
                }
            }

            if (TargetIndex == -1)
            {
                TargetIndex = closeDistIndex;
            }
            closetDist = 100f;
            TargetDist = 100f;
            getATarget = true;
        }

    }

    void AtkTarget()
    {
        if (TargetIndex == -1 || MonsterList.Count == 0)  // 추가 
        {
            animator.Anim.SetBool("ATTACK", false);
            return;
        }
       
        if (getATarget && !JoystickMovement.Instance.isPlayerMoving && MonsterList.Count != 0)
        {
            //            Debug.Log ( "lookat : " + MonsterList[TargetIndex].transform.GetChild ( 0 ) );  // 변경
            transform.LookAt(MonsterList[TargetIndex].transform.GetChild(0));
            if (animator.Anim.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
            {
              animator.Anim.SetBool("ATTACK", true);
              animator.Anim.SetBool("IDLE", false);
              animator.Anim.SetBool("WALK", false);

            }


          /*  if(room.playerInRoom == false)
            {
                animator.Anim.SetBool("ATTACK", false);
            }*/

        }
        else if (JoystickMovement.Instance.isPlayerMoving)
        {
            if (!animator.Anim.GetCurrentAnimatorStateInfo(0).IsName("WALK"))
            {
                animator.Anim.SetBool("ATTACK", false);
                animator.Anim.SetBool("IDLE", false);
                animator.Anim.SetBool("WALK", true);
            }
        }
       else
      {
         animator.Anim.SetBool("ATTACK", false);
        animator.Anim.SetBool("IDLE", true);
        animator.Anim.SetBool("WALK", false);
      }
    }

    



}
