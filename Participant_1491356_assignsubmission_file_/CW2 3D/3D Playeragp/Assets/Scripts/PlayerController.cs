using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {


    [SerializeField]
    private float speed;
    [SerializeField]
    private float Startspeed;
    [SerializeField]
    private float lookSensitivity;
    [SerializeField]
    private float Crouchspeed;
    [SerializeField]
    private float Sprintspeed;

    public bool CanSprint;
    public bool CanWalk;

    private PlayerMotor motor;


    // Use this for initialization
    void Start () {
        motor = GetComponent<PlayerMotor>();
        Startspeed = speed;
	}
	
	// Update is called once per frame
	void Update () {

        //Working out our value of our 3D player movement

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Moving the player
        motor.Move(_velocity);

        //Rotation of the player

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f,_yRot,0f)*lookSensitivity;

        motor.Rotate(_rotation);

        //Crouching
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = Crouchspeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = Startspeed;
        }


        //Sprinting

        if (CanWalk == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // CanWalk = true;
                StartCoroutine(CheckForRun());

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CanSprint = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            CanSprint = false;
            speed = Startspeed;
        }
        if (CanSprint ==true)
        {
            speed = Sprintspeed;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CanSprint = false;
                speed = Crouchspeed;
            }
        }
    }

    IEnumerator CheckForRun()
    {
        CanWalk = true;
        yield return new WaitForSeconds(1f);
        CanWalk = false;

      //  yield return new WaitForSeconds(0f);
    }
}
