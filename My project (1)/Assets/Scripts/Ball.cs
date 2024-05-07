using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Ball : MonoBehaviour
{
    bool GameOver = false;
    public int MaxScore;
    public SpriteRenderer SpriteRendererBall;
    public TextMeshProUGUI Player1Text;
    public TextMeshProUGUI Player2Text;
    public TextMeshProUGUI LeftScoreText;
    public TextMeshProUGUI RightScoreText;
    private Vector2 startingPosition;
    public Rigidbody2D rb;
    public float StartingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Player1Text.enabled = false;    
        Player2Text.enabled = false;

        startingPosition = transform.position;
        bool isRigth = UnityEngine.Random.value >= 5;
        float xVelocity = -1f;

        if (isRigth)
            xVelocity = 1f;

        float yVelocity = UnityEngine.Random.Range(-1f, 1f);
        rb.velocity = new Vector2 (xVelocity * StartingSpeed, yVelocity * StartingSpeed);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        if (rightScore == MaxScore)
        {
            Player2Text.enabled = true;
            SpriteRendererBall.enabled = false;
            GameOver = true;
            Invoke("Win", 1);
        }
        if (leftScore == MaxScore)
        {
            Player1Text.enabled = true;
            SpriteRendererBall.enabled = false;
            GameOver = true;
            Invoke("Win", 1);
        }
    }

    int leftScore = 0;
    int rightScore = 0;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftGate") && GameOver == false)
        {
            rightScore++;
            RightScoreText.text = rightScore.ToString();
            Debug.Log("Right score: " + rightScore);
            Reset();
        }
        if (collision.gameObject.CompareTag("RightGate") && GameOver == false) //&& rightScore != MaxScore && leftScore != MaxScore)
        {
            leftScore++;
            LeftScoreText.text = leftScore.ToString();
            Debug.Log("Left score: " + leftScore);
            Reset();
        }

    }
    
     public void Win()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    private void Reset()
    {
        transform.position = startingPosition;

        rb.velocity = Vector2.zero;

        Invoke("Start", 3f);
    }

}
