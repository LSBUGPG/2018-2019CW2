using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToScan : MonoBehaviour {

    public bool ReadyToScan;
    public Material FirstMaterial;
    public Material SecondMaterial;
  

    // Use this for initialization
    void Start () {
        ReadyToScan = false;
        
    }

    // Update is called once per frame
    void Update () {
        Renderer rend = GetComponent<Renderer>();
        if (ReadyToScan == true)
        {
            rend.material = SecondMaterial;
            Debug.Log("Ready to scan = true");

        }
        if (ReadyToScan == false)
        {
            rend.material = FirstMaterial;
            Debug.Log("Ready to scan = false");
        }
    }
}
