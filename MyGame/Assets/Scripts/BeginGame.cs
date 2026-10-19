using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BeginGame : MonoBehaviour
{
    public bool isGameActive;
    public bool gameEnded;
    public TextMeshProUGUI timeText;
    public float time;
    public PlayerController green;
    public Button startButton;
    // Start is called before the first frame update
    private void Awake()
    {
        isGameActive = false; //Allows me to set it to true later
        gameEnded = false; //After/before space is pressed
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (green.colors.Max() == green.transform.position.y)
        {
            time = 0;
        }
    }
    public void StartGame()
    {
        isGameActive = true; 
        startButton.gameObject.SetActive(false);
    }
}
