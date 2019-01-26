using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [System.Serializable]
    public class TreeStats
    {
        public int Health = 100;
    }

    public TreeStats stats = new TreeStats();
    public PlayerController player;
    
    public void DamageTree(int damage)
    {
        stats.Health -= damage;
        if (stats.Health <= 0)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.GiveWood(30);
            GameMaster.CutTree(this);
        }
    }
}
