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
            GameManager.instance.currentState = GameManager.GameState.GameOver;
            collision.gameObject.GetComponent<Ball>().ResetPosition();
        }
    }
}
