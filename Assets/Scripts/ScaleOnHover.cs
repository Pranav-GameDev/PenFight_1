using UnityEngine;
using System.Collections;

public class ScaleOnHover : MonoBehaviour
{
    // Game object to scale
    public GameObject targetObject;

    // Original scale of the object
    private Vector3 originalScale;

    // Scale amount to increase on hover
    public Vector3 hoverScaleAmount;

    // Maximum scale limit
    public Vector3 maxScaleLimit;

    // Animation duration
    public float animationDuration = 0.5f;

    private void Start()
    {
        // Store original scale
        originalScale = targetObject.transform.localScale;
    }

    private void OnMouseEnter()
    {
        // Clamp the target scale with max limit
        Vector3 clampedTargetScale = Vector3.Min(targetObject.transform.localScale + hoverScaleAmount, maxScaleLimit);

        // Start animation to increase scale
        StartCoroutine(ScaleObject(clampedTargetScale, animationDuration));
    }

    private void OnMouseExit()
    {
        // Start animation to scale back to original scale
        StartCoroutine(ScaleObject(originalScale, animationDuration));
    }

    private IEnumerator ScaleObject(Vector3 targetScale, float duration)
    {
        float currentTime = 0f;
        Vector3 startScale = targetObject.transform.localScale;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float lerpValue = currentTime / duration;
            targetObject.transform.localScale = Vector3.Lerp(startScale, targetScale, lerpValue);
            yield return null;
        }
    }
}