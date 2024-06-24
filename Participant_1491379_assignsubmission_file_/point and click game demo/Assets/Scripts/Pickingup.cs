using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickingup : MonoBehaviour {
    public GameObject matchesText;
    public GameObject pickUpText;

    bool pickUpAllowed;
    public fire dofire;

    void Start()
    {
        matchesText.SetActive(false);
        pickUpText.SetActive(false);
    }

    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.Space))
        {
            PickUp();
        }
    }


    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = false;
            pickUpText.SetActive(false);
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
        matchesText.gameObject.SetActive(true);
        pickUpText.SetActive(false);
        dofire.matchesCollected = true;
    }
}
