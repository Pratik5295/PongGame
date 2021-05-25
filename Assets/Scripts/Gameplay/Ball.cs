using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 startPosition;
    private Rigidbody2D rigi;

    public float moveSpeed;

    private void Awake()
    {
        startPosition = this.transform.position;

        rigi = this.GetComponent<Rigidbody2D>();

        StartGame();
    }

    public void StartGame()
    {
        rigi.velocity = new Vector2(Random.Range(0f, 5f) * moveSpeed, Random.Range(0f, 3f) * moveSpeed);
    }

    public void ResetPosition()
    {
        this.transform.position = startPosition;

        rigi.velocity = new Vector2(0, 0);
    }
}
