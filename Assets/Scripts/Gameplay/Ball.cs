using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 startPosition;
    private Rigidbody2D rigi;

    public float moveSpeed;
    public float originalSpeed;
    float yVel;
    float xVel;


    private void Awake()
    {
        startPosition = this.transform.position;
        originalSpeed = moveSpeed;
        rigi = this.GetComponent<Rigidbody2D>();

    }

    public virtual void StartGame()
    {
        xVel = Random.Range(-5f, 5f);
        yVel = Random.Range(0f, 3f);
        rigi.velocity = new Vector2(xVel* moveSpeed, yVel * moveSpeed);
    }

    public void ResetPosition()
    {
        this.transform.position = startPosition;

        rigi.velocity = new Vector2(0, 0);
        moveSpeed = originalSpeed;
    }

    public void IncreaseSpeed()
    {
        moveSpeed += 0.5f;
        rigi.AddForce(rigi.velocity * moveSpeed);
    }
}
