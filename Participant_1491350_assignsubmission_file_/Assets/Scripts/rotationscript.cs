using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationscript : MonoBehaviour {

    public GameObject moveDoor; 
    bool whatever = false;
    
    
    private void Update()
    {
        if (whatever == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                moveDoor.transform.Rotate(0.0f ,0.0f ,90 * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.Mouse1))
            {
                moveDoor.transform.Rotate(0.0f ,0.0f ,-90 * Time.deltaTime);
            }
        }
    }
    public void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player")) 
        {
            whatever = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            whatever = false;
        }
    }
}
