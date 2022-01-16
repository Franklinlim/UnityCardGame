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
            Debug.Log(isStart);
            Debug.Log(isCleared);
            StartEvent(gameObject);
        }
    }
    public void StartEvent(GameObject target)
    {
        //Play correseponding event
        if (eventType == EventTypes.Heal)
        {
            transform.parent.GetComponent<MapManager>().HealEvent();
            transform.GetComponentInParent<MapManager>().currentPos = target;
            transform.GetComponentInParent<MapManager>().UpdateCurrentPosMarker();
            transform.GetComponentInParent<MapManager>().SaveGame();
        }
        else if (eventType == EventTypes.Card)
        {
            transform.parent.GetComponent<MapManager>().CardEvent();
            transform.GetComponentInParent<MapManager>().currentPos = target;
            transform.GetComponentInParent<MapManager>().UpdateCurrentPosMarker();
            transform.GetComponentInParent<MapManager>().SaveGame();
        }
        else
        {
            transform.parent.GetComponent<MapManager>().FightEvent(ref GetComponent<Deck>().unitsInDeck);
            transform.GetComponentInParent<MapManager>().SaveGame();
            transform.GetComponentInParent<MapManager>().currentPos = target;
            transform.GetComponentInParent<MapManager>().UpdateCurrentPosMarker();
        }
        isCleared = true;
    }
}
