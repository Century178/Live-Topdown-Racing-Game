using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float turnSpeed = 3;
    private float x, y;

    private Rigidbody2D rb;

    private void Awake()
    {
        if (player != null) Destroy(gameObject);
        else player = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * y * moveSpeed;

        rb.rotation -= x * turnSpeed;
    }
}
