using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject highscoreButton;
    public GameObject exitButton;

    public camerafollow cameraFollowScript;
    public CameraMovement cameraMovementScript;

    void Start()
    {
        ExecuteActions();
    }

    void ExecuteActions()
    {
        // 1. Disable "Camerafollow" script & "CameraMovement" script from a game object
        if (cameraObject != null)
        {
            if (cameraFollowScript != null)
            {
                cameraFollowScript.enabled = false;
            }

            if (cameraMovementScript != null)
            {
                cameraMovementScript.enabled = false;
            }
        }

        // 2. Enable PlayButton, Settings, Highscore, and ExitButton Game objects
        EnableUI();

        // 3. Disable the code itself
        enabled = false;
    }

    void EnableUI()
    {
        // Enable PlayButton, Settings, Highscore, and ExitButton Game objects
        if (playButton != null)
        {
            playButton.SetActive(true);
        }
        if (settingsButton != null)
        {
            settingsButton.SetActive(true);
        }
        if (highscoreButton != null)
        {
            highscoreButton.SetActive(true);
        }
        if (exitButton != null)
        {
            exitButton.SetActive(true);
        }
    }
}