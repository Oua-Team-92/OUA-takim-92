using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   


    [SerializeField] private TMPro.TextMeshProUGUI result;


    private void Start()
    {
        result.text = "Congratulations " + PlayerPrefs.GetString("playerName") + "\n" + "Your score is " + Score.score;
    }



    public void RestartButton() 
    {
        Score.score = 0;
        Score.health = 100;
        SceneManager.LoadScene("Berk-Level");
    }
        
        
    public void MainMenuButton() 
    {
        Score.score = 0;
        Score.health = 100;
        SceneManager.LoadScene("Start");
    }

    public void ExitGame()
    {
      Application.Quit();   
    }
}
