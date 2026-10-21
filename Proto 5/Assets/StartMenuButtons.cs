using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public bool gameStart;
    public TextMeshProUGUI saveGameText;
    public GameManager score;
    public GameObject saveMenu;
    public GameObject difficultyMenu;
    public GameManager difficulty;
    public GameObject savedGame;
    public GameObject savedGameButton;
    public GameObject audioSettings;
    public AudioSource audioSource;
    public GameObject difficulty_txt;
    public GameObject difficulty_button;
    private void Start()
    {
        audioSource.mute = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        audioSource.Play();
    }
    public void StartButton()
    {
        mainMenu.SetActive(false);
        gameStart = true;
        //In Game Manager

    }

    public void SavedGame()
    {
        saveMenu.SetActive(true);
        saveGameText.text = "Last loaded game score: " + PlayerPrefs.GetInt("Score");

    }

    public void Difficulty()
    {
        difficultyMenu.SetActive(true);
        savedGame = GameObject.Find("Saved Game");
        savedGameButton = GameObject.Find("Saved Game Button");
        savedGame.SetActive(false);
        savedGameButton.SetActive(false);
        PlayerPrefs.SetInt("Easy", 0);
        PlayerPrefs.SetInt("Medium", 0); //Resets the difficulty when pressesing the difficulty button.
        PlayerPrefs.SetInt("Medium", 0);



    }
    public void AudioSettings()
    {
        audioSettings.SetActive(true);
        savedGame.SetActive(false);
        savedGameButton.SetActive(false);
        difficulty_txt.SetActive(false);
        difficulty_button.SetActive(false);



    }
    public void AudioSettingsOptionYes()
    {
        audioSource.mute = false;
        if (!audioSource.isPlaying)
            audioSource.Play();
        PlayerPrefs.SetInt("MusicMuted", 0);

        
    }
    public void AudioSettingsOptionNo()
    {
        audioSource.mute = true;
        PlayerPrefs.SetInt("MusicMuted", 1);
    }
    public void BackButtonAudio()
    {
        savedGame.SetActive(true);
        savedGameButton.SetActive(true);
        difficulty_txt.SetActive(true);
        difficulty_button.SetActive(true);
        audioSettings.SetActive(false);
    }
    public void BackButtondif()
    {
        difficultyMenu.SetActive(false);
        savedGame.SetActive(true);
        savedGameButton.SetActive(true);
        


    }
    public void BackButtonsave()
    {

        saveMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

