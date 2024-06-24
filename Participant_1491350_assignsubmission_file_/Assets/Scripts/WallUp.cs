using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUp : MonoBehaviour {
    public GameObject moveDoor; //Defining the object
    bool whatever = false; 
    //creating boolean
    //I chose the word whatever cause it can be whatever you want it to be
    //and later you will see Wait, its so it would move up using 3 seconds
    //(waiting to change comand) so I thought its a fitting name
    private void Update()//update void is required for continuce movement
    {
        if (whatever == true)//using the boolean to activate Wait
        {
            StartCoroutine(Wait());
         }
    }
    public void OnTriggerStay(Collider Other)//setting the trigger and collider
    {
        if (Other.gameObject.CompareTag("Player")) // If gameobject that is tagged as player in in the trigger do below
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))//if Space is pressed, do bellow
            {
                whatever = true;// whatever activates
            }
        }
    }
    IEnumerator Wait()//moves the door upwards during the time of 3seconds
    {
        moveDoor.transform.position += moveDoor.transform.up * Time.deltaTime;
        yield return new WaitForSeconds(3f);
        whatever = false;
    }
}