using UnityEngine;

public class CameraMovement2 : MonoBehaviour
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
    
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject highscoreButton;
    public GameObject exitButton;
    

    // Reference to the CameraFollow script
    private camerafollow cameraFollowScript;

    // Reference to the MouseMovement script on player1 and player2
    public MouseMovement player1MouseMovement;
    public MouseMovement player2MouseMovement;

    // Reference to the PlayButton script
    // public GameObject exitScript;

    void Start()
    {
        // Get the CameraFollow script attached to the main camera
        // cameraFollowScript = GetComponent<camerafollow>();
        // Disable CameraFollow initially
        // cameraFollowScript.enabled = false;

        // Disable MouseMovement on player1 and player2 initially
   
            player1MouseMovement.enabled = false;
    
            player2MouseMovement.enabled = false;
            cameraFollowScript.enabled = false;
        EnableUI();
    }

    void EnableUI()
    {
        // 3. Disable PlayButton, Settings, Highscore, and ExitButton Game objects
        if (playButton != null)
        {
            playButton.SetActive(true);
        }

        if (settingsButton != null)
        {
            settingsButton.SetActive(true);
        }

        if (highscoreButton != null)
        {
            highscoreButton.SetActive(true);
        }

        if (exitButton != null)
        {
            exitButton.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnimating)
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


        // Disable MouseMovement on player1 and player2 during the animation

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
        // Re-enable MouseMovement on player1 after the animation is complete

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
