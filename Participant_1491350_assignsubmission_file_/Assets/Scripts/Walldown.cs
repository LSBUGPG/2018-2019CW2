using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walldown : MonoBehaviour {
    public GameObject moveDoor; //Defining the wall
    bool whatever = false;

    private void Update()//update void is required for continuce movement
    {
        if (whatever == true)//using the boolean to activate Wait
        {
            StartCoroutine(Wait());
        }
    }
    public void OnTriggerStay(Collider Other)//setting the trigger and collider
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
             {
            whatever = true;//if the character hits the collider, whatever activates
              }
        }
    }
    IEnumerator Wait()//moves the door upwards during the time of 3seconds
    {
        moveDoor.transform.position += moveDoor.transform.up * -1 * Time.deltaTime;
        yield return new WaitForSeconds(3f);
        whatever = false;
    }
}
