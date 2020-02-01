using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    public float leftBoundary;
    public float rightBoundary;

    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = Vector3.zero;
        if (target.position.x > leftBoundary && target.position.x < rightBoundary)
        {
            targetPosition = new Vector3(target.position.x, 0, -10);
        }
        else if (target.position.x < leftBoundary)
        {
            targetPosition = new Vector3(leftBoundary, 0, -10);
        }
        else if (target.position.x > rightBoundary)
        {
            targetPosition = new Vector3(rightBoundary, 0, -10);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
