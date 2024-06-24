using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arrow")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Destroy (rb);
            GameManager.instance.OpenDoor();
        }
    }
}
