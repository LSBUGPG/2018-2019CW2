using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")

        {
            print("Item picked up");
            Destroy(gameObject);
        }
    }

}
	
