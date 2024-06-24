using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package_0041 : MonoBehaviour 
{
	public Rigidbody rb;
	float currentThrust = 9000;
	public GameObject objectE;					//Explosion
	public Transform objectD;					//this object

	// Use this for initialization
	void Start () 
	{
		//destroys the game Object after 10 seconds
		Destroy (gameObject,10);
	}

	// Update is called once per frame
	void Update () 
	{
		rb.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		rb.velocity = Vector3.zero;
	}

	void OnCollisionEnter(UnityEngine.Collision collisionInfo)
	{
		//Deletes the Projectile when it touches anything
		if (collisionInfo.gameObject.tag == "Untagged")
		{
			Instantiate (objectE, objectD.position, objectD.rotation);
			Destroy (gameObject);
		}
	}
}
