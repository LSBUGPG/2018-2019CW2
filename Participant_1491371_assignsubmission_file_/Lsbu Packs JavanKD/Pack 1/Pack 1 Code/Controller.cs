using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public CharacterController m_CharacterController;
    public float VerticalSpeed; //Movement forwards and backwards
    public float HorizontalSpeed; // Movement side-to-side
    public float XRotation; // Horizontal camera rotation
    public bool walking = false; // Walking true/false bool
    public float JumpPower; // Power of each Jump
    public float RaycastCheckLength; // Checks how long the RayCast is
    public bool OnGround = true; // A bool to check if you are on the ground or in the air
    Rigidbody rb; // Calls for the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        Cursor.lockState = CursorLockMode.Locked; // This script is what is causing your cursor to be "locked" in the center of your screen, meaning your cursor doesn't hover off onto your taskbar
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * VerticalSpeed; // Translates your character forward/backwards
        float sidetranslation = Input.GetAxis("Horizontal") * HorizontalSpeed; // Translate your character side-to-side
        float rotation = Input.GetAxis("Mouse X") * XRotation; // Allows you to move your camera side-to-side with your mouse
        sidetranslation *= Time.deltaTime; // Defines how fast it does this. This can be changed by looking at the script in the editor after it is applied to your character
        translation *= Time.deltaTime; // Defines how fast it does this. This can be changed by looking at the script in the editor after it is applied to your character
        rotation *= Time.deltaTime; // Defines how fast it does this. This can be changed by looking at the script in the editor after it is applied to your character
        transform.Translate(sidetranslation, 0, translation);
        transform.Rotate(0, rotation, 0);

        
        if (Input.GetKeyDown(KeyCode.LeftShift)) // When you hold down the Left Shift button
        {
            walking = true; // Walking is set to true
            if (walking) // If walking is true...
            {
                VerticalSpeed = 4.0f; // Forward/Backward speed is set to "4.0f", this can be changed to your liking
                HorizontalSpeed = 4.0f; // Side-to-side speed is set to "4.0f", this can be changed to your liking
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) // If you release the Left Shift key
        {
            walking = false; // Walking is set to false
            if (!walking) // If walking is false...
            {
                VerticalSpeed = 20.0f; // Speed is reset to its original value
                HorizontalSpeed = 20.0f; // Speed is reset to its original value
            }
        }

        RaycastHit hit; // Creating the raycast
        Vector3 physicsCentre = transform.position + GetComponent<CapsuleCollider>().center; // Shoots out the Raycast from the center point of the object
        Debug.DrawRay(physicsCentre, Vector3.down* RaycastCheckLength, Color.red, 1.8f); // Shoots out the Raycast down, you can adjust the "color.red" to the color you want. "1.9f" is the length of the
        // raycast, be sure to adjust it's length so that it touches the ground from your character


        if (Physics.Raycast(physicsCentre, Vector3.down, out hit, RaycastCheckLength)) // If the raycast hits the ground
        {
            if (hit.transform.gameObject.tag != "Player") // and it hits an object that does NOT have the tag "player" (which your character should have)
            {
                OnGround = true; // OnGround = True
                JumpPower = 10; // Meaning you can jump with a power of 10. This can be changed in the editor
            }
        }
        else // Otherwise
        {
            OnGround = false; // OnGround = False
            JumpPower = 0; // And jump power is set to 0, meaning you can't jump anymore
        }
        Debug.Log(OnGround);

        if(Input.GetKeyDown(KeyCode.Space) && OnGround)  // If you press the Space key & you're on the ground...
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * JumpPower, ForceMode.VelocityChange); // It adds force to your character * JumpPower, allowing your character to go up
        }
    }
    }

