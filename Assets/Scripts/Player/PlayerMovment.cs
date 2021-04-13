using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    public float maxSpeed;
    public float powerJump;
    public float rayCastDistance;
    public int maxHealth;
    public LayerMask whatToHit;
    public LayerMask groundLayer;
    public Transform groundChackPoint;
    

    private bool grounded;
    private bool doubleJump=false;
    private bool enableInput = true;
    private float h;
    private Rigidbody2D rb;
    private Animator anime;
    private SpriteRenderer flip;
    private RaycastHit2D hit;
    private float curTime = 0;
    private float nextDmg = .05f;


    [System.Serializable]
    public class PlayerStats
    {
        public int curHealth;
        public int str;
    }
    public PlayerStats playerStats = new PlayerStats();


    void Start ()
    {
        maxHealth = playerStats.curHealth;
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
    }
	
	void Update ()
    {
        anime.SetBool("Grounded", grounded);
        anime.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));

        if (enableInput == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                flip.flipX = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                flip.flipX = false;
            }
            if(grounded)
            {
                doubleJump = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                rb.velocity = Vector2.up * powerJump;
            }else if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
            {
                rb.velocity = Vector2.up * powerJump;
                doubleJump = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anime.SetTrigger("Attack");
            }
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundChackPoint.position, .1f, groundLayer);
        if (enableInput == true)
        {
            h = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(maxSpeed * h, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void TriggerAnime(string nazwa)
    {
        if(nazwa == "Die")
        {
            anime.SetTrigger("Die");
        }
    }

    public void AttackDelivery()
    {
        Vector2 dir = flip.flipX ? Vector2.left : Vector2.right;
        hit = Physics2D.Raycast(transform.position,dir, rayCastDistance, whatToHit);
        if(hit.collider != null)
        {
            var x = hit.transform.GetComponent<EnemyAI>();
            var y = hit.transform.GetComponent<ArcherAI>();
            var z = hit.transform.GetComponent<Boss>();
            if (x != null)
            {
                x.DamageEnemy(playerStats.str);
            }
            else if(y != null)
            {
                y.DamageEnemy(playerStats.str);
            }
            else if (z != null)
            {
                z.DamageEnemy(playerStats.str);
            }

        }
    }

    public void DamagePlayer(int damage)
    {
        if (curTime <= 0)
        {
            Debug.Log("Dostaje");
            playerStats.curHealth -= damage;
            if (playerStats.curHealth < 0)
            {
                playerStats.curHealth = 0;
            }
            if (playerStats.curHealth == 0)
            {
                enableInput = false;
                anime.SetTrigger("Die");
            }
            curTime = nextDmg;
        }
        else
        {
            Debug.Log("CZEKAM");
            curTime -= Time.deltaTime;
        }
    }

    void EventMethod()
    {
        GM.KillPlayer(this);
        enableInput = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            GM.gm.coins += 1;
        }
        else if (col.CompareTag("Potion"))
        {
            if (playerStats.curHealth < 5)
            {
                Destroy(col.gameObject);
                playerStats.curHealth = 5;
            }
            else
            {
                Destroy(col.gameObject);
            }
        }
        else if(col.CompareTag("Point1"))
        {
            GM.gm.point_1 = true;
            GM.gm.point_2 = false;
            GM.gm.point_3 = false;
            GM.gm.point_4 = false;
        }
        else if (col.CompareTag("Point2"))
        {
            GM.gm.point_1 = false;
            GM.gm.point_2 = true;
            GM.gm.point_3 = false;
            GM.gm.point_4 = false;
        }
        else if (col.CompareTag("Point3"))
        {
            GM.gm.point_1 = false;
            GM.gm.point_2 = false;
            GM.gm.point_3 = true;
            GM.gm.point_4 = false;
        }
        else if (col.CompareTag("Point4"))
        {
            GM.gm.point_1 = false;
            GM.gm.point_2 = false;
            GM.gm.point_3 = false;
            GM.gm.point_4 = true;
        }
    }
}
