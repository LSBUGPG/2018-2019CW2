using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float arrowVelocity;
    public float arrowLife = 2.0f;
    private float timer = 0f;
	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * arrowVelocity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer <= arrowLife)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
