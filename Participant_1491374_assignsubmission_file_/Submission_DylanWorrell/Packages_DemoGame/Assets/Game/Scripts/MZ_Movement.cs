using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MZ_Movement : MonoBehaviour 
{
	public Rigidbody rb;
	float currentThrust = 0;
	float minimalThrust = -10000;
	float maxThrust = 10000;

	//BreastFire
	public GameObject breastFire;
	bool breastFireToggle = false;

	//rocket punch
	public GameObject rocketPunch;
	bool rp_Active = true;
	public Transform spawnA;

	public MeshRenderer rightArm1;
	public MeshRenderer rightArm2;

	//Mazinger Missile
	public GameObject MM_Missile;
	public Transform MM_Spawn;
	float MM_Cooldown = 0;


	// Use this for initialization
	void Start () 
	{
		currentThrust = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		rb.velocity = Vector3.zero;

		MM_Cooldown -= 1 * Time.deltaTime;

	
		//Allows the player to move forwards when pressing "W"
		if (Input.GetKey ("w") && currentThrust <= maxThrust && breastFireToggle == false) 
		{
			currentThrust = maxThrust;
		}

		//Stops the player from moving forward once "W" is let go
		if (Input.GetKeyUp ("w")) 
		{
			currentThrust = 0;
		}

		//Allows the player to move backrwards when pressing "S"
		if (Input.GetKey ("s") && currentThrust >= minimalThrust && breastFireToggle == false) 
		{
			currentThrust = minimalThrust;
		}

		//Stops the player from moving backward once "S" is let go
		if (Input.GetKeyUp ("s")) 
		{
			currentThrust = 0;
		}

		//rotates the player left and right 
		if (Input.GetKey ("d") && breastFireToggle == false) 
		{
			transform.Rotate (0, 2f, 0);
		}

		if (Input.GetKey ("a") && breastFireToggle == false) 
		{
			transform.Rotate (0, -2f, 0);
		}

		//activates the BREAST FIRE (WIP)
		if (Input.GetKeyDown ("q")) 
		{
			breastFireToggle = true;
			currentThrust = 0;
			breastFire.SetActive(true);
		}	

		if (Input.GetKeyUp ("q")) 
		{
			breastFireToggle = false;
			breastFire.SetActive(false);

		}	

		//activates the Rocket PANCH! (WIP)
		if (Input.GetKeyUp ("e") && rp_Active == true) 
		{
			Instantiate (rocketPunch, spawnA.position, spawnA.rotation);
			rightArm1.enabled = false;
			rightArm2.enabled = false;
			rp_Active = false;
		}	
	
		//Launches the Missile
		if (Input.GetKeyUp ("r") && MM_Cooldown <= 0) 
		{
			Instantiate (MM_Missile, MM_Spawn.position, MM_Spawn.rotation);
			MM_Cooldown = 5;
		}	
	}

	void OnCollisionEnter(UnityEngine.Collision collisionInfo)
	{
		//Resets the Rocket Punch once it makes contact with MAzinger
		if (collisionInfo.gameObject.tag == "RocketPunchR") 
		{
			rightArm1.enabled = true;
			rightArm2.enabled = true;
			rp_Active = true;
		}
	
	
	}
}
