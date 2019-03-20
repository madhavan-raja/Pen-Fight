using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public ValueHolder data;

    public Canvas ui;

    public TextMeshProUGUI powerDisplay;

    public TextMeshProUGUI blueScore;
    public TextMeshProUGUI redScore;

    public TextMeshProUGUI turnIndicator;

    public Slider powerSlider;

    void Start()
    {
        blueScore.text = data.GetBlueScoreAsString();
        redScore.text = data.GetRedScoreAsString();
        turnIndicator.text = data.GetCurrentTurnAsString();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fly"))
            ui.enabled = false;
        else if (Input.GetButtonUp("Fly"))
            ui.enabled = true;

        powerDisplay.text = String.Format("{0:0.0}", powerSlider.value);
        turnIndicator.text = data.GetCurrentTurnAsString();

        blueScore.text = data.GetBlueScoreAsString();
        redScore.text = data.GetRedScoreAsString();
    }
}
