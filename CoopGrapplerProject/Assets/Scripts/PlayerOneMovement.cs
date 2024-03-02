using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    public int playerNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input based on player number
        float horizontalInput = 0f;

        if (playerNumber == 1)
        {
            horizontalInput = Input.GetAxis("Player1Horizontal");
        }
        else if (playerNumber == 2)
        {
            horizontalInput = Input.GetAxis("Player2Horizontal");
        }

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, 0f) * moveSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);

        if (isGrounded)
        {
            if ((playerNumber == 1 && Input.GetKeyDown(KeyCode.W)) ||
                (playerNumber == 2 && Input.GetKeyDown(KeyCode.UpArrow)))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
