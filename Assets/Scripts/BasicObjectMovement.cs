using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObjectMovement : MonoBehaviour
{
    [Header("Platform Settings")]
    public List<Transform> points;
    public Transform platform;
    public float moveSpeed = 2f;
    // Platform
    int goalPoint = 0;

    private void Update()
    {
        MoveToNextPoint();
    }
    private void MoveToNextPoint()
    {
        // Change the position of the platform (move towards the goal point)
        platform.position = Vector3.MoveTowards(platform.position, points[goalPoint].position, 1 * Time.deltaTime * moveSpeed);

        // Check if we are in very close proximity of the next point
        if (Vector3.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            if (goalPoint == points.Count - 1)
            {
                goalPoint = 0;
            }
            else
            {
                goalPoint++;
            }
        }
    }
}
