using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public int Score;
    public Text ScoreTxt;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        EventHandler.ScoreAddEvent += OnScoreAdd;
    }
    
    private void OnDisable()
    {
        EventHandler.ScoreAddEvent -= OnScoreAdd;
    }

    private void OnScoreAdd(int score)
    {
        Score += score;
        ScoreTxt.text = "Score:" + Score.ToString();
    }

}
