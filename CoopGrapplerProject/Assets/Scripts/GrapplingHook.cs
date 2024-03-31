using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer; // Layer mask for the environment
    [SerializeField] private LineRenderer rope;
    [SerializeField] private float verticalBoostForce = 10f; // Adjust the boost force as needed
    private DistanceJoint2D joint;

    // Use this angle for the base grapple direction
    private float baseGrappleAngle = 70f;

    // Input key for player
    [SerializeField] private KeyCode playerGrappleKey = KeyCode.F;
    [SerializeField] private string playerKey = "Player1Horizontal";

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
    }

    void Update()
    {
        // Change the input check to use the respective key for each player
        if (Input.GetKeyDown(playerGrappleKey))
        {
            // Check the player's movement direction
            float horizontalInput = Input.GetAxis(playerKey);

            // Set the base grapple angle based on the player's input
            float baseGrappleAngle = Mathf.Sign(horizontalInput) >= 0 ? 70f : 110f;

            // Calculate the grapple direction based on the movement direction and base angle
            Vector2 grappleDirection = Quaternion.Euler(0f, 0f, baseGrappleAngle) * Vector2.right;

            // Cast a ray in the grapple direction
            RaycastHit2D hit = Physics2D.Raycast(transform.position, grappleDirection, grappleLength, grappleLayer);

            // If the ray hits something, set the grapple point to the point of collision
            if (hit.collider != null)
            {
                joint.connectedAnchor = hit.point;
                joint.enabled = true;
                joint.distance = Vector2.Distance(transform.position, hit.point);
                rope.SetPosition(0, hit.point);
                rope.SetPosition(1, transform.position);
                rope.enabled = true;

                // Apply an initial force to get the player moving towards the grapple point
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce((hit.point - (Vector2)transform.position).normalized * verticalBoostForce, ForceMode2D.Impulse);
            }
            else
            {
                // If the ray doesn't hit anything, set the grapple point based on the direction and length
                Vector2 grapplePoint = (Vector2)transform.position + grappleDirection.normalized * grappleLength;
                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                joint.distance = grappleLength;
                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, transform.position);
                rope.enabled = true;
            }
        }

        // Change the input check to use the respective key for each player
        if (Input.GetKeyUp(playerGrappleKey))
        {
            joint.enabled = false;
            rope.enabled = false;

            // Apply a vertical boost after releasing the grapple
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * verticalBoostForce, ForceMode2D.Impulse);
        }

        if (rope.enabled == true)
        {
            rope.SetPosition(1, transform.position);
        }
    }
}
