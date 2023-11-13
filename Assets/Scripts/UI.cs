using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI gameOverText;
    public GameObject backgroundPanel;
    public TextMeshProUGUI scoreText;
    private int score = 0;
   
    public void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void GameOver(bool Win)    
    {
        backgroundPanel.SetActive(true);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        if (Win)
        {
            gameOverText.text = "You Win";
        }
        else
        {
            gameOverText.text = "You Lose";
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

}
