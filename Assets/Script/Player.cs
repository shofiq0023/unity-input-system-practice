using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private float moveSpeed = 18f;
    private float jumpPower = 10f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        // Create the InputSystemAction C# object
        playerInput = new PlayerInput();

        // Enable the Player input map and subscribe to the 'Jump' action
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += Jump;
    }

    private void FixedUpdate() {
        Vector2 inputVector = playerInput.Player.Movement.ReadValue<Vector2>();
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * moveSpeed, ForceMode2D.Force);
    }

    // Will be called by C# events
    private void Jump(InputAction.CallbackContext context) {
        if (context.performed) {
            // rb.velocity = Vector2.up * moveSpeed;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("Jump!");
        }
    }
}
