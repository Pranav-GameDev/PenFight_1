using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseMovement : MonoBehaviour
{
    private Vector3 mouseStartPosition;
    private Vector3 mouseEndPosition;
    private Vector3 mouseDirection;
    private float mouseMagnitude;

    private Rigidbody rb;

    public float movementSpeed = 5f;

    // Reference to another player's MouseMovement script
    public MouseMovement nextPlayerMouseMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable Unity's default gravity
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            RecordStartPosition();
        }
        else if (Input.GetMouseButton(0))
        {
            RecordEndPosition();
            CalculateMouseMovement();
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            MoveObject();
            // Disable this MouseMovement script
            enabled = false;
            // Enable the next player's MouseMovement script
            if (nextPlayerMouseMovement != null)
            {
                nextPlayerMouseMovement.enabled = true;
            }
        }
    }

    void RecordStartPosition()
    {
        mouseStartPosition = Input.mousePosition;
    }

    void RecordEndPosition()
    {
        mouseEndPosition = Input.mousePosition;
    }

    void CalculateMouseMovement()
    {
        // Calculate the movement direction based on mouse movement
        mouseDirection = (mouseEndPosition - mouseStartPosition).normalized;

        // Calculate the movement magnitude
        mouseMagnitude = Vector3.Distance(mouseEndPosition, mouseStartPosition);
    }

    void MoveObject()
    {
        // Move the object in the X and Z directions based on recorded mouse movement
        Vector3 movement = new Vector3(mouseDirection.x, 0f, mouseDirection.y) * mouseMagnitude * movementSpeed;
        rb.AddForce(movement, ForceMode.Impulse);
    }
}