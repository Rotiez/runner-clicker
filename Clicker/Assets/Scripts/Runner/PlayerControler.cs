using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public GameObject gameOver;
    public Text live;
    public int liveScore = 3;
    public float Score = 0;
    public Text SText;
    public Transform groundCheck;
    public LayerMask groundMask;
    private bool ground = false;
    private float groundRadius = 0.5f;

    private void Start()
    {
        Time.timeScale = 1;
    }


    private void Update()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
        if (Input.GetMouseButtonDown(0)&& ground==true)
        {
            Jump();
        }
        if (liveScore == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        //scoreText.text = ((int)(groundCheck.position.x / 1)).ToString();

        Score += Time.deltaTime;
        if (liveScore != 0)
        {
            SText.text = Score.ToString();
            SText.text = Mathf.Round(Score).ToString();
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (liveScore != 0)
            {
                liveScore--;
                live.text=liveScore.ToString();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Demo");
    }
}
