using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
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
