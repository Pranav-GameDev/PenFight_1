using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public CameraMovement cameraMovementScript;
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject highscoreButton;
    public GameObject exitButton;

    void OnMouseDown()
    {
        ExecuteActions();
    }

    void ExecuteActions()
    {
        // 1. Enable the "CameraMovement" code in Main Camera
        if (cameraMovementScript != null)
        {
            cameraMovementScript.enabled = true;
        }

        // 2. Wait for 3 seconds
        Invoke("DisableUI", 3f);
    }

    void DisableUI()
    {
        // 3. Disable PlayButton, Settings, Highscore, and ExitButton Game objects
        if (playButton != null)
        {
            playButton.SetActive(false);
        }
        if (settingsButton != null)
        {
            settingsButton.SetActive(false);
        }
        if (highscoreButton != null)
        {
            highscoreButton.SetActive(false);
        }
        if (exitButton != null)
        {
            exitButton.SetActive(false);
        }

        // 4. Disable the code itself
        enabled = false;
    }
}