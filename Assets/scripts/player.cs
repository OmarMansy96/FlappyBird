using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text HighScore;
    public Text counterText;
    int coins = 0;
    public AudioClip fly;
    public AudioClip lose;
    bool isGameOver ;

    private void Start()
    {

    }


    void Update()
    { 
        HighScore.text = "HIGH SCORE: \n"+PlayerPrefs.GetInt("HIGH_SCORE", 0).ToString();

        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
            GetComponent<Animator>().Play("birdFly", 0, 0);
            GetComponent<AudioSource>().PlayOneShot(fly);

        }

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneManager.LoadScene("Game");

            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "floor")
        {
            if (coins > PlayerPrefs.GetInt("HIGH_SCORE",0))
            {
                PlayerPrefs.SetInt("HIGH_SCORE",coins);
            }
            Debug.Log("Game Over");
            Time.timeScale = 0;
            GetComponent<AudioSource>().PlayOneShot(lose);
            isGameOver = true;
            GameOverPanel.SetActive(true);

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coins")
        {
            coins++;
            counterText.text = coins.ToString();
        }
    }


}
