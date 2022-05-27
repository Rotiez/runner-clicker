using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Text scoreText;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
       scoreText.text = Clicker.score.ToString();
    }

    public void OnClickClicker()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnClickRunner()
    {
        SceneManager.LoadScene(2);
    }
}
