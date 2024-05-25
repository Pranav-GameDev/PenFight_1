using UnityEngine;

public class ExitButton : MonoBehaviour
{
    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to determine if the mouse is over the button
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Exit the application
                ExitGame();
            }
        }
    }

    void ExitGame()
    {
        // Exit the application (works in standalone builds)
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        // Add additional exit logic for the Unity Editor or other platforms if needed
    }
}
