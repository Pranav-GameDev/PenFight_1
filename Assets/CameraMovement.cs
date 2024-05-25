using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float targetX;
    public float targetY;
    public float targetZ;

    public float targetRotationX;
    public float targetRotationY;
    public float targetRotationZ;

    public float animationDuration = 2f;
    public float delayBeforeAnimation = 1f;

    public bool isAnimating = false;
    

    // Reference to the CameraFollow script
    private camerafollow cameraFollowScript;

    // Reference to the MouseMovement script on player1 and player2
    public MouseMovement player1MouseMovement;
    public MouseMovement player2MouseMovement;

    // Reference to the PlayButton script
    public PlayButton playButtonScript;

    void Start()
    {
        // Get the CameraFollow script attached to the main camera
        cameraFollowScript = GetComponent<camerafollow>();
        // Disable CameraFollow initially
        cameraFollowScript.enabled = false;

        // Disable MouseMovement on player1 and player2 initially
        if (player1MouseMovement != null)
        {
            player1MouseMovement.enabled = false;
        }
        if (player2MouseMovement != null)
        {
            player2MouseMovement.enabled = false;
        }
    }

    void Update()
    {
        if (playButtonScript != null && Input.GetMouseButtonDown(0) && !isAnimating)
        {
            // Start camera movement when left mouse button is clicked
            StartCameraMovement();
        }

        if (isAnimating)
        {
            PerformCameraAnimation();
        }
    }

    void StartCameraMovement()
    {
        isAnimating = true;

        // Disable CameraFollow script during the animation
        cameraFollowScript.enabled = false;

        // Disable MouseMovement on player1 and player2 during the animation
        if (player1MouseMovement != null)
        {
            player1MouseMovement.enabled = false;
        }
        if (player2MouseMovement != null)
        {
            player2MouseMovement.enabled = false;
        }

        Invoke("StartAnimation", delayBeforeAnimation);
    }

    void StartAnimation()
    {
        Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);
        Vector3 targetRotation = new Vector3(targetRotationX, targetRotationY, targetRotationZ);

        LeanTween.move(gameObject, targetPosition, animationDuration).setEase(LeanTweenType.easeInOutQuad).setOnComplete(OnAnimationComplete);
        LeanTween.rotate(gameObject, targetRotation, animationDuration).setEase(LeanTweenType.easeInOutQuad);
    }

    void PerformCameraAnimation()
    {
        // You can perform additional actions during the animation if needed
        // For example, updating UI, triggering events, etc.
    }

    void OnAnimationComplete()
    {
        // Re-enable CameraFollow script after the animation is complete
        cameraFollowScript.enabled = true;

        // Re-enable MouseMovement on player1 after the animation is complete
        if (player1MouseMovement != null)
        {
            player1MouseMovement.enabled = true;
        }

        isAnimating = false;
        IsAnimating();
        // 4. Disable this code
        enabled = false;
    }
    public bool IsAnimating()
    {
        return isAnimating;
    }
}
