﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{


    public float DeadDelay;
    public GameObject DeadScreen;
    // Start is called before the first frame update


    public static void KillPlayer(PlayerController player)
    {

        Invoke("GameEnd", DeadDelay);

    }

    public static void GameEnd()
    {
        DeadScreen.SetActive(true);


    }
    void Start()
    {
        DeadDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
