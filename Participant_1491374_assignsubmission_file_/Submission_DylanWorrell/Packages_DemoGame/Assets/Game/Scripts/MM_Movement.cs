using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Movement : MonoBehaviour 
{
	public Rigidbody rb;
	float currentThrust = 9000;
	public GameObject MM_Explosion;
	public Transform thisObject;

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
	}

	void OnCollisionEnter(UnityEngine.Collision collisionInfo)
	{
		//Deletes the Projectile when it touches anything
		if (collisionInfo.gameObject.tag == "Untagged")
		{
			Instantiate (MM_Explosion, thisObject.position, thisObject.rotation);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") 
		{
			Instantiate (MM_Explosion, thisObject.position, thisObject.rotation);
			Destroy (gameObject);
		}
	}
}
