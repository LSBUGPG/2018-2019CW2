using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFOV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
        {
            if (Input.GetKey("z"))
            {
                //Change camera fov to 20
            }
            else if (Input.GetKeyDown("z"))
            {
                //Change camera fov to 10
            }
        }

    }

