using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float speed = 8f;
	private float jump = 15f;
	private float gravity = 30f;
	private Vector3 moveDir = Vector3.zero;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		CharacterController controller = gameObject.GetComponent<CharacterController> ();

		if (controller.isGrounded) {
			moveDir = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;

			if (Input.GetButtonDown ("Jump")) {
				moveDir.y = jump;
			}
		}

		moveDir.y -= gravity * Time.deltaTime;
		controller.Move (moveDir * Time.deltaTime);

	}
}