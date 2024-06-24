﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                                            //VARIABLES, FLOATS, BOOLS, (ETC)

    public float speed; // Player speed
    public float jumpForce; // Jump height 
    public float checkRadius; // Radius in which the ground is checked
    public float fallMultiplier = 2.5f; // gravity multiplier when falling
    public float lowJumpMultiplier = 2f; // gravity multiplier when falling after tapping space
    public float wallCheckDistance; // Distance of which the raycast is shot to detect a "wall" surface
    public float maxWallSlideVelocity; // Maximum speed at which the player 'slides' down the wall
    private float movement; // A float to define when our speed is used



    public LayerMask isGround; // Creating a LayerMask to determine what is the ground, and what isn't



    private int doubleJump; // Doublejump count
    public int doubleJumpValue; // Doublejump count (they both effect the same value, but change this one when changing the amount of jumps)



    public bool onGround; // Yes or No to determine the player is on the ground
    private bool isWallSliding = false; // Yes or No to determine the player is wall sliding



    public Transform groundCheck; // Calling the empty game objects' position (named "Groundcheck" in the hierarchy)
    public Transform wallCheck;// Calling the empty game objects' position (named "wallCheck" in the hierarchy)
    public Rigidbody2D rb; // Calling reference to the players' rigidbody2D



    private RaycastHit2D wallCheckHit; // A Raycast to detect walls (invisible laser that detects shit)



//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//START VOID FUNCTION



    void Awake()
    {
        doubleJump = doubleJumpValue; 
        rb = GetComponent<Rigidbody2D>(); // Calling the rigidbody
    }





//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//JUMPING AND MOVEMENT


    void Update()
    {
        movement = Input.GetAxis("Horizontal"); // Defining the player movement on the "Horizontal" axis (left/right)
        rb.velocity = new Vector2(movement * speed, rb.velocity.y); // Moving the character using velocity on the Y axis (which is up)
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround); // Checking if the player is on the ground by creating a circle radius as a form of detection


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            speed += 4 * Time.deltaTime;
        }


        if (speed >= 0.001 && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            speed -= 9 * Time.deltaTime;
        }


        if (speed <= 0)
        {
            speed = 0;
        }


        if (speed >= 6)
        {
            speed = 6;
        }


        if (Input.GetKeyDown(KeyCode.Space) && doubleJump > 0) // If the player presses space, the jump counter is more than OR EQUAL TO 0 and they're not on the ground...
        {
            rb.velocity = Vector2.up * jumpForce; // ...They jump, by going up * jumpForce!
            doubleJump--; // Once this happens, it takes away a jump from the jump counter!
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump == 0 && onGround == true) // Else, if they press space, they haven't jumped yet and they're on the ground...
        {
            rb.velocity = Vector2.up * jumpForce; // ...They jump! Only this time, it doesn't take away from the jump counter
        }

        if (onGround) 
        {
            doubleJump = doubleJumpValue; 
        }



//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//VARIABLE JUMP HEIGHT 


        if (rb.velocity.y < 0 && !onGround && !isWallSliding) // If the players' velocity on the y axis is less than 0...
        {
            rb.gravityScale = fallMultiplier; // The players' gravity is adjusted according to the fallMultiplier value, making the player fall faster.
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump") && !onGround && !isWallSliding) // However, if instead the y axis is greater than 0, but the player IS NOT pressing "Jump"...
        {
            rb.gravityScale = lowJumpMultiplier; // ...Then it will adjust the gravity of the player according to the lowJumpMultiplier, because they must be low jumping!
        }
        else
        {
            rb.gravityScale = 1f; // HOWEVER, if none of those are happening, then the players' gravity is set to it's natural number, 1.
        }



//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
