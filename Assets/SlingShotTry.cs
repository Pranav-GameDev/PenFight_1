using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlingShotTry : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float gravity = 9.8f;

    private Vector3 initialPosition;
    private Vector3 releasePosition;
    private bool isPulling = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
        HandleMouseInput();
        ApplyGravity();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button pressed
        {
            StartPull();
        }
        else if (Input.GetMouseButton(1))
        {
            ContinuePull();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Release();
        }
    }

    void StartPull()
    {
        isPulling = true;
        initialPosition = transform.position;
        rb.velocity = Vector3.zero; // Stop any existing velocity
    }

    void ContinuePull()
    {
        if (isPulling)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Ignore the Y component to restrict movement in X and Z directions only
            mousePos.y = transform.position.y;

            float pullDistance = Mathf.Clamp(Vector3.Distance(mousePos, initialPosition), 0f, float.MaxValue);
            Vector3 targetPosition = initialPosition + (mousePos - initialPosition).normalized * pullDistance;

            // Move the pen
            rb.MovePosition(targetPosition);
        }
    }

    void Release()
    {
        isPulling = false;
        releasePosition = transform.position;

        // Calculate and use the release information (magnitude and direction)
        Vector3 pullDirection = (initialPosition - releasePosition).normalized;
        float pullMagnitude = Mathf.Clamp(Vector3.Distance(releasePosition, initialPosition), 0f, float.MaxValue);

        Debug.Log("Pull Direction: " + pullDirection);
        Debug.Log("Pull Magnitude: " + pullMagnitude);

        // Apply a force to simulate the slingshot effect
        rb.AddForce(-pullDirection * pullMagnitude * movementSpeed, ForceMode.Impulse);
    }

    void ApplyGravity()
    {
        // Apply gravity manually
        rb.AddForce(Vector3.down * gravity * rb.mass);
    }
}
