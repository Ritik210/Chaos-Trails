using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : MonoBehaviour
{
    public static JoystickMovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<JoystickMovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("JoyStickMovement");
                    instance = instanceContainer.AddComponent<JoystickMovement>();
                }
            }
            return instance;
        }
    }
    private static JoystickMovement instance;
    MoveMent anim;
    PlayerTarget target;
    public GameObject smallStick;
    public GameObject bGStick;
    Vector3 stickFirstPosition;
    public Vector3 joyVec;
    Vector3 joystickFirstPosition;
    float stickRadius;
    public bool isPlayerMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = FindObjectOfType<MoveMent>();
        target = FindObjectOfType<PlayerTarget>();
        stickRadius = bGStick.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        joystickFirstPosition = bGStick.transform.position;
    }

    public void PointDown()
    {
        bGStick.transform.position = Input.mousePosition;
        smallStick.transform.position = Input.mousePosition;
        stickFirstPosition = Input.mousePosition;

        if(!anim.Anim.GetCurrentAnimatorStateInfo(0).IsName("WALK"))
        {
            anim.Anim.SetBool("ATTACK", false);
            anim.Anim.SetBool("IDLE", false);
            anim.Anim.SetBool("WALK", true);
        }
        isPlayerMoving = true;
        target.getATarget = false;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - stickFirstPosition).normalized;

        float stickDistance = Vector3.Distance(DragPosition, stickFirstPosition);

        if(stickDistance< stickRadius)
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickDistance;
        }
        else
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickRadius;
        }
    }

    public void Drop()
    {
        joyVec = Vector3.zero;
        bGStick.transform.position = joystickFirstPosition;
        smallStick.transform.position = joystickFirstPosition;

        if (!anim.Anim.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            anim.Anim.SetBool("ATTACK", false);
            anim.Anim.SetBool("WALK", false);
            anim.Anim.SetBool("IDLE", true);
        }
        isPlayerMoving = false;
        
    }

}
