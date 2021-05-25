using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rgbody;
    public float speed = 2f;

    public bool Player1;
    public bool Player2;

    private float y;

    public int Score;

    void Start()
    {
        rgbody = this.GetComponent<Rigidbody2D>();
        Score = 0;

        if (Player1)
        {
            Player2 = false;
        }
        else
        {
            Player2 = true;
        }
    }
    
    void Update()
    {
        Movement();
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
        if(collision.gameObject.tag == "Ball")
        {
            Score++;
        }
    }
}
