﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats {
		public int Health = 100;
        public int Wood = 0;
        public int Food = 0;
	}

	public PlayerStats playerStats = new PlayerStats();

	void Update () {

	}

	public void DamagePlayer (int damage) {
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			GameMaster.KillPlayer(this);
		}
	}

    public void GiveWood (int wood)
    {
        playerStats.Wood += wood;
    }

    public void GiveFood ( int food)
    {
        playerStats.Food += food;
    }
}
