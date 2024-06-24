using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {
    public Animator Rotation;
	// Use this for initialization
	void Start () {
        Rotation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Follower")
        {
            Rotation.Play("Beyond");
        }
    }   
        
}