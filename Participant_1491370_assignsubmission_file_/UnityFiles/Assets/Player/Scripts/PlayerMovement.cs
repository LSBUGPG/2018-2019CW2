using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpPower;

    bool isGrounded;
    public float groundCheckLength;
    public LayerMask groundCheckLayer;

    public float sensitivity;
    float playerRotation, cameraRotation;
    public Transform playerCam;

    Rigidbody rb;

	void Start () {

        rb = GetComponent<Rigidbody>();
		
	}
	
	void Update () {

        #region Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * moveY) + (transform.right * moveX);

        movement.x = Mathf.Clamp(movement.x, -1, 1);
        movement.z = Mathf.Clamp(movement.z, -1, 1);

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
        #endregion

        #region Camera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        playerRotation += mouseX * sensitivity;
        cameraRotation -= mouseY * sensitivity;

        cameraRotation = Mathf.Clamp(cameraRotation, -50, 55);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, playerRotation, transform.eulerAngles.z);
        playerCam.localEulerAngles = new Vector3(cameraRotation, 0, 0);
        #endregion

        #region Jumping
        isGrounded = Physics.Raycast(transform.position, Vector3.up * -1, groundCheckLength, groundCheckLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.VelocityChange);
        }
        #endregion
    }
}
