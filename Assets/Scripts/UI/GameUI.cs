using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI instance = null;
    public TMP_Text player1Score;
    public TMP_Text player2Score;

    public GameObject mainMenuPanel;
    public GameObject instructionPanel;
    public GameObject victoryPanel;
    public TMP_Text victoryText;
    private int p1Score;
    private int p2Score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            SetPlayer1Display(0);
            SetPlayer2Display(0);
            instructionPanel.SetActive(false);
            victoryPanel.SetActive(false);
        }

        else
        {
            Destroy(this);
        }
    }

    public void SetPlayer1Display(int _value)
    {
        player1Score.text = "Score: " + _value;
        p1Score = _value;
    }

    public void SetPlayer2Display(int _value)
    {
        player2Score.text = "Score: " + _value;
        p2Score = _value;
    }


    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void TurnMainMenuOn()
    {
        mainMenuPanel.SetActive(true);
    }

    public void ShowInstructions()
    {
        instructionPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionPanel.SetActive(false);
    }

    public void ShowVictory(string _text)
    {
        victoryText.text = _text;

        victoryPanel.SetActive(true);
    }

    public void HideVictory()
    {
        victoryPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
