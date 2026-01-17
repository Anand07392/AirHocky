using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    Canvas canvas;
    public int leftScore = 0;
    public int rightScore = 0;
    public TMP_Text leftText;
    public TMP_Text rightText;
    public Puck puck;
    public float respawnDelay = 1f;
    public int targetScore = 7;

    public GameObject WinCanvas;
    public GameObject StartCanvas;
    public TMP_Text WinText;

    private float time = 1f;
    void Awake()
    {
        
        WinCanvas.SetActive(false);
        StartCanvas.SetActive(true);
    }   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        UpdateUI();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale= 0f;
            StartCanvas.SetActive(true);
        }
    }

    public void ScoreLeft()
    {
        leftScore++;
        UpdateUI();
        StartCoroutine(HandleGoal(true));
    }

    public void ScoreRight()
    {
        rightScore++;
        UpdateUI();
        StartCoroutine(HandleGoal(false));
    }

    IEnumerator HandleGoal(bool lastScoredRight)
    {
        puck.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        puck.transform.position = Vector2.zero;
        yield return new WaitForSeconds(respawnDelay);
        puck.ResetAndServe(!lastScoredRight);
        CheckWin();
    }

    void UpdateUI()
    {
        leftText.text = leftScore.ToString();
        rightText.text = rightScore.ToString();
    }

    void CheckWin()
    {
        if (leftScore >= targetScore || rightScore >= targetScore)
        {
            // Handle end game
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            Win();
            if (rightScore >= targetScore)
            {
                WinText.text = "You Won!";
            }
            else
            {
                WinText.text = "You Lose!";
            }
        }
    }
    public void Win()
    {
        if (leftScore == 7)
        {
            WinCanvas.SetActive(true);
        }
        if(rightScore == 7)
        {
            WinCanvas.SetActive(true);
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        StartCanvas.SetActive(false);
    }
}
