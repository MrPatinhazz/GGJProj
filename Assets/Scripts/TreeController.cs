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

    public void DamageTree(int damage)
    {
        stats.Health -= damage;
        if (stats.Health <= 0)
        {
            GameMaster.CutTree(this);
        }
    }
}
