using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAI : MonoBehaviour {


    [System.Serializable]
    public class EnemyStats
    {
        public int Health;
        public int str;
    }
    public EnemyStats enemyStats = new EnemyStats();


    public void DamageEnemy(int damage)
    {
        enemyStats.Health -= damage;
        if (enemyStats.Health <= 0)
        {
            GM.KillA(this);
        }
    }

}
