using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text uiText;
    [SerializeField]
    private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    public GameObject mainMenu;
    public WaveSpawner wvspawn;
    public FamilyManager fMan;

    private void Start()
    {
        timer = mainTimer;
    }

    private void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "00.00";
            timer = 0.0f;
            ActivateMenu();
        }
    }

    public void RestartTimer()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;
    }

    public void ActivateMenu()
    {
        wvspawn.StopWaves();
        mainMenu.SetActive(true);
        fMan.GiveItems();

    }
}
