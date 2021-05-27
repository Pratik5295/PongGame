using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float gameTimer;     //This counter will be used to increase the speed of the ball
    public float powerTimer;       //This counter is for spawning power Timer;
    public Ball ball;

    public bool isRunning;

    public PowerUp powerObject;

    public enum GameState
    {
        MainMenu,
        PVP,
        PVE,
        GameOver
    }

    public GameState currentState;


    private void Awake()
    {

        //Assigning the instance of Game Manager class and destroying any additional or duplicates created of this class
        if (instance == null)
        {
            instance = this;
            currentState = GameState.MainMenu;
            gameTimer = 0f;
            powerTimer = 0f;
            isRunning = false;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        gameTimer += Time.deltaTime;
        powerTimer += Time.deltaTime;

        if(gameTimer >= 10f)
        {
            ball.IncreaseSpeed();
            gameTimer = 0f;
        }

        if(powerTimer >= 20f)
        {
            powerObject.gameObject.SetActive(true);
            powerObject.StartPower();
            powerTimer = 0f;
        }

    }

    public void StartGame()
    {
        ball.StartGame();
        isRunning = true;
        currentState = GameState.PVP;
        gameTimer = 0f;
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        isRunning = false;
        gameTimer = 0f;
        ball.ResetPosition();
        GameUI.instance.TurnMainMenuOn();
        GameUI.instance.ShowVictory();
    }
}
