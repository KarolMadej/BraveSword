using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {

    public GameObject bullet;
    public Transform spawnPoint;
    bool shoot = false;
    private float curTime = 0;
    private float nextAtc = 2f;
    private GameObject instantiatedObj;


    private void FixedUpdate()
    {

        if (curTime <= 0)
        {

            shoot = true;
            curTime = nextAtc;
        }
        else
        {
            shoot = false;
            curTime -= Time.deltaTime;
        }

        if (shoot)
        {
            instantiatedObj = (GameObject)Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            Destroy(instantiatedObj, 1);
        }
        
    }
}
