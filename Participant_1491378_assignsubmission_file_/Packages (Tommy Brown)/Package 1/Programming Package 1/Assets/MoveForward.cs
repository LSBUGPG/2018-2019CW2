using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
	public int projType, projHits;

	public float speed;
    public Vector3 dir;

	public bool projHit, effected;

    void Start()
    {
        SetDirection ();
    }

	public void SetDirection()
	{
		Vector3 target = GameObject.Find("Rotation Point").transform.position;
		dir = (target - transform.position).normalized;
	}


    void FixedUpdate()
    {
		if (!projHit && !effected) 
		{
			transform.Translate (dir * (speed * Time.deltaTime));
		}
    }
}
