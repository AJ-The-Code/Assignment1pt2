using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float Boundary = 10.0f;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -Boundary)
        {
            transform.position = new Vector3(-Boundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > Boundary)
        {
            transform.position = new Vector3(Boundary, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Launch a projectile form the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector2.right);
    }
}
