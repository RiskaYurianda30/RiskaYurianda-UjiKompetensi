using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static float GameScore = 0;
    public static bool IsGameOver = false;

    [SerializeField] private int timer;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TMP_Text endScore;
    [SerializeField] private GameObject pauseCanvas;

    private bool isPaused;

    private void Awake()
    {
        gameOverCanvas.SetActive(false);
    }
    void Start()
    {
        scoreText.text += GameScore;
        InvokeRepeating(nameof(Timer), 0, 1);
        Time.timeScale = 1;
        GameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                pauseCanvas.SetActive(false);
                isPaused = false;
                return;
            }

            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            isPaused = true;
        }

        if (timer <= 0)
        {
            GameOver();
            return;
        }

        scoreText.text = GameScore.ToString();
        timerText.text = timer.ToString();
    }

    private void GameOver()
    {
        IsGameOver = true;
        gameOverCanvas.SetActive(true);
        endScore.text = GameScore.ToString();
        Time.timeScale = 0;
    }

    private void Timer()
    {
        timer -= 1;
    }

    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
}
