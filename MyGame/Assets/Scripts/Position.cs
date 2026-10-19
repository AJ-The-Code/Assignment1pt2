using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Position : MonoBehaviour
{
    public PlayerController theColor;
    public BeginGame beginGame;
    // Start is called before the first frame update

    void Awake() //Goes before the start()
    {
        int rand_y = Random.Range(0, 100);
        transform.position = new Vector3(0, rand_y, 0);
    }
    void Start()
    {
        StartCoroutine(DestroyTarget());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator DestroyTarget()
    {
        int randTime = Random.Range(1, 10); //Time it takes for platform to disapear
        
            UnityEngine.WaitForSeconds wait = new WaitForSeconds(randTime); //camera going to green
            yield return new WaitUntil(() => beginGame.isGameActive); //Updates the value of the bool
            yield return wait;
            { Destroy(gameObject); } //Destorys Object after wait
           
    }
    private void OnDestroy()
    {
        if (theColor.colors.Count >= 1) 
        {
            theColor.colors.Remove(transform.position.y);

        }
         //Removes the y value from the list so that the list can keep updating the max.
    }
}
