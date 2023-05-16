using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 250.0f;
    [SerializeField] private float accelerateRate = 0.5f;
    [SerializeField] private float sprintMultiplier = 15.0f;

    private int currentScore = 0;
    private bool isSprinting = false;
    private bool isGameOver = false;

    public int CurrentScore => currentScore;

    public event Action ScoreChanged;
    public event Action GameOver;
    public event Action GameFinished;

    private void Update()
    {
        if (isGameOver)
            return;

        transform.Translate(transform.forward * movementSpeed * Time.deltaTime * (isSprinting ? sprintMultiplier : 1));

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Sprint(true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Sprint(false);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.Translate(transform.up * movementSpeed * Time.deltaTime * 20);
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    transform.Translate(transform.up * movementSpeed * Time.deltaTime * -20);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        movementSpeed += accelerateRate * Time.deltaTime;
    }

    private void MoveLeft()
    {
        if (transform.position.x == -1.5f)
            return;

        transform.Translate(transform.right * -1.5f);
    }

    private void MoveRight()
    {
        if (transform.position.x == 1.5f)
            return;

        transform.Translate(transform.right * 1.5f);
    }

    private void Sprint(bool sprintValue)
    {
        isSprinting = sprintValue;
    }

    public void ChangeScore(int amount)
    {
        currentScore += amount;
        ScoreChanged?.Invoke();

        if (currentScore < 0)
        {
            GameOver?.Invoke();
            isGameOver = true;
        }
    }

    public void FireGameOver()
    {
        GameFinished?.Invoke();
        isGameOver = true;
    }
}
