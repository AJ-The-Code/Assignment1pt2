using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gamerOverText;
    private int score;
    public TextMeshProUGUI scoreText;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public bool isGameActive;
    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    public void GameOver() {
        isGameActive = false;
        gamerOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        Debug.Log("Score received: " + scoreToAdd);
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
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
