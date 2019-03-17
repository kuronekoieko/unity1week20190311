using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class GameManager : MonoBehaviour
{

    [SerializeField] Text timeText;
    [SerializeField] Text catCountText;
    [SerializeField] Text resultCatCountText;

    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject tutrialPanel;
    [SerializeField] GameObject resultDialogPanel;


    [SerializeField] Text countDownText;


    float second;
    int countDownsec;


    // Start is called before the first frame update
    void Start()
    {
        Variable.InitVariable();
        timeText.text = Variable.limitTimeSec.ToString() + ".00";
        catCountText.text = Variable.catCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        switch (Variable.gameState)
        {
            case GameState.TUTORIAL:
                break;
            case GameState.COUNT_DOWN:
                CountDown();
                break;
            case GameState.PLAY:
                TextChange();
                CheckTimeUp();
                break;
            case GameState.RESULT:

                ShowResultDialogPanel();
                break;
            default:
                break;
        }

    }

    void CountDown()
    {
        second += Time.deltaTime;
        countDownsec = (int)(4 - second);
        countDownText.text = countDownsec.ToString();
        if (second > 3.0f)
        {
            second = 0;
            tutrialPanel.SetActive(false);
            Variable.gameState = GameState.PLAY;
        }

    }

    void TextChange()
    {
        timeText.text = (Variable.limitTimeSec - second).ToString("F");
        catCountText.text = Variable.catCount.ToString();
    }

    void CheckTimeUp()
    {
        second += Time.deltaTime;
        if (second < Variable.limitTimeSec) return;
        Variable.audioSource[3].Play();
        second = 0;
        timeText.text = "00.00";
        resultCatCountText.text = Variable.catCount.ToString() + " 匹";
        resultPanel.SetActive(true);
        resultDialogPanel.SetActive(false);
        Variable.gameState = GameState.RESULT;

    }

    void ShowResultDialogPanel()
    {
        second += Time.deltaTime;
        if (second < Variable.resultIntervalSec) return;
        //Variable.audioSource[5].Play();
        resultDialogPanel.SetActive(true);
    }


}
