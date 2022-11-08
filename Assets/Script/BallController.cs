using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    [SerializeField] float startSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float speedMultiplier;
    [SerializeField] float boundaryRightX;
    [SerializeField] float boundaryLeftX;
    public TrailRenderer trailRenderer;

    [SerializeField] TextMeshProUGUI scoreRedText;
    [SerializeField] TextMeshProUGUI scoreYellowText;
    [SerializeField] GameObject particleGoalYellow;
    [SerializeField] GameObject particleGoalRed;

    GameManager gameManager;

    public bool isWaiting;
    [SerializeField] float timerLaunch;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] bool lastGoalRed;
    [SerializeField] Transform kickoffRed;
    [SerializeField] Transform kickoffYellow;
    public void AddBallSpeed()
    {
        if(currentSpeed< maxSpeed)
        {
            currentSpeed = currentSpeed * speedMultiplier;
        }
        
    }
    private void Awake()
    {
        gameManager = GameManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        isWaiting = true;

    }

    // Update is called once per frame
    void Update()
    {
        ballRB.velocity = ballRB.velocity.normalized * currentSpeed;

        ResetBall();
        if(isWaiting)
        {
            Timer();
        }
    }

    public void ResetBall()
    {
        if (transform.position.x > boundaryRightX)
        {
            lastGoalRed = false;
            Instantiate(particleGoalRed, transform.position, Quaternion.identity);
            transform.position = kickoffRed.position;
            ballRB.velocity = Vector3.zero; 
            trailRenderer.Clear();

            timerLaunch = 3;
            isWaiting = true;

            AudioManager.instance.ChangePitch(1);
            AudioManager.instance.playSoundEffect(1, 1);
            AddScore(false);
        }
        else if (transform.position.x < boundaryLeftX)
        {
            lastGoalRed = true;
            Instantiate(particleGoalRed, transform.position, Quaternion.identity);
            transform.position = kickoffYellow.position;
            ballRB.velocity = Vector3.zero;
            trailRenderer.Clear();

            timerLaunch = 3;
            isWaiting = true;
            AudioManager.instance.ChangePitch(1);
            AudioManager.instance.playSoundEffect(1, 1);
            AddScore(true);
            
        }
    }
    public void AddScore(bool isRed)
    {
        if(isRed)
        {
            gameManager.AddScoreRed();
            scoreRedText.text = gameManager.GetScoreRed().ToString();
        }
        else
        {
            gameManager.AddScoreYellow();
            scoreYellowText.text = gameManager.GetScoreYellow().ToString();
        }
    }
    public void Timer()
    {
        timerLaunch -= Time.deltaTime*1.5f;
        timerText.text = ((int)timerLaunch + 1).ToString();
        if (timerLaunch < 0)
        {
            timerText.text = "";
            isWaiting = false;
            AudioManager.instance.playSoundEffect(2, 1);
            LaunchBall();
        }
    }
    public void LaunchBall()
    {
        //gets a random angle of the ball to start
        float angle = Random.Range(-100, 101);
        float dir = lastGoalRed ? 1 : -1;
        

        Vector2 randomDirection = new Vector2(dir, angle / 150);
        randomDirection.Normalize();

        ballRB.velocity = randomDirection * startSpeed;

        currentSpeed = startSpeed;
        
    }
    
}
