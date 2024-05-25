
 
    using UnityEngine;

    public class GameEnd : MonoBehaviour
    {
        public CameraMovement cameraMovementScript;
        public GameObject playButton;
        public GameObject settingsButton;
        public GameObject highscoreButton;
        public GameObject exitButton;

        // Use this boolean to determine if the player has right-clicked
        private bool rightClicked = false;

        void OnMouseDown()
        {
            // Check if right mouse button is clicked
            if (Input.GetMouseButtonDown(1))
            {
                rightClicked = true;
            }
            else
            {
                ExecuteActions();
            }
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

            // 4. Disable the code itself if right-clicked
            if (rightClicked)
            {
                // Trigger the reset logic if right-clicked
                Reset resetScript = FindObjectOfType<Reset>();
                if (resetScript != null)
                {
                    resetScript.CanI = true;
                }

                // Disable the PlayButton script
                enabled = false;
            }
        }
    }