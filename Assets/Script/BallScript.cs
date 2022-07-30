using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]private GameManagerScript gScript;


    [Header("Attributes")]
    [SerializeField] private float speedBall;
    private Vector2 speed;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        this.gScript = FindObjectOfType<GameManagerScript>();
        this.sprite = gameObject.GetComponent<SpriteRenderer>();
        this.speed = new Vector2(this.speedBall * Time.deltaTime, this.speedBall * Time.deltaTime);

        int dirX = Random.Range(0, 2);
        int dirY = Random.Range(0, 2);

        switch (dirX)
        {
            case 0:
                break;
            case 1:
                this.changeDirX();
                break;
        }

        switch (dirY)
        {
            case 0:
                break;
            case 1:
                this.changeDirY();
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(this.speed.x, this.speed.y, 0);


        if(!this.gScript.InGame)
        {
            this.movement();
        }
        else
        {
            this.inMovement();
        }

    }

    private void changeDirX()
    {
        this.speed.x = -this.speed.x;
    }

    private void changeDirY()
    {
        this.speed.y = -this.speed.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.changeDirX();
        }
    }

    private void inMovement()
    {
        if (this.transform.position.x + this.sprite.size.x / 2 >= this.gScript.Rect.xMax)
        {
            this.gScript.spawnBall();
            this.gScript.LeftPoint += 1;
        }

        if (this.transform.position.x - this.sprite.size.x / 2 <= this.gScript.Rect.xMin)
        {
            this.gScript.spawnBall();
            this.gScript.RightPoint += 1;
        }

        if (this.transform.position.y + this.sprite.size.y / 2 >= this.gScript.Rect.yMax || this.transform.position.y - this.sprite.size.y / 2 <= this.gScript.Rect.yMin)
        {
            this.changeDirY();
        }
    }

    private void movement()
    {
        if (this.transform.position.x + this.sprite.size.x / 2 >= this.gScript.Rect.xMax || this.transform.position.x - this.sprite.size.x / 2 <= this.gScript.Rect.xMin)
        {
            this.changeDirX();
        }

        if (this.transform.position.y + this.sprite.size.y / 2 >= this.gScript.Rect.yMax || this.transform.position.y - this.sprite.size.y / 2 <= this.gScript.Rect.yMin)
        {
            this.changeDirY();
        }
    }


    

}
