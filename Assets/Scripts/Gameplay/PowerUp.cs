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
        float xVel = Random.Range(-3f, 3f);
        if(xVel == 0)
        {
            xVel = 2f;
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(xVel * moveSpeed,0f);
     
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
