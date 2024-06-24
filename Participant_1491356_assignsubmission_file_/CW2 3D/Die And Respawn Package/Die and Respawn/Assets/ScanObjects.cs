using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanObjects : MonoBehaviour {

    public bool CanScan;
    
    public float ScannableTimer;
    public float StartTimer;
    
	// Use this for initialization
	void Start () {
        CanScan = false;
        StartTimer = ScannableTimer;
	}
	
	// Update is called once per frame
	void Update () {
        if (CanScan == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("scan = false");
                CanScan = false;
                ScannableTimer = StartTimer;
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("scan = true");
            CanScan = true;
        }

        if (CanScan == true)
        {
            ScannableTimer = ScannableTimer -+1f * Time.deltaTime;
        }
        if (ScannableTimer <= 0f)
        {
            CanScan = false;
            ScannableTimer = StartTimer;
        }

  

    }

   void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Scannable")
        {

            if (CanScan == true)
            {
                other.GetComponent<ObjectToScan>().ReadyToScan = true;
            }
            if (CanScan == false)
            {
                other.GetComponent<ObjectToScan>().ReadyToScan = false;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Scannable")
        {

            if (CanScan == true)
            {
                other.GetComponent<ObjectToScan>().ReadyToScan = false;
            }
            if (CanScan == false)
            {
                other.GetComponent<ObjectToScan>().ReadyToScan = false;
            }

        }
    }

}
