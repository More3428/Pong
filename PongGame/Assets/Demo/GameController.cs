using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject bal;
    public TextMeshProUGUI scoreTextleft;
    public TextMeshProUGUI scoreTextright;

    private bool start = false;
    private int left = 0;
    private int right = 0;

    private Ball ball;

    private Vector3 startingposition;
    // Start is called before the first frame update
    void Start()
    {
        this.ball = this.bal.GetComponent<Ball>();
        this.startingposition = this.bal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.start)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            this.start = true; 
            //Start Game
            this.ball.Go();
        }
    }

    public void ScoreGoalLeft()
    {
        Debug.Log("ScoredLeft!");
        this.right += 1; 
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight()
    {   
        Debug.Log("ScoredRight");
        this.left += 1; 
        UpdateUI();
        ResetBall();
    }
    private void UpdateUI()
    {
        this.scoreTextleft.text = this.left.ToString();
        this.scoreTextright.text = this.right.ToString(); 
    }

    private void ResetBall()
    {
        this.ball.Stop();
        this.bal.transform.position = this.startingposition;
        this.ball.Go();
    }
}
