using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private GameManagerScript gScript;
    [SerializeField] private KeyCode keyUp, keyDown;
    [SerializeField] private float speedPaddle;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        this.gScript = FindObjectOfType<GameManagerScript>();
        this.sprite = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        this.movement();
    }

    private void movement()
    {
        if(this.transform.position.y + this.sprite.size.y < this.gScript.Rect.yMax)
        {
            if (Input.GetKey(this.keyUp))
            {
                this.transform.position += new Vector3(0, this.speedPaddle * Time.deltaTime, 0);
            }
        }

        if (this.transform.position.y - this.sprite.size.y > this.gScript.Rect.yMin)
        {
            if (Input.GetKey(this.keyDown))
            {
                this.transform.position -= new Vector3(0, this.speedPaddle * Time.deltaTime, 0);
            }
        }
    }
}
