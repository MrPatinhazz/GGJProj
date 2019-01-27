using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
    }

    public static void KillEnemy(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
    }

    public static void CutTree(TreeController tree)
    {
        Destroy(tree.gameObject);
    }
}