using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    private float StartTime;
    private float PrevTime;
    private int GameTime;
    [SerializeField] private int coinCredit = 10;
    [SerializeField] private int ObstacleCredit = 10;
    [SerializeField] GameObject ScoreObject;
    private int score;

    private void Start()
    {
        //Initialization
        StartTime = Time.time;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = "0";
        score = 0;
    }

    private void Update()
    {
        //Time adding to score
        if (PrevTime != Mathf.RoundToInt(Time.time - StartTime))
        {
            GameTime = Mathf.RoundToInt(Time.time - PrevTime);
            
            score += Mathf.RoundToInt(GameTime);
            //Debug.Log(score);
            ScoreObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
            PrevTime = Mathf.RoundToInt(Time.time - StartTime);
        }
    }

    public void CollectingCoin()
    {
        score += coinCredit;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    public void CollideObstacle()
    {
        score -= ObstacleCredit;
        ScoreObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
