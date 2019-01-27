using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyManager : MonoBehaviour
{
    [System.Serializable]
    public class UpkeepList
    {
        public int upFood;
        public int upWood;
    }
    public UpkeepList[] upkeeplist;

    [System.Serializable]
    public class LeaveCostList
    {
        public int costFood;
        public int costWood;
    }
    public LeaveCostList[] leaveCostList;

    public GameObject MainMenu;
    public TimeManager tMan;
    public WaveSpawner wSpawn;
    public AxeScript _axeStats;
    public GunScript _gunStats;

    public int day;
    public Text dayText;
    public PlayerController player;
    public int wifeHp;
    public Text whText;

    public int kidHp;
    public Text khText;

    public bool dogAlive;
    public Text dogText;

    public Text ukText;
    public Text leaveText;

    public int sfood;
    public Text sfText;

    public int swood;
    public Text swText;

    // Start is called before the first frame update
    void Start()
    {
        day = 0;        
        wifeHp = 100;
        kidHp = 100;
        dogAlive = true;
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        dayText.text = "Day : " + day;
        whText.text = "Wife HP : " + wifeHp;
        khText.text = "Kid HP : " + kidHp;
        if(dogAlive)
        {
            dogText.text = "Dog : alive";
        }
        else
        {
            dogText.text = "Dog : dead";
        }        
        sfText.text = "Food : " + sfood;
        swText.text = "Wood : " + swood;
    }

    public void UpdateUpKeep()
    {
        ukText.text = "Upkeep: Food " + upkeeplist[day].upFood + " and Wood " + upkeeplist[day].upWood;
    }

    public void Sleep()
    {
        day++;

        if(upkeeplist[day].upFood > sfood || upkeeplist[day].upWood > swood)
        {
            wifeHp -= 15;
            kidHp -= 15;
            sfood = 0;
            swood = 0;
        }
        else
        {
            sfood -= upkeeplist[day].upFood;
            swood -= upkeeplist[day].upWood;
        }
        UpdateUpKeep();
        UpdateTexts();

        player.transform.position = new Vector3(57.69f, -28.73f, 0.0f);

        MainMenu.SetActive(false);
        tMan.RestartTimer();


    }

    public void UpdateLeave()
    {
        leaveText.text = "Leave: Food " + leaveCostList[day].costFood + " and Wood " + leaveCostList[day].costWood;
    }

    public void Leave()
    {
        if(leaveCostList[day].costFood < sfood && leaveCostList[day].costWood < swood)
        {
            Debug.Log("You Won");
        }
        else
        {
            leaveText.text = "Not enough resources stored. Go get some more";
        }
    }

    public void UpgradeAxe()
    {
        if(swood >= 70 && sfood >= 40)
        {
            swood -= 70;
            sfood -= 40;
            _axeStats.swingDmg += 5;
            _axeStats.swingRate += 0.5f;
        }
    }

    public void UpgradeGun()
    {
        if (swood >= 100 && sfood >= 70)
        {
            swood -= 100;
            sfood -= 70;
            _gunStats.fireRate += 0.5f;
            _gunStats.Damage += 5;
        }

    }

    public void GiveItems()
    {
        sfood += player.playerStats.Food;
        swood += player.playerStats.Wood;
        player.playerStats.Food = 0;
        player.playerStats.Wood = 0;
    }
}
