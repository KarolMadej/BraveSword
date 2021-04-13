using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDMG : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var x = collision.collider.GetComponent<PlayerMovment>();
        if (x != null)
        {
            x.DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}
