using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed = 10f; //speed of respond

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // so you dont see the cursor and keeps it in the game box
    }

    // Update is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;//keeps movement smooth and in time with update
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation); //translation is moving forward and backword

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None; //brings the cursor back when esc is pressed
    }
}
