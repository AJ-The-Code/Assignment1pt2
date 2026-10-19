using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    private float topBoundary = 30.0f;
    private float lowerboundary = -10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBoundary)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerboundary)
        {
            Destroy(gameObject);

        }

    }
}
