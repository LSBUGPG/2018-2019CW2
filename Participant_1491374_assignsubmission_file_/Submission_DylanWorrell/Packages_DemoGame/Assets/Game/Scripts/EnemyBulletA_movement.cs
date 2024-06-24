using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletA_movement : MonoBehaviour 
{
	public Rigidbody rb;
	float currentThrust = 9000;

	public Transform mazinger;
	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject,10);
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		rb.velocity = Vector3.zero;

		mazinger = GameObject.FindWithTag ("Mazinger").transform;
	}

	void OnCollisionEnter(UnityEngine.Collision collisionInfo)
	{
		//Resets the Rocket Punch once it makes contact with Mazinger
		if (collisionInfo.gameObject.tag == "Mazinger")
		{
			Destroy (gameObject);
		}

		//Deletes the Projectile when it touches anything
		if (collisionInfo.gameObject.tag == "Untagged")
		{
			Destroy (gameObject);
		}

	}
}
