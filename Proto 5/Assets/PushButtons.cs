using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButtons : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameManager gameManager;
    public float time;
    public void RestartButton()
    {
        Time.timeScale = 1; //Ensures the time always starts at 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseButton()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        ;//Stops time for the pause

    }
    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1; //Returns time to its normal scale.
        
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("Score",gameManager.score); 
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
