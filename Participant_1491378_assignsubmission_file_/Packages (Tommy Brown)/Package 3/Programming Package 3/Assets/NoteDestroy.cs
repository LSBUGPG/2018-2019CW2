using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDestroy : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
			if(col.gameObject.GetComponent<MoveForward>() != null)
			{
				MoveForward hitProj = col.gameObject.GetComponent<MoveForward> ();
                        if (!hitProj.projHit)
                        {
                            Deflect(col.gameObject);
                            hitProj.projHit = true;
				}	
			}
        }
    }


    void Deflect(GameObject projectile)
    {
        if (projectile.GetComponent<Rigidbody2D>() != null)
        {
            Vector3 dir = (projectile.transform.position - transform.position).normalized;
            projectile.GetComponent<Rigidbody2D>().AddForce(dir * speed);
        }
        Destroy(projectile, 2);
    }
}
