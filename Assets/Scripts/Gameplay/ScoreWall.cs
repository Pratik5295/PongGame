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
            GameManager.instance.GameOver();
            
        }

        if(collision.gameObject.tag == "PowerUp")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
