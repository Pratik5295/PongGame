using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rgbody;
    public float speed = 2f;
    private float originalSpeed;
    public bool Player1;
    public bool Player2;

    private float y;

    public int Score;

    private Vector3 startPosition;

    void Start()
    {
        rgbody = this.GetComponent<Rigidbody2D>();
        startPosition = this.transform.position;
        originalSpeed = speed;
        Score = 0;

        if (Player1)
        {
            Player2 = false;
        }
        else
        {
            Player2 = true;
            GameManager.instance.currentState = GameManager.GameState.PVP;
        }
    }

    void Update()
    {
        //If the game is not running, then dont take user controls and reset the position
        if (GameManager.instance.currentState == GameManager.GameState.GameOver || !GameManager.instance.isRunning)
        {
            this.transform.position = startPosition;
            speed = originalSpeed;
        }
        else
        {
            Movement();
        }
    }

    public void Movement()
    {
        if (Player1)
        {

            y = Input.GetAxisRaw("Vertical");
        }
        else if (Player2)
        {
            y = Input.GetAxisRaw("Vertical2");
        }
        rgbody.velocity = new Vector2(rgbody.velocity.x, y * speed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Score++;
            if (Player1)
            {
                GameUI.instance.SetPlayer1Display(Score);
            }
            else if (Player2)
            {
                GameUI.instance.SetPlayer2Display(Score);
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<PowerUp>().ResetPosition();
            speed += 1f;

        }
    }
}
