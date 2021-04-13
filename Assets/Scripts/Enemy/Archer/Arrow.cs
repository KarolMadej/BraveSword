using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float bulletForce = 750.00f;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FirePoint")
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletForce);
        }
    
    }
}
