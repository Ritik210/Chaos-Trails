using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    
    Vector3 cameraPosition;

    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = Player.position.x;
        temp.x += offset;
       // temp.z = Player.position.z;

        transform.position = temp;


    }
}
