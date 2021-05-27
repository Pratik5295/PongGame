using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall : MonoBehaviour
{
    public GameObject player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if(player.name == "Player1")
            {
                GameUI.instance.ShowVictory("Player 2 has won!");
            }
            else if(player.name == "Player2")
            {
                GameUI.instance.ShowVictory("Player 1 has won!");
            }
            GameManager.instance.GameOver();
            
        }

        if(collision.gameObject.tag == "PowerUp")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
