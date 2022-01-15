using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public enum EventTypes { 
        Heal,
        Card,
        Fight
    
    }
    public EventTypes eventType;
    public bool isCleared = false;

    public void StartEvent()
    {
        //Play correseponding event
        if (eventType == EventTypes.Heal)
        {
            transform.parent.GetComponent<MapManager>().HealEvent();
        }
        else if (eventType == EventTypes.Card)
        {
            transform.parent.GetComponent<MapManager>().CardEvent();
        }
        else
        {
            transform.parent.GetComponent<MapManager>().FightEvent(ref GetComponent<Deck>().unitsInDeck);
        }
        isCleared = true;
    }
}
