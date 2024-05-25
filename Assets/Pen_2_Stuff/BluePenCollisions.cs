using UnityEngine;

public class BluePenCollisions : MonoBehaviour
{
    public GameObject BothPlayerOutUI; // Placeholder for BothPlayerOutUI game object
    public GameObject BluePenPointUI; // Placeholder for BluePenPointUI game object
    public GameObject ResetHandler; // Placeholder for RestartHandler game object

    public bool Player2iscollide = false;
    public bool iscollide2freeze = false; // New boolean variable to control freezing

    public Vector3 CameraLocation; // Location for BothPlayerOutUI

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Border_1"))
        {
            // Perform your action here
            Debug.Log("Blue Pen Collision with Border!");

            // 1. Check & Modify the value of boolean variable "Player2iscollide" if it's not frozen
            Player2iscollide = true;
            if (!iscollide2freeze)
            {
                if (Player2iscollide == true)
                {
                    iscollide2freeze = true;
                }
                
                // Set "BluePoint" to true
                FindObjectOfType<ScoreSystem>().BluePoint = true;
            }

            // 2. Wait for 3 seconds
            Invoke("CheckPlayer1Collision", 3f);
        }
    }

    void CheckPlayer1Collision()
    {
        // 3. Check the value of boolean variable "Player1iscollide" from "BlackPenCollisions" code
        bool player1CollideData = FindObjectOfType<BlackPenCollisions>().Player1iscollide;

        // 4. If the value of both "Player2iscollide" & "Player1iscollide" is 1
        if (Player2iscollide && player1CollideData)
        {
            // Disable "CameraFollow" script from an game object
            Camera.main.GetComponent<camerafollow>().enabled = false;

            // Translate the MainCamera to the specified location for BothPlayerOutUI
            Camera.main.transform.position = CameraLocation;

            // Enable a game object (as start appearing on the scene/camera)
            BothPlayerOutUI.SetActive(true);

            // Wait for 3 seconds
            Invoke("DisableBothPlayerOutUI", 3f);
        }
        else
        {
            // Disable "CameraFollow" script from an game object
            Camera.main.GetComponent<camerafollow>().enabled = false;

            // Translate the MainCamera to the specified location for BluePenPointUI
            Camera.main.transform.position = CameraLocation;

            // Enable a Game Object (as start appearing on the scene/camera)
            BluePenPointUI.SetActive(true);

            // Wait for 3 seconds
            Invoke("DisableBluePenPointUI", 3f);
        }
    }

    void DisableBothPlayerOutUI()
    {
        // Disable the Game object that is enabled in Step 4
        BothPlayerOutUI.SetActive(false);

        // Enable "CameraFollow" script from an game object
        Camera.main.GetComponent<camerafollow>().enabled = true;

        // Skip to Step 6
        EnableGameRestart();
        enabled = false;
    }

    void DisableBluePenPointUI()
    {
        // Disable the Game object that is enabled in Step 5
        BluePenPointUI.SetActive(false);

        // Enable "CameraFollow" script from an game object
        // Camera.main.GetComponent<camerafollow>().enabled = true;

        // Disable this script
        // enabled = false;

        EnableGameRestart();
        enabled = false;
    }

    void EnableGameRestart()
    {
        // 6. Enable "GameRestart" code from a game object
        // ResetHandler.GetComponent<Reset>().enabled = true;
        // FindObjectOfType<Reset>().CanI = true;
        enabled = false;
    }
}
