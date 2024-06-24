using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package_002 : MonoBehaviour
{
	//Movement can be changed to fit your game
	public Rigidbody gameObjectb_Rigidbody;
	float currentThrust = 0;
	float minimalThrust = -10000;
	float maxThrust = 10000;

	//ObjectB's attack_001 (Boomerang attack, ObjectC)
	public GameObject gameObjectC;
	bool attack_001 = true;

	//ObjectD attack_002 (Explosive)
	public GameObject gameObjectD;

	//attack_003
	public float fireRate;
	private float nextFire;

	public Transform attackSpawn;
	public Transform attackSpawn2;
	public Transform attackSpawn3;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObjectb_Rigidbody.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		gameObjectb_Rigidbody.velocity = Vector3.zero;

		//Allows the player to move forwards when pressing "W"
		if (Input.GetKey ("w") && currentThrust <= maxThrust) {
			currentThrust = maxThrust;
		}

		//Stops the objectB from moving forward once "W" is let go
		if (Input.GetKeyUp ("w")) {
			currentThrust = 0;
		}

		//Allows the objectB to move backrwards when pressing "S"
		if (Input.GetKey ("s") && currentThrust >= minimalThrust) {
			currentThrust = minimalThrust;
		}

		//Stops the objectB from moving backward once "S" is let go
		if (Input.GetKeyUp ("s")) {
			currentThrust = 0;
		}

		//rotates the objectB left and right 
		if (Input.GetKey ("d")) {
			transform.Rotate (0, 2f, 0);
		}

		if (Input.GetKey ("a")) {
			transform.Rotate (0, -2f, 0);
		}

		//Launches ObjectC (Can be changed)
		if (Input.GetKeyUp ("e") && attack_001 == true) {
			Instantiate (gameObjectC, attackSpawn.position, attackSpawn.rotation);
			attack_001 = false;
		}	
		//Launches ObjectD
		if (Input.GetKeyUp ("r")) {
			Instantiate (gameObjectD, attackSpawn2.position, attackSpawn2.rotation);
		}	

		if (Input.GetKey ("q")) {
			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (gameObjectD, attackSpawn3.position, attackSpawn3.rotation);
			}
		}
	}

	void OnCollisionEnter (UnityEngine.Collision collisionInfo)
	{
		//Resets ObjectC once it makes contact with ObjectB
		if (collisionInfo.gameObject.tag == "ObjectC") {
			attack_001 = true;
		}
	}

}
