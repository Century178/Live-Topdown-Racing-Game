using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public Vector2[] path;
    private int pos = 0;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float offset;

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

        rb.position = Vector2.MoveTowards(transform.position, path[pos], (moveSpeed * Time.fixedDeltaTime) / 2);

        if (Vector3.Distance(transform.position, path[pos]) < 0.1f)
        {
            pos++;
        }

        if (pos < path.Length)
        {
            Vector3 rawDirection = (Vector2)transform.position - path[pos];
            rb.rotation = (Mathf.Atan2(rawDirection.y, rawDirection.x) * Mathf.Rad2Deg) - offset;
        }
    }
}
