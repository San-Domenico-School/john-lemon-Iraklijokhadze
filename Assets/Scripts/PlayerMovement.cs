/*This script is a component of the Player
/*  This class accepts user input to create player movement and align it with
 *  the player animation.
 *  
 *  IKA
 *  May 16, 2023
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Declare fields
    float turnSpeed;
    Animator animator;
    Rigidbody rb;
    Quaternion rotation;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize turnSpeed
        turnSpeed = 20f;

        // Initialize animator
        animator = GetComponent<Animator>();

        // Initialize rb
        rb = GetComponent<Rigidbody>();

        // Initialize movement and rotation
        movement = Vector3.zero;
        rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Sets the value of movement based on user input
    private void SetMovement()
    {
        // Get horizontal input
        float horizontal = Input.GetAxis("Horizontal");

        // Get vertical input
        float vertical = Input.GetAxis("Vertical");

        // Set movement vector
        movement.Set(horizontal, 0f, vertical);
    }

    // Sets the value of the IsWalking parameter in the Animator based on the value of the movement
    private void SetIsWalking()
    {
        
        if (Mathf.Approximately(movement.magnitude, 0f))
        {
           
            animator.SetBool("IsWalking", false);
        }
        else
        {
           
            animator.SetBool("IsWalking", true);
        }
    }

    // Sets the value of rotation based on the value of the movement
    private void SetRotation()
    {
        // Calculate desired forward direction
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);

        // Set rotation based on desired forward direction
        rotation = Quaternion.LookRotation(desiredForward);
    }

    // Moves and rotates the player based on an event from the Animator
    private void OnAnimatorMove()
    {
        // Normalize movement vector
        movement.Normalize();

        // Move rigidbody's position
        rb.MovePosition(rb.position + movement * animator.deltaPosition.magnitude);

        // Move rigidbody's rotation
        rb.MoveRotation(rotation);
    }

    void FixedUpdate()
    {
        // Call SetMovement to update movement based on user input
        SetMovement();

        // Call SetIsWalking to update the IsWalking parameter in the Animator
        SetIsWalking();

        // Call SetRotation to update rotation based on the movement
        SetRotation();
    }
}
