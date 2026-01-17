using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isRightGoal = true;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
           if (isRightGoal) gameManager.ScoreLeft();
           else gameManager.ScoreRight();
        }
    }
}