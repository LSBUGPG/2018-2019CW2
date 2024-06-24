using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package_001 : MonoBehaviour
{
	public GameObject objectA_GameObject;
	//GameObject of What you use to dock
	public Rigidbody objectA_Rigidbody;
	//Rigidbody of What you use to dock
	public GameObject dock_GameObject;
	//GameObject What you dock into
	public Transform objectB_Transform;
	//transformation of what you dock with
	public Rigidbody objectB_Rigidbody;
	//Rigidbody of what you dock with

	//package 002 can be its own movement script
	public Package_002 package_002;
	//Package_002 Script

	//Movement Can be changed to better fit your project
	float maxThrust = 5000f;
	float minimalThrust = -3000f;
	float currentThrust = 0f;

	//Will determine if you're docked or not
	bool docked = false;

	//cameras
	public Camera camera_a;
	//ObjectA Camera
	public Camera camera_b;
	//ObjectB camera

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Movement Can be changed to fit your project

		//Constantly Moves objectA Foward and removes the Velocity
		objectA_Rigidbody.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		objectA_Rigidbody.velocity = Vector3.zero;

		//makes the objectA move forward
		if (Input.GetKey ("w") && currentThrust <= maxThrust && docked == false) {
			currentThrust += 1500f * Time.deltaTime;
		}

		//resets the Movement speed when "W" is let go
		if (Input.GetKeyUp ("w") && docked == false) {
			currentThrust = 0f;
		}

		//makes the objectA move backrward	
		if (Input.GetKey ("s") && currentThrust >= minimalThrust && docked == false) {
			currentThrust -= 1500f * Time.deltaTime;
		}

		//resets the Movement speed when "S" is let go
		if (Input.GetKeyUp ("s") && docked == false) {
			currentThrust = 0f;
		}

		//Makes objectA go up
		if (Input.GetKey ("f")) {
			if (docked == false) {
				objectA_Rigidbody.AddForce (0, -1200f * Time.deltaTime, 0, ForceMode.VelocityChange);	
			}
		}

		//Makes objectA go down
		if (Input.GetKey ("g")) {
			objectA_Rigidbody.AddForce (0, 1200f * Time.deltaTime, 0, ForceMode.VelocityChange);	


			// If objectA is docked into objectB Release it from its bindings  
			if (docked == true) {
				objectA_GameObject.transform.parent = null;
				docked = false;
				package_002.enabled = false;
				objectA_Rigidbody.constraints = RigidbodyConstraints.None;
				objectA_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			}
		}

		//The Camera changer
		if (docked == true) {
			camera_a.enabled = false;
			camera_b.enabled = true;
		}

		if (docked == false) {
			camera_a.enabled = true;
			camera_b.enabled = false;
		}
	}

	void OnCollisionEnter (UnityEngine.Collision collisionInfo)
	{
		//activates objectB
		if (collisionInfo.gameObject.tag == "Dock") {
			Debug.Log ("Go!");
			docked = true;
			package_002.enabled = true;
			objectA_GameObject.transform.SetParent (objectB_Transform);
			objectA_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
	}
}
