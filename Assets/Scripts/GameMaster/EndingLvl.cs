using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EndingLvl : MonoBehaviour
{

    public Sprite DoorOpen;
    public Sprite DoorClose;
    public GameObject screen;
    public Boss isDeath;

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DoorClose;
        isDeath = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    private void Update()
    {
        if (isDeath.isDead == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DoorOpen;
        }

        if (isDeath.isDead == true && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isDeath.isDead == true)
        {
            screen.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}
