using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats {
		public int Health = 100;
        public int Wood = 0;
        public int Food = 0;
	}
    
	public PlayerStats playerStats = new PlayerStats();


    public Text foodText;
    public Text woodText;

    public void Start()
    {
        UpdateStatText();
    }

	public void DamagePlayer (int damage) {
		playerStats.Health -= damage;
        Application.Quit();
	}

    public void GiveWood (int wood)
    {
        playerStats.Wood += wood;
        UpdateStatText();
    }

    public void GiveFood ( int food)
    {
        playerStats.Food += food;
        UpdateStatText();
    }

    public void UpdateStatText()
    {
        foodText.text = "Food : " + playerStats.Food;
        woodText.text = "Wood : " + playerStats.Wood;
    }


}
