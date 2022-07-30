using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private Rect rect;
    [SerializeField] private TextMeshProUGUI leftScore, rightScore;
    [SerializeField] private int leftPoint, rightPoint;
    [SerializeField] private GameObject obj, startText, ball, ballScene;
    private GameObject insBall;
    [SerializeField] private int winValue;
    private BallScript bScript;
    private bool inGame = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rect = new Rect(0, 0, 18, 10);
        this.rect.center = Vector3.zero;
        this.bScript = FindObjectOfType<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        this.leftScore.text = this.leftPoint.ToString();
        this.rightScore.text = this.rightPoint.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!this.inGame)
                this.beginGame();
        }

        if(this.leftPoint >= this.winValue || this.rightPoint >= this.winValue )
        {
            this.endGame();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.rect.center, this.rect.size);
    }

    public Rect Rect
    {
        set { this.rect = value; }
        get { return this.rect; }
    }

    private void resetScore()
    {
        this.leftPoint = 0;
        this.rightPoint = 0;
    }

    public int LeftPoint
    {
        set { this.leftPoint = value; }
        get { return this.leftPoint; }
    }

    public int RightPoint
    {
        set { this.rightPoint = value; }
        get { return this.rightPoint; }
    }

    private void beginGame()
    {
        this.obj.SetActive(true);
        this.startText.SetActive(false);
        this.ballScene.SetActive(false);
        this.resetScore();
        this.inGame = true;
        this.spawnBall();
    }

    private void endGame()
    {
        Destroy(this.insBall);
        this.obj.SetActive(false);
        this.startText.SetActive(true);
        this.inGame = false;
        this.ballScene.SetActive(true);
    }

    public void spawnBall()
    {
        Destroy(this.insBall);
        this.insBall = Instantiate(this.ball, new Vector3(this.rect.center.x,Random.Range(this.rect.yMin,this.rect.yMax),0), Quaternion.identity);
    }

    public bool InGame
    {
        set { this.inGame = value; }
        get { return this.inGame; }
    }
}
