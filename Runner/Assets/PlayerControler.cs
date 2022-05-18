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
    [SerializeField] private Text scoreText;
    public Transform groundCheck;
    public LayerMask groundMask;
    private bool ground = false;
    private float groundRadius = 0.5f;

    private void Start()
    {
        
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
        }

        scoreText.text = ((int)(groundCheck.position.x / 1)).ToString();
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            liveScore--;
            live.text=liveScore.ToString();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Demo");
    }
}
