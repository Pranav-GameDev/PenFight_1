using UnityEngine;

public class GameRestart : MonoBehaviour
{
    public GameObject gameEndHandler; // Provide this from Inspector

    void Start()
    {
        Debug.Log("Restart!!");
        RestartGame();
    }

    public void RestartGame()
    { 
        // Delayed execution after 2 seconds
        Invoke("ExecuteAfterDelay", 2f);
    }


    

    void ExecuteAfterDelay()
    {
        // 1. Check the value of "BlackPenScore" & "BluePenScore" from "Score" code
        float blackPenScore = FindObjectOfType<ScoreSystem>().blackPenScore;
        float bluePenScore = FindObjectOfType<ScoreSystem>().bluePenScore;

        if (blackPenScore >= 10 || bluePenScore >= 10)
        {
            // Enable "GameEnd" code from a game object
            gameEndHandler.GetComponent<GameEnd>().enabled = true;
            enabled = false;
        }
        else
        {
            // 2. Check the value of boolean variables "Player1iscollide" & "Player2iscollide"
            bool player1IsCollide = FindObjectOfType<BlackPenCollisions>().Player1iscollide;
            bool player2IsCollide = FindObjectOfType<BluePenCollisions>().Player2iscollide;

            if (player1IsCollide && player2IsCollide)
            {
                BothOut();
            }

            // If the value of "Player1iscollide" is 0, enable "BlackPenCollision" code
            if (!player1IsCollide)
            {
                FindObjectOfType<BlackPenCollisions>().enabled = true;
                ResetCollids();
                enabled = false;
            }

            // If the value of "Player2iscollide" is 0, enable "BluePenCollision" code
            if (!player2IsCollide)
            {
                FindObjectOfType<BluePenCollisions>().enabled = true;
                ResetCollids();
                enabled = false;
            }

            // If both variables' values are 1, randomly choose one code and enable it
        }
    }

    void BothOut()
    {
        ResetCollids();
        if (Random.Range(0, 2) == 0)
        {
            FindObjectOfType<BlackPenCollisions>().enabled = true;
            enabled = false;
        }
        else
        {
            FindObjectOfType<BluePenCollisions>().enabled = true;
            enabled = false;
        }
    }

    void ResetCollids()
    {
        // Reset the collision variables to 0
        FindObjectOfType<BlackPenCollisions>().Player1iscollide = false;
        FindObjectOfType<BluePenCollisions>().Player2iscollide = false;
        FindObjectOfType<BluePenCollisions>().iscollide2freeze = false;
        FindObjectOfType<BlackPenCollisions>().iscollide1freeze = false;
        
        Camera.main.GetComponent<camerafollow>().enabled = true;
    }
}
