using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Movement : MonoBehaviour 
{
	//Variables for the game
	public GameObject pilder;
	public GameObject dock;
	public Transform mazingerZ;
	public Rigidbody mazingerZr;

	//plider RigidBody and Movement values
	public Rigidbody rb;
	float maxThrust = 5000f;
	float minimalThrust = -3000f;
	float currentThrust = 0f;

	//Pilder Wing variables
	public GameObject wingL;
	public GameObject wingR;

	//Pilder Thrusters
	public ParticleSystem LThruster;
	public ParticleSystem RThruster;
	public ParticleSystem BLThruster;
	public ParticleSystem BRThruster;

	//Pilder Toggles
	bool docked = false;
	bool bThrusterOn = false;
	bool wingsIn = false;

	public MZ_Movement mzMovement;
	public GameObject eyes;

	//cameras
	public Camera camera1;
	public Camera camera2;

	//Guiding Light (The green docking light)
	public MeshRenderer guidingLight;
	bool gl_On = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Constantly Moves the Player Foward and removes the Velocity
		rb.AddRelativeForce (Vector3.forward * currentThrust * Time.deltaTime, ForceMode.VelocityChange);
		rb.velocity = Vector3.zero;

	
		//makes the Pilder move forward
		if (Input.GetKey ("w") && currentThrust <= maxThrust && docked == false) 
		{
			currentThrust += 1500f * Time.deltaTime ;
			wingsIn = false;
			bThrusterOn = false;
		}

		//resets the Movement speed when "W" is let go
		if (Input.GetKeyUp ("w") && docked == false) 
		{
			currentThrust = 0f;
			wingsIn = false;
			bThrusterOn = false;
		}

		//makes the Pilder move backrward	
		if (Input.GetKey ("s") && currentThrust >= minimalThrust && docked == false) 
		{
			currentThrust -= 1500f * Time.deltaTime;
			wingsIn = false;
		}

		//resets the Movement speed when "S" is let go
		if (Input.GetKeyUp ("s") && docked == false)
		{
			currentThrust = 0f;
			wingsIn = false;
			bThrusterOn = false;
		}

		//Makes Pilder go up
		if (Input.GetKey ("f")) 
		{
			if (docked == false) 
			{
				bThrusterOn = true;
//				currentThrust = 0f;
				rb.AddForce (0, -1200f * Time.deltaTime, 0, ForceMode.VelocityChange);	
				wingsIn = true;
			}

			//fixes the rotation so that the pilder is in the right position to dock also reduces docking speed
			if (Input.GetKey ("left shift")) 
			{
				pilder.transform.rotation = dock.transform.rotation;
				currentThrust = 0f;
				wingsIn = true;
			}
		}

		if (Input.GetKeyUp ("f"))
		{
			if (docked == false) 
			{
				wingsIn = false;
				bThrusterOn = false;
			}
		}

		//Makes Pilder go down
		if (Input.GetKey ("g")) 
		{
			rb.AddForce (0, 1200f * Time.deltaTime, 0, ForceMode.VelocityChange);	
			wingsIn = true;
			bThrusterOn = true;
//			currentThrust = 0f;
			eyes.SetActive(false);

			// IF the Pilder is docked into the Mazinger Release it from its bindings and fly away 
			if (docked == true) 
			{
				pilder.transform.parent = null;
				docked = false;
				mzMovement.enabled = false;
				rb.constraints = RigidbodyConstraints.None;
				rb.constraints = RigidbodyConstraints.FreezeRotation;
			}
		}	

		if (Input.GetKeyUp ("g"))
		{
			if (docked == false) 
			{
				wingsIn = false;
				bThrusterOn = false;
			}
		}

		//Roates the Pilder left and right
		if (Input.GetKey ("d") && docked == false) 
		{
			transform.Rotate (0, 3f, 0);
		}
		if (Input.GetKey ("a") && docked == false) 
		{
			transform.Rotate (0, -3f, 0);
		}
			
		//Tucks the wings in
		if (wingsIn == true)
		{
			wingL.transform.localEulerAngles = new Vector3 (0, 0, -90);
			wingR.transform.localEulerAngles = new Vector3 (0, 0, 90);

			LThruster.Stop ();
			RThruster.Stop ();
		}

		//sticks the ings out 
		if (wingsIn == false) 
		{
			wingL.transform.localEulerAngles = new Vector3 (0, 0, 0);
			wingR.transform.localEulerAngles = new Vector3 (0, 0, 0);

			LThruster.Play ();
			RThruster.Play ();
		}

		//Starts the lower thrusters (paritcle effects)
		if (bThrusterOn == true) 
		{
			BLThruster.Play ();
			BRThruster.Play ();
		}
		//Stops the lower thrusters (paritcle effects)
		if (bThrusterOn == false) 
		{
			BLThruster.Stop ();
			BRThruster.Stop ();
		}

		//The Camera changer
		if (docked == true) 
		{
			camera1.enabled = false;
			camera2.enabled = true;
		}
	
		if (docked == false) 
		{
			camera2.enabled = false;
			camera1.enabled = true;
		}

		//Toggles the Guiding Light On and Off

		if (Input.GetKeyDown ("left shift")) 
		{
			gl_On = true;
		}

		if (Input.GetKeyUp ("left shift")) 
		{
			gl_On = false;
		}

		if (gl_On == true) 
		{
			guidingLight.enabled = true;
		}

		if (gl_On == false) 
		{
			guidingLight.enabled = false;
		}
	}


	void OnCollisionEnter(UnityEngine.Collision collisionInfo)
	{
		//activates the MAZINGER Z!
		if (collisionInfo.gameObject.tag == "MazingerDock") 
		{
			Debug.Log ("Go!");
			BLThruster.Stop ();
			BRThruster.Stop ();
			eyes.SetActive(true);
			docked = true;
			bThrusterOn = false;
			wingsIn = true;
			mzMovement.enabled = true;
			pilder.transform.SetParent(mazingerZ);
			rb.constraints = RigidbodyConstraints.FreezeAll;
			gl_On = false;
		}
	}

	}






