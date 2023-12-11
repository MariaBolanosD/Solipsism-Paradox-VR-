using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float timeLeft;
    int timeLeftMins;
    int timeLeftSec;
    [SerializeField]
    TextMeshProUGUI timeLeftUI1;

    [SerializeField]
    private int pointsToScore;

    public int pointsScored;
    [SerializeField]
    TextMeshProUGUI pointsScoredUI1;

    [SerializeField]
    TextMeshProUGUI pointsScoredUI2;
    [SerializeField]
    TextMeshProUGUI timeLeftUI2;

    // Start is called before the first frame update
    void Start()
    {
        pointsScored = 00;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        pointsScoredUI1.text = "" + pointsScored;
        pointsScoredUI2.text = "" + pointsScored;

        int inutil;
        timeLeftMins = Math.DivRem((int)timeLeft, 60, out inutil);
        timeLeftSec = (int)timeLeft - timeLeftMins*60;
        timeLeftUI1.text = timeLeftMins + ":" + timeLeftSec;
        timeLeftUI2.text = timeLeftMins + ":" + timeLeftSec;

        if (timeLeft <= 0 && pointsScored >= pointsToScore)
        {
            // TODO
        }
        else if(timeLeft > 0 && pointsScored >= pointsToScore)
        {
            // TODO
        }
        else
        {
            // TODO
        }

    }

    public void AddPoints()
    {
        pointsScored++;
    }
}
