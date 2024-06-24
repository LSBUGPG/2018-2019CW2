using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Main Player")

        animator.SetBool("Open", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
