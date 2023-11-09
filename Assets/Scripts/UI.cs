using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI gameOverText;
    public GameObject backgroundPanel;

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

}
