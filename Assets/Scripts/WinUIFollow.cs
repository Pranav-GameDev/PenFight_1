using UnityEngine;

public class WinUIFollow : MonoBehaviour
{
    public Transform player1;

    void Update()
    {
        // Ensure player1 is assigned before following
        if (player1 != null)
        {
            // Set the camera position to player1's position
            transform.position = new Vector3(player1.position.x, transform.position.y, player1.position.z);
        }
    }
}