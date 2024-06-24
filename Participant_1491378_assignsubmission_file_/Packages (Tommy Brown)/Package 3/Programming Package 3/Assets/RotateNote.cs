using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNote : MonoBehaviour {

	MoveForward moveForward;
	Transform firePlace;

	public float rotateTime;
	public float firePlaceDist;
	float speed;
	float firePlaceActualDist;

	bool hasRotated;

	void Start () 
	{
		if(firePlaceDist == 0)
		{
			firePlaceDist = 3.5f;
		}
		if (rotateTime == 0) 
		{
			rotateTime = 1;
		}
		moveForward = GetComponent<MoveForward> ();
		speed = moveForward.speed * 25;
		firePlace = GameObject.FindGameObjectWithTag ("DefendCube").transform;
	}

	void FixedUpdate () 
	{
		firePlaceActualDist = Vector3.Distance (transform.position, firePlace.position);

		if (firePlaceActualDist <= firePlaceDist) 
		{
			if (!hasRotated) 
			{
				transform.RotateAround (firePlace.position, new Vector3(0,0,1), speed * Time.deltaTime);
				rotateTime -= 1 * Time.fixedDeltaTime;

				if (rotateTime <= 0) 
				{
					hasRotated = true;
					moveForward.effected = false;
				}
			}

		}
	}
}
