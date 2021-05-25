using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

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
        }
        else
        {
            Destroy(this);
        }
    }
}
