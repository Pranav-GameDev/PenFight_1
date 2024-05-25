using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public float bluePenScore = 0f;
    public float blackPenScore = 0f;

    public Text bluePenScoreText;
    public Text blackPenScoreText;

    // Public boolean variables to represent whether a point is scored for each player
    public bool BluePoint = false;
    public bool BlackPoint = false;

    void Start()
    {
        // Set the initial scores
        bluePenScore = 0f;
        blackPenScore = 0f;

        // Update the UI with the initial scores
        UpdateScoreUI();
    }

    // Function to update the scores and UI based on boolean variables
    void UpdateScore()
    {
        // Check if a point is scored for the blue player
        if (BluePoint == true)
        {
            bluePenScore += 1;
            BluePoint = false; // Reset the boolean variable
        }

        // Check if a point is scored for the black player
        if (BlackPoint == true)
        {
            blackPenScore += 1;
            BlackPoint = false; // Reset the boolean variable
        }

        // Ensure scores don't go below 0
        bluePenScore = Mathf.Max(0f, bluePenScore);
        blackPenScore = Mathf.Max(0f, blackPenScore);

        // Update the UI with the new scores
    
        UpdateScoreUI();
    }

    // Function to update the UI with current scores
    void UpdateScoreUI()
    {
        if (bluePenScoreText != null)
        {
            bluePenScoreText.text = "Blue Pen Score: " + bluePenScore.ToString();
        }

        if (blackPenScoreText != null)
        {
            blackPenScoreText.text = "Black Pen Score: " + blackPenScore.ToString();
        }
        ShowScoreLog();
    }

    void ShowScoreLog()
    {
        Debug.Log("Black Pen Score: " + blackPenScore);
        Debug.Log("Blue Pen Score: " + bluePenScore);
        UpdateScoreUI();
    }
}