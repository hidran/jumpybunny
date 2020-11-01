using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ViewInGame : MonoBehaviour
{


    public TMP_Text coinsLabel;
    public TMP_Text scoreText;
    public TMP_Text hightestScoreText;

    private void Start()
    {
        
    }
     void showHighestScore()
    {
        hightestScoreText.text = PlayerController.GetInstance().GetMaxScore().ToString();
    }
    void Update()
    {
        if(GameManager.GetInstance().currentGameState == GameState.Menu)
        {
            showHighestScore();
        }
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
        scoreText.text = PlayerController.GetInstance().GetDistance().ToString();
       
    }
}
