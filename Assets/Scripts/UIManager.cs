using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    int score = 0;

    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    public void Resume() {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void UpdateScore() {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOver.SetActive(true);
    }

    public void Replay() {
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit() {
        Application.Quit();
    }
    
    public void StartGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitToMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
