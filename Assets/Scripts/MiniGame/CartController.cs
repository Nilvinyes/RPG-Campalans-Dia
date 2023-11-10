using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    private Rigidbody2D cart;
    public Camera mainCamera; // Drag and drop the main camera in the Inspector
    public float margin = 0.1f; // Margin to consider when checking proximity to the edges
    private bool edge = false;


    // Start is called before the first frame update
    void Start()
    {
        cart = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");

        if (!edge)
        {
            if(xMovement > 0)
            {
                cart.velocity = Vector2.right * 5;
            } else if (xMovement < 0)
            {
                cart.velocity = Vector2.left * 5;
            }
            else {
                cart.velocity = Vector2.zero;
            }
        }
    }

    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main camera reference is not set!");
            return;
        }

        // Get the player's position in screen space
        Vector3 playerScreenPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the player is about to get off from the camera's view
        if (playerScreenPos.x < margin || playerScreenPos.x > 1 - margin)
        {
            edge = true;
            cart.velocity = Vector2.zero;
            // Player is about to get off from the camera's view
            Debug.Log("Player is about to get off from the camera!");

            // You can add actions to keep the player inside the camera's view
            // For example, you can move the player back inside the camera's view.
            // Something like: transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        } else
        {
            edge = false;
        }
    }
}
