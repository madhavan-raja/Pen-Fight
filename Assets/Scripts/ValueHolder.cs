using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    int redScore;
    int blueScore;
    bool currentTurn;

    void Start()
    {
        redScore = 0;
        blueScore = 0;
        currentTurn = false;
    }

    public int GetRedScore()
    {
        return redScore;
    }

    public int GetBlueScore()
    {
        return blueScore;
    }

    public string GetRedScoreAsString()
    {
        return Convert.ToString(redScore);
    }

    public string GetBlueScoreAsString()
    {
        return Convert.ToString(blueScore);
    }

    public void IncrementRed()
    {
        redScore++;
    }

    public void IncrementBlue()
    {
        blueScore++;
    }

    public bool GetCurrentTurn()
    {
        return currentTurn;
    }

    public string GetCurrentTurnAsString()
    {
        if (currentTurn == false)
            return "RED'S TURN";
        else
            return "BLUE'S TURN";
    }

    public void SwitchTurn()
    {
        currentTurn = !currentTurn;
    }

    public void Exit()
    {
        Application.Quit(0);
    }

    public void ResetScores()
    {
        redScore = 0;
        blueScore = 0;
    }
}
