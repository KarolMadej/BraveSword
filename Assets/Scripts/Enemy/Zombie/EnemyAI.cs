using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float speed;
    public Transform groundDetection;

    private bool movingRight = true;


    [System.Serializable]
    public class EnemyStats
    {
        public int Health;
        public int str;
    }
    public EnemyStats enemyStats = new EnemyStats();


    void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
	}

    public void DamageEnemy(int damage)
    {
        enemyStats.Health -= damage;
        if (enemyStats.Health <= 0)
        {
            GM.KillEnemy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var x = collision.collider.GetComponent<PlayerMovment>();
        if(x != null)
        {
            x.DamagePlayer(enemyStats.str);
        }
    }


}
