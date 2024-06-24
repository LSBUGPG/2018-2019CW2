using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "DungeonRoom" && other.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
