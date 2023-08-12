using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public Vector2[] path;
    private int pos = 0;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed = 2.5f;
    [SerializeField] private float offset;
    [SerializeField] private float closeEnough = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (pos >= path.Length)
        {
            pos = 0;
            GameManager.gameManager.OppLapIncrease();
        }
        Vector3 directionToTarget = path[pos] - (Vector2)transform.position;

        // Calculate the target rotation angle in degrees
        float targetRotationAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        // Calculate the current rotation angle of the object
        float currentRotationAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;

        // Smoothly interpolate between the current rotation and target rotation
        float newRotationAngle = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, turnSpeed);

        // Apply the new rotation
        transform.rotation = Quaternion.Euler(0, 0, newRotationAngle + offset);

        rb.position = Vector2.MoveTowards(transform.position, transform.up + transform.position, (moveSpeed * Time.fixedDeltaTime) / 2);

        if (Vector3.Distance(transform.position, path[pos]) < closeEnough)
        {
            pos++;
        }
    }

    private void OnDrawGizmos()
    {
        if (path == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        foreach (Vector2 pos in path)
        {
            Gizmos.DrawWireSphere(pos, closeEnough);
        }

        Gizmos.color = Color.green;
        if (pos < path.Length)
            Gizmos.DrawLine(transform.position, path[pos]);
    }
}
