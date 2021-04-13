using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static GM gm;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public PlayerMovment player;
    public int coins;
    public bool point_1 = false;
    public bool point_2 = false;
    public bool point_3 = false;
    public bool point_4 = false;
    private static int CountKill = 0;

    private void Start(){
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>();
    }

    public void RespownPlayer()
    {
        if(point_1 == true)
        {
            spawnPoint = point1;
        }
        else if (point_2 == true)
        {
            spawnPoint = point2;
        }
        else if (point_3 == true)
        {
            spawnPoint = point3;
        }
        else if (point_4 == true)
        {
            spawnPoint = point4;
        }
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        player.playerStats.curHealth = player.maxHealth;
        CountKill++;
    }

    public static void KillPlayer(PlayerMovment player)
    {
        Destroy(player.gameObject);
        if(CountKill == 4)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            gm.RespownPlayer();
        }
    }

    public static void KillEnemy(EnemyAI enemy)
    {
        Destroy(enemy.gameObject);
    }

    public static void KillA(ArcherAI enemy)
    {
        Destroy(enemy.gameObject);
    }

    public static void EndLevel()
    {
        Time.timeScale = 0;
    }

}
