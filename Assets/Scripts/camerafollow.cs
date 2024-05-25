using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float followSpeed = 5f;

    void Update()
    {
        // Ensure both players are assigned before following
        if (player1 != null && player2 != null)
        {
            // Calculate the center position between the players
            Vector3 centerPosition = (player1.position + player2.position) / 2f;

            // Move the camera towards the center position
            transform.position = Vector3.Lerp(transform.position, new Vector3(centerPosition.x, transform.position.y, centerPosition.z), followSpeed * Time.deltaTime);
        }
    }
}
