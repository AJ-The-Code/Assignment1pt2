using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; // An array of game object animal prefabs
    // Start is called before the first frame update
    private float x = 20; //where on the horizontal will the animals spawn
    private float spawnPosZ = 20;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f); //Takes a method and constantly repeat it over time. This starts at 2 seconds and repeats every one second
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnRandomAnimal() 
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-x, x), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }


    
}
