using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [System.Serializable]
    public class Event
    {
        public string text;
        public int wifeHp;
        public int kidHp;
        public bool dogAlive;
        public int[] upkeepCost;
        public int[] leaveCost;
        public int gunRate;
        public int gunDmg;
        public int axeRate;
        public int axeDmg;
        public int food;
        public int wood;
    }

    public Event[] events;

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
