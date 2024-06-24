using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package_003 : MonoBehaviour
{
	//Thrust Values
	public Rigidbody rb;
	float maxThrust = 4000f;
	float minimalThrust = -2000f;
	float currentThrust = 0f;

	//forces the attack to return
	bool rp_return = false;

	//Objectb Transform
	public Transform objectB;

	// Use this for initialization
	void Start ()
	{
		currentThrust = maxThrust;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//The Object Constantly Moves forward
		rb.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		rb.velocity = Vector3.zero;

		//finds the transform of the object which uses the tag "ObjectB"
		objectB = GameObject.FindWithTag ("ObjectB").transform;


		if (currentThrust >= minimalThrust) {
			currentThrust -= 1500f * Time.deltaTime;
		}

		//When the Object begins to return
		if (currentThrust <= 0) {
			Debug.Log ("Returning");
			transform.rotation = Quaternion.LookRotation (transform.position - objectB.position);
		}

		//forces the Object to come back if it collides with an enemy or object
		if (rp_return == true) {
			if (currentThrust >= 0) {
				currentThrust = 0;
				rp_return = false;
			}
		}

		//pressing the E key will force it to return
		if (Input.GetKey ("e")) {
			rp_return = true;
		}
	}

	void OnCollisionEnter (UnityEngine.Collision collisionInfo)
	{
		//Resets the Rocket Punch
		if (collisionInfo.gameObject.tag == "ObjectB") {
			Destroy (gameObject);
		}

		//Returns the Rocket it hits an obstacle 
		if (collisionInfo.gameObject.tag == "[Insert Enenmy/Obstacle Tag Here]") {
			rp_return = true;
		}
	}
}
