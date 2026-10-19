using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using System.Linq;
using System.Xml;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //private bool timerRunning = false;
    // private float timer = 0f;
    public GameObject red;
    public GameObject blue;
    public GameObject black;
    public GameObject orange;
    public GameObject brown;
    public GameObject purple;
    public GameObject yellow;
    public List<float> colors;

    public BeginGame beginGame;


    // Start is called before the first frame update
    void Awake()
    {
        int rand_y = Random.Range(0, 100);
        transform.position = new Vector3(0, rand_y, 0);
    }
    void Start()
    {
        blue = GameObject.Find("Blue");
        float bluePos = blue.transform.position.y;
        red = GameObject.Find("Red");
        float redPos = red.transform.position.y;
        black = GameObject.Find("Black");
        float blackPos = black.transform.position.y;
        orange = GameObject.Find("Orange");
        float orangePos = orange.transform.position.y;
        brown = GameObject.Find("Brown");
        float brownPos = brown.transform.position.y;
        purple = GameObject.Find("Purple");
        float purplePos = purple.transform.position.y;
        yellow = GameObject.Find("Yellow");
        float yellowPos = yellow.transform.position.y;
        colors = new List<float> { bluePos, redPos, orangePos, blackPos, brownPos, purplePos, yellowPos, transform.position.y};

    }


    // Update is called once per frame
    void Update() //Loops through max y's to see if green is max. If it is good.
    {


        if (!Input.GetKeyDown(KeyCode.Space)) return; //Allows gameEnded to ignore when space not pressed
            if (beginGame.isGameActive == false) 
            {
                if (beginGame.gameEnded)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                 
            }
            return;//Allows me to show the win/loss text
        }
                float max = colors.Max(); //Highest pos and space pressed
                if (transform.position.y == max) //Updates everyframe and checks the max color y for the frame.
                { Debug.Log("Congrats, You Won!"); }
                else if (transform.position.y < max)
                {
                    Debug.Log("You lost, better luck next time.");
                }
                beginGame.isGameActive = false;
                beginGame.gameEnded = true;
            



        
    }
}