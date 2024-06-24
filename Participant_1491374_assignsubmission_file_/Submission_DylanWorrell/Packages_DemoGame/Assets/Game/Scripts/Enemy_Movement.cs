using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour 
{
	//Health
	public Transform mazinger;
	float maxHealth = 100;
	float currentHealth = 0;
	float minimalHealth = 0;

	//Enemy Shoot
	public GameObject projectile;
	public Transform bulletSpawn;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Forces the enemy to look at the mazinger
		transform.LookAt (mazinger);

		if (currentHealth <= minimalHealth)
		{
			Destroy (gameObject);
		}

		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (projectile, bulletSpawn.position, bulletSpawn.rotation);
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "RocketPunchR") 
		{
			currentHealth -= 30;
		}

		if (other.tag == "MM_Explosion") 
		{
			currentHealth -= 70;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "BreastFire") 
		{
			currentHealth -= 20 * Time.deltaTime;
		}
	}

}
