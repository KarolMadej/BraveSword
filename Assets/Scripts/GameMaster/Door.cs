using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Door : MonoBehaviour {

    public Sprite DoorOpen;
    public Sprite DoorClose;
    public GameObject screen;

    public PlayerMovment player;

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DoorClose;
    }

    private void Update()
    {
        if (GM.gm.coins == 4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DoorOpen;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(GM.gm.coins == 4)
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadScene("MapaDruga");
                File.WriteAllText("Save.txt", "2");
            }
        }
        if (GM.gm.coins == 5)
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadScene("MapaTrzecia");
                File.WriteAllText("Save.txt", "3");
            }
        }
    }


}
