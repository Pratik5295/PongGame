using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Ball
{

    private float lifeTime = 8f;
    
    public void StartPower()
    {
        StartGame();
    }

    public override void StartGame()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f) * moveSpeed, Random.Range(0, 3f)  * moveSpeed);
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0f)
        {
            this.gameObject.SetActive(false);
            ResetPosition();
            lifeTime = 8f;
        }
    }
}
