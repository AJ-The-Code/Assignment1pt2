using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(-.17f, 6.54f, -8.61f);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Makes the camera positiion mirror the players position plus the offset of the cameras intial position.
        transform.position = player.transform.position + offset; 
    }
}
