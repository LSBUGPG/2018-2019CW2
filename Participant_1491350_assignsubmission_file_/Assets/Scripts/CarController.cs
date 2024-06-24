using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    // Wheel Colliders
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelBL;
    public WheelCollider WheelBR;

    //Wheel GameObjects
    public GameObject FL;
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;

    public float topSpeed = 500f; // The Top Speed
    public float maxTorque = 200f; // The Maximum Torque to apply to the wheels
    public float maxSteerAngle = 75f;
    public float currentSpeed;
    public float maxBrakeTorque = 2200;
    public float booster = 100f;

    private float Forward; // Forward Axis
    private float Turn; // Turn Axis
    private float Brake; // Break Axis

    private Rigidbody rb; // Rigidbody of the car

    // Use this for initialization:
    void Start() {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate() { //Fixed Update is more physics realistic
        Forward = Input.GetAxis("Vertical");//The Vertical and the Horizontal make the WASD and the arrow keys moving keys
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");// the jump is same as space key

        WheelFL.steerAngle = maxSteerAngle * Turn;
        WheelFR.steerAngle = maxSteerAngle * Turn;

        currentSpeed = WheelBL.radius * WheelBL.rpm; // Formula for calculating speed in kmph
//2 * 22 / 7 
        if (currentSpeed < topSpeed)
        {
            WheelBL.motorTorque = maxTorque * Forward;// Runs the Wheel on the Back Left Wheel
            WheelBR.motorTorque = maxTorque * Forward;// Runs the Wheel on the Back Right Wheel 
            // you can just use the back wheels, but I am picky, and I want all my wheels to run.
            //WheelFL.motorTorque = maxTorque * Forward;// Runs the Wheel on the Front Left Wheel
            //WheelFR.motorTorque = maxTorque * Forward;// Runs the Wheel on the Front Back Wheel 
        }// will try to slow the car before top speed but it wont be accurate

        WheelBL.brakeTorque = maxBrakeTorque * Brake;//This is the brakes for each wheel
        WheelBR.brakeTorque = maxBrakeTorque * Brake;
        WheelFL.brakeTorque = maxBrakeTorque * Brake;
        WheelFR.brakeTorque = maxBrakeTorque * Brake;

        if (Input.GetKeyDown(KeyCode.LeftShift)){//boosterrrrrrrrrrrrrrrrrrr
            //currentSpeed = currentSpeed + booster;
            currentSpeed = Mathf.Min(topSpeed, currentSpeed + Time.deltaTime * booster);
        }
    }
    
    void Update()	// Update is called once per frame
    {
       // rb.mass = currentSpeed + 100;
        Quaternion flq;//Rotation of The Wheel Collider 
        Vector3 flv;//Position of The Wheel Collider
        WheelFL.GetWorldPose(out flv, out flq); // Get the wheel collider position and rotation
        BL.transform.position = flv;
        BL.transform.rotation = flq;

        Quaternion Blq;//Rotation of The Wheel Collider 
        Vector3 Blv;//Position of The Wheel Collider
        WheelBL.GetWorldPose(out Blv, out Blq); // Get the wheel collider position and rotation
        FL.transform.position = Blv;
        FL.transform.rotation = Blq;

        Quaternion fRq;//Rotation of The Wheel Collider 
        Vector3 fRv;//Position of The Wheel Collider
        WheelFR.GetWorldPose(out fRv, out fRq); // Get the wheel collider position and rotation
        FR.transform.position = fRv;
        FR.transform.rotation = fRq;

        Quaternion BRq;//Rotation of The Wheel Collider 
        Vector3 BRv;//Position of The Wheel Collider
        WheelBR.GetWorldPose(out BRv, out BRq); // Get the wheel collider position and rotation
        BR.transform.position = BRv;
        BR.transform.rotation = BRq;
    }
}
