using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.8f; // Adjust the gravity value as needed
    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        // Check if the controller is grounded (you might need to modify this depending on your setup)
        bool isGrounded = controller.isGrounded;

        // Apply gravity only if not grounded
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;

            // Move the controller based on the vertical velocity
            controller.Move(velocity * Time.deltaTime);
        }
    }
}