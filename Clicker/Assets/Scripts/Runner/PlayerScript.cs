using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    /// Score points
    public Text scoreText;

    public int scoreRun;
    public float decimalScoreRun;
    public int pointsPerSecond;

    public GameObject gameOver;

    /// Ground
    // public Transform groundCheck;
    // public LayerMask groundMask;
    // private bool ground = false;
    // private float groundRadius = 0.5f;

    public Rigidbody2D rb;

    void Start()
    {   
        Time.timeScale = 1;
        scoreRun = 0;

    }
    
    void Update()
    {
        /// Points counting
        decimalScoreRun += pointsPerSecond * Time.deltaTime;
        //scoreRun = Mathf.RoundToInt(decimalScoreRun);
        scoreText.text = scoreRun.ToString();
        PlayerPrefs.SetInt("Score+", Clicker.score);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        //rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        
        transform.position = new Vector2 (220,1200);
        Clicker.score += 10;
        scoreRun += 10;
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        PlayerPrefs.SetInt("Score+", Clicker.score);
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {   
        Clicker.score += scoreRun;
        SceneManager.LoadScene(2);
    }

}
