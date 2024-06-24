using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnable : MonoBehaviour
{
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            fire.SetActive(true);
        }
    }
}
