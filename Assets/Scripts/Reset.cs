using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public bool CanI = false;

    public GameObject blackPen;
    public GameObject bluePen;
    public GameObject mainCamera;

    public Vector3 cameraStartPosition;
    public Vector3 cameraStartRotation; // Euler angles for rotation
    public Vector3 blackPenStartPosition;
    public Vector3 blackPenStartRotation; // Euler angles for rotation
    public Vector3 bluePenStartPosition;
    public Vector3 bluePenStartRotation; // Euler angles for rotation

    public float transitionSpeed = 2f; // Adjust the speed of the transition

    public GameObject BlackCollDisable;
    public GameObject BlueCollDisable;

    public GameObject RestartHandler;

    // Update is called once per frame
    void Update()
    {
        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1)) // 1 corresponds to the right mouse button
        {
            // Toggle CanI
            CanI = true;

            // If CanI is true, initiate the reset
            if (CanI)
            {
                BlackCollDisable.GetComponent<BlackPenCollisions>().enabled = false;
                BlueCollDisable.GetComponent<BluePenCollisions>().enabled = false;
            }
        }

        if (CanI)
        {
            Camera.main.GetComponent<camerafollow>().enabled = true;

            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraStartPosition, Time.deltaTime * transitionSpeed);
            mainCamera.transform.rotation = Quaternion.Euler(Vector3.Lerp(mainCamera.transform.rotation.eulerAngles, cameraStartRotation, Time.deltaTime * transitionSpeed));

            blackPen.transform.position = Vector3.Lerp(blackPen.transform.position, blackPenStartPosition, Time.deltaTime * transitionSpeed);
            blackPen.transform.rotation = Quaternion.Euler(Vector3.Lerp(blackPen.transform.rotation.eulerAngles, blackPenStartRotation, Time.deltaTime * transitionSpeed));

            bluePen.transform.position = Vector3.Lerp(bluePen.transform.position, bluePenStartPosition, Time.deltaTime * transitionSpeed);
            bluePen.transform.rotation = Quaternion.Euler(Vector3.Lerp(bluePen.transform.rotation.eulerAngles, bluePenStartRotation, Time.deltaTime * transitionSpeed));

            RestartHandler.GetComponent<GameRestart>().enabled = true;
            CanI = false;
            enabled = false;
        }
    }
}
