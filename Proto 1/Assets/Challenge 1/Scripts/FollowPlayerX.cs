using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    private Vector3 offset = new Vector3(21.71f, 3.22f, 14.76f);
    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate() //Do late update so it doesnt jitter
    {
        transform.position = plane.transform.position + offset;
    }
}
