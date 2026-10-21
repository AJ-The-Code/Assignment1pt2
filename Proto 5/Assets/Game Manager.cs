using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
public class GameManager : MonoBehaviour
{
    //public TextMeshProUGUI gamerOverText;
    public GameObject gameOverMenu;
    public int score;
    public TextMeshProUGUI scoreText;
    public int highScore;
    public TextMeshProUGUI highScoreText;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public bool isGameActive;
    //public Button restartButton;
    public StartMenuButtons startGame;
    private float easyAdjuster = 3;
    private float mediumAdjuster = 0.5f;
    private float hardAdjuster = -0.5f;
    public StartMenuButtons difficultyMenu;
    // Start is called before the first frame update

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HighScore: " + highScore;

    }
    public bool Easy()
    {
        difficultyMenu.difficultyMenu.SetActive(false);
        difficultyMenu.difficultyMenu.SetActive(false);
        difficultyMenu.savedGame.SetActive(true);
        difficultyMenu.savedGameButton.SetActive(true);
        return true;
    }
    public void EasyCall() 
    { 
        Easy();
        PlayerPrefs.SetInt("Easy", Easy() ? 1 : 0);
    }   // ? 1:0 means if Easy() is true, 1, otherwise = 0
    public bool Medium()
    {
        difficultyMenu.difficultyMenu.SetActive(false);
        difficultyMenu.difficultyMenu.SetActive(false);
        difficultyMenu.savedGame.SetActive(true);
        difficultyMenu.savedGameButton.SetActive(true);
        return true;
    }
    public void MediumCall() 
    { 
      Medium();
      PlayerPrefs.SetInt("Medium", Medium() ? 1 : 0);
    }
    public bool Hard() 
    {
        difficultyMenu.difficultyMenu.SetActive(false);
        difficultyMenu.difficultyMenu.SetActive(false);
        difficultyMenu.savedGame.SetActive(true);
        difficultyMenu.savedGameButton.SetActive(true);
        return true;
    }
    public void HardCall() 
    { 
        Hard();
        PlayerPrefs.SetInt("Hard", Hard() ? 1 : 0);
    } //Unity doesnt allow me to call on public bool
    public void StartGame() 
    {
        //if (startGame.gameStart == true)
        {
            startGame.mainMenu.SetActive(false);
            isGameActive = true;
            score = 0;
            StartCoroutine(SpawnTarget());
            UpdateScore(0);
        }
    }
    public void StartSavedGame()
    {
        //if (startGame.gameStart == true)
        {
            startGame.mainMenu.SetActive(false);
            score = PlayerPrefs.GetInt("Score");
            isGameActive = true;
            StartCoroutine(SpawnTarget());
            UpdateScore(0);
        }
    }
    public void GameOver() {
        startGame.gameStart = false;
        isGameActive = false;
        gameOverMenu.SetActive(true);
        
    }
    IEnumerator SpawnTarget()
    {
        if (PlayerPrefs.GetInt("Medium", Medium() ? 1 : 0) == 1)
        { 
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate + mediumAdjuster);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
                
            }
        }
        else if (PlayerPrefs.GetInt("Easy", Easy() ? 1 : 0) == 1)
            { 
                while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate + easyAdjuster);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
                
            }

            }
        else if (PlayerPrefs.GetInt("Hard", Hard() ? 1 : 0) == 1) //Allows me to keep the diff values until changed.
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate + hardAdjuster);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
                

            }
        }
        else
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate + mediumAdjuster);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);

            }
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        //Debug.Log("Score received: " + scoreToAdd);
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
