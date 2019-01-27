using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushController : MonoBehaviour
{
    [System.Serializable]
    public class BushStats
    {
        public int Health = 20;
    }

    public BushStats stats = new BushStats();
    public PlayerController player;

    public void DamageBush(int damage)
    {
        stats.Health -= damage;
        if (stats.Health <= 0)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.GiveFood(30);
            GameMaster.CutBush(this);
        }
    }

}
