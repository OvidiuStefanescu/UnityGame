using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restart;
    [SerializeField] private GameObject gameFinishedPanel;

    private void Start()
    {
        score.SetText("Score: 0");
        controller.ScoreChanged += OnScoreChanged;
        controller.GameOver += OnGameOver;
        controller.GameFinished += OnGameFinished;
        restart.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    private void OnGameFinished()
    {
        gameFinishedPanel.SetActive(true);
    }

    private void OnScoreChanged()
    {
        score.SetText("Score: " + controller.CurrentScore.ToString());
    }

}
