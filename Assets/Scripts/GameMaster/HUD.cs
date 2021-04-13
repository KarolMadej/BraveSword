using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
    private PlayerMovment player;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>();
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>();
            if (player == null)
            {
                return;
            }
        }
        HeartUI.sprite = HeartSprites[player.playerStats.curHealth];
    }
}
