using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pen_2_Gravity : MonoBehaviour
{
    private Rigidbody rb;

    public float gravityStrength = 9.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable Unity's default gravity
    }

    void Update()
    {
        ApplyGravity();
    }

    void ApplyGravity()
    {
        // Apply constant gravity force
        rb.AddForce(Vector3.down * gravityStrength);
    }
}