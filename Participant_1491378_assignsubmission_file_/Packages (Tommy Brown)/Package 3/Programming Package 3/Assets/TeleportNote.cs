using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportNote : MonoBehaviour 
{
	MoveForward moveForward;
	Transform firePlace;

	public float firePlaceDist;
	float firePlaceActualDist;
	bool hasTeleported;

	void Start () 
	{
		if(firePlaceDist == 0)
		{
			firePlaceDist = 4f;
		}
		moveForward = GetComponent<MoveForward> ();
		firePlace = GameObject.FindGameObjectWithTag ("DefendCube").transform;
	}
	

	void FixedUpdate () 
	{
		firePlaceActualDist = Vector3.Distance (transform.position, firePlace.position);

		if (firePlaceActualDist < firePlaceDist) 
		{
			if (!hasTeleported) 
			{
				transform.position = -transform.position;
				hasTeleported = true;
				moveForward.SetDirection ();
			}
		}
	}
}
