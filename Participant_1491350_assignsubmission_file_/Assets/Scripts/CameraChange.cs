using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {
    public GameObject firstPersonCam;
    public GameObject thirdPersonCam;
	bool one;
	bool Cam = true;
	void Update(){
			one = false;
			}
    void OnTriggerStay(Collider Other){
        if(Other.gameObject.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.C) && Cam == true && one == false){
					firstPersonCam.gameObject.SetActive(false);
                	thirdPersonCam.gameObject.SetActive(true); 
					one = true;
					Cam = false;
            }
			if(Input.GetKeyDown(KeyCode.C) && Cam == false && one == false){
					firstPersonCam.gameObject.SetActive(true);
                	thirdPersonCam.gameObject.SetActive(false);					
					one = true;
					Cam = true;
			}
        }
    }
}
