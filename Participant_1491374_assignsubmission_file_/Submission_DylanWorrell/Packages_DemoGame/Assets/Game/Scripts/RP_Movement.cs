using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RP_Movement : MonoBehaviour 
{
	//Thrust Values
	public Rigidbody rb;
	float maxThrust = 8000f;
	float minimalThrust = -4000f;
	float currentThrust = 0f;

	bool rp_return = false; 

	//Controls The Thrusters
	public ParticleSystem thruster;
	public ParticleSystem thrusterFinger;
	public ParticleSystem thrusterThumb;

	//Fingers Mesh
	public MeshRenderer fingers;
	public MeshRenderer thumb;

	//mazinger Transform
	public Transform mazinger;

	// Use this for initialization
	void Start () 
	{
		currentThrust = maxThrust;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//The Fist Constantly Moves forward
		rb.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		rb.velocity = Vector3.zero;

		//finds the transform of the object which uses the tag "[Insert Tag Here]"
		mazinger = GameObject.FindWithTag ("Mazinger").transform;

		if (currentThrust >= minimalThrust) 
		{
			currentThrust -= 1500f * Time.deltaTime;
		}

		//When the fist begins to return
		if (currentThrust <= 0) 
		{
			//toggles the Thrusters
			Debug.Log ("Returning");
			thruster.Stop ();
			thrusterFinger.Play ();
			thrusterThumb.Play ();

			fingers.enabled = true;
			thumb.enabled = true;

			transform.rotation = Quaternion.LookRotation (transform.position - mazinger.position);
		}

		//forces the fist to come back if it collides with an enemy or wall
		if (rp_return == true) 
		{
			if (currentThrust >= 0) 
			{
				currentThrust = 0;
				rp_return = false;
			}
		}

		if (Input.GetKey ("e")) 
		{
			rp_return = true;
		}


	}

	void OnCollisionEnter(UnityEngine.Collision collisionInfo)
	{
		//Resets the Rocket Punch
		if (collisionInfo.gameObject.tag == "Mazinger") 
		{
			Destroy (gameObject);
		}

		//Returns the Rocket it hits an obstacle 
		if (collisionInfo.gameObject.tag == "Untagged") 
		{
			rp_return = true;
		}
	}
}