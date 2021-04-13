using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;


    public Animator camAnim;
    private Animator anim;
    public bool isDead = false;
    public Slider healbar;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health <= 150) {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0) {
            anim.SetTrigger("death");
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

        healbar.value = health;

    }

        public void DamageEnemy(int damage)
        {
            health -= damage;
        }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var x = collision.collider.GetComponent<PlayerMovment>();
        if (x != null && timeBtwDamage <= 0)
        {
            x.DamagePlayer(damage);
        }
    }



}
