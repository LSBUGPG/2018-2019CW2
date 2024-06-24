using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D Rigidbody2D;
    public int jumpCount = 0;

    public void Start()
    {

    }

    public void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpHeight);
            print ("Jump");
            jumpCount++;
        }

      if (Input.GetKey(KeyCode.D))
        {
            Rigidbody2D.velocity = new Vector2(moveSpeed, Rigidbody2D.velocity.y);
            print ("Move!");
        }
      if (Input.GetKey(KeyCode.A))
        {
            Rigidbody2D.velocity = new Vector2(-moveSpeed, Rigidbody2D.velocity.y);
            print("Move!");
        }

    }
}