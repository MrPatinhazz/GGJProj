using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyManager : MonoBehaviour
{
    public int wifeHp;
    public Text whText;

    public int kidHp;
    public Text khText;

    public bool dogAlive;
    public Text dogText;

    public int[] upkeepCost;
    public int[] leaveCost = new int[2];

    public int sfood;
    public Text sfText;

    public int swood;
    public Text swText;

    // Start is called before the first frame update
    void Start()
    {
        upkeepCost = new int[2];
        leaveCost = new int[2];

        wifeHp = 100;
        kidHp = 100;
        dogAlive = true;
        upkeepCost[0] = 30;
        upkeepCost[1] = 60;
        leaveCost[0] = 100;
        leaveCost[1] = 100;

        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTexts()
    {
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
}
