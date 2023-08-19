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
    public Text timeScore;
    public Text finalScore;

    public StarsUI relicStars;
    public StarsUI timeStars;
    public StarsUI totalStars;

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
            GetComponent<SoundEffectsPlayer>().playSound();
            score.SetActive(true);
            endScreenText = "YOU WON";
            GameStats.finishTime = GetComponent<GameManager>().countdown;
            /*relicsScore.text = GameStats.relics.ToString();
            timeScore.text = GameStats.finishTime.ToString();
            finalScore.text = CalculateFinalScore().ToString();*/

            int relicsScore = GameStats.relics > 3 ? 3 : GameStats.relics;
            relicStars.Show(relicsScore);
            int timeScore = (int)(GameStats.finishTime / 30) > 3 ? 3 : (int)(GameStats.finishTime / 30);
            timeStars.Show(timeScore);
            int totalScore = CalculateFinalScore(relicsScore, timeScore);
            totalStars.Show(totalScore);
        }
        else
        {
            score.SetActive(false);
            endScreenText = "GAME OVER";
        }

        resultTxt.text = endScreenText;
        gameOverUI.SetActive(true);
    }

    private int CalculateFinalScore(int relicsScore,  int timeScore)
    {
        // return (int)(GameStats.relics * 100 + GameStats.finishTime * 10);
        Debug.Log("Final stars: " + (relicsScore + timeScore)/2);
        return (relicsScore + timeScore)/2;
    }
}
