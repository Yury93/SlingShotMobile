using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMetrics : SingletonBase<PlayerMetrics>
{
    [SerializeField] private Text scoreTxt, timerTxt, recordTxt;
    private int scoreGeneral = 0;
    public int ScoreGeneral => scoreGeneral;
    private int recordGeneral = 0;
    [SerializeField] private float timerStartGame = 200f;

    private void Start()
    {
        scoreTxt.text = "Score: " + scoreGeneral;
        recordGeneral = PlayerPrefs.GetInt("score");
        recordTxt.text = "Record: " + recordGeneral.ToString();
    }
    private void Update()
    {
        timerStartGame -= Time.deltaTime;
        ShowTimer(timerStartGame);
       
    }
    /// <summary>
    /// показывает на экране количество очков
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        scoreGeneral += score;
        scoreTxt.text = "Score: " + scoreGeneral;
        RecordUpdate();
    }
    public void RecordUpdate()
    {
        if(scoreGeneral > recordGeneral)
        {
            PlayerPrefs.SetInt("score", scoreGeneral);
            recordGeneral = scoreGeneral;
            recordTxt.text = "Record: " + recordGeneral.ToString();
        }
    }
    public void ShowTimer(float time)
    {
        timerTxt.text = "Timer: "+ Convert.ToInt32(time).ToString();
        if (time <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
