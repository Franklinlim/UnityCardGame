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
    public bool isStart = false;
    private void Start()
    {
        if (isStart && !isCleared)
        {
            StartEvent(gameObject);
        }
    }
    public void StartEvent(GameObject target)
    {
        //Play correseponding event
        if (eventType == EventTypes.Heal)
        {
            transform.parent.GetComponent<MapManager>().HealEvent();
            transform.parent.GetComponent<MapManager>().currentPos = target;
            transform.parent.GetComponent<MapManager>().UpdateCurrentPosMarker();
            transform.parent.GetComponent<MapManager>().SaveGame();
        }
        else if (eventType == EventTypes.Card)
        {
            transform.parent.GetComponent<MapManager>().CardEvent();
            transform.parent.GetComponent<MapManager>().currentPos = target;
            transform.parent.GetComponent<MapManager>().UpdateCurrentPosMarker();
            transform.parent.GetComponent<MapManager>().SaveGame();
        }
        else
        {
            transform.parent.GetComponent<MapManager>().SaveGame();
            transform.parent.GetComponent<MapManager>().currentPos = target;
            transform.parent.GetComponent<MapManager>().UpdateCurrentPosMarker();
            transform.parent.GetComponent<MapManager>().FightEvent(ref GetComponent<Deck>().unitsInDeck);

        }
        isCleared = true;
    }
}
