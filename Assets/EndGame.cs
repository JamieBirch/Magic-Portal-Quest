using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public static EndGame instance;
    public GameObject playerCanvas;
    public GameObject gameOverUI;
    public GameObject score;
    public Text resultTxt;
    public Text relicsScore;
    public Text finalScore;

    private void Awake()
    {
        instance = this;
    }

    public void FinishGame(bool won)
    {
        //turn off ui
        playerCanvas.SetActive(false);
        
        // PlayerMessageService.instance.ShowMessage("GameOver");
        Debug.Log("GameOver");
        String endScreenText;
        if (won)
        {
            score.SetActive(true);
            endScreenText = "YOU WON";
            relicsScore.text = GameStats.relics.ToString();
            finalScore.text = CalculateFinalScore().ToString();
        }
        else
        {
            score.SetActive(false);
            endScreenText = "GAME OVER";
        }

        resultTxt.text = endScreenText;
        gameOverUI.SetActive(true);
    }

    private int CalculateFinalScore()
    {
        return (int)(GameStats.relics * 100 + GameStats.finishTime * 10);
    }
}
